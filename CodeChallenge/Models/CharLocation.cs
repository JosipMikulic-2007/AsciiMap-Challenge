using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using static CodeChallenge.Helpers.Enums;

namespace CodeChallenge.Models
{
    public class CharLocation
    {
        public char Character { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Direction { get; set;}
    }
}