using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMusic.Model
{
    public class Music
    {
        public int ID { get; set; }
        public string Song { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public int StarRating { get; set; }
    }
}
