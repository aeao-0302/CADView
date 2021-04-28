using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CADView
{
    class CadLayer
    {
        public string layer { get; set; }   // CADASTER, LESO, POCHKATEG, REGPLAN, SHEMI, MORВRIAG, ZTZ, PODZEМNI
        public List<GeoPoint> pnt { get; set; }
       // public List<SymPoint> smb { get; set; }
       // public List<TxtPoint> txt { get; set; }
        public List<GeoLine> ln { get; set; }
       // public List<GeoContur> cn { get; set; }
       // public List<GeoMPoly> mp { get; set; }
    }
}
