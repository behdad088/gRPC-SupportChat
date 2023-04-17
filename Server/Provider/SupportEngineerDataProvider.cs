using grpc.server.Abstract;
using Support;

namespace grpc.server.Provider
{
    internal class SupportEngineerDataProvider : ISupportEngineerDataProvider
    {
        private readonly ISet<SupportDetail> _supportEngineers;

        public SupportEngineerDataProvider()
        {
            _supportEngineers = new HashSet<SupportDetail>();
        }

        public string AddSupportEngineer(SupportDetail supportDetail)
        {
            var id = Guid.NewGuid().ToString();
            supportDetail.Id = id;
            _supportEngineers.Add(supportDetail);
            return id;
        }

        public void DeleteSupportEngineer(string id)
        {
            var support = _supportEngineers.FirstOrDefault(support => support.Id == id);
            if (support != null)
                _supportEngineers.Remove(support);
        }

        /// <summary>
        /// Returns a random available engineer. Using random to aviod assign task to the first 
        /// engineers all the time to spread the task equaly among all the engineers.
        /// </summary>
        /// <returns></returns>
        public SupportDetail GetAvailableSupport()
        {
            var random = new Random();
            var availableSupportEngineers = _supportEngineers.Where(x => x.Status == AvailabiltyStatus.Available).ToList();
            int index = random.Next(availableSupportEngineers.Count);
            var availableEngineer = availableSupportEngineers[index];
            availableEngineer.Status = AvailabiltyStatus.Busy;
            return availableEngineer;
        }

        public void SetEngineerStatusToAvailable(SupportDetail supportDetail)
        {
            supportDetail.Status = AvailabiltyStatus.Available;
        }
    }
}
