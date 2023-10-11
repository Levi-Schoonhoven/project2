
using Microsoft.EntityFrameworkCore;

namespace character.Models
{
    public class Characters : DbContext
    {
        public Characters(DbContextOptions<Characters> options)
            : base(options)
        { }

        public DbSet<Names> Names { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Names>().HasData(
                new Names { Name = "Master Chief", Year = 2001, Description= "The Master Chief is a towering supersoldier known as a \"Spartan\", trained from childhood for combat. The designers intended for players to be able to project their own intentions into the character, and thus reduced his voiced lines and concealed his appearance under his armor." },
                new Names { Name = "Ansem", Year = 2002, Description= "Ansem, Seeker of Darkness is the main antagonist of Kingdom Hearts and the \"Reverse/Rebirth\" mode in Kingdom Hearts: Chain of Memories. He is the Heartless of Xehanort, and retains the dark \"guardian\" which belonged to his original self." },
                new Names { Name = "Guybrush Threepwood", Year =1990, Description= "Guybrush Ulysses Threepwood is a fictional character who serves as the main protagonist of the Monkey Island series of computer adventure games by LucasArts. He is a pirate who adventures throughout the Caribbean in search of fame and treasure alongside his love interest and later wife, Elaine Marley, often thwarting the plans of the undead pirate LeChuck in the process." }
              

             );
           
        }


    }
}
