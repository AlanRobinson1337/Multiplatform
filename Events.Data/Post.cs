using Events.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Events.Web.Models
{
    public class Post
    {
        public Post()
        {
            this.DatePosted = DateTime.Now;
            //this.Comments = new HashSet<Comment>();
        }


        [Key]
        public int PostId { get; set; }
        [Required]
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }


        [Display(Name = "Date Posted")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:d}")]//format as ShortDateTime
        public DateTime DatePosted
        {
            get;
            set;
        }

        [Display(Name = "Author")]
        public string Author { get; set; }

        //navigation property
        [ForeignKey("Event")]
        public int Id { get; set; }
        public Event Event { get; set; }
    }
}