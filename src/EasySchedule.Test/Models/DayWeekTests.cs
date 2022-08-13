using System;
using Moq;
using Xunit;
using FluentAssertions;
using Bogus;
using EasySchedule.Application.Core.Models;
using EasySchedule.Application.Core.Specifications;


namespace EasySchedule.Test.Models;

public class DayWeekTests
{
    [Fact]
    public void Profile_Should_Be_Valid()
    {
        // Given
        var faker = new Faker("en");
        var IdStore = Guid.NewGuid();
        var Day = faker.Random.AlphaNumeric(5);
        var From = faker.Date.Timespan(new TimeSpan(1, 0, 0));
        var Until = faker.Date.Timespan(new TimeSpan(5, 1, 0));
        var specifications = new DayWeekSpecifications();

        // When
        var dayWeek = DayWeek.Raise(IdStore, Day, From, Until, specifications);
        var valid = dayWeek.Valid;
        // Then
        dayWeek.Valid.Should().BeTrue();
    }

    [Fact]
    public void DayWeek_IdStore_Should_Not_Be_Empty()
    {
        // Given
        var faker = new Faker("en");
        var IdStore = Guid.Empty;
        var Day = faker.Random.AlphaNumeric(5);
        var From = faker.Date.Timespan();
        var Until = faker.Date.Timespan();
        var specifications = new DayWeekSpecifications();

        // When
        var dayWeek = DayWeek.Raise(IdStore, Day, From, Until, specifications);

        // Then
        dayWeek.Valid.Should().BeFalse();
    }

    [Fact]
    public void DayWeek_Day_Should_Not_Be_Empty()
    {
        // Given
        var faker = new Faker("en");
        var IdStore = Guid.NewGuid();
        var Day = String.Empty;
        var From = faker.Date.Timespan(new TimeSpan(1, 0, 0));
        var Until = faker.Date.Timespan(new TimeSpan(2, 0, 0));
        var specifications = new DayWeekSpecifications();

        // When
        var dayWeek = DayWeek.Raise(IdStore, Day, From, Until, specifications);

        // Then
        dayWeek.Valid.Should().BeFalse();
    }

    [Fact]
    public void DayWeek_From_Should_Be_Less_Than_Until()
    {
        // Given
        var faker = new Faker("en");
        var IdStore = Guid.NewGuid();
        var Day = faker.Random.AlphaNumeric(5);
        var From = new TimeSpan(1, 0, 0);
        var Until = new TimeSpan(2, 0, 0);
        var specifications = new DayWeekSpecifications();

        // When
        var dayWeek = DayWeek.Raise(IdStore, Day, From, Until, specifications);

        // Then
        dayWeek.Valid.Should().BeTrue();
    }

    [Fact]
    public void DayWeek_Until_Should_Be_Greater_Than_From()
    {
        // Given
        var faker = new Faker("en");
        var IdStore = Guid.NewGuid();
        var Day = faker.Random.AlphaNumeric(5);
        var From = new TimeSpan(4, 0, 0);
        var Until = new TimeSpan(5, 0, 0);
        var specifications = new DayWeekSpecifications();

        // When
        var dayWeek = DayWeek.Raise(IdStore, Day, From, Until, specifications);

        // Then
        dayWeek.Valid.Should().BeTrue();
    }
}