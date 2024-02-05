using System;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading.Tasks;

namespace KBBWebView
{
    public partial class Form1 : Form
    {
        public List<TradeVehicle> ymms = new List<TradeVehicle>();
        public List<TradeVehicle> ymmswithbodys = new List<TradeVehicle>();
        public Form1()
        {
            //string args = Environment.CommandLine;
            //var vehicle = new TradeVehicle
            //{
            //    Year = "2018",
            //    Make = "GMC",
            //    Model = "Yukon",
            //};
            //var jsonargs = args.Split(new string[] { ".exe\" " }, StringSplitOptions.None)[1];
            //string[] vehicle = args.Split(new[] { ' ' }, 2);
            //var options = new JsonSerializerOptions { WriteIndented = true };
            //string jsonString = JsonSerializer.Serialize(newargs, options);
            // Console.WriteLine(jsonString);
            //TradeVehicle vehicleobject = JsonSerializer.Deserialize<TradeVehicle>(jsonargs);
            //
            //string year = args[1];
            //string make = args[2];
            //string model = args[3];
            //string kbburl = "https://www.kbb.com/"+ vehicleobject.Make + "/"+ vehicleobject.Model + "/"+ vehicleobject.Year + "/styles/?intent=trade-in-sell&mileage=";
            string kbburl = "https://www.kbb.com/whats-my-car-worth/";
            Uri kbburi = new Uri(kbburl);
            InitializeComponent();
            label1.Text = kbburl;
            webView.Source = kbburi;
            //webView.ExecuteScriptAsync("");

        }
        public class TradeVehicle
        {
            public string Year { get; set; }
            public string Make { get; set; }
            public string Model { get; set; }
            public string Bodystyle { get; set; }
            public string Miles { get; set; }
        }

        private async void getYrsBtn_Click(object sender, EventArgs e)
        {
            //string x = await webView.ExecuteScriptAsync("document.getElementsByClassName('css-1dp2hne e1c5k7mc0')[0].childNodes[3].value;");
            //string x = await webView.ExecuteScriptAsync("document.getElementsByClassName('css-1dp2hne e1c5k7mc0')[2].childNodes");
            string htmlslice = await webView.ExecuteScriptAsync("document.getElementsByClassName('css-1dp2hne e1c5k7mc0')[0].innerHTML");
            htmlslice = Regex.Unescape(htmlslice); 
            string lastyear = "";
            string lastmake = "";
            //document.getElementById('my_drop_down')
            //x.Wait();
            var htmlslicearray = htmlslice.Split('>');
            foreach (var portion in htmlslicearray)
            {
                if (!portion.StartsWith("<option"))
                {
                    TradeVehicle vehicle = new TradeVehicle();
                    string year = await webView.ExecuteScriptAsync("document.getElementsByClassName('css-1gvxv3k e1c5k7mc0')[0].options[document.getElementsByClassName('css-1gvxv3k e1c5k7mc0')[0].selectedIndex].text");
                    //year = year.Replace("\"", "");
                    string make = await webView.ExecuteScriptAsync("document.getElementsByClassName('css-1gvxv3k e1c5k7mc0')[1].options[document.getElementsByClassName('css-1gvxv3k e1c5k7mc0')[1].selectedIndex].text");
                    //make = make.Replace("\"", "");
                    var newportion = portion.Split('<');
                    if (newportion[0] != "\"" && newportion[0] != "Model")
                    {
                        string model = "\"" + newportion[0] + "\"";
                        //Console.WriteLine(year+","+make+","+ model);
                        vehicle.Year = year;
                        lastyear = year;
                        vehicle.Make = make;
                        lastmake = make;
                        vehicle.Model = model;
                        ymms.Add(vehicle);
                    }                    
                }
            }

            Console.WriteLine("Vehicles added " + lastyear + " " + lastmake);
            //Console.WriteLine(x);
            //Console.WriteLine();
        }

        private void exportBtn_Click(object sender, EventArgs e)
        {
            foreach (var vehicle in ymms)
            {
                Console.WriteLine(vehicle.Year + "," + vehicle.Make + "," + vehicle.Model);
            }
        }

        private void loadBtn_Click(object sender, EventArgs e)
        {
            string filename = @"ymm-2022.txt";
            using (var reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    TradeVehicle vehicle = new TradeVehicle();
                    vehicle.Year = values[0];
                    vehicle.Make = values[1];
                    vehicle.Model = values[2];
                    ymms.Add(vehicle);
                }
            }

            Console.WriteLine("Vehicles loaded from saved file: " + filename);
        }
        

        private void webViewSourceChanged(object sender, CoreWebView2SourceChangedEventArgs e)
        {
            label1.Text = webView.Source.ToString();
        }

        private async void loadVehicleBtn_Click(object sender, EventArgs e)
        {

            if (ymms.Count > 0)
            {


                //TradeVehicle vehicleobject = ymms[2];
                //var year = vehicleobject.Year.Replace("\"", "");
                //var make = vehicleobject.Make.Replace("\"", "");
                //var model = vehicleobject.Model.Replace("\"", "");
                //string kbburl = "https://www.kbb.com/" + make + "/" + model + "/" + year + "/styles/?intent=trade-in-sell&mileage=";
                //Console.WriteLine(kbburl);
                //Uri kbburi = new Uri(kbburl);
                //webView.Source = kbburi;
                //
                //await webView.ExecuteScriptAsync("window.location(" + kbburi + ")");
                ////webView.NavigationCompleted += WebView_NavigationCompleted;
                //bool nextstep = await gotothenextstep();
                //
                ////Console.WriteLine("v1: " + v);
                ////await Task.Delay(10000);


                var yymcounter = 0;



                foreach (var ymm in ymms)
                {

                    //if (yymcounter < 1)
                    {
                        TradeVehicle vehicleobject = ymm;
                        var year = vehicleobject.Year.Replace("\"", "");
                        var make = vehicleobject.Make.Replace("\"", "").Replace(" ", "-");
                        var model = vehicleobject.Model.Replace("\"", "").Replace(" ", "-");
                        //debug
                        //string kbburl = "https://www.kbb.com/Chevrolet/Camaro/2023/styles/?intent=trade-in-sell&mileage=";
                        string kbburl = "https://www.kbb.com/" + make + "/" + model + "/" + year + "/styles/?intent=trade-in-sell&mileage=";
                        Console.WriteLine(yymcounter+": "+kbburl);
                        Uri kbburi = new Uri(kbburl);
                        webView.Source = kbburi;

                        await webView.ExecuteScriptAsync("window.location(" + kbburi + ")");
                        //webView.NavigationCompleted += WebView_NavigationCompleted;
                        bool nextstep = await gotothenextstep(ymm);

                        //Console.WriteLine("v1: " + v);
                        //await Task.Delay(10000);

                        yymcounter++;
                    }
                }

                Console.WriteLine("done");

            }
            else
            {
                Console.WriteLine("Load Vehicle List");
            }
        }

        private async Task<bool> gotothenextstep(TradeVehicle ymm)
        {
            await Task.Delay(5000);


            var currenturl = webView.Source.ToString();
            if (currenturl.Contains("styles"))
            {

            //var v = await webView.ExecuteScriptAsync("if(document.readyState === 'complete'{ document.readyState; }");
            //Console.WriteLine("v2: " + v);
            string htmlslice = await webView.ExecuteScriptAsync("document.getElementsByClassName('e1qqueke1')[1].innerHTML");
            htmlslice = Regex.Unescape(htmlslice);
            Console.WriteLine(htmlslice);
            Console.WriteLine();


                if (htmlslice.Contains("Which Category Is Your Vehicle?"))
                {
                    Console.WriteLine();
                    string[] htmlsliceseperator = { "css-16dwid6 e9vui821\">" };
                    var htmlportion = htmlslice.Split(htmlsliceseperator, System.StringSplitOptions.RemoveEmptyEntries);
                    var newportioncounter = 0;
                    foreach (var htmlportionb in htmlportion)
                    {
                        var category = htmlportionb.Split('<');
                        if (category[0] != "\"")
                        {
                            await webView.ExecuteScriptAsync("document.getElementsByClassName('e9vui824')["+ newportioncounter + "].click()");
                            await Task.Delay(3000);
                            var htmlportionccountvar = await webView.ExecuteScriptAsync("document.getElementsByClassName('e9xj1y74').length");
                            Console.WriteLine("htmlportionccountvar: " + htmlportionccountvar);
                            int htmlportionccount = int.Parse(htmlportionccountvar);
                            for (int i = 0; i < htmlportionccount; i++)
                            {
                                //Console.WriteLine("here");
                                var htmlportionc = await webView.ExecuteScriptAsync("document.getElementsByClassName('e9xj1y74')[" + i + "].innerHTML");

                                htmlportionc = Regex.Unescape(htmlportionc);
                                //Console.WriteLine(i + " htmlportionc: " + htmlportionc);

                                string[] htmlportioncseperator = { "\">" };
                                //var htmlportion = htmlslice.Split(htmlsliceseperator, System.StringSplitOptions.RemoveEmptyEntries);

                                var bodystylepart = htmlportionc.Split(htmlportioncseperator, System.StringSplitOptions.RemoveEmptyEntries);

                                //Console.WriteLine(i + " bodystylepart: " + bodystylepart[1]);

                                string[] bodystylepartseperator = { "</ div >" };
                                var bodystylearray = bodystylepart[1].Split('<');
                                var bodystyle = "\"" + bodystylearray[0] + "\"";
                                Console.WriteLine("bodystyle: " + bodystyle);

                                TradeVehicle newTrades = new TradeVehicle();
                                newTrades.Year = ymm.Year;
                                newTrades.Make = ymm.Make;
                                newTrades.Model = ymm.Model;
                                newTrades.Bodystyle = bodystyle;
                                ymmswithbodys.Add(newTrades);


                            }

                            //var htmlportionc = await webView.ExecuteScriptAsync("document.getElementsByClassName('e9xj1y74')[0].childNodes[0].innerHTML");
                            //
                            //TradeVehicle newTrades = new TradeVehicle();
                            //newTrades.Year = ymm.Year;
                            //newTrades.Make = ymm.Make;
                            //newTrades.Model = ymm.Model;
                            //newTrades.Bodystyle = htmlportionc;
                            //ymmswithbodys.Add(newTrades);
                            //
                            //Console.WriteLine(htmlportionc);

                            newportioncounter++;
                        }
                    }
                }
                if (htmlslice.Contains("Which Style Is Your Vehicle?"))
                {

                    string[] htmlslicestringseperator = { "custom-label css-to6oan e9xj1y74" };

                    var htmlportion = htmlslice.Split(htmlslicestringseperator, System.StringSplitOptions.RemoveEmptyEntries);
                    var newportioncounter = 0;
                    foreach (var newportion in htmlportion)
                    {
                        Console.WriteLine(newportioncounter + ": newportioncounter: " + newportion);


                        string[] newportionstringseperator = { "\">" };
                        var nextportion = newportion.Split(newportionstringseperator, System.StringSplitOptions.RemoveEmptyEntries);
                        var nextportioncounter = 0;
                        foreach (var item in nextportion)
                        {
                            if (nextportioncounter == 1 && newportioncounter != 0)
                            {

                                string[] bodyseperator = { "</" };
                                var bodyportion = item.Split(bodyseperator, System.StringSplitOptions.RemoveEmptyEntries);
                                Console.WriteLine(bodyportion[0]);
                                TradeVehicle newTrades = new TradeVehicle();
                                newTrades.Year = ymm.Year;
                                newTrades.Make = ymm.Make;
                                newTrades.Model = ymm.Model;
                                newTrades.Bodystyle = "\"" + bodyportion[0] + "\"";
                                ymmswithbodys.Add(newTrades);

                            }
                            nextportioncounter++;
                        }


                        newportioncounter++;

                    }
                }



            }
            else
            {
                var urlparts = currenturl.Split('/');

                TradeVehicle newTrades = new TradeVehicle();
                newTrades.Year = ymm.Year;
                newTrades.Make = ymm.Make;
                newTrades.Model = ymm.Model;
                newTrades.Bodystyle = "\"" + urlparts[6] + "\"";
                Console.WriteLine(urlparts[6]);
                ymmswithbodys.Add(newTrades);

            }
            return true;
        }

        private async void WebView_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {


        }

        private void exportBodysBtn_Click(object sender, EventArgs e)
        {

            foreach (var vehicle in ymmswithbodys)
            {
                Console.WriteLine(vehicle.Year + "," + vehicle.Make + "," + vehicle.Model + "," + vehicle.Bodystyle);
            }
        }
    }
}
