using AutoMapper;
using FluentValidation.TestHelper;
using MediatR;
using Moq;
using OpenBaseNET.Application.DTOs.Customer.Requests;
using OpenBaseNET.Application.DTOs.Customer.Responses;
using OpenBaseNET.Application.Features.CustomerFeatures.CreateCustomerFeature;
using OpenBaseNET.Application.Features.CustomerFeatures.DeleteCustomerFeature;
using OpenBaseNET.Application.Features.CustomerFeatures.UpdateCustomerFeature;
using OpenBaseNET.Application.Services;
using OpenBaseNET.Domain.Entities;
using OpenBaseNET.Domain.Interfaces.Services;
using OpenBaseNET.Domain.ValueObjects;

namespace OpenBaseNET.Tests.Unit;

// ─────────────────────────────────────────────────────────────────────────────
// Value Object: Name
// ─────────────────────────────────────────────────────────────────────────────
public class NameValueObjectTests
{
    [Fact]
    public void CreateInstance_ComNomeValido_DeveRetornarName()
    {
        var name = Name.CreateInstance("Rodrigo Brito");
        Assert.Equal("Rodrigo Brito", name.Value);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null!)]
    public void CreateInstance_ComNomeVazioOuNulo_DeveLancarArgumentException(string? valor)
    {
        Assert.Throws<ArgumentException>(() => Name.CreateInstance(valor!));
    }

    [Fact]
    public void CreateInstance_ComNomeMenorQue5Chars_DeveLancarArgumentException()
    {
        Assert.Throws<ArgumentException>(() => Name.CreateInstance("Ana"));
    }

    [Fact]
    public void CreateInstance_ComNomeMaiorQue255Chars_DeveLancarArgumentException()
    {
        var nomeGigante = new string('A', 256);
        Assert.Throws<ArgumentException>(() => Name.CreateInstance(nomeGigante));
    }

    [Fact]
    public void ConversaoImplicita_DeStringParaName_DeveFuncionar()
    {
        Name name = "Rodrigo Brito";
        Assert.Equal("Rodrigo Brito", name.Value);
    }

    [Fact]
    public void ConversaoImplicita_DeNameParaString_DeveFuncionar()
    {
        var name = Name.CreateInstance("Rodrigo Brito");
        string valor = name;
        Assert.Equal("Rodrigo Brito", valor);
    }

    [Fact]
    public void ToString_DeveRetornarOValor()
    {
        var name = Name.CreateInstance("Rodrigo Brito");
        Assert.Equal("Rodrigo Brito", name.ToString());
    }
}

// ─────────────────────────────────────────────────────────────────────────────
// Validator: CreateCustomerCommandValidator
// ─────────────────────────────────────────────────────────────────────────────
public class CreateCustomerCommandValidatorTests
{
    private readonly CreateCustomerCommandValidator _validator = new();

    [Fact]
    public void Validate_ComNomeValido_NaoDeveRetornarErros()
    {
        var command = new CreateCustomerCommand("Rodrigo Brito");
        var result = _validator.TestValidate(command);
        result.ShouldNotHaveAnyValidationErrors();
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void Validate_ComNomeVazio_DeveRetornarErro(string nome)
    {
        var command = new CreateCustomerCommand(nome);
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(c => c.Name);
    }

    [Fact]
    public void Validate_ComNomeMenorQue5Chars_DeveRetornarErro()
    {
        var command = new CreateCustomerCommand("Ana");
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(c => c.Name);
    }

    [Fact]
    public void Validate_ComNomeMaiorQue255Chars_DeveRetornarErro()
    {
        var command = new CreateCustomerCommand(new string('A', 256));
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(c => c.Name);
    }

    [Fact]
    public void Validate_ComNomeExatamenteNoLimite255Chars_NaoDeveRetornarErro()
    {
        var command = new CreateCustomerCommand(new string('A', 255));
        var result = _validator.TestValidate(command);
        result.ShouldNotHaveValidationErrorFor(c => c.Name);
    }
}

// ─────────────────────────────────────────────────────────────────────────────
// Handler: CreateCustomerCommandHandler
// ─────────────────────────────────────────────────────────────────────────────
public class CreateCustomerCommandHandlerTests
{
    private readonly Mock<ICustomerDomainService> _domainServiceMock = new();
    private readonly Mock<IMapper> _mapperMock = new();

    [Fact]
    public async Task Handle_ComDadosValidos_DeveCriarERetornarResponse()
    {
        var command = new CreateCustomerCommand("Rodrigo Brito");
        var customer = new Customer { Id = 1, Name = "Rodrigo Brito" };
        var expectedResponse = new CreateCustomerResponse(1, "Rodrigo Brito");

        _mapperMock.Setup(m => m.Map<Customer>(command)).Returns(customer);
        _domainServiceMock
            .Setup(s => s.AddAsync(customer, It.IsAny<CancellationToken>()))
            .ReturnsAsync(customer);
        _mapperMock.Setup(m => m.Map<CreateCustomerResponse>(customer)).Returns(expectedResponse);

        var handler = new CreateCustomerCommandHandler(_domainServiceMock.Object, _mapperMock.Object);
        var result = await handler.Handle(command, CancellationToken.None);

        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
        Assert.Equal("Rodrigo Brito", result.Name);
        _domainServiceMock.Verify(s => s.AddAsync(customer, It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task Handle_QuandoDomainServiceRetornaNull_DeveRetornarNull()
    {
        var command = new CreateCustomerCommand("Rodrigo Brito");
        var customer = new Customer { Id = 1, Name = "Rodrigo Brito" };

        _mapperMock.Setup(m => m.Map<Customer>(command)).Returns(customer);
        _domainServiceMock
            .Setup(s => s.AddAsync(customer, It.IsAny<CancellationToken>()))
            .ReturnsAsync((Customer?)null);
        _mapperMock.Setup(m => m.Map<CreateCustomerResponse>(null)).Returns(((CreateCustomerResponse?)null)!);

        var handler = new CreateCustomerCommandHandler(_domainServiceMock.Object, _mapperMock.Object);
        var result = await handler.Handle(command, CancellationToken.None);

        Assert.Null(result);
    }
}

// ─────────────────────────────────────────────────────────────────────────────
// Service: CustomerApplicationService
// ─────────────────────────────────────────────────────────────────────────────
public class CustomerApplicationServiceTests
{
    private readonly Mock<IMediator> _mediatorMock = new();
    private readonly Mock<IMapper> _mapperMock = new();
    private readonly CustomerApplicationService _sut;

    public CustomerApplicationServiceTests()
    {
        _sut = new CustomerApplicationService(_mediatorMock.Object, _mapperMock.Object);
    }

    [Fact]
    public async Task CreateAsync_ComRequestValido_DeveEnviarCommandERetornarResponse()
    {
        var request = new CreateCustomerRequest("Rodrigo Brito");
        var command = new CreateCustomerCommand("Rodrigo Brito");
        var expected = new CreateCustomerResponse(1, "Rodrigo Brito");

        _mapperMock.Setup(m => m.Map<CreateCustomerCommand>(request)).Returns(command);
        _mediatorMock.Setup(m => m.Send(command, CancellationToken.None)).ReturnsAsync(expected);

        var result = await _sut.CreateAsync(request, CancellationToken.None);

        Assert.NotNull(result);
        Assert.Equal(expected.Id, result!.Id);
        _mediatorMock.Verify(m => m.Send(command, CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task DeleteAsync_ComRequestValido_DeveEnviarCommandERetornarResponse()
    {
        var request = new DeleteCustomerRequest(1);
        var command = new DeleteCustomerCommand(1);
        var expected = new DeleteCustomerResponse(true);

        _mapperMock.Setup(m => m.Map<DeleteCustomerCommand>(request)).Returns(command);
        _mediatorMock.Setup(m => m.Send(command, CancellationToken.None)).ReturnsAsync(expected);

        var result = await _sut.DeleteAsync(request, CancellationToken.None);

        Assert.NotNull(result);
        Assert.True(result!.Success);
        _mediatorMock.Verify(m => m.Send(command, CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task UpdateAsync_ComRequestValido_DeveEnviarCommandERetornarResponse()
    {
        var request = new UpdateCustomerRequest(1, "Rodrigo Atualizado");
        var command = new UpdateCustomerCommand(1, "Rodrigo Atualizado");
        var expected = new UpdateCustomerResponse(1, "Rodrigo Atualizado");

        _mapperMock.Setup(m => m.Map<UpdateCustomerCommand>(request)).Returns(command);
        _mediatorMock.Setup(m => m.Send(command, CancellationToken.None)).ReturnsAsync(expected);

        var result = await _sut.UpdateAsync(request, CancellationToken.None);

        Assert.NotNull(result);
        Assert.Equal("Rodrigo Atualizado", result!.Name);
        _mediatorMock.Verify(m => m.Send(command, CancellationToken.None), Times.Once);
    }
}