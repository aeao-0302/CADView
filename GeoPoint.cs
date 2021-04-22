using System;


namespace CADView
{
    class GeoPoint          //  // Точките от геодезическата мрежа <Р t n х у h k mx my kh mh mst msg sgn cen ono b d>
    {

        public ushort t { get; set; }       // тип на точката по класификатора в приложение №1;
        public ulong n { get; set; }        // уникален номер на точката;
        public double x { get; set; }       // координати и надморска височина на точката;
        public double y { get; set; }       // координати и надморска височина на точката;
        public float h { get; set; }        // координати и надморска височина на точката;
        public ushort kp { get; set; }      // клас по положение на точката;
        public float mx { get; set; }       // точност по x;
        public float my { get; set; }       // точност по y;
        public ushort kh { get; set; }      // клас по височина на точката;
        public float mh { get; set; }       // точност по h;
        public ushort mst { get; set; }     // начин на стабилизиране (номенклатура за начин на стабилизиране)
        public ushort msg { get; set; }     // начин на сигнализиране (номенклатура за начин на сигнализиране)
        public ushort sgn { get; set; }     // номер на знак
        public ushort cen { get; set; }     // подземен център (0 – няма, 1 – има)
        public string ono { get; set; }     // стар номер, ограден в кавички, включително и картния лист
        public DateTime b { get; set; }     // дата на легалната поява на обекта във формат “dd.mm.gggg”;
        public DateTime d { get; set; }     // дата на преустановяване на легалното съществуване обекта във формат “dd.mm.gggg”;

    }
}
