using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainApplication.Models
{
    public class Base
    {
        public Base()
        {
            CreationDate = DateTime.Now;
            UpdateDate = DateTime.Now;
            Active = true;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool Active { get; set; }
    }
}
