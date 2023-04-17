using grpc.server.Abstract;
using Grpc.Core;
using Support;
using static Support.SupportService;

namespace grpc.server.Services
{
    internal class SupportServiceImpl : SupportServiceBase
    {
        private readonly ISupportEngineerDataProvider _supportEngineerDataProvider;

        public SupportServiceImpl(ISupportEngineerDataProvider supportEngineerDataProvider)
        {
            _supportEngineerDataProvider = supportEngineerDataProvider ?? throw new ArgumentNullException(nameof(supportEngineerDataProvider));
        }

        public override Task<AddSupportEngineerResponse> AddSupportEngineer(AddSupportEngineerRequest request, ServerCallContext context)
        {
            var supportEngineerDetails = request.Detail;
            if (supportEngineerDetails == null)
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Support detail cannot be null."));

            var id = _supportEngineerDataProvider.AddSupportEngineer(supportEngineerDetails);

            return Task.FromResult(new AddSupportEngineerResponse
            {
                SupportId = id
            });
        }

        public override Task<GetAvailableSupportEngineerResponse> GetAvailableSupportEngineer(GetAvailableSupportEngineerRequest request, ServerCallContext context)
        {
            var result = _supportEngineerDataProvider.GetAvailableSupport();
            return Task.FromResult(new GetAvailableSupportEngineerResponse
            {
                SupportDetail = result
            });
        }
    }
}
