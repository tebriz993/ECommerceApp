using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tech.BusinessLogic.Dtos
{
    public class ProductAddDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public string ImagePath { get; set; } = string.Empty;
        public int CategoryId { get; set; }
    }
}
