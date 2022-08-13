using FluentValidation;
using EasySchedule.Application.Core.Extensions;

namespace EasySchedule.Application.Core.Models;
public class Profile : BaseEntity
{
    private readonly IValidator<Profile> specifications;

    public Profile(IValidator<Profile> specifications)
    : base()
    {
        this.specifications = specifications;
    }

    public string? Name { get; private set; }
    public DateTime Birthday { get; private set; }
    public string? Document { get; private set; }
    public string? Email { get; private set; }
    public string? Password { get; private set; }

    private void Specify()
    {
        var (errors, valid) = specifications.Validate(this);

        Errors = errors.AsDefaultFormat();
        Valid = valid;
    }

    public static Profile Raise(string? name, DateTime birthday, string? document, string? email, string? password, IValidator<Profile> specifications)
    {
        var instance = new Profile(specifications)
        {
            Name = name,
            Birthday = birthday,
            Document = document,
            Email = email,
            Password = password
        };

        instance.Specify();

        return instance;
    }
}
