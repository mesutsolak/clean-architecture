﻿namespace App.Application.Features.Products;

public class ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork, IMapper mapper) : IProductService
{
    public async Task<ServiceResult<CreateProductResponse>> CreateAsync(CreateProductRequest request)
    {
        var isAnyProduct = await productRepository.AnyAsync(x => x.Name.Equals(request.Name));

        if (isAnyProduct)
            return ServiceResult<CreateProductResponse>.Fail("Product found", HttpStatusCode.BadRequest);

        var product = mapper.Map<Product>(request);

        await productRepository.AddAsync(product);
        await unitOfWork.SaveChangesAsync();

        return ServiceResult<CreateProductResponse>.SuccessAsCreated(new CreateProductResponse(product.Id), $"api/products/{product.Id}");
    }

    public async Task<ServiceResult<List<ProductDto>>> GetAllListAsync()
    {
        var products = await productRepository.GetAllAsync();

        var productAsDto = mapper.Map<List<ProductDto>>(products);

        return ServiceResult<List<ProductDto>>.Success(productAsDto);
    }

    public async Task<ServiceResult<ProductDto?>> GetByIdAsync(int id)
    {
        var product = await productRepository.GetByIdAsync(id);

        if (product is null)
            return ServiceResult<ProductDto?>.Fail("Product not found", HttpStatusCode.NotFound);

        var productAsDto = mapper.Map<ProductDto>(product);

        return ServiceResult<ProductDto>.Success(productAsDto)!;
    }

    public async Task<ServiceResult<List<ProductDto>>> GetTopPriceProductsAsync(int count)
    {
        var products = await productRepository.GetTopPriceProductsAsync(count);

        var productsAsDto = mapper.Map<List<ProductDto>>(products!);

        return ServiceResult<List<ProductDto>>.Success(productsAsDto);
    }

    public async Task<ServiceResult> UpdateAsync(int id, UpdateProductRequest request)
    {
        var isProductNameExist = await productRepository.AnyAsync(x => x.Name == request.Name && x.Id != id);

        if (isProductNameExist)
            return ServiceResult.Fail("ürün ismi veritabanında bulunmaktadır.", HttpStatusCode.BadRequest);

        var product = mapper.Map<Product>(request);
        product.Id = id;

        productRepository.Update(product);
        await unitOfWork.SaveChangesAsync();

        return ServiceResult.Success(HttpStatusCode.NoContent);
    }

    public async Task<ServiceResult> DeleteAsync(int id)
    {
        var product = await productRepository.GetByIdAsync(id);

        productRepository.Delete(product!);
        await unitOfWork.SaveChangesAsync();

        return ServiceResult.Success(HttpStatusCode.NoContent);
    }

    public async Task<ServiceResult<List<ProductDto>>> GetPagedAllListAsync(int pageNumber, int pageSize)
    {
        var products = await productRepository.GetAllPagedAsync(pageNumber, pageSize);

        var productsAsDto = mapper.Map<List<ProductDto>>(products);

        return ServiceResult<List<ProductDto>>.Success(productsAsDto!);
    }

    public async Task<ServiceResult> UpdateStockAsync(UpdateProductStockRequest request)
    {
        var product = await productRepository.GetByIdAsync(request.ProductId);

        if (product is null)
            return ServiceResult.Fail("Product not found", HttpStatusCode.NotFound);

        product.Stock = request.Quantity;

        productRepository.Update(product);
        await unitOfWork.SaveChangesAsync();

        return ServiceResult.Success(HttpStatusCode.NoContent);
    }
}