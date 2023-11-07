using AutoMapper;
using ProjectTemplate.Application.DTOs.Base.Response;
using ProjectTemplate.Application.DTOs.Cliente.Requests;
using ProjectTemplate.Application.DTOs.Cliente.Responses;
using ProjectTemplate.Application.Features.Clientes.AtualizarCliente;
using ProjectTemplate.Application.Features.Clientes.BuscarClientePorId;
using ProjectTemplate.Application.Features.Clientes.BuscarClientesPorNome;
using ProjectTemplate.Application.Features.Clientes.BuscarClientesPorNomeComDapper;
using ProjectTemplate.Application.Features.Clientes.BuscarTodosOsClientes;
using ProjectTemplate.Application.Features.Clientes.CadastrarCliente;
using ProjectTemplate.Application.Features.Clientes.DeletarCliente;
using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Domain.QueryResults;

namespace ProjectTemplate.Application.Mappers;

public sealed class ClienteMapperProfile : Profile
{
    public ClienteMapperProfile()
    {
        CreateMap<TodosOsClientesRequest, BuscarTodosOsClientesQuery>();
        CreateMap<BuscaClientePorNomeRequest, BuscarClientesPorNomeComDapperQuery>();
        CreateMap<BuscaClientePorNomeRequest, BuscarClientesPorNomeQuery>();
        CreateMap<BuscaClienteRequest, BuscarClientePorIdQuery>();
        CreateMap<AtualizarClienteRequest, AtualizarClienteCommand>();
        CreateMap<AtualizarClienteCommand, Cliente>();
        CreateMap<CadastrarClienteRequest, CadastrarClienteCommand>();
        CreateMap<CadastrarClienteCommand, Cliente>();
        CreateMap<DeletarClienteRequest, DeletarClienteCommand>();

        CreateMap<Cliente, BuscaClienteResponse>();
        CreateMap<PaginationQueryResult<Cliente>, PaginatedResponse<BuscaClienteResponse>>()
            .ForMember(x => x.Results,
                opt => 
                    opt.MapFrom(x => x.Results));

        CreateMap<ClienteQueryResult, BuscaClienteResponse>();

        CreateMap<Cliente, AtualizarClienteResponse>();
        CreateMap<Cliente, CadastrarClienteResponse>();
    }
}