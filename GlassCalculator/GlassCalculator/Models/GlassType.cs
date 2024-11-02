using GlassCalculator.Models.Enums;

namespace GlassCalculator.Models
{
    public class GlassType
    {
        public string Name { get; set; }
        public GlassColorEnum GlassColor {get;set;}
        public PriceType Price { get; set;}
        public int Thickness { get; set; }
    }
}
