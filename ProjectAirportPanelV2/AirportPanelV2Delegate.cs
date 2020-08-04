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
    enum SelectedAirportProp
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

        delegate Predicate<Airport> SearchPredicate();

        static Dictionary<SelectedAirportProp, SearchPredicate> DelegatesCache = new Dictionary<SelectedAirportProp, SearchPredicate>
        {
            [SelectedAirportProp.FlightStatus] = CreateSearchByStatusPredicate,
            [SelectedAirportProp.FlightNumber] = CreateSearchByFlightNumberPredicate,
            [SelectedAirportProp.CityOfArrivval] = CreateSearchByCityOfArrivvalPredicate,
            [SelectedAirportProp.CityOfDeparture] = CreateSearchByCityOfDeparturePredicate,
            [SelectedAirportProp.PortofArrival] = CreateSearchByPortofArrivalPredicate,
            [SelectedAirportProp.PortofDeparture] = CreateSearchByPortofDeparturePredicate,
            [SelectedAirportProp.Terminal] = CreateSearchByTerminalPredicate,
            [SelectedAirportProp.Airline] = CreateSearchByAirlinePredicate,
            [SelectedAirportProp.DateArrival] = CreateSearchByDateArrivalPredicate,
            [SelectedAirportProp.DateDeparture] = CreateSearchByDateDeparturePredicate,
            // 2020-07-09T22:18:43Z
            //[SelectedAirportProp.DateArrival] = (a, dateStr) => a.DateArrival.Date == DateTime.Parse(dateStr, "Pattern").Date
        };

        private static Predicate<Airport> CreateSearchByStatusPredicate()
        {
            Console.WriteLine("Enter desired status to find all flights");
            string userInput = Console.ReadLine();

            return a => a.Status.ToString().Contains(userInput);
            //var closure = new IsMatchStatusPredicateClosure(userInput);
            //return closure.IsMatch;
        }

        private static Predicate<Airport> CreateSearchByFlightNumberPredicate()
        {
            Console.WriteLine("Enter desired flight number to find all flights");
            string userInput = Console.ReadLine();
            return a => a.FlightNumber.ToString().Contains(userInput);
        }

        private static Predicate<Airport> CreateSearchByCityOfArrivvalPredicate()
        {
            Console.WriteLine("Enter desired city Of arrival to find all flights");
            string userInput = Console.ReadLine();
            return a => a.CityOfArrival.ToString().Contains(userInput);
        }

        private static Predicate<Airport> CreateSearchByCityOfDeparturePredicate()
        {
            Console.WriteLine("Enter desired city Of departure to find all flights");
            string userInput = Console.ReadLine();
            return a => a.CityOfDeparture.ToString().Contains(userInput);
        }

        private static Predicate<Airport> CreateSearchByPortofArrivalPredicate()
        {
            Console.WriteLine("Enter desired port Of arrival to find all flights");
            string userInput = Console.ReadLine();
            return a => a.PortOfArrival.ToString().Contains(userInput);
        }

        private static Predicate<Airport> CreateSearchByPortofDeparturePredicate()
        {
            Console.WriteLine("Enter desired port Of departure to find all flights");
            string userInput = Console.ReadLine();
            return a => a.PortOfDeparture.ToString().Contains(userInput);
        }

        private static Predicate<Airport> CreateSearchByTerminalPredicate()
        {
            Console.WriteLine("Enter desired Terminal to find all flights");
            string userInput = Console.ReadLine();
            return a => a.Terminal.ToString().Contains(userInput);
        }

        private static Predicate<Airport> CreateSearchByAirlinePredicate()
        {
            Console.WriteLine("Enter desired airline to find all flights");
            string userInput = Console.ReadLine();
            return a => a.Airline.ToString().Contains(userInput);
        }

        private static Predicate<Airport> CreateSearchByDateArrivalPredicate()
        {
            Console.WriteLine("Enter desired date arrival to find all flights\nExample:  dd.mm.year hh:mm:ss");
            string userInput = Console.ReadLine();
            return a => a.DateArrival.ToString().Contains(userInput);
        }

        private static Predicate<Airport> CreateSearchByDateDeparturePredicate()
        {
            Console.WriteLine("Enter desired date departure to find all flights\nExample:  dd.mm.year hh:mm:ss");
            string userInput = Console.ReadLine();
            return a => a.DateDeparture.ToString().Contains(userInput);
        }
        //private class IsMatchStatusPredicateClosure
        //{
        //    private string _searchStatus;
        //    public IsMatchStatusPredicateClosure(string searchStatus)
        //    {
        //        _searchStatus = searchStatus;
        //    }

        //    public bool IsMatch(Airport a)
        //    {
        //        return a.Status.ToString() == _searchStatus;
        //    }
        //}


        //delegate bool SearchPredicate(Airport a, string arg);

        //static Dictionary<SelectedAirportProp, SearchPredicate> DelegatesCache;
        //static List<Airport> Airports;
        //static void Main()
        //{
        //    DelegatesCache = new Dictionary<PropName, SearchPredicate>
        //    {
        //        [PropName.Status] = (a, status) => a.Status.ToString() == status,
        //        // 2020-07-09T22:18:43Z
        //        [PropNames.DateArrival] = (a, dateStr) => a.DateArrival.Date == DateTime.Parse(dateStr, "Pattern").Date
        //    };


        //    Console.WriteLine("Enter desired status to find all flights");

        //    string userInput = Console.ReadLine(); // Arrived
        //    SearchPredicate p = DelegatesCache[PropName.Status];
        //    List<Airport> searchResult = Airports.FindAll(a => p(a, userInput));
        //}

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
                            foreach (string availableChoiseName in Enum.GetNames(typeof(SelectedAirportProp)))
                            {
                                Console.WriteLine("{0} {1}", num++, availableChoiseName);
                            }

                            SelectedAirportProp toEdit = Enum.Parse<SelectedAirportProp>(Console.ReadLine());

                            switch (toEdit)
                            {
                                case SelectedAirportProp.Airline:
                                    {
                                        EditAirline(ai);
                                        break;
                                    }
                                case SelectedAirportProp.CityOfArrivval:
                                    {
                                        EditCityOfArrivval(ai);
                                        break;
                                    }
                                case SelectedAirportProp.CityOfDeparture:
                                    {
                                        EditCityOfDeparture(ai);
                                        break;
                                    }
                                case SelectedAirportProp.DateArrival:
                                    {
                                        EditDateArrival(ai);
                                        break;
                                    }
                                case SelectedAirportProp.DateDeparture:
                                    {
                                        EditDateDeparture(ai);
                                        break;
                                    }
                                case SelectedAirportProp.FlightNumber:
                                    {
                                        EditFlightNumber(ai);
                                        break;
                                    }
                                case SelectedAirportProp.FlightStatus:
                                    {
                                        EditFlightStatus(ai);
                                        break;
                                    }
                                case SelectedAirportProp.PortofArrival:
                                    {
                                        EditPortofArrival(ai);
                                        break;
                                    }
                                case SelectedAirportProp.PortofDeparture:
                                    {
                                        EditPortofDeparture(ai);
                                        break;
                                    }
                                case SelectedAirportProp.Terminal:
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
            int sheet = 1;

            int countRecords = list.Count;
            int recordOnPage = 5;
            Page(sheet);
            void Page(int page)
            {
                double countsPages = Convert.ToDouble(countRecords) / recordOnPage;//к-сть сторінок
                double pagesCounts = Math.Ceiling(countsPages);//заокруглення

                int start = (page - 1) * recordOnPage;
                int end = page * recordOnPage;

                string[] columns = {"Index".PadLeft(10),"Flight number".PadLeft(18), "Date and time of departure".PadLeft(31), "City of departure".PadLeft(20),
                    "City of arrival".PadLeft(20), "Date and time of arrival".PadLeft(31), "Port of departure".PadLeft(20), "Port of arrival".PadLeft(20), "Airline".PadLeft(16), "Terminal".PadLeft(18), "Flight status".PadLeft(18) };

                Console.Clear();
                Console.WriteLine(string.Join("|", columns));

                //цикл для пагінації
                for (int info = start; info < end; info++)
                {
                    if (info < list.Count)
                    {
                        Scoop(info);
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
                ReEnter(pagesCounts);
            }

            void ReEnter(double countsPage)
            {                
                int pag = int.Parse(Console.ReadLine());
                if (pag > 0 && pag <= countsPage)
                {
                    Page(pag);
                }
                else if (pag > countsPage)
                {
                    Console.WriteLine("Eror....Please re-Enter number");
                    ReEnter(countsPage);
                }
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
            Console.Write("Enter flight status:\n1)check in\n2)gate closed\n3)arrived\n4)departed at\n5)unknown\n6)canceled" +
                "\n7)expected at\n8)delayed\n9)in flight");
            int newFlightStatus = Convert.ToInt32(Console.ReadLine());
            airport.Status = (Airport.FlightStatus)newFlightStatus;
        }

        public void SearchRecord()
        {

            //DelegatesCache = new Dictionary<SelectedAirportProp, SearchPredicate>
            //{
            //    [SelectedAirportProp.FlightStatus] = (a, status) => a.Status.ToString() == status

            //    // 2020-07-09T22:18:43Z
            //    //[SelectedAirportProp.DateArrival] = (a, dateStr) => a.DateArrival.Date == DateTime.Parse(dateStr, "Pattern").Date
            //};


            //Console.WriteLine("Enter desired status to find all flights");

            //string userInput = Console.ReadLine(); // Arrived
            //SearchPredicate p = DelegatesCache[SelectedAirportProp.FlightStatus];
            //List<Airport> searchResult = Airports.FindAll(a => p(a, userInput));
            //List<Airport> searchResult1 = Airports.Contains(b => p(b, userInput));

            Console.Clear();
            while (true)
            {
                Console.WriteLine("Enter number of column to search\n1)Search flight number\n2)Search date of arrival airplane\n3)Search date of departure airplane\n4)Search city of arrivval" +
                    "\n5)Search city of departure\n6)Search airline\n7)Search terminal\n8)Search port of arrival\n9)Search port of departure\n10)Search flight status\n11)Nothing");

                string rawInput = Console.ReadLine();
                if (!Enum.TryParse<SelectedAirportProp>(rawInput, out var selectedProp))
                {
                    Console.WriteLine("Invalid value: " + rawInput + "\nTry again.\n");
                    continue;
                }

                var searchDelegate = DelegatesCache[selectedProp];
                var predicate = searchDelegate();
                //var results = new List<Airport>();
                //foreach (var item in list)
                //{
                //    if (predicate(item))
                //    {
                //        results.Add(item);
                //    }
                //}
                var results = list.FindAll(predicate);
                //var results = list.Contains(predicate);
                DumpAirportList(results);
                // dump all results to console
                break;
                DumpAirportList(results);
            }
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
