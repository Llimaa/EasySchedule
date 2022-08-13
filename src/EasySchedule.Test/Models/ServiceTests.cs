using System;
using Bogus;
using EasySchedule.Application.Core.Models;
using EasySchedule.Application.Core.Specifications;
using FluentAssertions;
using Moq;
using Xunit;

namespace EasySchedule.Test.Models;
public class ServiceTests
{

    [Fact]
    public void Service_Should_Be_Valid()
    {
        // Given
        var faker = new Faker("en");
        var idCategory = Guid.NewGuid();
        var title = faker.Commerce.Random.AlphaNumeric(10);
        var description = faker.Commerce.Random.AlphaNumeric(10);
        var time = faker.Date.Timespan();
        var value = faker.Random.Number(100);
        var specifications = new ServiceSpecifications();

        // When
        var service = Service.Raise(idCategory, title, description, time, value, specifications);

        // Then
        service.Valid.Should().BeTrue();
    }

    [Fact]
    public void Service_Id_Category_Not_Be_Empty()
    {
        // Given
        var faker = new Faker("en");
        var idCategory = Guid.Empty;
        var title = faker.Random.AlphaNumeric(10);
        var description = faker.Commerce.Random.AlphaNumeric(10);
        var time = faker.Date.Timespan();
        var value = faker.Random.Number(100);
        var specifications = new ServiceSpecifications();

        // When

         var service = Service.Raise(idCategory, title, description, time, value, specifications);

        // Then
        service.Valid.Should().BeFalse();
    }

        [Fact]
    public void Service_Title_Not_Be_Empty()
    {
        // Given
        var faker = new Faker("en");
        var idCategory = Guid.NewGuid();
        var title = string.Empty;
        var description = faker.Commerce.Random.AlphaNumeric(10);
        var time = faker.Date.Timespan();
        var value = faker.Random.Number(100);
        var specifications = new ServiceSpecifications();

        // When
         var service = Service.Raise(idCategory, title, description, time, value, specifications);

        // Then
        service.Valid.Should().BeFalse();
    }

    [Fact]
    public void Service_Description_Not_Be_Empty()
    {
        // Given
        var faker = new Faker("en");
        var idCategory = Guid.NewGuid();
        var title = faker.Commerce.Random.AlphaNumeric(10);
        var description = string.Empty;
        var time = faker.Date.Timespan();
        var value = faker.Random.Number(100);
        var specifications = new ServiceSpecifications();

        // When
         var service = Service.Raise(idCategory, title, description, time, value, specifications);

        // Then
        service.Valid.Should().BeFalse();
    }
    
    [Fact]
    public void Service_Value_Not_Be_Zero()
    {
        // Given
        var faker = new Faker("en");
        var idCategory = Guid.NewGuid();
        var title = faker.Commerce.Random.AlphaNumeric(10);
        var description = string.Empty;
        var time = faker.Date.Timespan();
        var value = 0;
        var specifications = new ServiceSpecifications();

        // When
         var service = Service.Raise(idCategory, title, description, time, value, specifications);

        // Then
        service.Valid.Should().BeFalse();
    }
}