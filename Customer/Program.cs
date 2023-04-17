using Chat;
using Grpc.Core;
using Support;

namespace Customer
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var channel = await SetupChannel();
            var supportClient = new SupportService.SupportServiceClient(channel);
            var chatClient = new ChatService.ChatServiceClient(channel);

            var senderId = Guid.NewGuid().ToString();
            var (firstname, lastname) = GetCustomerData();
            Console.ForegroundColor = ConsoleColor.Green;
            var availableEnigneer = await supportClient.GetAvailableSupportEngineerAsync(new GetAvailableSupportEngineerRequest());
            ShowWelcomeMessage(firstname, lastname, availableEnigneer.SupportDetail);

            var sendChatMessageStream = chatClient.SendChatMessage();

            var response = Task.Run(async () =>
            {
                while (await sendChatMessageStream.ResponseStream.MoveNext())
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"{sendChatMessageStream.ResponseStream.Current.ChatMessage.SenderName}: {sendChatMessageStream.ResponseStream.Current.ChatMessage.Message}");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
            });

            await SendMessage(sendChatMessageStream.RequestStream, senderId, firstname, lastname, string.Empty);
            await ConnectCustomerToSupport(chatClient, senderId, availableEnigneer.SupportDetail.Id);

            var message = Console.ReadLine();
            PreviewSentMessage(message);
            while (!string.Equals(message, "qw!", StringComparison.OrdinalIgnoreCase))
            {
                await SendMessage(sendChatMessageStream.RequestStream, senderId, firstname, lastname, message);
                message = Console.ReadLine();
                PreviewSentMessage(message);
            }
            await sendChatMessageStream.RequestStream.CompleteAsync();

            Console.ReadKey();

            channel?.ShutdownAsync()?.Wait();
        }

        private static async Task ConnectCustomerToSupport(ChatService.ChatServiceClient chatClient, string customerId, string supportId)
        {
            await chatClient.ConnectToChannelAsync(new ConnetChannelRequest
            {
                CustomerId = customerId,
                SupportId = supportId
            });
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

        private static (string firstname, string lastname) GetCustomerData()
        {
            Console.WriteLine("Please enter your first name:");
            string firstname = Console.ReadLine();
            while (string.IsNullOrEmpty(firstname))
            {
                Console.WriteLine("Please enter a valid firstname. Firstname cannot be null or empty.");
                firstname = Console.ReadLine();
            }
            Console.WriteLine("Please enter your last name:");
            string lastname = Console.ReadLine();
            while (string.IsNullOrEmpty(lastname))
            {
                Console.WriteLine("Please enter a valid lastname. Lastname cannot be null or empty.");
                lastname = Console.ReadLine();
            }
            Console.Clear();
            Console.Title = $"{firstname} {lastname}";
            return (firstname, lastname);
        }

        private static void ShowWelcomeMessage(string firstname, string lastname, SupportDetail supportDetail)
        {
            Console.WriteLine($"Welcome {firstname} {lastname}," +
                $" I am {supportDetail.Firstname} {supportDetail.Lastname}, How can I help you?");
        }

        private static void PreviewSentMessage(string message)
        {
            if (Console.CursorTop == 0) return;
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            if (!string.IsNullOrEmpty(message))
                Console.WriteLine($"You: {message}");
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
