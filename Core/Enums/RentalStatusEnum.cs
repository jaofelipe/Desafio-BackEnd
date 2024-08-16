using System.ComponentModel;

namespace DesafioBackEnd.Core.Enums
{
    public enum RentalStatusEnum
    {
        [Description("Ativo")]
        Active,
        [Description("Devolvido")]
        Completed,
        [Description("Cancelado")]
        Canceled
    }
}
