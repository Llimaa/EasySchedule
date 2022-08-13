using Xunit;
using Bogus;
using System;
using EasySchedule.Application.Core.Specifications;
using EasySchedule.Application.Core.Models;
using FluentAssertions;

namespace EasySchedule.Test.Models;

public class StoreTests
{
    [Fact]
    public void Store_Should_Be_Valid()
    {
        // Given
        var faker = new Faker("en");
        var profileId = Guid.NewGuid();
        var specifications = new StoreSpecifications();

        // When
        var store = Store.Raise(profileId, specifications);

        // Then
        store.Valid.Should().BeTrue();
    }

    [Fact]
    public void Store_profileId_Should_Not_Be_Empty()
    {
        // Given
        var faker = new Faker("en");
        var profileId = Guid.Empty;
        var specifications = new StoreSpecifications();
        // When
        var store = Store.Raise(profileId, specifications);
        // Then
        store.Valid.Should().BeFalse();
    }

    [Fact]
    public void Store_Raise_Should_Be_Active_Is_True()
    {
        // Given
        var faker = new Faker("en");
        var profileId = Guid.Empty;
        var specifications = new StoreSpecifications();
        // When
        var store = Store.Raise(profileId, specifications);
        // Then
        store.Active.Should().BeTrue();
    }
}