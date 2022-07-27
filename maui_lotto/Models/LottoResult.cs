using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maui_lotto.Models
{
    public class LottoResult
    {
        public long totSellamnt { get; set; }
        public string returnValue { get; set; }
        public string drwNoDate { get; set; }
        public long firstWinamnt { get; set; }
        public int drwtNo6 { get; set; }
        public int drwtNo4 { get; set; }
        public long firstPrzwnerCo { get; set; }
        public int drwtNo5 { get; set; }
        public int bnusNo { get; set; }
        public long firstAccumamnt { get; set; }
        public int drwNo { get; set; }
        public int drwtNo2 { get; set; }
        public int drwtNo3 { get; set; }
        public int drwtNo1 { get; set; }

        [JsonIgnore]
        public Brush color1 { get; set; }
        [JsonIgnore]
        public Brush color2 { get; set; }
        [JsonIgnore]
        public Brush color3 { get; set; }
        [JsonIgnore]
        public Brush color4 { get; set; }
        [JsonIgnore]
        public Brush color5 { get; set; }
        [JsonIgnore]
        public Brush color6 { get; set; }
        [JsonIgnore]
        public Brush colorBonus { get; set; }

        [JsonIgnore]
        public Color bgColor { get; set; }

    }
}
