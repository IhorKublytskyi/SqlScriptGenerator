using Grpc.Net.Client;

namespace Storefront.Clients
{
    public class ScriptBuildingClient
    {
        private readonly ScriptFileBuilder.ScriptFileBuilderClient _client;
        public ScriptBuildingClient(ScriptFileBuilder.ScriptFileBuilderClient client)
        {
            _client = client;
        }

        public async Task<byte[]> BuildAsync(BuildRequest request)
        {
            var response = await _client.BuildAsync(request);

            var scriptFile = response.Script.ToByteArray();

            return scriptFile;
        }
    }
}
