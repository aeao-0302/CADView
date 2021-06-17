//
using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace CADView
{
    using Map = Xamarin.Forms.Maps.Map;
    public class MapPage : ContentPage
    {
        Map customMap;
        
        public MapPage()
        {

            customMap = new Xamarin.Forms.Maps.Map
            {
                MapType = MapType.Street
                //map.MapType = GoogleMap.MapTypeTerrain;   //.MapTypeHybrid;
            };

            Button btn = new Button
            {
                Text = "Add file",
                HorizontalOptions = LayoutOptions.Start,    //.CenterAndExpand,
                VerticalOptions = LayoutOptions.End         //.CenterAndExpand
            };

            btn.Clicked += Button_Clicked;

            Content = new StackLayout
            {
                Children =
                {
                    customMap, btn
                }
            };

            customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(42.754219, 25.240299), Distance.FromKilometers(107.0)));
        }

        //
        private async void Button_Clicked(object sender, EventArgs e)
        {
            var status = await Permissions.RequestAsync<Permissions.StorageRead>();
            if (status == PermissionStatus.Denied) return;

            var file = await FilePicker.PickAsync();
            if (file == null) return;

            string[] PTypeStr = {"Астрономическа точка","Триангулачна точка на терена",
            "Триангулачна точка на църква","Триангулачна точка на комин","Триангулачна точка на гръмоотвод",
            "Триангулачна точка на минаре","Триангулачна точка с кота, определена с геометрична нивелация",
            "Триангулачна точка на могила","Точка от прецизна полигонометрия",
            "Полигонова точка, стабилизирана с дървен кол","Полигонова точка, стабилизирана с бетонно блокче",
            "Полигонова точка, стабилизирана с желязна тръба","Полигонова точка, стабилизирана на скала",
            "Точка от прецизна тригонометрия","Осова точка","Гравиметрична точка","Засечка с теодолит",
            "Точка от строителна мрежа","Възлова точка","Трайно стабилизирана полигонова точка",
            "Операционна точка","Нетрайно стабилизирана полигонова точка","Теренна точка",
            "Точка от графическа засечка","Нивелачен репер I,II,III и IV клас","Нивелачен репер I,II,III и IV клас на сграда",
            "Височинна опорна точка","Подробна точка","Осова точка от регулационен план",
            "Определяща точка, означена с регламентиран знак","Изходна точка за определяне на морската граница"};

            try
            {
                List<CadLayer> cadL = new List<CadLayer>();                 // List of Layers

                CADReader cd = new CADReader();
                cd.ReadCAD(file.FullPath, ref cadL);

                //Pin pinPnt;
                //Polyline pline;
                //  customMap.CustomPins = new List<Pin> { pinPnt };
                for (ushort j = 0; j < cadL.Count; j++)
                {
                    //for (int i = 0; i < cadL[j].pnt.Count; i++)               // Marker points
                    //{
                    //    pinPnt = new Pin
                    //    {
                    //        Label = PTypeStr[cadL[j].pnt[i].t - 1],
                    //        //Address = "???",
                    //        Type = PinType.SearchResult,
                    //        Position = new Position(cadL[j].pnt[i].x, cadL[j].pnt[i].y)
                    //    };
                    //    customMap.Pins.Add(pinPnt);
                    //}
                    //if (cadL[j].pnt.Count > 0)
                    //    customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(cadL[j].pnt[0].x, cadL[j].pnt[0].y), Distance.FromMeters(1000.0)));

                    //customMap.CustomPLines = new List<Polyline> ();
                    for (int i = 0; i < cadL[j].ln.Count; i++)                  // List of lines
                    {
                        Polyline pline = new Polyline();
                        pline.Geopath.Clear();
                        pline.StrokeColor = Color.Blue;
                        pline.StrokeWidth = 4;

                        for (int k = 0; k < cadL[j].ln[i].l.Count; k++)         // List of vertex
                        {
                            //pline.Positions.Add(new Position(cadL[j].ln[i].l[k].x, cadL[j].ln[i].l[k].y));
                            pline.Geopath.Add(new Position(cadL[j].ln[i].l[k].x, cadL[j].ln[i].l[k].y));
                        }
                        customMap.MapElements.Add(pline);
                        //customMap.CustomPLines.Add(pline);                        
                    }
                    if (cadL[j].ln.Count > 0)
                        customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(cadL[j].ln[0].l[0].x, cadL[j].ln[0].l[0].y), Distance.FromMeters(1000.0)));
                }

                //await DisplayAlert("CID" ,  CID.ToArray().Length.ToString, "OK");
                //await DisplayAlert("CPoint", CPoint.Count.ToString, "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alert - CAD File", ex.Message, "OK");
            }

        }

    }
}


/*
 When drawing a list of polylines, only the first line is displayed on the map, the rest are colorless, maxLines = 2130903480 is a large number, it is less than 1000 lines. The coordinates are correct. The same result is obtained with Xamarin.GooglePlayServices.Maps 
 */