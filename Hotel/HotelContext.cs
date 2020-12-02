using Microsoft.EntityFrameworkCore;

#pragma warning disable 8618

namespace Hotel {
    public class HotelContext : DbContext {
        public HotelContext(DbContextOptions<HotelContext> options) : base(options) { }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelSpecial> HotelSpecials { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<RoomPrice> RoomPrices { get; set; }
    }
}
