using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CADView
{
    class GeoLine        // Информацията за линиите се представя във формат <L t n k b d {h}>
    {
        public ushort t { get; set; }       // тип на линията по класификатора в т. 1.2 от приложение № 1;
        public ulong n { get; set; }        // уникален номер на линията;
        public ushort k { get; set; }       // тип на линията като граница : (със стойности от 0 до 4)
        public float h { get; set; }        // надморска височина на линията, когато се описват линии с еднаква височина или измерена дължина на линията, когато се описва репераж
        public DateTime b { get; set; }     // дата на легалната поява на обекта във формат “dd.mm.gggg”;
        public DateTime d { get; set; }     // дата на преустановяване на легалното съществуване обекта във формат “dd.mm.gggg”;
        public List<Vertex> l { get; set; } // списък на точките от линията
    }
}
