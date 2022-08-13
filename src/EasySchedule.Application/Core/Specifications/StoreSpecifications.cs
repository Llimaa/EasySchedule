using EasySchedule.Application.Core.Models;
using EnumsNET;
using FluentValidation;

namespace EasySchedule.Application.Core.Specifications;

public class StoreSpecifications : AbstractValidator<Store>
{
    public StoreSpecifications()
    {
        RuleFor(_ => _.Id)
            .NotEmpty()
            .WithErrorCode(StoreValidatorErrors.Store_Id_Is_Required.AsString())
            .WithMessage(StoreValidatorErrors.Store_Id_Is_Required.AsString(EnumFormat.Description));

        RuleFor(_ => _.ProfileId)
            .NotEmpty()
            .WithErrorCode(StoreValidatorErrors.Store_ProfileId_Is_Required.AsString())
            .WithMessage(StoreValidatorErrors.Store_ProfileId_Is_Required.AsString(EnumFormat.Description));

        RuleFor(_ => _.Active)
            .NotEmpty()
            .WithErrorCode(StoreValidatorErrors.Store_Active_Is_Required.AsString())
            .WithMessage(StoreValidatorErrors.Store_Active_Is_Required.AsString(EnumFormat.Description));

    }
}