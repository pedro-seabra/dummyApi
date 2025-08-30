namespace dummyApi.src.Domain.Entities
{
    public class Market
    {
        public int Id { get; private set; }
        
        public string Name { get; private set; }

        public Location Location { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public DateTime UpdatedAt { get; private set; }

        protected Market() { }

        public Market(int id, string name, Location location)
        {
            Id = id;
            Name = name;
            Location = location;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public void setName(string name)
        {
            Name = name;
            UpdatedAt = DateTime.UtcNow;
        }

        public void setLocation(Location location)
        {
            Location = location;
            UpdatedAt = DateTime.UtcNow;
        }

        public void setUpdatedAt(DateTime updatedAt)
        {
            UpdatedAt = updatedAt;
        }
    }
}
