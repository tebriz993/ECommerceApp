using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tech.BusinessLogic.Dtos;

namespace Tech.BusinessLogic.Abstract
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryListDto>> GetCategoryList();
    }
}
