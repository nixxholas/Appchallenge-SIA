from random import choice, randrange

econTix = """
            FlightTickets ft%s;
            ft%s = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = %s,
                Quantity = %s,
                PurchaseDate = %s
            };

            """

originalprice = 1500

dates = []
for i in range(225):
    days = randrange(0, 40)
    dates.append((days, "new DateTime(2016, 09, 12, 00, 13, 00).addDays(-%s)" % days))
dates.sort()

for i in range(225, 1, -1):
    id = 226 - i
    originalprice += randrange(0, 3)
    quantity = i
    print(econTix % (id, id, originalprice, quantity, dates.pop()[1]))

businessTix = """
            FlightTickets ft%s;
            ft%s = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = %s,
                Quantity = %s,
                PurchaseDate = %s
            };

            """

dates = []
for i in range(45):
    days = randrange(0, 40)
    dates.append((days, "new DateTime(2016, 09, 12, 00, 13, 00).addDays(-%s)" % days))
dates.sort()

originalprice = 5000
flightid = 226
for i in range(45, 1, -1):
    flightid += 1
    originalprice += randrange(0, 5)
    quantity = i
    print(businessTix % (flightid, flightid, originalprice, quantity, dates.pop()[1]))

firstClassTix = """
            FlightTickets ft%s;
            ft%s = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = firstClass,
                Price = %s,
                Quantity = %s,
                PurchaseDate = %s
            };

            """

dates = []
for i in range(8):
    days = randrange(0, 40)
    dates.append((days, "new DateTime(2016, 09, 12, 00, 13, 00).addDays(-%s)" % days))
dates.sort()

originalprice = 11000
flightid = 300
for i in range(8, 1, -1):
    flightid += 1
    originalprice += randrange(0, 20)
    quantity = i
    print(firstClassTix % (flightid, flightid, originalprice, quantity, dates.pop()[1]))
