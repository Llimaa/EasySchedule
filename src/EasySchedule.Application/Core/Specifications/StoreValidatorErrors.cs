using System.ComponentModel;

namespace EasySchedule.Application.Core.Specifications;

public enum StoreValidatorErrors
{
    [Description("Store Id Is Required")]
    Store_Id_Is_Required,

    [Description("Store ProfileId Is Required")]
    Store_ProfileId_Is_Required,

    [Description("Store Active is Required")]
    Store_Active_Is_Required
}