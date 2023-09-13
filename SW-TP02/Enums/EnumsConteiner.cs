using System.ComponentModel;

namespace TP02___SWII6.Enums
{
    public class EnumsConteiner
    {
        public enum Tipo 
        {
            [Description("Dry")]
            Dry = 1,
            
            [Description("Reefer")]
            Reefer = 2,
        }

        public enum Tamanho
        {
            [Description("20")]
            C20 = 1,

            [Description("40")]
            C40 = 2,
        }
    }
}
