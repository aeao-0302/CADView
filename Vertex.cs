using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CADView
{
    class Vertex                // Точките на линията  <n1 x1 y1 t1 o1 m1; n2 х2 у2 t2 o2 m2;... ;>
    {
        public ulong n { get; set; }        // уникален номер на точката;
        public double x { get; set; }       // координати на точката;
        public double y { get; set; }       // координати на точката;
        public ushort t { get; set; }       // код за точност на точката (приложение №2);
        public ushort o { get; set; }       // код на трайно означаване (приложение №2);
        public ushort m { get; set; }       // код за метод на определяне (приложение №2);
    }
}
