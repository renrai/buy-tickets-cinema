using System.Net.Http;
using System.Threading.Tasks;
using Grpc.Net.Client;
using ProtoDefinitions;

namespace DataApplication
{
    public class ApiClientGrpc
    {
        public async Task<responseModel> GetById(string id)
        {
            var httpHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback =
                    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };

            var channel =
                GrpcChannel.ForAddress("https://localhost:7443", new GrpcChannelOptions()
                {
                    HttpHandler = httpHandler
                });
            var client = new MoviesApi.MoviesApiClient(channel);
            var response = await client.GetByIdAsync(new IdRequest { Id = id });
            return response;
        }
    }
}