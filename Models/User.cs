namespace AtomsBackend.Models
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string passwordHash { get; set; }
    }
}
