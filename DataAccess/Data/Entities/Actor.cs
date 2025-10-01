using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Entities
{
    public class Actor
    {
        public int Id { get; set; }

        public string Name { get; set; }

        // navigation property
        public ICollection<MovieActor>? MovieActors { get; set; }
    }
}
