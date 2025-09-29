using DataAccess.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs.ReviewDto
{
    public class ReviewDto
    {
        public int Id { get; set; }

        public string Comment { get; set; }

        public string MovieTitle { get; set; }
        public string UserUserName { get; set; }
    }
}
