using EnumsNET;
using EasySchedule.Application.Core.Models;
using FluentValidation;

namespace EasySchedule.Application.Core.Specifications;
public class DayWeekSpecifications : AbstractValidator<DayWeek>
{
    public DayWeekSpecifications()
    {
        RuleFor(_ => _.Id)
            .NotEmpty()
            .WithErrorCode(DayWeekValidatorErrors.DayWeek_Id_Is_Required.AsString())
            .WithMessage(DayWeekValidatorErrors.DayWeek_Id_Is_Required.AsString(EnumFormat.Description));

        RuleFor(_ => _.IdStore)
           .NotEmpty()
           .WithErrorCode(DayWeekValidatorErrors.DayWeek_StoreId_Is_Required.AsString())
           .WithMessage(DayWeekValidatorErrors.DayWeek_StoreId_Is_Required.AsString(EnumFormat.Description));

        RuleFor(_ => _.Day)
            .NotEmpty()
            .WithErrorCode(DayWeekValidatorErrors.DayWeek_Day_Is_Required.AsString())
            .WithMessage(DayWeekValidatorErrors.DayWeek_Day_Is_Required.AsString(EnumFormat.Description));

        RuleFor(_ => _.From)
           .LessThan(_ => _.Until)
           .WithErrorCode(DayWeekValidatorErrors.DayWeek_From_Is_Less_Than_Until.AsString())
           .WithMessage(DayWeekValidatorErrors.DayWeek_From_Is_Less_Than_Until.AsString(EnumFormat.Description));

        RuleFor(_ => _.Until)
          .GreaterThan(_ => _.From)
          .WithErrorCode(DayWeekValidatorErrors.DayWeek_Until_Is_Greater_Than_From.AsString())
          .WithMessage(DayWeekValidatorErrors.DayWeek_Until_Is_Greater_Than_From.AsString(EnumFormat.Description));
    }
}