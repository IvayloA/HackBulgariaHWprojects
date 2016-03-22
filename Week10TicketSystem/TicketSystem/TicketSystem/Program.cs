using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TicketSystem
{
    class Program
    {

        static void PrintHelp()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("List of commands:");
            Console.WriteLine("add city - adds a city into the database");
            Console.WriteLine("add train - adds a train into the database");
            Console.WriteLine("add trip - adds a trip");
            Console.WriteLine("add discount card - adds a discount card into the database");
            Console.WriteLine("edit train <trainID> - edits train information");
            Console.WriteLine("edit trip <tripID> - edits trip information");
            Console.WriteLine("delete city <cityName> - deletes a city and trips containing it");
            Console.WriteLine("delete train <trainID> - deletes a train and it's trips and/or tickets");
            Console.WriteLine("delete trip <tripID> - deletes a trip");
            Console.WriteLine("register user - adds a user into the database");
            Console.WriteLine("buy ticket <tripID> - buys ticket for a trip.");
            Console.WriteLine("list cities - lists cities with Id and name");
            Console.WriteLine("list trains - lists trains with Id and description");
            Console.WriteLine("list trips - lists trips with Id, start city, end city");
            Console.WriteLine("exit - exits the program");
            Console.WriteLine();
        }

        private static void CreateCity()
        {
            using (var db = new TicketSystemDBEntities())
            {

                var allCities = from city in db.Cities
                                select city.CityName;

                Console.Write("CityName: ");
                string cityName = Console.ReadLine().Trim();

                foreach (var item in allCities)
                {
                    if (item == cityName)
                    {
                        Console.WriteLine("City already exists!");
                        return;
                    }
                }

                try
                {
                    City city = new City() { CityName = cityName };

                    db.Cities.Add(city);
                    db.SaveChanges();
                }
                catch (OptimisticConcurrencyException e)
                {
                    Console.WriteLine("Failed to add a city into the database!");
                    Console.WriteLine(e.Message);
                    return;
                }
                Console.WriteLine("City was added into the databese");
            }
        }

        private static void CreateTrain()
        {
            using (var db = new TicketSystemDBEntities())
            {
                Console.Write("Enter a description: ");
                string description = Console.ReadLine().Trim();
                Console.Write("Enter a number of seats: ");
                string numberOfSeatsHolder = Console.ReadLine().Trim();

                int numberOfSeats;

                try
                {
                    numberOfSeats = int.Parse(numberOfSeatsHolder);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid number! Please enter a valid number next time.");
                    return;
                }

                try
                {
                    Train train = new Train() {
                        Description = description,
                        SeatNumber = numberOfSeats
                    };

                    db.Trains.Add(train);
                    db.SaveChanges();
                }
                catch (OptimisticConcurrencyException e)
                {
                    Console.WriteLine("Couldn't add the train into the database!");
                    Console.WriteLine(e.Message);
                    return;
                }
                Console.WriteLine("The train was added into the datbase");
            }
        }

        private static void CreateTrip()
        {
            using (var db = new TicketSystemDBEntities())
            {

                Console.WriteLine("List of cities:");
                HashSet<string> cityNames = new HashSet<string>();
                foreach (var city in db.Cities)
                {
                    cityNames.Add(city.CityName);
                    Console.WriteLine(city.CityName);
                }

                Console.Write("Start City(Name): ");
                string startCityName = Console.ReadLine().Trim();
                Console.Write("End City(Name): ");
                string endCityName = Console.ReadLine().Trim();

                int startCityId, endCityId;

                if (!cityNames.Contains(startCityName) || !cityNames.Contains(endCityName))
                {
                    Console.WriteLine("The provided cities don't exist!");
                    return;
                } else
                {
                    startCityId = (from city in db.Cities
                                   where startCityName == city.CityName
                                   select city.CityID).SingleOrDefault();

                    endCityId = (from city in db.Cities
                                 where endCityName == city.CityName
                                 select city.CityID).SingleOrDefault();


                }

                Console.Write("Travel date and time (yyyy-MM-dd HH:mm): ");
                var departerTimeArg = Console.ReadLine().Trim();

                DateTime departureTime;
                if (!DateTime.TryParseExact(departerTimeArg, "yyyy-MM-dd HH:mm", null, System.Globalization.DateTimeStyles.None, out departureTime))
                {
                    Console.WriteLine("Invalid date and time format!");
                    return;
                }

                Console.Write("Travel Time(hh:mm): ");
                var travelTimeArg = Console.ReadLine().Trim().Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

                if (travelTimeArg.Length != 2)
                {
                    Console.WriteLine("Invalid time format!");
                    return;
                }

                TimeSpan travelTime;
                try
                {
                    travelTime = new TimeSpan(int.Parse(travelTimeArg[0]), int.Parse(travelTimeArg[1]), 0);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid id format!");
                    return;
                }

                Console.WriteLine("List of trains: ");
                HashSet<int> trainIds = new HashSet<int>();
                foreach (var train in db.Trains)
                {
                    trainIds.Add(train.TrainID);
                    Console.WriteLine( "Train number: " + train.TrainID + "  train description: " + train.Description);
                }

                Console.Write("Train number: ");
                var trainArg = Console.ReadLine().Trim();

                int trainId;
                try
                {
                    trainId = int.Parse(trainArg);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid number format!");
                    return;
                }

                if (!trainIds.Contains(trainId))
                {
                    Console.WriteLine("Invalid number! Train with such number does not exist!");
                    return;
                }

                Console.Write("Ticket Price: ");
                var ticketPriceArg = Console.ReadLine().Trim();

                decimal ticketPrice;
                try
                {
                    ticketPrice = decimal.Parse(ticketPriceArg);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid price format!");
                    return;
                }

                try
                {
                    Schedule schedule = new Schedule
                    {
                        StartingCityID = startCityId,
                        EndCityID = endCityId,
                        TravelDate = departureTime,
                        TravelTime = travelTime,
                        TrainID = trainId,
                        TicketPrice = ticketPrice
                    };

                    db.Schedules.Add(schedule);

                    db.SaveChanges();

                    var numberOfSeatsInTrain = (from train in db.Trains
                                                where train.TrainID == trainId
                                                select train.SeatNumber).Single();

                    for (int i = 0; i < numberOfSeatsInTrain; i++)
                    {
                        Seat seat = new Seat
                        {
                            SeatNumber = i + 1,
                            TrainID = trainId,                          
                            SeatTaken = false,
                            SeatClass = SeatClassType.Second
                        };

                        db.Seats.Add(seat);
                    }

                    db.SaveChanges();
                }
                catch (OptimisticConcurrencyException ex)
                {
                    Console.WriteLine("Cannot insert trip in database!:");
                    Console.WriteLine(ex.Message);
                    return;
                }

                Console.WriteLine("Trip created successfully!");
            }
        }

        private static void CreateDiscountCard()
        {
            using (var db = new TicketSystemDBEntities())
            {
               
                var cardsId = new HashSet<string>();
                foreach (var card in db.DiscountCards)
                {
                    cardsId.Add(card.DiscountCardNumber);
                    Console.WriteLine($"{card.DiscountCardNumber}");
                }

                Console.Write("Discount card ID: ");
                var discountNumber = Console.ReadLine().Trim();

                if (cardsId.Contains(discountNumber))
                {
                    Console.WriteLine("Discount card id is not unique!");
                    return;
                }
             
                Console.Write("Choose type (0 for student,1 for ISIC): ");
                var typeArg = Console.ReadLine().Trim();

                int typeNum;
                if (!int.TryParse(typeArg, out typeNum))
                {
                    Console.WriteLine("Invalid number format!");
                    return;
                }

                DiscountCardType type;
                if (!Enum.IsDefined(typeof(DiscountCardType), typeNum))
                {
                    Console.WriteLine("Invalid number format!");
                    return;
                }
                type = (DiscountCardType)typeNum;
                
                Console.Write("Does the card apply to first class (Yes/No):");
                var cardTypeAns = Console.ReadLine().Trim();
                cardTypeAns = cardTypeAns.ToLower();

                int cardType ;

                if (cardTypeAns == "no")
                {
                    cardType = 1;
                    DiscountCardType cType;
                    if (!Enum.IsDefined(typeof(DiscountCardType), cardType))
                    {
                        Console.WriteLine("Invalid number format!");
                        return;
                    }
                    cType = (DiscountCardType)cardType;
                } else if (cardTypeAns == "yes")
                {
                    cardType = 0;
                    DiscountCardType cType;
                    if (!Enum.IsDefined(typeof(DiscountCardType), cardType))
                    {
                        Console.WriteLine("Invalid number format!");
                        return;
                    }
                    cType = (DiscountCardType)cardType;
                } else
                {
                    Console.WriteLine("Invalid input! Please answer with (Yes/No)!");
                    return;
                }

                    
                Console.Write("Discount amount (from 0 to 100): ");
                var discountArg = Console.ReadLine().Trim();

                decimal discount;
                if (!decimal.TryParse(discountArg, out discount))
                {
                    Console.WriteLine("Invalid number format!");
                    return;
                }

                try
                {
                    DiscountCard card = new DiscountCard
                    {
                        DiscountCardNumber = discountNumber,
                        CardType = type,
                        DiscountAmount = discount
                    };
                   
                    db.DiscountCards.Add(card);

                    db.SaveChanges();
                }
                catch (OptimisticConcurrencyException ex)
                {
                    Console.WriteLine("Cannot insert discount card into the database! ");
                    Console.WriteLine(ex.Message);
                    return;
                }

                Console.WriteLine("Discount card was created successfully!");
            }
        }
   
        private static void RegisterUser()
        {
            
            using(var db = new TicketSystemDBEntities())
            {
                Console.Write("User name: ");
                string userName = Console.ReadLine().Trim();

                var userNameCheck = from uName in db.Users
                                    where uName.UserName == userName
                                    select uName.UserName;

                if (userNameCheck.Count() != 0)
                {
                    Console.WriteLine("User name already exist!");
                    return;
                }


                Console.Write("Password: ");
                string password = HidePassword();

                Console.Write("Email: ");
                string email = Console.ReadLine().Trim();

                if (Regex.IsMatch(email,
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))
                    @(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase))
                {
                    Console.WriteLine("Invalid email! Please check you email format.");
                    return;
                }

                Console.Write("Credit Card Number: ");
                string creditCardNumber = Console.ReadLine().Trim();
                Console.Write("First Name: ");
                string firstName = Console.ReadLine().Trim();
                Console.Write("Last Name: ");
                string lastName = Console.ReadLine().Trim();
                Console.Write("Address: ");
                string address = Console.ReadLine().Trim();
                Console.Write("Zip Code: ");
                string zipCode = Console.ReadLine().Trim();
                Console.Write("Do you have discount card?(Yes/No): ");
                string userInput = Console.ReadLine().Trim();
                userInput = userInput.ToLower();

                string cardNumber = null;
                bool detector;

                if (userInput == "yes")
                {
                    Console.Write("Enter your discount card number: ");
                    cardNumber = Console.ReadLine().Trim();

                    var discountCard = (from disc in db.DiscountCards
                                        where disc.DiscountCardNumber == cardNumber
                                        select disc).SingleOrDefault();

                    if (discountCard == null)
                    {
                        Console.WriteLine("Card does not exist!");
                        return;
                    }
                    else detector = true;
                }
                else if (userInput == "no")
                {
                    detector = false;
                } else
                {
                    Console.WriteLine("Invalid answer! Please answer with Yes/No next time!");
                    return;
                }

                try
                {
                    var user = new User(userName, password);
                    user.UserEmail = email;
                    user.FirstName = firstName;
                    user.LastName = lastName;
                    user.UserAddress = address;
                    user.ZipCode = zipCode;
                    user.CreditCardNumber = creditCardNumber;
                    user.isAdmin = false;
                    if (detector) user.DicoundCardID = cardNumber;

                    db.Users.Add(user);
                    db.SaveChanges();
                }
                catch (OptimisticConcurrencyException e)
                {
                    Console.WriteLine("Failed to add the user into the database! ");
                    Console.WriteLine(e.Message);
                    return;
                }
                Console.WriteLine("User was added into the database");
            }
        }

        private static void EditTrain(string trainIdHolder)
        {
            using (var db = new TicketSystemDBEntities())
            {
                int traindId;
                try
                {
                    traindId = int.Parse(trainIdHolder);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid train ID! Please enter a valid train ID next time.");
                    return;
                }


                var trainEdit = (from train in db.Trains
                                 where train.TrainID == traindId
                                 select train).SingleOrDefault();

                if (trainEdit == null)
                {
                    Console.WriteLine("Train with that ID doesn't exist");
                    return;
                }

                Console.WriteLine("Train was found!");
                Console.Write("Train description: ");
                Console.WriteLine(trainEdit.Description);
                Console.WriteLine();
                Console.Write("Write the new description: ");
                string newDesc = Console.ReadLine().Trim();

                Console.Write("Number of seats in the train: ");
                Console.WriteLine(trainEdit.SeatNumber);
                Console.WriteLine();
                Console.Write("Enter the new number of seats: ");
                string seatNumberHolder = Console.ReadLine().Trim();
                int seatNumber;

                try
                {
                    if(!int.TryParse(seatNumberHolder, out seatNumber))
                    {
                        Console.WriteLine("Please enter a valid number for the number of seats! ");
                        return;
                    }
                    trainEdit.Description = newDesc;
                    trainEdit.SeatNumber = seatNumber;

                    db.SaveChanges();
                }
                catch (OptimisticConcurrencyException e)
                {
                    Console.WriteLine("Couldn't edit the train from the database!");
                    Console.WriteLine(e.Message);
                    return;
                }
                Console.WriteLine("Train was edited successfully!");
            }
        }

        private static void DeleteCity(string cityName)
        {
            using (var db = new TicketSystemDBEntities())
            {

                var cityToDelete = (from city in db.Cities
                                    where city.CityName == cityName
                                    select city).SingleOrDefault();

                if (cityToDelete == null)
                {
                    Console.WriteLine("The city was not found in the database! ");
                    return;
                }

                try
                {
                    var schedulesToDelete = from schedule in db.Schedules
                                            where schedule.EndCity.CityName == cityName
                                            || schedule.EndCity.CityName == cityName
                                            select schedule;

                    foreach (var schedule in schedulesToDelete)
                    {

                        var ticketsToDelete = from ticket in db.Tickets
                                              where ticket.ScheduleID == schedule.ScheduleID
                                              select ticket;

                        db.Tickets.RemoveRange(ticketsToDelete);

                        var seatsToDelete = from seat in schedule.Train.Seats
                                            where seat.Ticket.ScheduleID == schedule.ScheduleID
                                            select seat;

                        db.Seats.RemoveRange(seatsToDelete);

                        db.Schedules.Remove(schedule);
                    }

                    db.Cities.Remove(cityToDelete);

                    db.SaveChanges();
                }
                catch (OptimisticConcurrencyException e)
                {
                    Console.WriteLine("Cannot delete the city from database!");
                    Console.WriteLine(e.Message);
                    return;
                }

                Console.WriteLine("The city was deleted successfully!");
            }
        }

        private static void DeleteTrain(string trainIdHolder)
        {
            using (var db = new TicketSystemDBEntities())
            {
                int trainId;
                if (!int.TryParse(trainIdHolder, out trainId))
                {
                    Console.WriteLine("Invalid train ID!Please enter a valid city ID next time! ");
                    return;
                }

                var trainToDelete = (from train in db.Trains
                                     where train.TrainID == trainId
                                     select train).SingleOrDefault();


                if (trainToDelete == null)
                {
                    Console.WriteLine("The train was not found in the database!");
                    return;
                }
              
                try
                {
                    trainToDelete.isDeleted = true;

                    var ticketsToDelete = from ticket in db.Tickets
                                           where ticket.TrainID == trainId
                                           select ticket;

                    foreach (var tckt in ticketsToDelete)
                    {
                        tckt.isDeleted = true;
                    }

                    var schedulesToDelete = from schedule in db.Schedules
                                            where schedule.TrainID == trainId
                                            select schedule;

                    foreach (var sched in schedulesToDelete)
                    {
                        sched.isDeleted = true;
                    }

                                    
                    db.SaveChanges();
                }
                catch (OptimisticConcurrencyException ex)
                {
                    Console.WriteLine("Cannot delete train in database!");
                    Console.WriteLine(ex.Message);
                    return;
                }

                Console.WriteLine("Train deleted successfully!");
            }
        }

        private static void EditTrip(string tripIDHolder)
        {
            using (var db = new TicketSystemDBEntities())
            {
                int scheduleId;
                if (!int.TryParse(tripIDHolder, out scheduleId))
                {
                    Console.WriteLine("Invalid trip ID! ");
                    return;
                }

                var scheduleToEdit = (from schedule in db.Schedules
                                      where schedule.TrainID == scheduleId
                                      select schedule).SingleOrDefault();

                if (scheduleToEdit == null)
                {
                    Console.WriteLine("No such trip! ");
                    return;
                }


                Console.WriteLine("Trip was found!");
                Console.WriteLine("StartCityID: " + scheduleToEdit.StartingCityID);
                Console.WriteLine("EndCityID: " + scheduleToEdit.EndCityID);
                Console.WriteLine("TravelTime: " + scheduleToEdit.TravelTime.ToString("hh\\:mm"));
                Console.WriteLine("TrainID: " + scheduleToEdit.TrainID);
                Console.WriteLine("TicketPrice: " + scheduleToEdit.TicketPrice);

                HashSet<string> cityNames = new HashSet<string>();
                foreach (var city in db.Cities)
                {
                    cityNames.Add(city.CityName);
                    Console.WriteLine(city.CityName);
                }

                Console.WriteLine("Editing trip!");

                Console.Write("Start City(Name): ");
                var startCityName = Console.ReadLine().Trim();
                Console.Write("End City(Name): ");
                var endCityName = Console.ReadLine().Trim();

                int startCityId, endCityId;

                  
                    if (!cityNames.Contains(startCityName) || !cityNames.Contains(endCityName))
                    {
                        Console.WriteLine("Wrong city names! ");
                        return;
                    } else
                    {
                        startCityId = (from city in db.Cities
                                       where city.CityName == startCityName
                                       select city.CityID).SingleOrDefault();

                        endCityId = (from city in db.Cities
                                     where city.CityName == endCityName
                                     select city.CityID).SingleOrDefault();
                    }


                TimeSpan travelTime;
                Console.Write("Travel Time(hh:mm): ");
                var travelTimeInput = Console.ReadLine().Trim();

                if (travelTimeInput != string.Empty)
                {
                    var travelTimeArg = travelTimeInput.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                    if (travelTimeArg.Length != 2)
                    {
                        Console.WriteLine("Invalid time format!");
                        return;
                    }

                    try
                    {
                        travelTime = new TimeSpan(int.Parse(travelTimeArg[0]), int.Parse(travelTimeArg[1]), 0);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid id format!");
                        return;
                    }
                }
                else travelTime = scheduleToEdit.TravelTime;

                Console.WriteLine("List of trains:");
                HashSet<int> trainIds = new HashSet<int>();
                foreach (var train in db.Trains)
                {
                    trainIds.Add(train.TrainID);
                    Console.WriteLine(train.TrainID + "-" + train.Description);
                }

                Console.Write("Train(Id): ");
                var trainArg = Console.ReadLine().Trim();

                int trainId;
                try
                {
                    if (trainArg != string.Empty)
                    {
                        trainId = int.Parse(trainArg);
                    }
                    else trainId = scheduleToEdit.TrainID;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid id format!");
                    return;
                }

                if (!trainIds.Contains(trainId))
                {
                    Console.WriteLine("Id does not exist! ");
                    return;
                }

                Console.Write("Ticket Price: ");
                var ticketPriceArg = Console.ReadLine().Trim();

                decimal ticketPrice;
                try
                {
                    if (ticketPriceArg != string.Empty) ticketPrice = decimal.Parse(ticketPriceArg);
                    else ticketPrice = scheduleToEdit.TicketPrice;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid price format!");
                    return;
                }

                try
                {
                    scheduleToEdit.StartingCityID = startCityId;
                    scheduleToEdit.EndCityID = endCityId;
                    scheduleToEdit.TravelTime = travelTime;
                    scheduleToEdit.TrainID = trainId;
                    scheduleToEdit.TicketPrice = ticketPrice;

                    db.SaveChanges();
                }
                catch (OptimisticConcurrencyException ex)
                {
                    Console.WriteLine("Cannot edit trip into the datebase!: ");
                    Console.WriteLine(ex.Message);
                    return;
                }

                Console.WriteLine("Trip edited successfully!");
            }
        }

        private static void DeleteTrip(string tripIDHolder)
        {

            using (var db = new TicketSystemDBEntities())
            {
                int scheduleId;
                if (!int.TryParse(tripIDHolder, out scheduleId))
                {
                    Console.WriteLine("Invalid trip ID!");
                    return;
                }

                var scheduleToDelete = (from schedule in db.Schedules
                                        where schedule.ScheduleID == scheduleId
                                        select schedule).SingleOrDefault();


                if (scheduleToDelete == null)
                {
                    Console.WriteLine("No such trip! ");
                    return;
                } else
                {
                    scheduleToDelete.isDeleted = true;
                }

                try
                {
                    var ticketsToDelete = from ticket in db.Tickets
                                          where ticket.ScheduleID == scheduleToDelete.ScheduleID
                                          select ticket;

                    foreach (var item in ticketsToDelete)
                    {
                        item.isDeleted = true;
                    }

                    var seatsToDelete = from seat in db.Seats 
                                        where seat.TrainID == scheduleToDelete.TrainID
                                        select seat;

                    foreach (var item in seatsToDelete)
                    {
                        item.isDeleted = true;
                    }                

                    db.SaveChanges();
                }
                catch (OptimisticConcurrencyException ex)
                {
                    Console.WriteLine("Cannot delete trip in database!");
                    Console.WriteLine(ex.Message);
                    return;
                }

                Console.WriteLine("Trip deleted successfully!");
            }   

      }

        private static void BuyTicket(string tripIDHolder)
        {
            using (var db = new TicketSystemDBEntities())
            {
                int scheduleId;
                if (!int.TryParse(tripIDHolder, out scheduleId))
                {
                    Console.WriteLine("Invalid trip ID!");
                    return;
                }

                var scheduleOfTicket = (from schedule in db.Schedules
                                        where schedule.ScheduleID == scheduleId
                                        select schedule).SingleOrDefault();

                if (scheduleOfTicket == null)
                {
                    Console.WriteLine("No such trip!");
                    return;
                }

                var trainOfSchedule = scheduleOfTicket.Train;

                List<int> availableSeats = new List<int>(trainOfSchedule.SeatNumber);
                foreach (var seat in trainOfSchedule.Seats)
                {
                    if (!seat.SeatTaken) availableSeats.Add(seat.SeatNumber);
                }

                if (availableSeats.Count == 0)
                {
                    Console.WriteLine("No more available seats!");
                    return;
                }

                Console.WriteLine("Available seats: " + string.Join(", ", availableSeats));

                Console.WriteLine("Write the seat number you would want to book: ");
                var seatArg = Console.ReadLine().Trim();

                int seatNumber;
                if (!int.TryParse(seatArg, out seatNumber))
                {
                    Console.WriteLine("Invalid number format!");
                    return;
                }

                if (!availableSeats.Contains(seatNumber))
                {
                    Console.WriteLine("Seat number provided does not exist! ");
                    return;
                }

                Console.WriteLine("Please enter your username and password in order to continue!");
                Console.Write("Username: ");
                var username = Console.ReadLine();
                Console.Write("Password: ");
                var password = HidePassword();

                if (!SystemSecurity.UserExist(db, username, password))
                {
                    Console.WriteLine("No such user! ");
                    return;
                }

                var userBuyingTicket = (from user in db.Users
                                        where user.UserName == username
                                        select user).SingleOrDefault();

                decimal discount = userBuyingTicket.DiscountCard?.DiscountAmount ?? 0;

                decimal originalPrice = scheduleOfTicket.TicketPrice;

                decimal priceSold = originalPrice - ((originalPrice * discount) / 100);
                if (priceSold < 0) priceSold = 0;

                try
                {
                    Ticket ticket = new Ticket
                    {
                        SeatNumber = seatNumber,
                        TrainID = trainOfSchedule.TrainID,
                        ScheduleID = scheduleId,
                        TripDateAndTime = scheduleOfTicket.TravelDate,
                        OriginalPrice = originalPrice,
                        PriceSold = priceSold,
                        UserID = userBuyingTicket.UserID
                    };

                    db.Tickets.Add(ticket);

                    db.SaveChanges();
                }
                catch (OptimisticConcurrencyException ex)
                {
                    Console.WriteLine("Cannot add ticket in database!");
                    Console.WriteLine(ex.Message);
                    return;
                }

                Console.WriteLine("Ticket bought successfully!");
            }
        }

        public static void ListCities()
        {
            using (var db = new TicketSystemDBEntities())
            {
                Console.WriteLine("City number - Name");
                Console.WriteLine("===================");
                foreach (var city in db.Cities)
                {
                    Console.WriteLine(city.CityID + " - " + city.CityName);
                }
                Console.WriteLine();
            }
        }

        public static void ListTrains()
        {
            using (var db = new TicketSystemDBEntities())
            {
                Console.WriteLine("Train number - Description");
                Console.WriteLine("===========================");
                foreach (var train in db.Trains)
                {
                    Console.WriteLine(train.TrainID + " - " + train.Description);
                }
                Console.WriteLine();
            }
        }

        public static void ListTrips()
        {
            using (var db = new TicketSystemDBEntities())
            {
                Console.WriteLine("Schedule number - Start city - End city - Travel time");
                Console.WriteLine("=====================================================");
                foreach (var schedule in db.Schedules)
                {
                    var startCity = (from city in db.Cities
                                     join sch in db.Schedules on city.CityID equals sch.StartingCityID
                                     select city.CityName).SingleOrDefault();
                    
                    var endCity = (from city in db.Cities
                                   join sch in db.Schedules on city.CityID equals sch.EndCityID
                                   select city.CityName).SingleOrDefault();
                    Console.WriteLine(schedule.ScheduleID + "-" + startCity + "-" + endCity + "-" + schedule.TravelDate);
                }
                Console.WriteLine();
            }
        }

        private static string HidePassword()
        {
            string pass = "";        
            ConsoleKeyInfo key = Console.ReadKey(true);

            while (key.Key != ConsoleKey.Enter)
            {
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    pass += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                    {
                        pass = pass.Substring(0, (pass.Length - 1));
                        Console.Write("\b \b");
                    }
                }
                key = Console.ReadKey(true);
            }
            Console.WriteLine();
            return pass;
        } 

        static void Main(string[] args)
        {

            bool exit = false;
            Console.WriteLine("help - display the list of all commands");
            string trainID;
            string cityName;
            string userInput = string.Empty;


            while (!exit)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Enter a command: ");
                userInput = Console.ReadLine().Trim();
                userInput.ToLower();
                userInput = userInput.Replace(" ", "");
                if (userInput == string.Empty) continue;

                if (userInput == "help")
                {
                    PrintHelp();
                }
                else if (userInput == "addcity")
                {
                    CreateCity();
                }
                else if (userInput == "addtrain")
                {
                    CreateTrain();
                }
                else if (userInput == "addtrip")
                {
                    CreateTrip();
                }
                else if (userInput == "adddiscountcard")
                {
                    CreateDiscountCard();
                }
                else if (userInput == "registeruser")
                {
                    RegisterUser();
                }
                else if (userInput == "exit")
                {
                    exit = true;
                }
                else if (userInput == "edittrain")
                {
                    Console.Write("Enter the train(ID) you want to edit: ");
                    trainID = Console.ReadLine();
                    EditTrain(trainID);
                }
                else if (userInput == "deletecity")
                {
                    Console.Write("Enter the name of the city you would want to delete: ");
                    cityName = Console.ReadLine();
                    DeleteCity(cityName);
                }
                else if (userInput == "deletetrain")
                {
                    Console.Write("Enter the train(trainID) you would want to delete: ");
                    trainID = Console.ReadLine();
                    DeleteTrain(trainID);
                }
                else if (userInput == "listcities")
                {
                    ListCities();
                }
                else if (userInput == "listtrains")
                {
                    ListTrains();
                }
                else if (userInput == "listtrips")
                {
                    ListTrips();
                }
                else if (userInput == "edittrip")
                {
                    Console.Write("Write the tripID you would want to edit: ");
                    string tripID =  Console.ReadLine();
                    EditTrip(tripID);
                }
                else if (userInput == "deletetrip")
                {
                    Console.Write("Write the tripID you would want to delete: ");
                    string tripId = Console.ReadLine();
                    DeleteTrip(tripId);
                }
                else if (userInput == "buyticket")
                {
                    Console.WriteLine("Enter the tripId you would like to buy a ticket for: ");
                    string tripID = Console.ReadLine();
                    BuyTicket(tripID);
                }

            }
        }
    }
}
