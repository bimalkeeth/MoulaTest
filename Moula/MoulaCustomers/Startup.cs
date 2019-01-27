using AutoMapper;
using BIRuleProcessor.Mapppers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Moula.CustomerService;
using MoulaCustomers.CustomerServiceImpl;
using MoulaCustomers.DIContainer;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config")]
namespace MoulaCustomers
{
    public class Startup
    {
        

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            var mapping = new MapperConfiguration(mc =>{mc.AddProfile(new AutoMapperConfiguration());});
            ContainerInjector.Config(services,Configuration);
            services.AddSingleton<CustomerService.CustomerServiceBase, CustomerServiceProcess>();
            services.AddSingleton<CustomerServiceProcess, CustomerServiceProcess>();
            services.Configure<Services.ServiceOptions>(Configuration.GetSection("Services"));
            services.AddSingleton(mapping.CreateMapper());
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime lifetime)
        {
           
        }
        
       
    }
}