using EasySchedule.Application.Core.Extensions;
using FluentValidation;

namespace EasySchedule.Application.Core.Models;

public class Reserve : BaseEntity
{
    private readonly IValidator<Reserve> specifications;

    public Reserve(IValidator<Reserve> specifications)
    : base()
    {
        this.specifications = specifications;
        Errors = new();
    }

    public Guid IdStore { get; private set; }
    public Guid IdService { get; private set; }
    public Guid IdDayWeek { get; private set; }
    public TimeSpan Time { get; private set; }


    private void Specify()
    {
        var (errors, valid) = specifications.Validate(this);

        Errors = errors.AsDefaultFormat();
        Valid = valid;
    }

    public static Reserve Raise(Guid idStore, Guid idService, Guid idDayWeek, TimeSpan time, IValidator<Reserve> specifications)
    {
        var instance = new Reserve(specifications)
        {
            IdStore = idStore,
            IdService = idService,
            IdDayWeek = idDayWeek,
            Time = time,
        };

        instance.Specify();

        return instance;
    }
}
