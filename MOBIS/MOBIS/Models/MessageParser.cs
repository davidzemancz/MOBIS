﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MOBIS.Models
{
    class MessageParser
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Workplace { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Date { get; set; }
        public string ExpirationDate { get; set; }
        public string ContentText { get; set; }

    }
}
