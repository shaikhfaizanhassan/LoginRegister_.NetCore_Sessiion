using System.ComponentModel.DataAnnotations;

namespace loginregister.Models
{
    public class usertb
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}
