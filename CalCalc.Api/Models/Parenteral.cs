namespace CalCalc.Api.Models
{
    public class Parenteral
    {
        public int Id { get; set; }
        public int CalEntryId { get; set; }
        public decimal? Dextrose { get; set; }
        public decimal? Amino { get; set; }
        public decimal? Lipid { get; set; }
        public decimal Volume { get; set; }

        public CalEntry CalEntry { get; set; }
    }
}