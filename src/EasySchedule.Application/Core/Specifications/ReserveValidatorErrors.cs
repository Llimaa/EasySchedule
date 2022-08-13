using System.ComponentModel;

namespace EasySchedule.Application.Core.Specifications;

public enum ReserveValidatorErrors
{
    [Description("Reserve Id is required")]
    Reserve_Id_Is_Required,

    [Description("Reserve StoreId is required")]
    Reserve_StoreId_Is_Required,

    [Description("Reserve ServiceId is required")]
    Reserve_ServiceId_Is_Required,
    [Description("Reserve DayWeekId is required")]
    Reserve_DayWeekId_Is_Required,

    [Description("Reserve Time is required")]
    Reserve_Time_Required,
}