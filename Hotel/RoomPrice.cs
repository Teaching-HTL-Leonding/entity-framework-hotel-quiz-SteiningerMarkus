using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel {
    public class RoomPrice {
        public int Id { get; set; }
        public RoomType? RoomType { get; set; }
        public int RoomTypeId { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidUntil { get; set; }
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }
    }
}
