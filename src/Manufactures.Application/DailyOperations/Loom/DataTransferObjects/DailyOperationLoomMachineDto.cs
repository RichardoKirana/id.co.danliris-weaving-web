using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manufactures.Application.DailyOperations.Loom.DataTransferObjects
{
    public class DailyOperationLoomMachineDto
    {
        public Guid Identity { get; set; }
        [JsonProperty(PropertyName = "Date")]
        public int Date { get; set; }
        [JsonProperty(PropertyName = "YearPeriode")]
        public string YearPeriode { get; set; }
        [JsonProperty(PropertyName = "MonthPeriode")]
        public string MonthPeriode { get; set; }
        [JsonProperty(PropertyName = "MonthPeriodeId")]
        public int MonthPeriodeId { get; set; }

        [JsonProperty(PropertyName = "Shift")]
        public string Shift { get; set; }
        [JsonProperty(PropertyName = "MCNo")]

        public string MCNo { get; set; }

        [JsonProperty(PropertyName = "TotMCNo")]
        public decimal TotMCNo { get; set; }
        [JsonProperty(PropertyName = "SPNo")]
        public string SPNo { get; set; }
        [JsonProperty(PropertyName = "Year")]
        public string Year { get; set; }
        [JsonProperty(PropertyName = "TA")]
        public string TA { get; set; }
        [JsonProperty(PropertyName = "Warp")]
        public string Warp { get; set; }
        [JsonProperty(PropertyName = "Weft")]
        public string Weft { get; set; }
        [JsonProperty(PropertyName = "Length")]
        public string Length { get; set; }
        [JsonProperty(PropertyName = "WarpType")]
        public string WarpType { get; set; }
        [JsonProperty(PropertyName = "WeftType")]
        public string WeftType { get; set; }

        [JsonProperty(PropertyName = "WeftType2")]
        public string WeftType2 { get; set; }
        [JsonProperty(PropertyName = "WeftType3")]
        public string WeftType3 { get; set; }
        [JsonProperty(PropertyName = "AL")]
        public string AL { get; set; }
        [JsonProperty(PropertyName = "AP")]
        public string AP { get; set; }
        [JsonProperty(PropertyName = "AP2")]
        public string AP2 { get; set; }
        [JsonProperty(PropertyName = "AP3")]
        public string AP3 { get; set; }
        [JsonProperty(PropertyName = "Thread")]
        public string Thread { get; set; }
        [JsonProperty(PropertyName = "Construction")]
        public string Construction { get; set; }
        [JsonProperty(PropertyName = "ThreadType")]
        public string ThreadType { get; set; }
        [JsonProperty(PropertyName = "MonthId")]
        public string MonthId { get; set; }
        [JsonProperty(PropertyName = "ProductionCMPX")]

        public string ProductionCMPX { get; set; }

        [JsonProperty(PropertyName = "TotProductionCMPX")]
        public Decimal TotProductionCMPX { get; set; }
        [JsonProperty(PropertyName = "EFFMC")]
        public string EFFMC { get; set; }
        [JsonProperty(PropertyName = "RPM")]

        public string RPM { get; set; }

        [JsonProperty(PropertyName = "TotRPM")]
        public decimal TotRPM { get; set; }
        [JsonProperty(PropertyName = "T")]
        public string T { get; set; }
        [JsonProperty(PropertyName = "F")]

        public string F { get; set; }
        [JsonProperty(PropertyName = "TotF")]
        public decimal TotF { get; set; }
        [JsonProperty(PropertyName = "W")]
        public string W { get; set; }

        [JsonProperty(PropertyName = "TotW")]
        public decimal TotW { get; set; }
        [JsonProperty(PropertyName = "L")]
        public string L { get; set; }
        [JsonProperty(PropertyName = "Column1")]
        public string Column1 { get; set; }
        [JsonProperty(PropertyName = "Production")]

        public string Production { get; set; }
        [JsonProperty(PropertyName = "TotProduction")]
        public decimal TotProduction { get; set; }
        [JsonProperty(PropertyName = "Production100")]
        public string Production100 { get; set; }
        [JsonProperty(PropertyName = "TotProduction100")]
        public decimal TotProduction100 { get; set; }
        [JsonProperty(PropertyName = "PercentEff")]
        public string PercentEff { get; set; }
        [JsonProperty(PropertyName = "TotPercentEff")]
        public decimal TotPercentEff { get; set; }
        [JsonProperty(PropertyName = "MC2Eff")]
        public string MC2Eff { get; set; }
        [JsonProperty(PropertyName = "TotMC2Eff")]
        public decimal TotMC2Eff { get; set; }
        [JsonProperty(PropertyName = "RPMProduction100")]
        public string RPMProduction100 { get; set; }
        [JsonProperty(PropertyName = "Location")]
        public string Location { get; set; }
        [JsonProperty(PropertyName = "MachineType")]
        public string MachineType { get; set; }
        [JsonProperty(PropertyName = "MachineNameType")]
        public string MachineNameType { get; set; }
        [JsonProperty(PropertyName = "Block")]
        public string Block { get; set; }
        [JsonProperty(PropertyName = "BlockName")]
        public string BlockName { get; set; }
        [JsonProperty(PropertyName = "MTCLock")]
        public string MTCLock { get; set; }
        [JsonProperty(PropertyName = "MTC")]
        public string MTC { get; set; }
        [JsonProperty(PropertyName = "MTCName")]
        public string MTCName { get; set; }
        [JsonProperty(PropertyName = "MCNo2")]
        public string MCNo2 { get; set; }
        [JsonProperty(PropertyName = "MCRPM")]
        public string MCRPM { get; set; }
        [JsonProperty(PropertyName = "Row")]
        public string Row { get; set; }
        [JsonProperty(PropertyName = "Operator")]
        public string Operator { get; set; }
        [JsonProperty(PropertyName = "SPYear")]
        public string SPYear { get; set; }

        [JsonProperty(PropertyName = "CreatedDate")]
        public string CreatedDate { get; set; }

        [JsonProperty(PropertyName = "Periode")]
        public DateTime Periode { get; set; }

        [JsonProperty(PropertyName = "UploadDate")]
        public DateTimeOffset UploadDate { get; set; }
    }
}
