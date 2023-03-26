using Project_2022_CV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_2022_CV.ViewModel
{
    public class MessageViewModel
    {
        public MessageModel messageModel { get; set; }
        public ApplicationUser applicationUser { get; set; }
    }
}