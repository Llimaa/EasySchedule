using System.ComponentModel;

namespace EasySchedule.Application.Core.Specifications;

public enum ServiceValidatorErrors
{
    [Description("Service Id is required")]
    Service_Id_Is_Required,

    [Description("Service IdCategory is required")]
    Service_IdCategory_Is_Required,

    [Description("Service Title is required")]
    Service_Title_Is_Required,

    [Description("Service Description is required")]
    Service_Description_Is_Required,

    [Description("Service Time is required")]
    Service_Time_Is_Required,

    [Description("Service Value is greater than 0")]
    Service_Value_Is_Greater_Than_0
}