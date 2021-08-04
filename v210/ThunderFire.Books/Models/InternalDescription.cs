﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ThunderFire.Books.Models
{
    public class InternalDescription
    {
        [XmlAttribute("english")]
        public string English { get; set; } = "";
        [XmlText]
        public string Text { get; set; } = "";
    }
}
