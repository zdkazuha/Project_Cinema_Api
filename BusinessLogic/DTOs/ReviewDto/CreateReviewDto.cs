using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs.ReviewDto
{
    public class CreateReviewDto
    {
        public string Comment { get; set; }

        public int MovieId { get; set; }

        public string UserId { get; set; }
    }
}
