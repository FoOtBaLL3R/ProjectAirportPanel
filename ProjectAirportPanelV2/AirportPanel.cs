using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
//using static ProjectAirportPanelV2.Airport;

namespace ProjectAirportPanelV2
{
    class AirportPanel
    {
        string format = @"yyyy/MM/dd HH:mm:ss";
        DateTime dateArrival, dateDeparture;
        string flightNumber, cityOfArrivval, cityOfDeparture, airline, terminal, portofArrival, portofDeparture;
        int flightStatus;
        string delim = new string('-', 233);

        List<Airport> airoport = new List<Airport>();
        
        public void Records()
        {

            for (int b = 0; b <= 10; b++)
            {
                airoport.Add(new Airport(new DateTime(2020, 01, 13, 10, 00, 00), new DateTime(2020, 01, 14, 18, 30, 00), "32RE46", "Ternopil", "Manchester", "Skyline", "F2", "FA123", "CG321", 2));
                airoport.Add(new Airport(new DateTime(2020, 01, 12, 11, 05, 20), new DateTime(2020, 01, 13, 22, 50, 15), "45RE87", "Lviv", "London", "Sky", "A2", "PF321", "FK852", 4));
            }

        }

        

        public void Information()
        {
            Info();

            View();
        }

        public void Scoop(int i)
        {
            Console.WriteLine(delim);
            Console.Write(string.Join('|', i).PadLeft(8));
            Console.Write(string.Join('|', airoport[i].FlightNumber).PadLeft(20));
            Console.Write(string.Join('|', airoport[i].DateDeparture).PadLeft(30));
            Console.Write(string.Join('|', airoport[i].DateArrival).PadLeft(30));
            Console.Write(string.Join('|', airoport[i].CityOfDeparture).PadLeft(20));
            Console.Write(string.Join('|', airoport[i].CityOfArrival).PadLeft(20));
            Console.Write(string.Join('|', airoport[i].PortOfDeparture).PadLeft(18));
            Console.Write(string.Join('|', airoport[i].PortOfArrival).PadLeft(18));
            Console.Write(string.Join('|', airoport[i].Airline).PadLeft(28));
            Console.Write(string.Join('|', airoport[i].Terminal).PadLeft(12));
            Console.Write(string.Join('|', airoport[i].Status).PadLeft(17));
            Console.WriteLine();
        }


        public void Info()
        {
            ConsoleColor current = Console.ForegroundColor;
            int page = 1;

            int countRecords = airoport.Count;
            int recordOnPage = 5;

            Page:
            double countsPages = Convert.ToDouble(countRecords) / recordOnPage;//к-сть сторінок
            double pagesCounts = Math.Ceiling(countsPages);//заокруглення
            
            int start = (page - 1) * recordOnPage;
            int end = page * recordOnPage;
            

            //var delim = new string('-', 233);
            string[] columns = {"Index".PadLeft(10),"Flight number".PadLeft(18), "Date and time of departure".PadLeft(31), "Date and time of arrival".PadLeft(31), "City of departure".PadLeft(20),
                "City of arrival".PadLeft(20),"Port of departure".PadLeft(20), "Port of arrival".PadLeft(20), "Airline".PadLeft(16), "Terminal".PadLeft(18), "Flight status".PadLeft(18) };

            Console.Clear();
            Console.WriteLine(string.Join("|", columns));

            //цикл для пагінації
            for (int info = start; info < end; info++)
            {
                if (info < airoport.Count)
                {
                    Scoop(info);
                    //Console.WriteLine(delim);
                    //Console.Write(string.Join('|', info).PadLeft(8));
                    //Console.Write(string.Join('|', airoport[info].FlightNumber).PadLeft(20));
                    //Console.Write(string.Join('|', airoport[info].DateDeparture).PadLeft(30));
                    //Console.Write(string.Join('|', airoport[info].DateArrival).PadLeft(30));
                    //Console.Write(string.Join('|', airoport[info].CityOfDeparture).PadLeft(20));
                    //Console.Write(string.Join('|', airoport[info].CityOfArrival).PadLeft(20));
                    //Console.Write(string.Join('|', airoport[info].PortOfDeparture).PadLeft(18));
                    //Console.Write(string.Join('|', airoport[info].PortOfArrival).PadLeft(18));
                    //Console.Write(string.Join('|', airoport[info].Airline).PadLeft(28));
                    //Console.Write(string.Join('|', airoport[info].Terminal).PadLeft(12));
                    //Console.Write(string.Join('|', airoport[info].Status).PadLeft(17));
                    //Console.WriteLine();
                }
            }
            Console.WriteLine();
            //цикл виведення сторінок і на якій сторінці знаходимся
            for (var c = 1; c <= pagesCounts; c++)
            {
                if (page == c)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }

                Console.Write(c + " ");
                Console.ForegroundColor = current;
            }
            Console.WriteLine();
            Console.WriteLine("Enter number of page... or 0 to quit");
            ReEnter:
            page = int.Parse(Console.ReadLine());
            if (page > 0 && page <= pagesCounts)
            {
                goto Page;
            }
            else if (page > pagesCounts)
            {
                Console.WriteLine("Eror....Please re-Enter number");
                goto ReEnter;
            }


                for (int a = 0; a <= 3; a++)
            {
                Console.WriteLine();
            }
        }
        public void AddRecord()
        {            
            Console.WriteLine("How many airplane you want add");
            int numAirplane = int.Parse(Console.ReadLine());
            for (int c = 0; c < numAirplane; c++)
            {
                Add();
                airoport.Add(new Airport(dateArrival, dateDeparture, flightNumber, cityOfArrivval, cityOfDeparture, airline, terminal, portofArrival, portofDeparture, flightStatus));

            }
            for (int a = 0; a <= 3; a++)
            {
                Console.WriteLine();
            }

            View();
        }

        public void Add()
        {
            Console.WriteLine("Enter date of arrival airplane\n Date format - {0} ", format);
            string arrivalDate = Console.ReadLine();
            dateArrival = DateTime.ParseExact(arrivalDate, format, CultureInfo.InvariantCulture, DateTimeStyles.None);
            Console.WriteLine("Enter date of departure airplane\n Date format - {0} ", format);
            string departureDate = Console.ReadLine();
            dateDeparture = DateTime.ParseExact(departureDate, format, CultureInfo.InvariantCulture, DateTimeStyles.None);
            Console.WriteLine("Enter flight number ");
            flightNumber = Console.ReadLine();
            Console.WriteLine("Enter city of arrivval ");
            cityOfArrivval = Console.ReadLine();
            Console.WriteLine("Enter city of departure ");
            cityOfDeparture = Console.ReadLine();
            Console.WriteLine("Enter airline ");
            airline = Console.ReadLine();
            Console.WriteLine("Enter terminal ");
            terminal = Console.ReadLine();
            Console.WriteLine("Enter port of arrival ");
            portofArrival = Console.ReadLine();
            Console.WriteLine("Enter port of departure");
            portofDeparture = Console.ReadLine();
            Console.WriteLine("Enter flight status:\n1)check in\n2)gate closed\n3)arrived\n4)departed at\n5)unknown\n6)canceled" +
                        "\n7)expected at\n8)delayed\n9)in flight");
            flightStatus = Convert.ToInt32(Console.ReadLine());
        }
        delegate void AirportEditor(Airport p);
        public void EditRecord()
        {
            Info();
            //DateTime dateArrival, dateDeparture;
            //string flightNumber, cityOfArrivval, cityOfDeparture, airline, terminal, portofArrival, portofDeparture;
            //int flightStatus;
            Console.WriteLine("Enter number index");
            int indx = int.Parse(Console.ReadLine());
            dateArrival = airoport[indx].DateArrival;
            dateDeparture = airoport[indx].DateDeparture;
            flightNumber = airoport[indx].FlightNumber;
            cityOfArrivval = airoport[indx].CityOfArrival;
            cityOfDeparture = airoport[indx].CityOfDeparture;
            airline = airoport[indx].Airline;
            terminal = airoport[indx].Terminal;
            portofArrival = airoport[indx].PortOfArrival;
            portofDeparture = airoport[indx].PortOfDeparture;
            flightStatus = (int)airoport[indx].Status;

            //var delim = new string('-', 233);
            string[] columns = {"Index".PadLeft(10),"Flight number".PadLeft(18), "Date and time of departure".PadLeft(31), "Date and time of arrival".PadLeft(31), "City of departure".PadLeft(20),
                "City of arrival".PadLeft(20),"Port of departure".PadLeft(20), "Port of arrival".PadLeft(20), "Airline".PadLeft(16), "Terminal".PadLeft(18), "Flight status".PadLeft(18) };
        Repeat:
            Console.Clear();
            Console.WriteLine(string.Join("|", columns));
            for (var info = indx; info <= indx; info++)
            {
                Scoop(info);
                //Console.WriteLine(delim);
                //Console.Write(string.Join('|', info).PadLeft(8));
                //Console.Write(string.Join('|', airoport[info].FlightNumber).PadLeft(20));
                //Console.Write(string.Join('|', airoport[info].DateDeparture).PadLeft(30));
                //Console.Write(string.Join('|', airoport[info].DateArrival).PadLeft(30));
                //Console.Write(string.Join('|', airoport[info].CityOfDeparture).PadLeft(20));
                //Console.Write(string.Join('|', airoport[info].CityOfArrival).PadLeft(20));
                //Console.Write(string.Join('|', airoport[info].PortOfDeparture).PadLeft(18));
                //Console.Write(string.Join('|', airoport[info].PortOfArrival).PadLeft(18));
                //Console.Write(string.Join('|', airoport[info].Airline).PadLeft(28));
                //Console.Write(string.Join('|', airoport[info].Terminal).PadLeft(12));
                //Console.Write(string.Join('|', airoport[info].Status).PadLeft(17));
                //Console.WriteLine();
            }
            for (int a = 0; a <= 3; a++)
            {
                Console.WriteLine();
            }


            Console.WriteLine("Enter number to edit column\n1)Edit date of arrival airplane\n2)Edit date of departure airplane\n3)Edit flight number\n4)Edit city of arrivval" +
                "\n5)Edit city of departure\n6)Edit airline\n7)Edit terminal\n8)Edit port of arrival\n9)Edit port of departure\n10)Edit flight status\n11)Edit all columns\n12)Nothing");
            int editChoice = Convert.ToInt32(Console.ReadLine());
            //var editChoiceChar = editChoice.ToCharArray();
            switch (editChoice)
            {
                case 1:
                    //AirportEditor airportEditor = new AirportEditor(EditDateArrival);
                    //dateArrival = Convert.ToDateTime(airportEditor);
                    Console.WriteLine("Enter date of arrival airplane\n Date format - {0} ", format);
                    string arrivalDate = Console.ReadLine();
                    dateArrival = DateTime.ParseExact(arrivalDate, format, CultureInfo.InvariantCulture, DateTimeStyles.None);
                    EditAirport();
                    goto Repeat;
                case 2:
                    Console.WriteLine("Enter date of departure airplane\n Date format - {0} ", format);
                    string departureDate = Console.ReadLine();
                    dateDeparture = DateTime.ParseExact(departureDate, format, CultureInfo.InvariantCulture, DateTimeStyles.None);
                    EditAirport();
                    goto Repeat;
                case 3:
                    Console.WriteLine("Enter flight number ");
                    flightNumber = Console.ReadLine();
                    EditAirport();
                    goto Repeat;
                case 4:
                    Console.WriteLine("Enter city of arrivval ");
                    cityOfArrivval = Console.ReadLine();
                    EditAirport();
                    goto Repeat;
                case 5:
                    Console.WriteLine("Enter city of departure ");
                    cityOfDeparture = Console.ReadLine();
                    EditAirport();
                    goto Repeat;
                case 6:
                    Console.WriteLine("Enter airline ");
                    airline = Console.ReadLine();
                    EditAirport();
                    goto Repeat;
                case 7:
                    Console.WriteLine("Enter terminal ");
                    terminal = Console.ReadLine();
                    EditAirport();
                    goto Repeat;
                case 8:
                    Console.WriteLine("Enter port of arrival ");
                    portofArrival = Console.ReadLine();
                    EditAirport();
                    goto Repeat;
                case 9:
                    Console.WriteLine("Enter port of departure");
                    portofDeparture = Console.ReadLine();
                    EditAirport();
                    goto Repeat;
                case 10:
                    Console.WriteLine("Enter flight status:\n1)check in\n2)gate closed\n3)arrived\n4)departed at\n5)unknown\n6)canceled" +
                               "\n7)expected at\n8)delayed\n9)in flight");
                    flightStatus = Convert.ToInt32(Console.ReadLine());
                    EditAirport();
                    goto Repeat;
                case 11:
                    Add();
                    EditAirport();
                    View();
                    break;
                case 12:
                    View();
                    break;
            }
            void EditAirport()
            {
                
                airoport[indx] = new Airport
                (
                    dateArrival,
                    dateDeparture,
                    flightNumber,
                    cityOfArrivval,
                    cityOfDeparture,
                    airline,
                    terminal,
                    portofArrival,
                    portofDeparture,
                    flightStatus
                );
                
            }

        }

        public void EditDateArrival(Airport p) //метод для делегата який я не зміг використати
        {
            var format = @"yyyy/MM/dd HH:mm:ss";
            Console.WriteLine("Enter date of arrival airplane\n Date format - {0} ", format);
            string arrivalDate = Console.ReadLine();
            DateTime dateArrivalEdit = DateTime.ParseExact(arrivalDate, format, CultureInfo.InvariantCulture, DateTimeStyles.None);
            //p.Name = newName;
            p.DateArrival = dateArrivalEdit;
        }

        public void SearchRecord()
        {
            int da = 0;
            List<int> indxSearch = new List<int>();
            string[] columnSearch = new string[airoport.Count];
            Console.Clear();
            Console.WriteLine("Enter number of column to search\n1)Search date of arrival airplane\n2)Search date of departure airplane\n3)Search flight number\n4)Search city of arrivval" +
                "\n5)Search city of departure\n6)Search airline\n7)Search terminal\n8)Search port of arrival\n9)Search port of departure\n10)Search flight status\n11)Nothing");
            int searchChoice = Convert.ToInt32(Console.ReadLine());
            switch (searchChoice)
            {
                case 1:
                    da = 1;
                    for (int d = 0; d < airoport.Count; d++)
                    {
                        columnSearch[d] = Convert.ToString(airoport[d].DateArrival);
                    }
                    Search();
                    break;
                case 2:
                    da = 1;
                    for (int d = 0; d < airoport.Count; d++)
                    {
                        columnSearch[d] = Convert.ToString(airoport[d].DateDeparture);
                    }
                    Search();
                    break;
                case 3:
                    for (int d = 0; d < airoport.Count; d++)
                    {
                        columnSearch[d] = airoport[d].FlightNumber;
                    }
                    Search();
                    break;
                case 4:
                    for (int d = 0; d < airoport.Count; d++)
                    {
                        columnSearch[d] = airoport[d].CityOfArrival;
                    }
                    Search();
                    break;
                case 5:
                    for (int d = 0; d < airoport.Count; d++)
                    {
                        columnSearch[d] = airoport[d].CityOfDeparture;
                    }
                    Search();
                    break;
                case 6:
                    for (int d = 0; d < airoport.Count; d++)
                    {
                        columnSearch[d] = airoport[d].Airline;
                    }
                    Search();
                    break;
                case 7:
                    for (int d = 0; d < airoport.Count; d++)
                    {
                        columnSearch[d] = airoport[d].Terminal;
                    }
                    Search();
                    break;
                case 8:
                    for (int d = 0; d < airoport.Count; d++)
                    {
                        columnSearch[d] = airoport[d].PortOfArrival;
                    }
                    Search();
                    break;
                case 9:
                    for (int d = 0; d < airoport.Count; d++)
                    {
                        columnSearch[d] = airoport[d].PortOfDeparture;
                    }
                    Search();
                    break;
                case 10:
                    for (int d = 0; d < airoport.Count; d++)
                    {
                        columnSearch[d] = Convert.ToString(airoport[d].Status);
                    }
                    Search();
                    break;
                case 11:
                    View();
                    break;

            }
            void Search()
            {
                if (da == 1)
                {
                    Console.WriteLine("Date format: dd.MM.yyyy HH:mm:ss");
                }


                Console.WriteLine("Enter a value to search");
                string valueSearch = Console.ReadLine();
                for (int e = 0; e < columnSearch.Length; e++)
                {
                    if (columnSearch[e].Contains(valueSearch))
                    {
                        indxSearch.Add(e);
                    }
                }
            }

            void Result()
            {
                //var delim = new string('-', 233);
                string[] columns = {"Index".PadLeft(10),"Flight number".PadLeft(18), "Date and time of departure".PadLeft(31), "Date and time of arrival".PadLeft(31), "City of departure".PadLeft(20),
                "City of arrival".PadLeft(20),"Port of departure".PadLeft(20), "Port of arrival".PadLeft(20), "Airline".PadLeft(16), "Terminal".PadLeft(18), "Flight status".PadLeft(18) };
                Console.Clear();
                Console.WriteLine(string.Join("|", columns));
                for (var f = 0; f < airoport.Count; f++)
                {
                    if (indxSearch.Contains(f))
                    {
                        Scoop(f);
                        //Console.WriteLine(delim);
                        //Console.Write(string.Join('|', f).PadLeft(8));
                        //Console.Write(string.Join('|', airoport[f].FlightNumber).PadLeft(20));
                        //Console.Write(string.Join('|', airoport[f].DateDeparture).PadLeft(30));
                        //Console.Write(string.Join('|', airoport[f].DateArrival).PadLeft(30));
                        //Console.Write(string.Join('|', airoport[f].CityOfDeparture).PadLeft(20));
                        //Console.Write(string.Join('|', airoport[f].CityOfArrival).PadLeft(20));
                        //Console.Write(string.Join('|', airoport[f].PortOfDeparture).PadLeft(18));
                        //Console.Write(string.Join('|', airoport[f].PortOfArrival).PadLeft(18));
                        //Console.Write(string.Join('|', airoport[f].Airline).PadLeft(28));
                        //Console.Write(string.Join('|', airoport[f].Terminal).PadLeft(12));
                        //Console.Write(string.Join('|', airoport[f].Status).PadLeft(17));
                        //Console.WriteLine();
                    }

                }
                for (int a = 0; a <= 3; a++)
                {
                    Console.WriteLine();
                }
                Console.Write("press any key ");
                Console.ReadKey();

            }
            Result();
            View();
        }
        public void DeleteRecord()
        {
            Info();
            Console.WriteLine("Enter number index");
            int indxDelete = int.Parse(Console.ReadLine());
            airoport.RemoveAt(indxDelete);
            View();
        }
        enum UserChoice
        {
            Information = 1,
            AddRecords,
            EditRecords,
            SearchRecords,
            DeleteRecords
        }
        public void View()
        {
            Console.Clear();
            Console.WriteLine("v2.0\nPlease, type the number\n1)Information about airplanes\n2)Add airplane\n3)Edit airplane\n4)Search airplane\n5)Delete airplane");
            Console.WriteLine();
            UserChoice userChoice = (UserChoice)int.Parse(Console.ReadLine());
            Console.WriteLine(userChoice);
            switch (userChoice)
            {
                case UserChoice.Information:
                    Information();
                    break;
                case UserChoice.AddRecords:
                    AddRecord();
                    break;
                case UserChoice.EditRecords:
                    EditRecord();
                    break;
                case UserChoice.SearchRecords:
                    SearchRecord();
                    break;
                case UserChoice.DeleteRecords:
                    DeleteRecord();
                    break;

            }
        }
    }
}
