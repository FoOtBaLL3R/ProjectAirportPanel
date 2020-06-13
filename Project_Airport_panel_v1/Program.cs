using System;
using System.Globalization;

namespace Project_Airport_panel_v1
{
    class Program
    {
        struct AirportPanel
        {
            public DateTime dateArrival;

            public DateTime dateDeparture;

            public string flight_number;
            public string cityOfArrival;
            public string cityOfDeparture;
            public string portOfArrival;
            public string portOfDeparture;
            public string airline;
            public string terminal;
            public Flight_Status flight_status;
        }
        enum Flight_Status
        {
            check_in,
            gate_closed,
            arrived,
            departed_at,
            unknown,
            canceled,
            expected_at,
            delayed,
            in_flight,
            empty = 100
        }
        static void Main(string[] args)
        {
            //var format = @"yyyy/MM/dd HH:mm:ss";
            //string rawDate = "2020/01/20 18:40:40";// Console.ReadLine();
            //DateTime parsed = DateTime.ParseExact(rawDate, format, CultureInfo.InvariantCulture, DateTimeStyles.None);


            Console.WindowWidth = Console.LargestWindowWidth;
            Console.WindowHeight = Console.LargestWindowHeight;
            Console.BufferHeight = Console.LargestWindowHeight;
            Console.BufferWidth = Console.LargestWindowWidth;
            AirportPanel[] airportPanel = new AirportPanel[50];
            int indx = 0;

            //airportPanel[0].date_time_departure = "12:30 13/01/2020";
            //airportPanel[0].date_time_arrival = "18:30 14/01/2020";
            airportPanel[0].dateArrival = new DateTime(2020, 01, 13, 10, 00, 00);
            airportPanel[0].dateDeparture = new DateTime(2020, 01, 14, 18, 30, 00);
            airportPanel[0].flight_number = "C240E";
            airportPanel[0].cityOfArrival = "London";
            airportPanel[0].cityOfDeparture = "Ternopil";
            airportPanel[0].portOfArrival = "16";
            airportPanel[0].portOfDeparture = "32";
            airportPanel[0].airline = "Sky Up Airlines";
            airportPanel[0].terminal = "F";
            airportPanel[0].flight_status = (Flight_Status)4;
            indx++;

            var delim = new string('-', 186);
            string[] columns = {"Index".PadLeft(10),"Date and time of departure".PadLeft(31), "Flight number".PadLeft(18), "City of arrival".PadLeft(20),
                "Port of arrival".PadLeft(20), "Airline".PadLeft(16), "Terminal".PadLeft(18), "Arrival date and time".PadLeft(26),
                "Flight status".PadLeft(18) };
            begin:
            Console.WriteLine();
            Console.WriteLine("Please,  type the number\n1)Information about airplanes\n2)Add airplane\n3)Edit airplane\n4)Delete airplane");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1://виведення інформації по літаках
                    Console.Clear();
                    Console.WriteLine(string.Join("|", columns));
                    for (int a = 0; a < indx; a++)
                    {
                        //string[] data1 = new string[30];
                        //data1[a] = { airportPanel[a].date_time_arrival,airportPanel[a].date_time_departure,airportPanel[a].flight_number,airportPanel[a].portOfArrival,
                        //airportPanel[a].portOfDeparture,airportPanel[a].terminal,airportPanel[a].flight_status,airportPanel[a].airline,airportPanel[a].cityOfArrival,
                        //airportPanel[a].cityOfDeparture};

                        //if (airportPanel[a].flight_number != null)
                        //{
                        Console.WriteLine(delim);
                        Console.Write(string.Join('|', a).PadLeft(8));
                        Console.Write(string.Join('|', airportPanel[a].dateDeparture).PadLeft(30));
                        Console.Write(string.Join('|', airportPanel[a].flight_number).PadLeft(20));
                        Console.Write(string.Join('|', airportPanel[a].cityOfArrival).PadLeft(20));
                        Console.Write(string.Join('|', airportPanel[a].portOfArrival).PadLeft(18));
                        Console.Write(string.Join('|', airportPanel[a].airline).PadLeft(28));
                        Console.Write(string.Join('|', airportPanel[a].terminal).PadLeft(12));
                        Console.Write(string.Join('|', airportPanel[a].dateArrival).PadLeft(30));
                        Console.Write(string.Join('|', airportPanel[a].flight_status).PadLeft(17));
                        Console.WriteLine();
                        //}

                    }
                    Console.WriteLine();
                    goto begin;

                case 2://додавання даних до аеропорта
                    Console.Clear();
                    Console.WriteLine("How many airplane you want add");
                    int numAirplane = int.Parse(Console.ReadLine());                 

                    for (int b = indx; b < numAirplane+1; b++)
                    {
                        Console.Clear();
                        Console.WriteLine("Enter flight number");
                        airportPanel[b].flight_number = Console.ReadLine();
                        //Console.WriteLine("Enter date and time arrival (yyyy,MM,dd,hh,mm,ss)");
                        Console.WriteLine("Enter day arrival");
                        var dayArrival = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter month arrival");
                        var monthArrival = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter year arrival");
                        var yearArrival = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter hour arrival");
                        var hourArrival = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter minute arrival");
                        var minuteArrival = Convert.ToInt32(Console.ReadLine());
                        airportPanel[b].dateArrival = new DateTime(yearArrival, monthArrival, dayArrival, hourArrival, minuteArrival, 00);
                        Console.WriteLine("Enter city of arrival");
                        airportPanel[b].cityOfArrival = Console.ReadLine();
                        Console.WriteLine("Enter port of arrival");
                        airportPanel[b].portOfArrival = Console.ReadLine();
                        Console.WriteLine("Enter of airline");
                        airportPanel[b].airline = Console.ReadLine();
                        Console.WriteLine("Enter terminal");
                        airportPanel[b].terminal = Console.ReadLine();
                        //Console.WriteLine("Enter date and time departure (yyyy,MM,dd,hh,mm,ss)");
                        Console.WriteLine("Enter day departure");
                        var dayDeparture = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter month departure");
                        var monthDeparture = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter year departure");
                        var yearDeparture = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter hour departure");
                        var hourDeparture = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter minute departure");
                        var minuteDeparture = Convert.ToInt32(Console.ReadLine());
                        airportPanel[b].dateDeparture = new DateTime(yearDeparture, monthDeparture, dayDeparture, hourDeparture, minuteDeparture, 00);
                        Console.WriteLine("Enter city of departure");
                        airportPanel[b].cityOfDeparture = Console.ReadLine();
                        Console.WriteLine("Enter port of departure");
                        airportPanel[b].portOfDeparture = Console.ReadLine();
                        Console.WriteLine("Enter flight status:\n1)check_in\n2)gate_closed\n3)arrived\n4)departed_at\n5)unknown\n6)canceled" +
                            "\n7)expected_at\n8)delayed\n9)in_flight");
                        airportPanel[b].flight_status = (Flight_Status) int.Parse(Console.ReadLine())-1;                        
                        indx++;

                        
                    }
                    goto begin;

                case 3://редагування даних аеропорта
                    Console.Clear();
                    Console.WriteLine(string.Join("|", columns));
                    for (int e = 0; e < indx; e++)
                    {
                        Console.WriteLine(delim);
                        Console.Write(string.Join('|', e).PadLeft(8));
                        Console.Write(string.Join('|', airportPanel[e].dateDeparture).PadLeft(30));
                        Console.Write(string.Join('|', airportPanel[e].flight_number).PadLeft(20));
                        Console.Write(string.Join('|', airportPanel[e].cityOfArrival).PadLeft(20));
                        Console.Write(string.Join('|', airportPanel[e].portOfArrival).PadLeft(18));
                        Console.Write(string.Join('|', airportPanel[e].airline).PadLeft(28));
                        Console.Write(string.Join('|', airportPanel[e].terminal).PadLeft(12));
                        Console.Write(string.Join('|', airportPanel[e].dateArrival).PadLeft(30));
                        Console.Write(string.Join('|', airportPanel[e].flight_status).PadLeft(17));

                    }
                    Console.WriteLine();
                    Console.WriteLine("Specify the aircraft index you want to edit");
                    int editChoice = int.Parse(Console.ReadLine());
                    Console.Clear();
                    Console.WriteLine("Enter flight number");
                    airportPanel[editChoice].flight_number = Console.ReadLine();
                    //Console.WriteLine("Enter date and time arrival (yyyy,MM,dd,hh,mm,ss)");
                    Console.WriteLine("Enter day arrival");
                    var eddayArrival = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter month arrival");
                    var edmonthArrival = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter year arrival");
                    var edyearArrival = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter hour arrival");
                    var edhourArrival = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter minute arrival");
                    var edminuteArrival = Convert.ToInt32(Console.ReadLine());
                    //airportPanel[editChoice].dateArrival = new DateTime(edyearArrival, edmonthArrival, edyearArrival, edhourArrival, edminuteArrival, 00);
                    Console.WriteLine("Enter city of arrival");
                    airportPanel[editChoice].cityOfArrival = Console.ReadLine();
                    Console.WriteLine("Enter port of arrival");
                    airportPanel[editChoice].portOfArrival = Console.ReadLine();
                    Console.WriteLine("Enter of airline");
                    airportPanel[editChoice].airline = Console.ReadLine();
                    Console.WriteLine("Enter terminal");
                    airportPanel[editChoice].terminal = Console.ReadLine();
                    //Console.WriteLine("Enter date and time departure (yyyy,MM,dd,hh,mm,ss)");
                    Console.WriteLine("Enter day departure");
                    var eddayDeparture = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter month departure");
                    var edmonthDeparture = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter year departure");
                    var edyearDeparture = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter hour departure");
                    var edhourDeparture = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter minute departure");
                    var edminuteDeparture = Convert.ToInt32(Console.ReadLine());
                   // airportPanel[editChoice].dateDeparture = new DateTime(edyearDeparture, edmonthDeparture, eddayDeparture, edhourDeparture, edminuteDeparture, 00);
                    Console.WriteLine("Enter city of departure");
                    airportPanel[editChoice].cityOfDeparture = Console.ReadLine();
                    Console.WriteLine("Enter port of departure");
                    airportPanel[editChoice].portOfDeparture = Console.ReadLine();
                    Console.WriteLine("Enter flight status:\n1)check_in\n2)gate_closed\n3)arrived\n4)departed_at\n5)unknown\n6)canceled" +
                        "\n7)expected_at\n8)delayed\n9)in_flight");
                    airportPanel[editChoice].flight_status = (Flight_Status)int.Parse(Console.ReadLine()) - 1;
                    goto begin;

                case 4://видалення даних по індексу
                    Console.Clear();
                    Console.WriteLine(string.Join("|", columns));
                    for (int f = 0; f < indx; f++)
                    {
                        Console.WriteLine(delim);
                        Console.Write(string.Join('|', f).PadLeft(8));
                        Console.Write(string.Join('|', airportPanel[f].dateDeparture).PadLeft(30));
                        Console.Write(string.Join('|', airportPanel[f].flight_number).PadLeft(20));
                        Console.Write(string.Join('|', airportPanel[f].cityOfArrival).PadLeft(20));
                        Console.Write(string.Join('|', airportPanel[f].portOfArrival).PadLeft(18));
                        Console.Write(string.Join('|', airportPanel[f].airline).PadLeft(28));
                        Console.Write(string.Join('|', airportPanel[f].terminal).PadLeft(12));
                        Console.Write(string.Join('|', airportPanel[f].dateArrival).PadLeft(30));
                        Console.Write(string.Join('|', airportPanel[f].flight_status).PadLeft(17));

                    }
                    Console.WriteLine();
                    Console.WriteLine("Specify the aircraft index you want to delete");
                    int indxChoice = int.Parse(Console.ReadLine());
                    Array.Clear(airportPanel, indxChoice, 1);
                    airportPanel[indxChoice].dateArrival = new DateTime();
                    airportPanel[indxChoice].dateDeparture = new DateTime();
                    airportPanel[indxChoice].flight_status = (Flight_Status)100;
                    Console.Clear();
                    Console.WriteLine(string.Join("|", columns));
                    for (int f = 0; f < indx; f++)
                    {
                        Console.WriteLine(delim);
                        Console.Write(string.Join('|', f).PadLeft(8));
                        Console.Write(string.Join('|', airportPanel[f].dateDeparture).PadLeft(30));
                        Console.Write(string.Join('|', airportPanel[f].flight_number).PadLeft(20));
                        Console.Write(string.Join('|', airportPanel[f].cityOfArrival).PadLeft(20));
                        Console.Write(string.Join('|', airportPanel[f].portOfArrival).PadLeft(18));
                        Console.Write(string.Join('|', airportPanel[f].airline).PadLeft(28));
                        Console.Write(string.Join('|', airportPanel[f].terminal).PadLeft(12));
                        Console.Write(string.Join('|', airportPanel[f].dateArrival).PadLeft(30));
                        Console.Write(string.Join('|', airportPanel[f].flight_status).PadLeft(17));

                    }
                    Console.WriteLine();
                    goto begin;
            }


            Console.ReadKey();
        }
    }
}
