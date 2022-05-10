using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Todo_web_api.Models
{
    public class Sign_up
    {
        [Key]
        public int Id { get; set; }

        public String FullName { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public String Phone { get; set; }
        public String Usertype { get; set; }


    }
}
