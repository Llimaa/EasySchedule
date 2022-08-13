using EasySchedule.Application.Core.Models;
using EnumsNET;
using FluentValidation;
namespace EasySchedule.Application.Core.Specifications;

public class CategorySpecifications : AbstractValidator<Category>
{
    public CategorySpecifications()
    {
        RuleFor(_ => _.Id)
            .NotEmpty()
            .WithErrorCode(CategoryValidatorErrors.Category_Id_Is_Required.AsString())
            .WithMessage(CategoryValidatorErrors.Category_Id_Is_Required.AsString(EnumFormat.Description));

        RuleFor(_ => _.IdStore)
            .NotEmpty()
            .WithErrorCode(CategoryValidatorErrors.Category_StoreId_Is_Required.AsString())
            .WithMessage(CategoryValidatorErrors.Category_StoreId_Is_Required.AsString(EnumFormat.Description));

        RuleFor(_ => _.Active)
           .NotEmpty()
           .WithErrorCode(CategoryValidatorErrors.Category_Active_Is_Required.AsString())
           .WithMessage(CategoryValidatorErrors.Category_Active_Is_Required.AsString(EnumFormat.Description));
    }
}