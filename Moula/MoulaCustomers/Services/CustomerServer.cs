using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http.Features;

namespace MoulaCustomers.Services
{
    public class CustomerServer:IServer
    {
        private readonly Server _server;
        private int _stopped;
        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public Task StartAsync<TContext>(IHttpApplication<TContext> application, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public IFeatureCollection Features { get; }
    }
}