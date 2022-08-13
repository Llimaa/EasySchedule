using System;
using Bogus;
using EasySchedule.Application.Core.Models;
using EasySchedule.Application.Core.Specifications;
using FluentAssertions;
using Moq;
using Xunit;

namespace EasySchedule.Test.Models;
public class ReserveTests
{
    [Fact]
    public void Reserve_Should_Be_Valid()
    {
        // Given
        var faker = new Faker("en");
        var idStore = Guid.NewGuid();
        var idService = Guid.NewGuid();
        var idDayWeek = Guid.NewGuid();
        var time = faker.Date.Timespan();
        var specifications = new ReserveSpecifications();

        // When
        var reserve = Reserve.Raise(idStore, idService, idDayWeek, time, specifications);

        // Then

        reserve.Valid.Should().BeTrue();
    }

    [Fact]
    public void Reserve_IdStore_Should_Be_Not_Empty()
    {
        // Given
        var faker = new Faker("en");
        var idStore = Guid.Empty;
        var idService = Guid.NewGuid();
        var idDayWeek = Guid.NewGuid();
        var time = faker.Date.Timespan();
        var specifications = new ReserveSpecifications();

        // When
        var reserve = Reserve.Raise(idStore, idService, idDayWeek, time, specifications);

        // Then

        reserve.Valid.Should().BeFalse();
    }

    [Fact]
    public void Reserve_IdService_Should_Be_Not_Empty()
    {
        // Given
        var faker = new Faker("en");
        var idStore = Guid.NewGuid();
        var idService = Guid.Empty;
        var idDayWeek = Guid.NewGuid();
        var time = faker.Date.Timespan();
        var specifications = new ReserveSpecifications();

        // When
        var reserve = Reserve.Raise(idStore, idService, idDayWeek, time, specifications);

        // Then

        reserve.Valid.Should().BeFalse();
    }

    [Fact]
    public void Reserve_IdDayWeek_Should_Be_Not_Empty()
    {
        // Given
        var faker = new Faker("en");
        var idStore = Guid.NewGuid();
        var idService = Guid.NewGuid();
        var idDayWeek = Guid.Empty;
        var time = faker.Date.Timespan();
        var specifications = new ReserveSpecifications();

        // When
        var reserve = Reserve.Raise(idStore, idService, idDayWeek, time, specifications);

        // Then

        reserve.Valid.Should().BeFalse();
    }
}