using Xunit;
using Bogus;
using Moq;
using EasySchedule.Application.Core.ErrorBag;
using FluentAssertions;
using System.Collections.Generic;

namespace EasySchedule.Test.ErrorBag;

public class ErrorBagHandlerTests
{
    [Fact]
    public void When_Error_Should_Be_HasError_Is_True()
    {
        // Given
        var errorBagHandler = new ErrorBagHandler();

        // When
        errorBagHandler.HandlerError("Error", "Error Message");

        //Then
        errorBagHandler.HasError().Should().BeTrue();
    }

    [Fact]
    public void When_Errors_Should_Be_Raise_Return_Errors()
    {
        // Given
        var errorBagHandler = new ErrorBagHandler();
        var mockDictionary = new Dictionary<string, string> {
            {"Error1", "error message"},
            {"Error2", "error message"}
        };
        errorBagHandler.HandlerError(mockDictionary);

        // When
        // Then
        errorBagHandler.Raise().Should().ContainKey("Error1");
    }
}