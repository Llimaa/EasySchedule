using EasySchedule.Application.Core.Extensions;
using FluentValidation;

namespace EasySchedule.Application.Core.Models;

public class DayWeek : BaseEntity
{
    private readonly IValidator<DayWeek> specifications;

    public DayWeek(IValidator<DayWeek> specifications)
    : base()
    {
        this.specifications = specifications;
        Errors = new();
    }

    public Guid IdStore { get; private set; }
    public string? Day { get; private set; }
    public TimeSpan From { get; private set; }
    public TimeSpan Until { get; private set; }

    private void Specify()
    {
        var (errors, valid) = specifications.Validate(this);

        Errors = errors.AsDefaultFormat();
        Valid = valid;
    }

    public static DayWeek Raise(Guid idStore, string day, TimeSpan from, TimeSpan until, IValidator<DayWeek> specifications)
    {
        var instance = new DayWeek(specifications)
        {
            IdStore = idStore,
            Day = day,
            From = from,
            Until = until
        };

        instance.Specify();

        return instance;
    }
}