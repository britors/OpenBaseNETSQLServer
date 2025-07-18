using AutoMapper;
using MediatR;
using Moq;
using OpenBaseNET.Application.DTOs.Customer.Requests;
using OpenBaseNET.Application.DTOs.Customer.Responses;
using OpenBaseNET.Application.Features.CustomerFeatures.CreateCustomerFeature;
using OpenBaseNET.Application.Services;

namespace OpenBaseNET.Tests.Unit;
public class CustomerApplicationServiceTests
{
    private readonly Mock<IMediator> _mockMediator;
    private readonly Mock<IMapper> _mockMapper;
    private readonly CustomerApplicationService _sut; // SUT = System Under Test

    public CustomerApplicationServiceTests()
    {
        _mockMediator = new Mock<IMediator>();
        _mockMapper = new Mock<IMapper>();

        _sut = new CustomerApplicationService(
            _mockMediator.Object,
            _mockMapper.Object
        );
    }

    [Fact]
    public async Task CreateAsync_WithValidRequest_ShouldSendCommandAndReturnMappedResponse()
    {
        var request = new CreateCustomerRequest("Rodrigo Brito");
        var cancellationToken = CancellationToken.None;

        var command = new CreateCustomerCommand("Rodrigo Brito");
        var customerEntityFromHandler = new CreateCustomerResponse(0, "Rodrigo Brito");
        var finalResponse = new CreateCustomerResponse(customerEntityFromHandler.Id,  customerEntityFromHandler.Name );

        _mockMapper.Setup(m => m.Map<CreateCustomerCommand>(request)).Returns(command);
        _mockMediator.Setup(m => m.Send(command, cancellationToken)).ReturnsAsync(customerEntityFromHandler);
        _mockMapper.Setup(m => m.Map<CreateCustomerResponse>(customerEntityFromHandler))
            .Returns(finalResponse);

        var result = await _sut.CreateAsync(request, cancellationToken);

        Assert.NotNull(result);
        Assert.Equal(finalResponse.Id, result.Id);

        _mockMediator.Verify(m => m.Send(command, cancellationToken), Times.Once);
    }

}
