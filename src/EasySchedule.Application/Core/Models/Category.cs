using EasySchedule.Application.Core.Extensions;
using FluentValidation;

namespace EasySchedule.Application.Core.Models;

public class Category : BaseEntity
{
    private readonly IValidator<Category> specifications;

    public Category(IValidator<Category> specifications)
    : base()
    {
        this.specifications = specifications;
        Errors = new();
        Services = new();
    }

    public Guid IdStore { get; private set; }
    public bool Active { get; private set; }
    public string? Name { get; private set; }
    public List<Service> Services { get; private set; }


    private void Specify()
    {
        var (errors, valid) = specifications.Validate(this);

        Errors = errors.AsDefaultFormat();
        Valid = valid;
    }

    public static Category Raise(Guid idStore, bool active, string name, IValidator<Category> specifications)
    {
        var instance = new Category(specifications)
        {
            IdStore = idStore,
            Active = active,
            Name = name,
        };

        instance.Specify();

        return instance;
    }
}