using AutoMapper;
using ProjectTemplate.Application.DTOs.Cliente;
using ProjectTemplate.Application.Features.Clientes.BuscarClientesPorNomeComDapper;
using ProjectTemplate.Domain.QueryResults;

namespace ProjectTemplate.Application.Mappers;

public sealed class ClienteMapperProfile : Profile
{
    public ClienteMapperProfile()
    {
        CreateMap<BuscaClienteRequest, BuscarClientesPorNomeComDapperQuery>();
        CreateMap<ClienteQueryResult, BuscaClienteResponse>();
    }
}