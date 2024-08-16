using System.ComponentModel;

namespace DesafioBackEnd.Core.Enums
{
    public enum RentalPlanEnum
    {
        [Description("7 Dias")]
        SevenDays,
        [Description("15 Dias")]
        FifteenDays,
        [Description("30 Dias")]
        ThirtyDays,
        [Description("40 Dias")]
        FortyFiveDays,
        [Description("50 Dias")]
        FiftyDays
    }
}
