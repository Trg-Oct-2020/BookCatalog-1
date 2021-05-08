using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookCatalog.Application.DTOs
{
    public class BookDTO
    {
        public String id { get; set; }

        [Required(ErrorMessage = "The Title is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Title")]
        public String title { get; set; }


        [Required(ErrorMessage = "The Author is Required")]
        [DisplayName("Author")]
        public String author { get; set; }


        [Required(ErrorMessage = "The ISBN is Required")]
        [MinLength(13)]
        [MaxLength(13)]
        [DisplayName("ISBN")]
        public String isbn { get; set; }


        [Required(ErrorMessage = "The PublishedDate is Required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Invalid Date Format")]
        [DisplayName("Published Date")]
        public String publishedDate { get; set; }
    }
}
