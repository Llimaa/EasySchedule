using System.ComponentModel;

namespace EasySchedule.Application.Core.Specifications;

public enum DayWeekValidatorErrors
{
    [Description("DayWeek Id is required")]
    DayWeek_Id_Is_Required,

    [Description("DayWeek StoreId is required")]
    DayWeek_StoreId_Is_Required,

    [Description("DayWeek Day is required")]
    DayWeek_Day_Is_Required,

    [Description("DayWeek From is less than Until")]
    DayWeek_From_Is_Less_Than_Until,

    [Description("DayWeek Until is greater than From")]
    DayWeek_Until_Is_Greater_Than_From,

}