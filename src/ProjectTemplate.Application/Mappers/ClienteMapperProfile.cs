using AutoMapper;
using ProjectTemplate.Application.DTOs.Cliente.Requests;
using ProjectTemplate.Application.DTOs.Cliente.Responses;
using ProjectTemplate.Application.Features.Clientes.BuscarClientesPorNome;
using ProjectTemplate.Application.Features.Clientes.BuscarClientesPorNomeComDapper;
using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Domain.QueryResults;

namespace ProjectTemplate.Application.Mappers;

public sealed class ClienteMapperProfile : Profile
{
    public ClienteMapperProfile()
    {
        CreateMap<BuscaClienteRequest, BuscarClientesPorNomeComDapperQuery>();
        CreateMap<BuscaClienteRequest, BuscarClientesPorNomeQuery>();

        CreateMap<ClienteQueryResult, BuscaClienteResponse>();
        CreateMap<Cliente, BuscaClienteResponse>();
    }
}