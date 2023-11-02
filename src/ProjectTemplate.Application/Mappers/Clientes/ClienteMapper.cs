using AutoMapper;
using ProjectTemplate.Application.DTOs.Cliente;
using ProjectTemplate.Application.Features.Clientes.BuscarClientesPorNome;
using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Domain.QueryResults;

namespace ProjectTemplate.Application.Mappers.Clientes;

public class ClienteMapper : Profile
{
    public ClienteMapper()
    {
        CreateMap<BuscaClienteRequest, BuscarClientesPorNomeQuery>();
        CreateMap<ClienteQueryResult, BuscaClienteResponse>();
    }
}
