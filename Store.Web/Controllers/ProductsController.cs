﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Repository.Specification.ProductSpecs;
using Store.Service.Services;
using Store.Service.Services.ProductServices.Dtos;
using Store.Web.Helper;

namespace Store.Web.Controllers
{
   
    public class ProductsController : BaseController
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<BrandTypeDetailsDto>>> GetAllBrands()
            => Ok(await _productService.GetAllBrandsAsync());

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<BrandTypeDetailsDto>>> GetAllTypes()
           => Ok(await _productService.GetAllTypesAsync());


        [HttpGet]
        [Cache(10)] 
        public async Task<ActionResult<IReadOnlyList<ProductDetailsDto>>> GetAllProducts([FromQuery] ProductSpecification input)
            => Ok(await _productService.GetAllProductAsync(input));


        [HttpGet]
        public async Task<ActionResult<ProductDetailsDto>> GetProductById(int? id)
         => Ok(await _productService.GetProductByIdAsync(id));

    }
}
