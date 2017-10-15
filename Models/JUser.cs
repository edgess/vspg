using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class JUser
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public string Passwd { get; set; }
        public JUser() { }
        public JUser(string name,string passwd)
        {

            this.Name = name;
            this.Passwd = passwd;

        }
    }
}