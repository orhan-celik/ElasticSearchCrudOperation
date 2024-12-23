using AutoMapper;
using ElasticSearchCrudOperation.API.DTOs;
using ElasticSearchCrudOperation.API.Models;
using ElasticSearchCrudOperation.API.Repositories;
using System.Net;

namespace ElasticSearchCrudOperation.API.Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(ProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<ProductDto>> SaveAsync(ProductCreateDto request)
        {
            var product = _mapper.Map<Product>(request);

            var response = await _productRepository.SaveAsync(product);

            var newProductDto = _mapper.Map<ProductDto>(response);

            if (response == null) return ResponseDto<ProductDto>.Fail(new List<string> { "İndexleme sırasında bir hata oluştu" }, HttpStatusCode.InternalServerError);

            return ResponseDto<ProductDto>.Success(data: newProductDto, httpStatusCode: HttpStatusCode.Created);

        }

        public async Task<ResponseDto<List<ProductDto>>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();
            var productsListDto = new List<ProductDto>();
            foreach (var product in products) productsListDto.Add(_mapper.Map<ProductDto>(product));
            return ResponseDto<List<ProductDto>>.Success(data: productsListDto, httpStatusCode: HttpStatusCode.OK);
        }

        public async Task<ResponseDto<ProductDto>> GetByIdAsync(string id)
        {
            var response = await _productRepository.GetByIdAsync(id);

            if (response is null)
                return ResponseDto<ProductDto>.Fail(error: "Hata : Aradığınız kayıt bulunmadı.", httpStatusCode: HttpStatusCode.NotFound);

            var getProductDto = _mapper.Map<ProductDto>(response);

            return ResponseDto<ProductDto>.Success(data: getProductDto, httpStatusCode: HttpStatusCode.OK);
        }

        public async Task<ResponseDto<bool>> UpdateAsync(ProductUpdateDto request)
        {
            var response = await _productRepository.UpdateAsync(request);

            if (!response)
                return ResponseDto<bool>.Fail(error: "Hata : Kayıt güncellenemedi", httpStatusCode: HttpStatusCode.NoContent);

            return ResponseDto<bool>.Success(data: response, httpStatusCode: HttpStatusCode.OK);

        }

        public async Task<ResponseDto<bool>> DeleteAsync(string id)
        {
            var response = await _productRepository.DeleteAsync(id);
            if (!response)
                return ResponseDto<bool>.Fail(error: "Hata : Kayıt silinemedi", httpStatusCode: HttpStatusCode.InternalServerError);

            return ResponseDto<bool>.Success(data: response, httpStatusCode: HttpStatusCode.OK);
        }
    }
}