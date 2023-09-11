using System.ComponentModel;

namespace TP02___SWII6.Enums
{
    public class EnumsConteiner
    {
        public enum Tipo 
        {
            [Description("Dry")]
            Dry = 0,
            
            [Description("Reefer")]
            Reefer = 1,
        }

        public enum Tamanho
        {
            [Description("20")]
            C20 = 0,

            [Description("40")]
            C40 = 1,
        }
    }
}
