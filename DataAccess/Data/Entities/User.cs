using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        // navigation property

        public ICollection<Review>? Reviews { get; set; }

    }
}
