using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tech.BusinessLogic.Dtos
{
    public class ProductViewDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string Category { get; set; }
    }
}
