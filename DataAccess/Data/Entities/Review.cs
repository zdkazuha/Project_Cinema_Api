using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Entities
{
    public class Review
    {
        [Key]
        public int Id{ get; set; }

        [Required, MinLength(10)]
        public string Comment { get; set; }

        [Required]
        public int MovieId { get; set; }

        [Required]
        public int UserId { get; set; }

        // navigation property

        public Movie Movie { get; set; }
        public User User { get; set; }
    }
}
