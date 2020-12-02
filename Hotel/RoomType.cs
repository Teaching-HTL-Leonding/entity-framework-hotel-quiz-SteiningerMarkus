namespace Hotel {
    public class RoomType {
        public int Id { get; set; }
        public Hotel? Hotel { get; set; }
        public int HotelId { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public int Size { get; set; }
        public bool DisabilityAccessible { get; set; }
        public int RoomsAvailable { get; set; }
    }
}
