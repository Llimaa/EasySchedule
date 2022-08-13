using EasySchedule.Application.Core.Extensions;
using FluentValidation;

namespace EasySchedule.Application.Core.Models;

public class Service : BaseEntity
{

    private readonly IValidator<Service> specifications;
    public Service(IValidator<Service> specifications)
    {
        this.specifications = specifications;
    }

    public Guid IdCategory { get; private set; }
    public string? Title { get; private set; }
    public string? Description { get; private set; }
    public TimeSpan Time { get; private set; }
    public decimal Value { get; private set; }

    private void Specify()
    {
        var (errors, valid) = specifications.Validate(this);

        Errors = errors.AsDefaultFormat();
        Valid = valid;
    }

    public static Service Raise(Guid idCategory, string title, string description, TimeSpan time, decimal value, IValidator<Service> specifications)
    {
        var instance = new Service(specifications)
        {
            IdCategory = idCategory,
            Title = title,
            Description = description,
            Time = time,
            Value = value
        };

        instance.Specify();

        return instance;
    }
}