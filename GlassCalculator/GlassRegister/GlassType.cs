namespace GlassRegister
{
    public class GlassType
    {
        public string Name { get; set; }
        public GlassColorEnum GlassColor { get; set; }
        public PriceType Price { get; set; }
        public int Thickness { get; set; }
    }

    public enum GlassColorEnum
    {
        ExtraClear,
        Float,
        Bronz,
        Gray
    }

    public class PriceType
    {
        public GlassWorkTypeEnum GlassWorkType { get; set; }
        public float Price { get; set; }
    }

    public enum GlassWorkTypeEnum
    {
        Standard,
        WithHoles,
        WithCutoutsAndHoles
    }
}
