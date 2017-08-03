namespace CalCalc.Api.Models
{
    public class FluidInfusions
    {
        public int Id { get; set; }
        public int CalEntryId { get; set; }
        public int DextroseConcentrationId { get; set; }
        public int Volume { get; set; }

        public CalEntry CalEntry { get; set; }
        public DextroseConcentration DextroseConcentration { get; set; }
    }
}