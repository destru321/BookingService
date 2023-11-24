namespace BookingService
{
    public interface IBookingService
    {
        public void BookFlight(int id);
        public List<Flight> GetFlights();
    }

    public interface IFlightRespository
    {
        public List<Flight> GetFlights();
    }

    public class Flight
    {
        public int Id { get; }
        public string? Airline { get; }
        public string? From { get; }
        public string? To { get; }
        public DateTime DepartureTime { get; }
        public DateTime LandingTime { get; }

        public Flight(int _Id, string _Airline, string _From, string _To, DateTime _DepartureTime, DateTime _LandingTime)
        {
            Id = _Id;
            Airline = _Airline;
            From = _From;
            To = _To;
            DepartureTime = _DepartureTime;
            LandingTime = _LandingTime;
        }
    }

    public class FlightRespository : IFlightRespository
    {
        private static List<Flight> AvailableFlights = new List<Flight>
        {
            new Flight(1, "Ryanair", "Warsaw", "Lisbon", DateTime.Parse("2023-11-24T08:00:00"), DateTime.Parse("2023-11-24T12:00:00")),
            new Flight(2, "Lufthansa", "Berlin", "Paris", DateTime.Parse("2023-11-25T10:30:00"), DateTime.Parse("2023-11-25T14:30:00")),
            new Flight(3, "British Airways", "London", "New York", DateTime.Parse("2023-11-26T12:45:00"), DateTime.Parse("2023-11-26T20:00:00")),
            new Flight(4, "Emirates", "Dubai", "Tokyo", DateTime.Parse("2023-11-27T15:00:00"), DateTime.Parse("2023-11-27T23:30:00")),
            new Flight(5, "Delta Airlines", "New York", "Los Angeles", DateTime.Parse("2023-11-28T08:15:00"), DateTime.Parse("2023-11-28T11:30:00")),
            new Flight(6, "Air France", "Paris", "Rome", DateTime.Parse("2023-11-29T11:45:00"), DateTime.Parse("2023-11-29T15:15:00")),
            new Flight(7, "Qatar Airways", "Doha", "Sydney", DateTime.Parse("2023-11-30T14:20:00"), DateTime.Parse("2023-11-30T22:45:00")),
            new Flight(8, "Singapore Airlines", "Singapore", "Hong Kong", DateTime.Parse("2023-12-01T17:30:00"), DateTime.Parse("2023-12-01T19:45:00")),
            new Flight(9, "KLM Royal Dutch Airlines", "Amsterdam", "Barcelona", DateTime.Parse("2023-12-02T09:00:00"), DateTime.Parse("2023-12-02T11:15:00")),
            new Flight(10, "Turkish Airlines", "Istanbul", "Cairo", DateTime.Parse("2023-12-03T13:45:00"), DateTime.Parse("2023-12-03T16:00:00"))
        };

        public List<Flight> GetFlights()
        {
            return AvailableFlights;
        }

    };

    public class BookingService : IBookingService
    {
        private readonly IFlightRespository FlightRepo;

        public BookingService(IFlightRespository _FlightRepo)
        {
            FlightRepo = _FlightRepo;
        }

        public void BookFlight(int id)
        {
            Console.WriteLine(" ");
            Console.WriteLine("You have just reserved flight with ID " + id);
        }

        public List<Flight> GetFlights()
        {
            return FlightRepo.GetFlights();
        }
    }

    public class Program
    {
        static void Main()
        {
            IFlightRespository flightRespository = new FlightRespository();

            IBookingService bookingService = new BookingService(flightRespository);

            Console.WriteLine("Available flights: ");
            var AvailableFlights = bookingService.GetFlights();
            foreach(Flight flight in AvailableFlights)
            {
                Console.WriteLine($"ID: {flight.Id}, Departure city: {flight.From}, Landing city: {flight.To}, Airline: {flight.Airline}, Departure time: {flight.DepartureTime}, Landing time: {flight.LandingTime}");
            }

            Console.WriteLine(" ");
            Console.Write("Which flight would you like to book? (Type ID): ");
            bookingService.BookFlight(int.Parse(Console.ReadLine()));
        }
    }
}