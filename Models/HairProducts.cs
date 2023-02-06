using System.ComponentModel.DataAnnotations;

namespace FM_Secrets_Web_App.Models
{
    public class HairProducts
    {
        public int HairProductsId { get; set; }

        public string HairProductsName { get; set; }

        public string HairProduct_Description { get; set; }

        public string HairProduct_Code { get; set; }

        public int HairProduct_Quantity { get; set; }

        public int HairProduct_Price { get; set; }

    }
}
