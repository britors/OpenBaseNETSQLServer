using AutoMapper;
using OpenBaseNET.Application.DTOs.Base.Response;
using OpenBaseNET.Application.DTOs.Customer.Requests;
using OpenBaseNET.Application.DTOs.Customer.Responses;
using OpenBaseNET.Application.Features.CustomerFeatures.CreateCustomerFeature;
using OpenBaseNET.Application.Features.CustomerFeatures.DeleteCustomerFeature;
using OpenBaseNET.Application.Features.CustomerFeatures.FindCustomerByIdFeature;
using OpenBaseNET.Application.Features.CustomerFeatures.FindCustomerByNameFeature;
using OpenBaseNET.Application.Features.CustomerFeatures.FindCustomerByNameUsingDapperFeature;
using OpenBaseNET.Application.Features.CustomerFeatures.GetCustomersFeature;
using OpenBaseNET.Application.Features.CustomerFeatures.UpdateCustomerFeature;
using OpenBaseNET.Domain.Entities;
using OpenBaseNET.Domain.QueryResults;

namespace OpenBaseNET.Application.Mappers;

public sealed class CustomerMapperProfile : Profile
{
    public CustomerMapperProfile()
    {
        CreateMap<GetCustomerRequest, GetCustomerQuery>();
        CreateMap<FindCustomerByNameRequest, FindCustomerByNameUsingDapperQuery>();
        CreateMap<FindCustomerByNameRequest, FindCustomerByNameQuery>();
        CreateMap<FindCustomerByIdRequest, FindCustomerByIdQuery>();
        CreateMap<UpdateCustomerRequest, UpdateCustomerCommand>();
        CreateMap<UpdateCustomerCommand, Customer>();
        CreateMap<CreateCustomerRequest, CreateCustomerCommand>();
        CreateMap<CreateCustomerCommand, Customer>();
        CreateMap<DeleteCustomerRequest, DeleteCustomerCommand>();
        CreateMap<Customer, CustomerResponse>();
        CreateMap<PaginateQueryResult<Customer>, PaginateResponse<CustomerResponse>>();
        CreateMap<CustomerQueryResult, CustomerResponse>();
        CreateMap<Customer, UpdateCustomerResponse>();
        CreateMap<Customer, CreateCustomerResponse>();
    }
}