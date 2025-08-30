namespace dummyApi.src.Domain.Entities
{
    public class Location
    {
        public int Id { get; private set; }
        public string Address { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public Location(int id, string address, string city, string state, string country, string zipCode)
        {
            Id = id;
            Address = address;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public void setAddress(string address)
        {
            Address = address;
            UpdatedAt = DateTime.UtcNow;
        }

        public void setCity(string city)
        {
            City = city;
            UpdatedAt = DateTime.UtcNow;
        }

        public void setState(string state)
        {
            State = state;
            UpdatedAt = DateTime.UtcNow;
        }

        public void setCountry(string country)
        {
            Country = country;
            UpdatedAt = DateTime.UtcNow;
        }

        public void setZipCode(string zipCode)
        {
            ZipCode = zipCode;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
