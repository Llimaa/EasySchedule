using FluentValidation;
using EasySchedule.Application.Core.Extensions;

namespace EasySchedule.Application.Core.Models;

public class Store : BaseEntity
{
    private readonly IValidator<Store> specifications;

    public Store(IValidator<Store> specifications)
    {
        this.specifications = specifications;
        Categories = new();
        DaysWeek = new();
    }

    public Guid ProfileId { get; private set; }
    public bool Active { get; private set; }
    public List<Category>? Categories { get; private set; }
    public List<DayWeek>? DaysWeek { get; private set; }

    private void Specify()
    {
        var (errors, valid) = specifications.Validate(this);
        Errors = errors.AsDefaultFormat();
        Valid = valid;
    }

    public static Store Raise(Guid profileId, IValidator<Store> specifications)
    {
        var instance = new Store(specifications)
        {
            ProfileId = profileId,
            Active = true
        };

        instance.Specify();
        return instance;
    }
}
