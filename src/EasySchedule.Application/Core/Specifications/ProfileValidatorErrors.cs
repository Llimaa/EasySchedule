using System.ComponentModel;

namespace EasySchedule.Application.Core.Specifications;

public enum ProfileValidatorErrors
{
    [Description("Profile Id is requered")]
    Profile_Id_Is_Required,

    [Description("Profile Name is Required")]
    Profile_Name_Is_Required,

    [Description("Profile BirthDay Should Be 18 Years Or More")]
    Profile_BirthDay_Should_Be_18_Years_Or_More,

    [Description("Profile Document is Required")]
    Profile_Document_Is_Required,

    [Description("Profile Email is Required")]
    Profile_Email_Is_Required,

    [Description("Profile Email is Invalid")]
    Profile_Email_Is_Invalid,

    [Description("Profile Password is Required")]
    Profile_Password_Is_Required
}