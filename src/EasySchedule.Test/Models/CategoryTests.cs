using System;
using Bogus;
using EasySchedule.Application.Core.Models;
using EasySchedule.Application.Core.Specifications;
using FluentAssertions;
using Xunit;

namespace EasySchedule.Test.Models;
public class CategoryTests
{

    [Fact]
    public void Category_Should_Be_Valid()
    {
        // Given
        var faker = new Faker("en");
        var idStore = Guid.NewGuid();
        var active = true;
        var name = faker.Commerce.Random.AlphaNumeric(10);
        var value = faker.Random.Number(100);
        var specifications = new CategorySpecifications();

        // When
        var category = Category.Raise(idStore, active, name, specifications);

        // Then
        category.Valid.Should().BeTrue();
    }

    [Fact]
    public void Category_Id_Should_Be_Not_Empty()
    {
        // Given
        var faker = new Faker("en");
        var idStore = Guid.NewGuid();
        var active = true;
        var name = faker.Commerce.Random.AlphaNumeric(10);
        var value = faker.Random.Number(100);
        var specifications = new CategorySpecifications();

        // When
        var category = Category.Raise(idStore, active, name, specifications);

        // Then
        category.Id.Should().NotBe(Guid.Empty);
    }

    [Fact]
    public void Category_IdStory_Should_Be_Not_Empty()
    {
        // Given
        var faker = new Faker("en");
        var idStore = Guid.Empty;
        var active = true;
        var name = faker.Commerce.Random.AlphaNumeric(10);
        var value = faker.Random.Number(100);
        var specifications = new CategorySpecifications();

        // When
        var category = Category.Raise(idStore, active, name, specifications);

        // Then
        category.IdStore.Should().Be(Guid.Empty);
    }

    [Fact]
    public void Category_Services_Should_Be_New_Instance()
    {
        // Given
        var faker = new Faker("en");
        var idStore = Guid.Empty;
        var active = true;
        var name = faker.Commerce.Random.AlphaNumeric(10);
        var value = faker.Random.Number(100);
        var specifications = new CategorySpecifications();

        // When
        var category = Category.Raise(idStore, active, name, specifications);

        // Then
        category.Services.Should().NotBeNull();
    }

    [Fact]
    public void Category_Services_Should_Be_Two_Services()
    {
        // Given
        var faker = new Faker("en");
        var idStore = Guid.Empty;
        var active = true;
        var name = faker.Commerce.Random.AlphaNumeric(10);
        var value = faker.Random.Number(100);
        var specifications = new CategorySpecifications();


        var idCategory = Guid.NewGuid();
        var title = faker.Random.AlphaNumeric(10);
        var description = faker.Random.AlphaNumeric(10);
        var time = faker.Date.Timespan();
        var specificationsService = new ServiceSpecifications();

        // When
        var category = Category.Raise(idStore, active, name, specifications);

        var service = Service.Raise(idCategory, title, description, time, value, specificationsService);
        category.Services.Add(service);
        category.Services.Add(service);
        var length = category.Services.Count;

        // Then
        category.Services.Count.Should().Be(2);
    }
}