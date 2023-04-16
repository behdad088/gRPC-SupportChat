using grpc.server.Abstract;
using Support;

namespace grpc.server.Provider
{
    internal class SupportEngineerDataProvider : ISupportEngineerDataProvider
    {
        private readonly ISet<string> _availableEngineerIds;
        private readonly ISet<SupportDetail> _supportEngineers;

        public SupportEngineerDataProvider()
        {
            _supportEngineers = new HashSet<SupportDetail>();
            _availableEngineerIds = new HashSet<string>();
        }

        public string AddSupportEngineer(SupportDetail supportDetail)
        {
            var id = Guid.NewGuid().ToString();
            supportDetail.Id = id;
            _supportEngineers.Add(supportDetail);

            AddNewEngineerToAvailableList(id);

            return id;
        }

        public void DeleteSupportEngineer(string id)
        {
            var support = _supportEngineers.FirstOrDefault(support => support.Id == id);
            if (support != null)
                _supportEngineers.Remove(support);
        }

        private void AddNewEngineerToAvailableList(string id)
        {
            _availableEngineerIds.Add(id);
        }
    }
}
