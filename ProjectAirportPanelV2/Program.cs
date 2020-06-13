using System;
using System.Collections.Generic;

namespace ProjectAirportPanelV2
{
    class Program
    {
        static void PanelInterface()
        {
            Console.WindowWidth = Console.LargestWindowWidth;
            Console.WindowHeight = Console.LargestWindowHeight;
        }
        static void Main(string[] args)
        {
            PanelInterface();

            //var AiroClass = new AirportPanel();            
            //AiroClass.Records();
            //AiroClass.View();

            var airClass = new AirportPanelV2Delegate();
            airClass.Working();

            Console.ReadKey();
        }
    }
}
