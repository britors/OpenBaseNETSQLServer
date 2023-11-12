using AutoMapper;
using OpenBaseNET.Application.DTOs.Base.Response;
using OpenBaseNET.Application.DTOs.Customer.Requests;
using OpenBaseNET.Application.DTOs.Customer.Responses;
using OpenBaseNET.Application.Features.CustomerFeatures.CreateCustomer;
using OpenBaseNET.Application.Features.CustomerFeatures.DeleteCustomer;
using OpenBaseNET.Application.Features.CustomerFeatures.FindCustomerById;
using OpenBaseNET.Application.Features.CustomerFeatures.FindCustomerByName;
using OpenBaseNET.Application.Features.CustomerFeatures.FindCustomerByNameUsingDapper;
using OpenBaseNET.Application.Features.CustomerFeatures.GetCustomers;
using OpenBaseNET.Application.Features.CustomerFeatures.UpdateCustomer;
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
        CreateMap<PaginationQueryResult<Customer>, PaginateResponse<CustomerResponse>>();
        CreateMap<CustomerQueryResult, CustomerResponse>();
        CreateMap<Customer, UpdateCustomerResponse>();
        CreateMap<Customer, CreateCustomerResponse>();
    }
}