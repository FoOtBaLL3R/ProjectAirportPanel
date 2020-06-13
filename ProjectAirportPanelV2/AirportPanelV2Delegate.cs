using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ProjectAirportPanelV2
{
    enum UserChoice
    {
        Information = 1,
        CreateRecords,
        EditRecords,
        EditSpecificProp,
        SearchRecords,
        DeleteRecords
    }
    enum SelectedAirportEditProp
    {
        FlightNumber = 1,
        DateArrival,
        DateDeparture,
        CityOfArrivval,
        CityOfDeparture,
        Airline,
        Terminal,
        PortofArrival,
        PortofDeparture,
        FlightStatus
    }
    class AirportPanelV2Delegate
    {
        string format = @"yyyy/MM/dd HH:mm:ss";       

        string delim = new string('-', 233);

        List<Airport> list = new List<Airport>();
        public void Records()
        {
            for (int b = 0; b <= 10; b++)
            {
                list.Add(new Airport(new DateTime(2020, 01, 13, 10, 00, 00), new DateTime(2020, 01, 14, 18, 30, 00), "32RE46", "Ternopil", "Manchester", "Skyline", "F2", "FA123", "CG321", 2));
                list.Add(new Airport(new DateTime(2020, 01, 12, 11, 05, 20), new DateTime(2020, 01, 13, 22, 50, 15), "45RE87", "Lviv", "London", "Sky", "A2", "PF321", "FK852", 4));
            }

        }
        public void Working()
        {
            Records();
            AirportPropEditor airportEdit = null;
            airportEdit += EditAirline;
            airportEdit += EditCityOfArrivval;
            airportEdit += EditCityOfDeparture;
            airportEdit += EditDateArrival;
            airportEdit += EditDateDeparture;
            airportEdit += EditFlightNumber;
            airportEdit += EditFlightStatus;
            airportEdit += EditPortofArrival;
            airportEdit += EditPortofDeparture;
            airportEdit += EditTerminal;

            while (true)
            {
                Console.Clear();                
                Console.WriteLine(new string('-', 50));
                UserChoice chooise = PromptWhatToDo();

                switch (chooise)
                {
                    case UserChoice.Information:
                        {
                            DumpAirportList(list);                            
                            break;
                        }
                    case UserChoice.CreateRecords:
                        {
                            Console.WriteLine("How many airplane you want add?");
                            int numAirplane = int.Parse(Console.ReadLine());
                            for (int c = 0; c < numAirplane; c++)
                            {
                                var airport = new Airport();
                                airportEdit(airport);
                                list.Add(airport);
                            }                            
                            break;
                        }

                    case UserChoice.EditRecords:
                        {
                            Airport aira = GetEditToEdit(list);
                            airportEdit(aira);
                            break;
                        }

                    case UserChoice.EditSpecificProp:
                        {
                            Airport ai = GetEditToEdit(list);
                            Console.WriteLine("Choose what to edit (enter number):");
                            int num = 1;
                            foreach (string availableChoiseName in Enum.GetNames(typeof(SelectedAirportEditProp)))
                            {
                                Console.WriteLine("{0} {1}", num++, availableChoiseName);
                            }

                            SelectedAirportEditProp toEdit = Enum.Parse<SelectedAirportEditProp>(Console.ReadLine());

                            switch (toEdit)
                            {
                                case SelectedAirportEditProp.Airline:
                                    {
                                        EditAirline(ai);
                                        break;
                                    }
                                case SelectedAirportEditProp.CityOfArrivval:
                                    {
                                        EditCityOfArrivval(ai);
                                        break;
                                    }
                                case SelectedAirportEditProp.CityOfDeparture:
                                    {
                                        EditCityOfDeparture(ai);
                                        break;
                                    }
                                case SelectedAirportEditProp.DateArrival:
                                    {
                                        EditDateArrival(ai);
                                        break;
                                    }
                                case SelectedAirportEditProp.DateDeparture:
                                    {
                                        EditDateDeparture(ai);
                                        break;
                                    }
                                case SelectedAirportEditProp.FlightNumber:
                                    {
                                        EditFlightNumber(ai);
                                        break;
                                    }
                                case SelectedAirportEditProp.FlightStatus:
                                    {
                                        EditFlightStatus(ai);
                                        break;
                                    }
                                case SelectedAirportEditProp.PortofArrival:
                                    {
                                        EditPortofArrival(ai);
                                        break;
                                    }
                                case SelectedAirportEditProp.PortofDeparture:
                                    {
                                        EditPortofDeparture(ai);
                                        break;
                                    }
                                case SelectedAirportEditProp.Terminal:
                                    {
                                        EditTerminal(ai);
                                        break;
                                    }
                            }

                            break;
                        }
                    case UserChoice.SearchRecords:
                        {
                            SearchRecord();
                            break;
                        }
                    case UserChoice.DeleteRecords:
                        {
                            DeleteRecord();
                            break;
                        }
                }
            }
        }

        private UserChoice PromptWhatToDo()
        {
            Console.WriteLine("Choose what to do (enter number):");
            int num = 1;
            foreach (string availableChoiseName in Enum.GetNames(typeof(UserChoice)))
            {
                Console.WriteLine("{0} {1}", num++, availableChoiseName);
            }

            UserChoice chooise = Enum.Parse<UserChoice>(Console.ReadLine());
            return chooise;
        }

        private Airport GetEditToEdit(List<Airport> list)
        {                        
            DumpAirportList(list);
            Console.Write("Enter index number of airport to edit:");
            int idx = int.Parse(Console.ReadLine()) - 1;
            Airport air = list[idx];
            return air;
        }

        private void DumpAirportList(List<Airport> list)
        {
            
            //int numIndx = 1;
            ConsoleColor current = Console.ForegroundColor;
            int page = 1;

            int countRecords = list.Count;
            int recordOnPage = 5;

            Page:
            double countsPages = Convert.ToDouble(countRecords) / recordOnPage;//к-сть сторінок
            double pagesCounts = Math.Ceiling(countsPages);//заокруглення

            int start = (page - 1) * recordOnPage;
            int end = page * recordOnPage;            
            
            string[] columns = {"Index".PadLeft(10),"Flight number".PadLeft(18), "Date and time of departure".PadLeft(31), "Date and time of arrival".PadLeft(31), "City of departure".PadLeft(20),
                "City of arrival".PadLeft(20),"Port of departure".PadLeft(20), "Port of arrival".PadLeft(20), "Airline".PadLeft(16), "Terminal".PadLeft(18), "Flight status".PadLeft(18) };

            Console.Clear();
            Console.WriteLine(string.Join("|", columns));

            //цикл для пагінації
            for (int info = start; info < end; info++)
            {
                if (info < list.Count)
                {
                    Console.WriteLine(delim);
                    Console.Write(string.Join('|', ++start).PadLeft(8));
                    Console.Write(string.Join('|', list[info].FlightNumber).PadLeft(20));
                    Console.Write(string.Join('|', list[info].DateDeparture).PadLeft(30));
                    Console.Write(string.Join('|', list[info].DateArrival).PadLeft(30));
                    Console.Write(string.Join('|', list[info].CityOfDeparture).PadLeft(20));
                    Console.Write(string.Join('|', list[info].CityOfArrival).PadLeft(20));
                    Console.Write(string.Join('|', list[info].PortOfDeparture).PadLeft(18));
                    Console.Write(string.Join('|', list[info].PortOfArrival).PadLeft(18));
                    Console.Write(string.Join('|', list[info].Airline).PadLeft(28));
                    Console.Write(string.Join('|', list[info].Terminal).PadLeft(12));
                    Console.Write(string.Join('|', list[info].Status).PadLeft(17));
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            //цикл виведення сторінок і на якій сторінці знаходимся
            for (var c = 1; c <= pagesCounts; c++)
            {
                if (page == c)
                {
                    Console.ForegroundColor = ConsoleColor.White;
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

        public void EditDateArrival(Airport airport)
        {
            Console.Write("Enter date of arrival airplane\n Date format - {0} ", format);
            string newArrivalDate = Console.ReadLine();
            DateTime newDateArrival = DateTime.ParseExact(newArrivalDate, format, CultureInfo.InvariantCulture, DateTimeStyles.None);
            airport.DateArrival = newDateArrival;
        }

        public void EditDateDeparture(Airport airport)
        {
            Console.Write("Enter date of departure airplane\n Date format - {0} ", format);
            string newDepartureDate = Console.ReadLine();
            DateTime newDateDeparture = DateTime.ParseExact(newDepartureDate, format, CultureInfo.InvariantCulture, DateTimeStyles.None);
            airport.DateDeparture = newDateDeparture;
        }      

        public void EditFlightNumber(Airport airport)
        {
            Console.Write("Enter flight number ");
            string newFlightNumber = Console.ReadLine();            
            airport.FlightNumber = newFlightNumber;
        }

        public void EditCityOfArrivval(Airport airport)
        {
            Console.Write("Enter city of arrivval ");
            string newCityOfArrivval = Console.ReadLine();
            airport.CityOfArrival = newCityOfArrivval;
        }

        public void EditCityOfDeparture(Airport airport)
        {
            Console.Write("Enter city of departure ");
            string newCityOfDeparture = Console.ReadLine();
            airport.CityOfDeparture = newCityOfDeparture;
        }

        public void EditAirline(Airport airport)
        {
            Console.Write("Enter airline ");
            string newAirline = Console.ReadLine();
            airport.Airline = newAirline;
        }
        
        public void EditTerminal(Airport airport)
        {
            Console.Write("Enter terminal ");
            string newTerminal = Console.ReadLine();
            airport.Terminal = newTerminal;
        }

        public void EditPortofArrival(Airport airport)
        {
            Console.Write("Enter terminal ");
            string newPortofArrival = Console.ReadLine();
            airport.PortOfArrival = newPortofArrival;
        }

        public void EditPortofDeparture(Airport airport)
        {
            Console.Write("Enter terminal ");
            string newPortofDeparture = Console.ReadLine();
            airport.PortOfDeparture = newPortofDeparture;
        }
        
        public void EditFlightStatus(Airport airport)
        {
            Console.Write("Enter flight status:\n1)check in\n2)gate closed\n3)arrived\n4)departed at\n5)unknown\n6)canceled"+
                "\n7)expected at\n8)delayed\n9)in flight");
            int newFlightStatus = Convert.ToInt32(Console.ReadLine());
            airport.Status = (Airport.FlightStatus)newFlightStatus;
        }

        public void SearchRecord()
        {
            int da = 0;
            List<int> indxSearch = new List<int>();
            string[] columnSearch = new string[list.Count];
            Console.Clear();
            Console.WriteLine("Enter number of column to search\n1)Search date of arrival airplane\n2)Search date of departure airplane\n3)Search flight number\n4)Search city of arrivval" +
                "\n5)Search city of departure\n6)Search airline\n7)Search terminal\n8)Search port of arrival\n9)Search port of departure\n10)Search flight status\n11)Nothing");
            int searchChoice = Convert.ToInt32(Console.ReadLine());
            switch (searchChoice)
            {
                case 1:
                    da = 1;
                    for (int d = 0; d < list.Count; d++)
                    {
                        columnSearch[d] = Convert.ToString(list[d].DateArrival);
                    }
                    Search();
                    break;
                case 2:
                    da = 1;
                    for (int d = 0; d < list.Count; d++)
                    {
                        columnSearch[d] = Convert.ToString(list[d].DateDeparture);
                    }
                    Search();
                    break;
                case 3:
                    for (int d = 0; d < list.Count; d++)
                    {
                        columnSearch[d] = list[d].FlightNumber;
                    }
                    Search();
                    break;
                case 4:
                    for (int d = 0; d < list.Count; d++)
                    {
                        columnSearch[d] = list[d].CityOfArrival;
                    }
                    Search();
                    break;
                case 5:
                    for (int d = 0; d < list.Count; d++)
                    {
                        columnSearch[d] = list[d].CityOfDeparture;
                    }
                    Search();
                    break;
                case 6:
                    for (int d = 0; d < list.Count; d++)
                    {
                        columnSearch[d] = list[d].Airline;
                    }
                    Search();
                    break;
                case 7:
                    for (int d = 0; d < list.Count; d++)
                    {
                        columnSearch[d] = list[d].Terminal;
                    }
                    Search();
                    break;
                case 8:
                    for (int d = 0; d < list.Count; d++)
                    {
                        columnSearch[d] = list[d].PortOfArrival;
                    }
                    Search();
                    break;
                case 9:
                    for (int d = 0; d < list.Count; d++)
                    {
                        columnSearch[d] = list[d].PortOfDeparture;
                    }
                    Search();
                    break;
                case 10:
                    for (int d = 0; d < list.Count; d++)
                    {
                        columnSearch[d] = Convert.ToString(list[d].Status);
                    }
                    Search();
                    break;
                    //case 11:
                    //    View();
                    //    break;

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
                for (var f = 0; f < list.Count; f++)
                {
                    if (indxSearch.Contains(f))
                    {
                        Scoop(f);
                        
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
            
        }

        private void Scoop(int i)
        {
            Console.WriteLine(delim);
            Console.Write(string.Join('|', i).PadLeft(8));
            Console.Write(string.Join('|', list[i].FlightNumber).PadLeft(20));
            Console.Write(string.Join('|', list[i].DateArrival).PadLeft(30));
            Console.Write(string.Join('|', list[i].CityOfDeparture).PadLeft(20));
            Console.Write(string.Join('|', list[i].CityOfArrival).PadLeft(20));
            Console.Write(string.Join('|', list[i].DateDeparture).PadLeft(30));
            Console.Write(string.Join('|', list[i].PortOfDeparture).PadLeft(18));
            Console.Write(string.Join('|', list[i].PortOfArrival).PadLeft(18));
            Console.Write(string.Join('|', list[i].Airline).PadLeft(28));
            Console.Write(string.Join('|', list[i].Terminal).PadLeft(12));
            Console.Write(string.Join('|', list[i].Status).PadLeft(17));
            Console.WriteLine();
        }

        public void DeleteRecord()
        {
            DumpAirportList(list);
            Console.WriteLine("Enter number index");
            int indxDelete = int.Parse(Console.ReadLine());
            list.RemoveAt(indxDelete);
            DumpAirportList(list);
        }

    }

    public delegate void AirportPropEditor(Airport airport);
}
