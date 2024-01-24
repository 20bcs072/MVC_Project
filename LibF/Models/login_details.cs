using System.ComponentModel.DataAnnotations;

namespace LibF.Models
{
    public class login_details
    {
        [Key]
        public int userid {  get; set; }
        public string username { get; set; }
            public string pwd { get; set; }
    }
}
