using Chat;
using Grpc.Core;

namespace Support
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var channel = await SetupChannel();
            var suppportClient = new SupportService.SupportServiceClient(channel);
            var chatClient = new ChatService.ChatServiceClient(channel);

            var (firstname, lastname) = GetEngineerData();
            Console.ForegroundColor = ConsoleColor.Green;
            var addSupportEngineerRequest = GetAddSupportEngineerRequestObject(firstname, lastname);
            var addedSupportEngineerResponse = suppportClient.AddSupportEngineer(addSupportEngineerRequest);

            Console.WriteLine($"Support was added successfuly. Support Id is {addedSupportEngineerResponse.SupportId}");

            var sendChatMessageStream = chatClient.SendChatMessage();

            var chatResponse = Task.Run(async () =>
            {
                while (await sendChatMessageStream.ResponseStream.MoveNext())
                {
                    ShowReceivedMessage(sendChatMessageStream.ResponseStream.Current.ChatMessage);
                }
            });

            await SendMessage(sendChatMessageStream.RequestStream, addedSupportEngineerResponse.SupportId, firstname, lastname, string.Empty);

            var message = Console.ReadLine();
            PreviewSentMessage(message);
            while (!string.Equals(message, "qw!", StringComparison.OrdinalIgnoreCase))
            {
                await SendMessage(sendChatMessageStream.RequestStream, addedSupportEngineerResponse.SupportId, firstname, lastname, message);
                message = Console.ReadLine();
                PreviewSentMessage(message);
            }
            await sendChatMessageStream.RequestStream.CompleteAsync();

            Console.ReadKey();
            channel?.ShutdownAsync()?.Wait();
        }

        private static async Task<Channel?> SetupChannel()
        {
            var channel = new Channel("localhost:5001", ChannelCredentials.Insecure);

            await channel.ConnectAsync().ContinueWith((t) =>
            {
                if (t.Status == TaskStatus.RanToCompletion)
                {
                    Console.WriteLine("The client connected successfully.");
                }
            });

            return channel;
        }

        private static (string firstname, string lastname) GetEngineerData()
        {
            Console.WriteLine("Please enter your first name:");
            string firstname = Console.ReadLine() ?? string.Empty;
            while (string.IsNullOrEmpty(firstname))
            {
                Console.WriteLine("Please enter a valid firstname. Firstname cannot be null or empty.");
                firstname = Console.ReadLine() ?? string.Empty;
            }
            Console.WriteLine("Please enter your last name:");
            string lastname = Console.ReadLine() ?? string.Empty;
            while (string.IsNullOrEmpty(lastname))
            {
                Console.WriteLine("Please enter a valid lastname. Lastname cannot be null or empty.");
                lastname = Console.ReadLine() ?? string.Empty;
            }
            Console.Clear();
            Console.Title = $"{firstname} {lastname}";

            return (firstname, lastname);
        }

        private static void PreviewSentMessage(string message)
        {
            if (Console.CursorTop == 0) return;
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            if (!string.IsNullOrEmpty(message))
                Console.WriteLine($"You: {message}");
        }

        private static void ShowReceivedMessage(ChatMessage chatMessage)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{chatMessage.SenderName}: {chatMessage.Message}");
            Console.ForegroundColor = ConsoleColor.Green;
        }

        private static AddSupportEngineerRequest GetAddSupportEngineerRequestObject(string firstname, string lastname)
        {
            return new AddSupportEngineerRequest
            {
                Detail = new SupportDetail
                {
                    Firstname = firstname,
                    Lastname = lastname,
                    Title = "Support Engineer",
                    Department = "Support",
                    Status = AvailabiltyStatus.Available
                }
            };
        }

        private static async Task SendMessage(IClientStreamWriter<ChatMessageRequest> streamWriter, string senderId, string firstname, string lastname, string message)
        {
            await streamWriter.WriteAsync(new ChatMessageRequest
            {
                ChatMessage = new ChatMessage
                {
                    SenderId = senderId,
                    Message = message,
                    SenderName = $"{firstname} {lastname}"
                }
            });

        }
    }
}
