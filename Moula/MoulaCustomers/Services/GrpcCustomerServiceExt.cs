using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Moula.CustomerService;

namespace MoulaCustomers.Services
{
    public static class GrpcCustomerServiceExt
    {
        /// <summary>
        /// Entry point for GRPC server start
        /// </summary>
        /// <param name="hostBuilder"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IWebHostBuilder UseGrpc<T>(this IWebHostBuilder hostBuilder)
            where T : CustomerService.CustomerServiceBase
        {
            return hostBuilder.ConfigureServices(services =>
            {
                services.AddSingleton<IServer, CustomerServer>(provider =>
                {
                    var serverOption = provider.GetService<IOptions<ConfigSettings>>().Value;
                    var contract = provider.GetService<T>();
                    var serviceDefinition = CustomerService.BindService(contract);
                    return new CustomerServer(serverOption.Service.Host, serverOption.Service.Port, serviceDefinition);
                });
            });
        }
        /// <summary>-----------------------------------------
        /// Create Server Scope
        /// </summary>----------------------------------------
        /// <param name="webHost"></param>
        /// <returns></returns>
        public static IWebHost CreateScope(this IWebHost webHost)
        {
            return webHost;
        }
        /// <summary>----------------------------------------
        /// Run GRPC Server 
        /// </summary>---------------------------------------
        /// <param name="webHost"></param>
        /// <returns></returns>
        public static IWebHost RunCustomerServer(this IWebHost webHost)
        {
            var scope = webHost.Services.CreateScope();
            var services = scope.ServiceProvider.GetRequiredService<CustomerService.CustomerServiceBase>();
            var serviceOptions=scope.ServiceProvider.GetRequiredService<IOptions<ConfigSettings>>().Value;

            var serviceDefinition = CustomerService.BindService(services);
            using (var server = new CustomerServer(serviceOptions.Service.Host, serviceOptions.Service.Port, serviceDefinition))
            {
                server.Start();
            }
            return webHost;
        }
    }
}