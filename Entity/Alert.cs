using System;
using System.Collections.Generic;

#nullable disable

namespace Entity
{
    public partial class Alert
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime? Date { get; set; }
    }
}
