
using Newtonsoft.Json;
using System;

namespace Manufactures.Application.DailyOperations.Spu.DataTransferObjects
{
    public class WeavingDailyOperationSpuMachineDto 
    {

        [JsonProperty(PropertyName = "Month")]
        public string Month { get; set; }

        [JsonProperty(PropertyName = "YearPeriode")]
        public string YearPeriode { get; set; }

        [JsonProperty(PropertyName = "CreatedDate")]
        public string CreatedDate { get; set; }



        public int Date { get; set; }

        public string Week { get; set; }
        public string MachineSizing { get; set; }
        public string Shift { get; set; }
        public string Group { get; set; }
        public string Lot { get; set; }
        public string SP { get; set; }
        public string YearProduction { get; set; }
        public string SPYear { get; set; }
        public string WarpType { get; set; }
        public string AL { get; set; }
        public string Construction { get; set; }
        public string Code { get; set; }
        public string ThreadOrigin { get; set; }
        public string Recipe { get; set; }
        public string Water { get; set; }
        public string BeamNo { get; set; }
        public string BeamWidth { get; set; }
        public string TekSQ { get; set; }
        public string ThreadCount { get; set; }
        public string Ne { get; set; }
        public string TempSD1 { get; set; }
        public string TempSD2 { get; set; }
        public string VisCoseSD1 { get; set; }
        public string VisCoseSD2 { get; set; }
        public string F1 { get; set; }
        public string F2 { get; set; }
        public string FDS { get; set; }
        public string FW { get; set; }
        public string FP { get; set; }
        public string A12 { get; set; }
        public string A34 { get; set; }
        public string B12 { get; set; }
        public string B34 { get; set; }
        public string C1234 { get; set; }
        public string Pis { get; set; }
        public string AddedLength { get; set; }
        public string Length { get; set; }
        public string EmptyBeamWeight { get; set; }
        public string Bruto { get; set; }
        public string Netto { get; set; }
        public string Teoritis { get; set; }
        public string SPU { get; set; }
        public string WarpingLenght { get; set; }
        public string FinalCounter { get; set; }
        public string Draft { get; set; }
        public string Speed { get; set; }
        public string Information { get; set; }
        public string SpeedMin { get; set; }
        public string Capacity { get; set; }
        public string Efficiency { get; set; }
        //tambahan ku
        public DateTime Periode { get; set; }




    }
}
