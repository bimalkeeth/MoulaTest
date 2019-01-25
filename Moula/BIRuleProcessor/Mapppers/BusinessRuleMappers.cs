using AutoMapper;
using CommonContracts;
using DataAccess.Entities;

namespace BIRuleProcessor.Mapppers
{
    public static class AutoMapperConfiguration
    {
        /// <summary>--------------------------------------------------
        /// Auto mapper mapping database entities with business object
        /// </summary>-------------------------------------------------
        /// <returns></returns>
        internal; class BusinessRuleMappers:AutoMapper.Profile
        {
            public BusinessRuleMappers()
            {
                CreateMap<Address, AddressBo>()
                    .ForMember(des => des.Id, src => src.MapFrom(d => d.Id))
                    .ForMember(des => des.State, src => src.MapFrom(d => d.State))
                    .ForMember(des => des.AddressType, src => src.MapFrom(d => d.AddressType))
                    .ForMember(des => des.Street, src => src.MapFrom(d => d.Street))
                    .ForMember(des => des.Suburb, src => src.MapFrom(d => d.Suburb))
                    .ForMember(des => des.Street2, src => src.MapFrom(d => d.Street2))
                    .ForMember(des => des.StateId, src => src.MapFrom(d => d.StateId))
                    .ForMember(des => des.AddressTypeId, src => src.MapFrom(d => d.AddressTypeId))
                    .IgnoreAllPropertiesWithAnInaccessibleSetter().ReverseMap();

                CreateMap<AddressType, AddressTypeBo>()
                    .ForMember(des => des.Id, src => src.MapFrom(d => d.Id))
                    .ForMember(des => des.AddressTypeAbbr, src => src.MapFrom(d => d.AddressTypeAbbr))
                    .ForMember(des => des.AddressTypeName, src => src.MapFrom(d => d.AddressTypeName))
                    .IgnoreAllPropertiesWithAnInaccessibleSetter().ReverseMap();

                CreateMap<Contacts, ContactsBo>()
                    .ForMember(des => des.Id, src => src.MapFrom(d => d.Id))
                    .ForMember(des => des.ContactType, src => src.MapFrom(d => d.ContactType))
                    .ForMember(des => des.ContactTypeId, src => src.MapFrom(d => d.ContactTypeId))
                    .ForMember(des => des.Contact, src => src.MapFrom(d => d.Contact))
                    .IgnoreAllPropertiesWithAnInaccessibleSetter().ReverseMap();
                
                CreateMap<ContactType, ContactTypeBo>()
                    .ForMember(des => des.Id, src => src.MapFrom(d => d.Id))
                    .ForMember(des => des.ContactTypeAbbr, src => src.MapFrom(d => d.ContactTypeAbbr))
                    .ForMember(des => des.ContactTypeName, src => src.MapFrom(d => d.ContactTypeName))
                    .IgnoreAllPropertiesWithAnInaccessibleSetter().ReverseMap();
                
                CreateMap<CustomerContacts, CustomerContactsBo>()
                    .ForMember(des => des.Id, src => src.MapFrom(d => d.Id))
                    .ForMember(des => des.ContactId, src => src.MapFrom(d => d.ContactId))
                    .ForMember(des => des.CustomerId, src => src.MapFrom(d => d.CustomerId))
                    .ForMember(des => des.IsPrimary, src => src.MapFrom(d => d.IsPrimaryint))
                    .ForMember(des => des.Customer, src => src.MapFrom(d => d.Customer))
                    .ForMember(des => des.Contact, src => src.MapFrom(d => d.Contact))
                    .IgnoreAllPropertiesWithAnInaccessibleSetter().ReverseMap();

                CreateMap<CustomerAddress, CustomerAddressBo>()
                    .ForMember(des => des.Id, src => src.MapFrom(d => d.Id))
                    .ForMember(des => des.AddressId, src => src.MapFrom(d => d.AddressId))
                    .ForMember(des => des.CustomerId, src => src.MapFrom(d => d.CustomerId))
                    .ForMember(des => des.IsPrimary, src => src.MapFrom(d => d.IsPrimary))
                    .ForMember(des => des.Customer, src => src.MapFrom(d => d.Customer))
                    .ForMember(des => des.Address, src => src.MapFrom(d => d.Address))
                    .IgnoreAllPropertiesWithAnInaccessibleSetter().ReverseMap();
                

            }
        }
    }e
}