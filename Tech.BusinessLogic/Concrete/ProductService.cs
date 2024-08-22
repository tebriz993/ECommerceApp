using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tech.BusinessLogic.Abstract;
using Tech.BusinessLogic.Dtos;
using Tech.DataAccess.Abstract.Products;
using Tech.DataAccess.EntityFrameworks.Contexts;
using Tech.Entity.Concrete.Products;

namespace Tech.BusinessLogic.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task AddProduct(ProductAddDto productAddDto)
        {

            if (productAddDto is null)
            {
                throw new Exception("Product can't be null");
            }



            if (productAddDto.Id != 0)
            {
                var product = await _productRepository.GetByIdAsync(productAddDto.Id);
                if (product != null)
                {
                    try
                    {
                        product.Name = productAddDto.Name;
                        product.Price = productAddDto.Price;
                        product.ImagePath = productAddDto.ImagePath;
                        product.CategoryId = productAddDto.CategoryId;
                        product.Description = productAddDto.Description;
                    }
                    catch (Exception e)
                    {
                        var message = e.Message;
                        throw;
                    }
                }
            }
            else
            {
                var product = _mapper.Map<Product>(productAddDto);
                bool result = await _productRepository.AddAsync(product);
                if (result is false)
                {
                    throw new Exception("Product can't add");
                }
            }
            await _productRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductViewDto>> GetAllProduct()
        {
            var productList = await _productRepository.GetProducts();
            var productViewDtos = _mapper.Map<IEnumerable<ProductViewDto>>(productList);
            return productViewDtos;
        }

        public async Task<ProductAddDto> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductAddDto>(product);
        }

        public async Task Remove(int id)
        {
            var deletedProduct = await _productRepository.GetByIdAsync(id);

            if (deletedProduct is null)
            {
                throw new Exception("Product cant found");
            }
            _productRepository.Remove(deletedProduct);
            await _productRepository.SaveChangesAsync();

        }
    }
}
