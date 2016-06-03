namespace SLRFC.Model
{
    using System.Data.Entity;

    public class MyDbContext : DbContext
    {
        public MyDbContext()
            : base("name=SlrfcConnectionString")
        {
        }

        public DbSet<Member> Members { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Availability> Availabilities { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<ContactDetails> ContactDetailsSet { get; set; }
    }
}