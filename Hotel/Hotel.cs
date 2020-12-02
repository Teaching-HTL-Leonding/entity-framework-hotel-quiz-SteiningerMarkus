using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hotel {
    public class Hotel {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; } = "";
        public string Address { get; set; } = "";
        public List<HotelSpecial> Specials { get; set; } = new();
        public List<RoomType> RoomTypes { get; set; } = new();
    }
}
