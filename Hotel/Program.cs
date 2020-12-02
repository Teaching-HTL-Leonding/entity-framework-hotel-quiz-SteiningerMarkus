using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel;

var factory = new HotelContextFactory();
var context = factory.CreateDbContext();

switch (args[0]) {
    case "add":
        await Add();
        break;
    case "query":
        Query();
        break;
}

async Task Add() {
    HotelSpecial dogFriendly, organicFood, spa, sauna, indoorPool, outdoorPool;
    await context.HotelSpecials.AddRangeAsync(dogFriendly = new HotelSpecial {
        Special = Special.DogFriendly, 
    }, organicFood = new HotelSpecial {
        Special = Special.OrganicFood, 
    }, spa = new HotelSpecial {
        Special = Special.Spa, 
    }, sauna = new HotelSpecial {
        Special = Special.Sauna, 
    }, indoorPool = new HotelSpecial {
        Special = Special.IndoorPool, 
    }, outdoorPool = new HotelSpecial {
        Special = Special.OutdoorPool, 
    });
    
    RoomType double3X10, double10X15, single10X15, double25X30, junior5X45, honeymoon1X100;
    await context.RoomTypes.AddRangeAsync(double3X10 = new RoomType {
        Title = "Single room",
        Size = 10,
        RoomsAvailable = 3,
    }, double10X15 = new RoomType {
        Title = "Double room",
        Size = 15,
        RoomsAvailable = 10,
    }, single10X15 = new RoomType {
        Title = "Single room",
        Size = 15,
        RoomsAvailable = 10,
        DisabilityAccessible = true,
    }, double25X30 = new RoomType {
        Title = "Double room",
        Size = 30,
        RoomsAvailable = 25,
        DisabilityAccessible = true,
    }, junior5X45 = new RoomType {
        Title = "Junior suite",
        Size = 45,
        RoomsAvailable = 5,
        DisabilityAccessible = true,
    }, honeymoon1X100 = new RoomType {
        Title = "Honeymoon suite",
        Size = 100,
        RoomsAvailable = 1,
        DisabilityAccessible = true,
    });
    
    await context.RoomPrices.AddRangeAsync(new RoomPrice {
        Price = 40,
        RoomType = double3X10,
    }, new RoomPrice {
        Price = 60,
        RoomType = double10X15,
    }, new RoomPrice {
        Price = 70,
        RoomType = single10X15,
    }, new RoomPrice {
        Price = 120,
        RoomType = double25X30,
    }, new RoomPrice {
        Price = 190,
        RoomType = junior5X45,
    }, new RoomPrice {
        Price = 300,
        RoomType = honeymoon1X100,
    });
    
    await context.Hotels.AddRangeAsync(new Hotel.Hotel {
        Name = "Pension Marianne",
        Address = "Am Hausberg 17, 1234 Irgendwo",
        Specials = new List<HotelSpecial> { dogFriendly, organicFood },
        RoomTypes = new List<RoomType> { double3X10, double10X15 },
    }, new Hotel.Hotel {
        Name = "Grand Hotel Goldener Hirsch",
        Address = "Im stillen Tal 42, 4711 Schönberg",
        Specials = new List<HotelSpecial> { spa, sauna, indoorPool, outdoorPool },
        RoomTypes = new List<RoomType> { single10X15, double25X30, junior5X45, honeymoon1X100 },
    });

    await context.SaveChangesAsync();
}

void Query() {
    foreach (var hotel in context.Hotels) {
        Console.WriteLine($"# {hotel.Name}\n");
        Console.WriteLine("## Location\n");
        Console.WriteLine($"{hotel.Address}\n");
        Console.WriteLine("## Specials");
        foreach (HotelSpecial special in hotel.Specials)
            Console.WriteLine($"* {special.Special}");
        
        Console.WriteLine("\n## Room types\n");
        Console.WriteLine("| Room type            | Size   | Price valid from | Price valid to | Price in EUR |");
        Console.WriteLine(
            $"| {new string('-', 20)} | {new string('-', 6)} | {new string('-', 16)} | {new string('-', 14)} | {new string('-', 12)} |");
        
        foreach (RoomPrice price in context.RoomPrices)
            if (price.RoomType!.HotelId == hotel.Id)
                Console.WriteLine(
                    $"| {price.RoomType!.Title, -20} | {price.RoomType.Size + " m²", -6} | {price.ValidFrom, -16} | {price.ValidUntil, -14} | {price.Price + " EUR", -12} |");
    }
}
