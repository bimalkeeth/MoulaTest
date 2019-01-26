using BIRuleManager.implementation;
using BIRuleManager.interfaces;
using BIRuleProcessor.Implementations;
using BIRuleProcessor.Interfaces;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MoulaCustomers.DIContainer
{
    public static class ContainerInjector
    {
        public static void Config(IServiceCollection service,IConfiguration configuration)
        {
            service.AddDbContext<CustomerDbContext>(option=>option.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            service.AddTransient<ICustomerRuleManager, CustomerRuleManager>();
            service.AddTransient<IAddressRuleProcessor, AddressRuleProcessor>();
            service.AddTransient<IContactsRuleProcessor, ContactsRuleProcessor>();
            service.AddTransient<ICustomerRulesProcessor, CustomerRulesProcessor>();
        }
    }
}