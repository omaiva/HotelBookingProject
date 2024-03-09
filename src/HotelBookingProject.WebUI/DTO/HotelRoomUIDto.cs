namespace HotelBookingProject.WebUI.DTO
{
    public class HotelRoomUIDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int NumberOfBeds { get; set; }
        public string? Description { get; set; }
        public bool HasBath { get; set; }
        public bool HasContidioning { get; set; }
        public bool HasWiFi { get; set; }
        public bool IsAvailable { get; set; }
        public decimal Price { get; set; }
        public int ImageId { get; set; }
        public int HotelId { get; set; }
    }
}
