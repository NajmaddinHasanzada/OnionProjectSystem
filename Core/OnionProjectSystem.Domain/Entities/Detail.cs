using OnionProjectSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProjectSystem.Domain.Entities
{
    public class Detail:EntityBase
    {
        public Detail() { }
        public Detail(string title, int categoryId)
        {
            Title = title;
            CategoryId = categoryId;
        }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
