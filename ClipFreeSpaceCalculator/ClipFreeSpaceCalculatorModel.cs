
using System.Text.Json.Serialization;

namespace ClipFreeSpaceCalculator
{
    public class ClipFreeSpaceCalculatorModel
    {
        [JsonPropertyName("parts")]
        public List<double> ZirkariSizeList { get; set; }
        [JsonPropertyName("totalSpace")]
        public double TotalSpace { get; set; }
        [JsonPropertyName("neededSpace")]
        public double NeededSpace { get; set; }

    }
}
