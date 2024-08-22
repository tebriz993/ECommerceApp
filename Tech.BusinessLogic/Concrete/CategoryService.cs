using AutoMapper;
using Tech.BusinessLogic.Abstract;
using Tech.BusinessLogic.Dtos;
using Tech.DataAccess.Abstract.Products;

namespace Tech.BusinessLogic.Concrete
{
    public class CategoryService(ICategoryRepository categoryRepository,IMapper mapper) : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository = categoryRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<CategoryListDto>> GetCategoryList()
        {
            var categories =  await  _categoryRepository.GetAllAsync(false);
            return _mapper.Map<IEnumerable<CategoryListDto>>(categories);

        }
    }
}
