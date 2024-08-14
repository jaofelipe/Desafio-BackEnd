using System.ComponentModel;

namespace DesafioBackEnd.Enums
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
