using AutoMapper;
using OpenBaseNET.Application.DTOs.Base.Response;
using OpenBaseNET.Application.DTOs.Cliente.Requests;
using OpenBaseNET.Application.DTOs.Cliente.Responses;
using OpenBaseNET.Application.Features.Clientes.AtualizarCliente;
using OpenBaseNET.Application.Features.Clientes.BuscarClientePorId;
using OpenBaseNET.Application.Features.Clientes.BuscarClientesPorNome;
using OpenBaseNET.Application.Features.Clientes.BuscarClientesPorNomeComDapper;
using OpenBaseNET.Application.Features.Clientes.BuscarTodosOsClientes;
using OpenBaseNET.Application.Features.Clientes.CadastrarCliente;
using OpenBaseNET.Application.Features.Clientes.DeletarCliente;
using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Domain.QueryResults;

namespace OpenBaseNET.Application.Mappers;

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
        CreateMap<PaginationQueryResult<Cliente>, PaginatedResponse<BuscaClienteResponse>>();
        CreateMap<ClienteQueryResult, BuscaClienteResponse>();
        CreateMap<Cliente, AtualizarClienteResponse>();
        CreateMap<Cliente, CadastrarClienteResponse>();
    }
}