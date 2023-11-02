using AutoMapper;
using ProjectTemplate.Application.DTOs.Cliente;
using ProjectTemplate.Application.Features.Clientes.BuscarClientesPorNome;
using ProjectTemplate.Domain.QueryResults;

namespace ProjectTemplate.Application.Mappers;

public class ClienteMapperProfile : Profile
{
    public ClienteMapperProfile()
    {
        CreateMap<BuscaClienteRequest, BuscarClientesPorNomeQuery>();
        CreateMap<ClienteQueryResult, BuscaClienteResponse>();
    }
}