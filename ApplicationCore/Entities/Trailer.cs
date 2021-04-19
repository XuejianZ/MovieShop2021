using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Trailer
    {
        public int Id { get; set; }
        public string TrailerUrl { get; set; }
        public String Name { get; set; }

        //The combinational the following two make up the FK
        public int MovieId { get; set; }  //Fk

        //navigation property
        public Movie Movie { get; set; }

    }
}
