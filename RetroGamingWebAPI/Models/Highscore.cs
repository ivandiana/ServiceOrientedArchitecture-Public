using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetroGamingWebAPI.Models
{
    public class Highscore
    {
        public string Game { get; set; }
        public string Nickname { get; set; }
        public int Points { get; set; }
    }
}
