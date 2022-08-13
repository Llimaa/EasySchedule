using EnumsNET;
using EasySchedule.Application.Core.Models;
using FluentValidation;

namespace EasySchedule.Application.Core.Specifications;
public class ReserveSpecifications : AbstractValidator<Reserve>
{
    public ReserveSpecifications()
    {
        RuleFor(_ => _.Id)
            .NotEmpty()
            .WithErrorCode(ReserveValidatorErrors.Reserve_Id_Is_Required.AsString())
            .WithMessage(ReserveValidatorErrors.Reserve_Id_Is_Required.AsString(EnumFormat.Description));

        RuleFor(_ => _.IdStore)
           .NotEmpty()
           .WithErrorCode(ReserveValidatorErrors.Reserve_StoreId_Is_Required.AsString())
           .WithMessage(ReserveValidatorErrors.Reserve_StoreId_Is_Required.AsString(EnumFormat.Description));

        RuleFor(_ => _.IdService)
            .NotEmpty()
            .WithErrorCode(ReserveValidatorErrors.Reserve_ServiceId_Is_Required.AsString())
            .WithMessage(ReserveValidatorErrors.Reserve_ServiceId_Is_Required.AsString(EnumFormat.Description));

        RuleFor(_ => _.IdDayWeek)
           .NotEmpty()
           .WithErrorCode(ReserveValidatorErrors.Reserve_DayWeekId_Is_Required.AsString())
           .WithMessage(ReserveValidatorErrors.Reserve_DayWeekId_Is_Required.AsString(EnumFormat.Description));

        RuleFor(_ => _.Time)
           .NotEmpty()
           .WithErrorCode(ReserveValidatorErrors.Reserve_Time_Required.AsString())
           .WithMessage(ReserveValidatorErrors.Reserve_Time_Required.AsString(EnumFormat.Description));
    }
}