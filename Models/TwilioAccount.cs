using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RPM_Tool.Models
{
    public class TwilioAccount
    {
        [Key]
        public int Id { get; set; }
        public string AuthToken { get; set; }
        public string ApiKey { get; set; }
        public string FromNumber { get; set; }
    }
}
