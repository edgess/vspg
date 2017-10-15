using System.Data.Entity;

namespace WebApplication1.Models
{
    public class JUserContext :DbContext
    {
        public JUserContext() : base("name=AccountContext")
        {
        }
            
        public DbSet<JUser> JUsers { get; set; }
    }
}