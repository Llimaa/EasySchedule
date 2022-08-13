using EnumsNET;
using EasySchedule.Application.Core.Models;
using FluentValidation;

namespace EasySchedule.Application.Core.Specifications;
public class ServiceSpecifications : AbstractValidator<Service>
{
    public ServiceSpecifications()
    {
        RuleFor(_ => _.Id)
            .NotEmpty() 
            .WithErrorCode(ServiceValidatorErrors.Service_Id_Is_Required.AsString())
            .WithMessage(ServiceValidatorErrors.Service_Id_Is_Required.AsString(EnumFormat.Description));

        RuleFor(_ => _.IdCategory)
           .NotEmpty()
           .WithErrorCode(ServiceValidatorErrors.Service_IdCategory_Is_Required.AsString())
           .WithMessage(ServiceValidatorErrors.Service_IdCategory_Is_Required.AsString(EnumFormat.Description));

        RuleFor(_ => _.Title)
            .NotEmpty()
            .WithErrorCode(ServiceValidatorErrors.Service_Title_Is_Required.AsString())
            .WithMessage(ServiceValidatorErrors.Service_Title_Is_Required.AsString(EnumFormat.Description));

        RuleFor(_ => _.Description)
           .NotEmpty()
           .WithErrorCode(ServiceValidatorErrors.Service_Description_Is_Required.AsString())
           .WithMessage(ServiceValidatorErrors.Service_Description_Is_Required.AsString(EnumFormat.Description));

        RuleFor(_ => _.Time)
           .NotEmpty()
           .WithErrorCode(ServiceValidatorErrors.Service_Time_Is_Required.AsString())
           .WithMessage(ServiceValidatorErrors.Service_Time_Is_Required.AsString(EnumFormat.Description));
        RuleFor(_ => _.Value)
           .NotEmpty()
           .WithErrorCode(ServiceValidatorErrors.Service_Value_Is_Greater_Than_0.AsString())
           .WithMessage(ServiceValidatorErrors.Service_Value_Is_Greater_Than_0.AsString(EnumFormat.Description));
    }
}