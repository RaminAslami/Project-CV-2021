using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project_2022_CV.Models;

namespace Project_2022_CV.ViewModel
{
    public class ProfileMessageViewModel
    {
        public string Message { get; set; }
        public ApplicationUser CurrentUser { get; set; }
    }
}