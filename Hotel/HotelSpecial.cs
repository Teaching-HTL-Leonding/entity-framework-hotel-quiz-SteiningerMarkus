using System.Collections.Generic;

#pragma warning disable 8618

namespace Hotel {
    public class HotelSpecial {
        public int Id { get; set; }
        public Special Special { get; set; }

        public List<Hotel> Hotels { get; set; }
    }
}
