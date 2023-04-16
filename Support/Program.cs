using Grpc.Core;

namespace Support
{
    internal class Program
    {
        const string target = "localhost:50051";
        static async Task Main(string[] args)
        {
            var channel = await SetupChannel();
            var client = new SupportService.SupportServiceClient(channel);

            var (firstname, lastname) = GetEngineerData();

            var addSupportEngineerRequest = new AddSupportEngineerRequest
            {
                Detail = new SupportDetail
                {
                    Firstname = firstname,
                    Lastname = lastname,
                    Title = "Support Engineer",
                    Department = "Support"
                }
            };

            var response = client.AddSupportEngineer(addSupportEngineerRequest);

            Console.WriteLine($"Support was added successfuly. Support Id is {response.SupportId}");
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

            return (firstname, lastname);
        }
    }
}
