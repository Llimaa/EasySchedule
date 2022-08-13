using EasySchedule.Application.Core.Models;
using EnumsNET;
using FluentValidation;
namespace EasySchedule.Application.Core.Specifications;

public class ProfileSpecifications : AbstractValidator<Profile>
{
    public ProfileSpecifications()
    {
        RuleFor(_ => _.Id)
            .NotEmpty()
            .WithErrorCode(ProfileValidatorErrors.Profile_Id_Is_Required.AsString())
            .WithMessage(ProfileValidatorErrors.Profile_Id_Is_Required.AsString(EnumFormat.Description));

        RuleFor(_ => _.Name)
            .NotEmpty()
            .WithErrorCode(ProfileValidatorErrors.Profile_Name_Is_Required.AsString())
            .WithMessage(ProfileValidatorErrors.Profile_Name_Is_Required.AsString(EnumFormat.Description));

        RuleFor(_ => _.Birthday)
            .LessThanOrEqualTo(DateTime.Now.AddYears(-18))
            .WithErrorCode(ProfileValidatorErrors.Profile_BirthDay_Should_Be_18_Years_Or_More.AsString())
            .WithMessage(ProfileValidatorErrors.Profile_BirthDay_Should_Be_18_Years_Or_More.AsString(EnumFormat.Description));

        RuleFor(_ => _.Document)
            .NotEmpty()
            .WithErrorCode(ProfileValidatorErrors.Profile_Document_Is_Required.AsString())
            .WithMessage(ProfileValidatorErrors.Profile_Document_Is_Required.AsString(EnumFormat.Description));

        RuleFor(_ => _.Email)
            .NotEmpty()
            .WithErrorCode(ProfileValidatorErrors.Profile_Email_Is_Required.AsString())
            .WithMessage(ProfileValidatorErrors.Profile_Email_Is_Required.AsString(EnumFormat.Description));

        RuleFor(_ => _.Email)
            .NotEmpty()
            .WithErrorCode(ProfileValidatorErrors.Profile_Email_Is_Invalid.AsString())
            .WithMessage(ProfileValidatorErrors.Profile_Email_Is_Invalid.AsString(EnumFormat.Description));

        RuleFor(_ => _.Password)
            .NotEmpty()
            .WithErrorCode(ProfileValidatorErrors.Profile_Password_Is_Required.AsString())
            .WithMessage(ProfileValidatorErrors.Profile_Password_Is_Required.AsString(EnumFormat.Description));
    }
}