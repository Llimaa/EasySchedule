using System;
using System.Linq;
using Bogus;
using EasySchedule.Application.Core.Models;
using EasySchedule.Application.Core.Specifications;
using EnumsNET;
using FluentAssertions;
using Moq;
using Xunit;

namespace EasySchedule.Test.Models;

public class ProfileTest
{

    [Fact]
    public void Profile_Should_Be_Valid()
    {
        // Given
        var faker = new Faker("en");
        var name = faker.Person.UserName;
        var birthday = faker.Person.DateOfBirth;
        var document = faker.Random.AlphaNumeric(11);
        var email = faker.Person.Email;
        var password = faker.Random.AlphaNumeric(10);
        var specifications = new ProfileSpecifications();

        // When
        var profile = Profile.Raise(name, birthday, document, email, password, specifications);

        // Then
        profile.Valid.Should().BeTrue();
    }

    [Fact]
    public void Profile_Name_Should_Not_Be_Empty()
    {
        // Given
        var faker = new Faker("en");
        var name = string.Empty;
        var birthday = faker.Person.DateOfBirth;
        var document = faker.Random.AlphaNumeric(11);
        var email = faker.Person.Email;
        var password = faker.Random.AlphaNumeric(10);
        var specifications = new ProfileSpecifications();

        // When
        var profile = Profile.Raise(name, birthday, document, email, password, specifications);

        // Then
        profile.Valid.Should().BeFalse();
    }

    [Fact]
    public void Profile_BirthDay_Should_Be_18_Years_Or_More()
    {
        // Given
        var faker = new Faker("en");
        var name = faker.Person.UserName;
        var birthday = faker.Person.DateOfBirth;
        var document = faker.Random.AlphaNumeric(11);
        var email = faker.Person.Email;
        var password = faker.Random.AlphaNumeric(10);
        var specifications = new ProfileSpecifications();

        // When
        var profile = Profile.Raise(name, birthday, document, email, password, specifications);

        // Then
        profile.Valid.Should().BeTrue();
    }

    [Fact]
    public void Profile_BirthDay_Should_Be_Not_18_Years_Or_More()
    {
        // Given
        var faker = new Faker("en");
        var name = faker.Person.UserName;
        var birthday = DateTime.Now;
        var document = faker.Random.AlphaNumeric(11);
        var email = faker.Person.Email;
        var password = faker.Random.AlphaNumeric(10);
        var specifications = new ProfileSpecifications();

        // When
        var profile = Profile.Raise(name, birthday, document, email, password, specifications);
        // Then
        profile.Errors.Keys.First().Should().Be(ProfileValidatorErrors.Profile_BirthDay_Should_Be_18_Years_Or_More.AsString());
    }

    [Fact]
    public void Profile_Document_Should_Not_Be_Empty()
    {
        // Given
        var faker = new Faker("en");
        var name = faker.Person.UserName;
        var birthday = faker.Person.DateOfBirth;
        var document = string.Empty;
        var email = faker.Person.Email;
        var password = faker.Random.AlphaNumeric(10);
        var specifications = new ProfileSpecifications();

        // When
        var profile = Profile.Raise(name, birthday, document, email, password, specifications);

        // Then
        profile.Valid.Should().BeFalse();
    }

    [Fact]
    public void Profile_Email_Should_Not_Be_Empty()
    {
        // Given
        var faker = new Faker("en");
        var name = faker.Person.UserName;
        var birthday = faker.Person.DateOfBirth;
        var document = faker.Random.AlphaNumeric(11);
        var email = string.Empty;
        var password = faker.Random.AlphaNumeric(10);
        var specifications = new ProfileSpecifications();

        // When
        var profile = Profile.Raise(name, birthday, document, email, password, specifications);

        // Then
        profile.Valid.Should().BeFalse();
    }

    [Fact]
    public void Profile_Password_Should_Not_Be_Empty()
    {
        // Given
        var faker = new Faker("en");
        var name = faker.Person.UserName;
        var birthday = faker.Person.DateOfBirth;
        var document = faker.Random.AlphaNumeric(11);
        var email = faker.Person.Email;
        var password = string.Empty;
        var specifications = new ProfileSpecifications();

        // When
        var profile = Profile.Raise(name, birthday, document, email, password, specifications);

        // Then
        profile.Valid.Should().BeFalse();
    }
}