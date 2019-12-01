using System;
using System.Collections.Generic;
using System.Text;

namespace HW
{
    public class Image : Entity
    {
        public Game Game { get; set; }
        public Guid GameId { get; set; }
        public string Url { get; set; }
    }
}
