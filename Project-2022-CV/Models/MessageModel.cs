using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project_2022_CV.Models
{
    public class MessageModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Title cannot be longer than 50 characters and less than 3 characters")]

        public string Author { get; set; }
        public string Title { get; set; }
        [Required]
        [StringLength(600, MinimumLength = 10, ErrorMessage = "Text cannot be longer than 600 characters and less than 10 characters")]
        public string Text { get; set; }
        public DateTime WhenSent { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }
        public bool ReadMessage { get; set; }
        public string ReceiverId { get; set; }
        public string SenderId { get; set; }

        public string AuthorEmail { get; set; }
        public MessageModel()
        {
            ReadMessage = false;
        }
    }
}