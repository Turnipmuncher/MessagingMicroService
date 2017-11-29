using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MessagingService.Models
{
    public class Message
    { 
        public string id { get; set; }
        public string subject { get; set; }
        public string message { get; set; }
        public string sender { get; set; }
        public string recipient { get; set; }
        public bool isDraft { get; set; }
    }
}
