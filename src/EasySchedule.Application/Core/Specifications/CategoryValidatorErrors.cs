using System.ComponentModel;

namespace EasySchedule.Application.Core.Specifications;

public enum CategoryValidatorErrors
{
    [Description("Category Id is required")]
    Category_Id_Is_Required,

    [Description("Category StoreId is required")]
    Category_StoreId_Is_Required,

    [Description("Category Active is required")]
    Category_Active_Is_Required,

    [Description("Category Name is required")]
    Category_Name_Is_Required,
}