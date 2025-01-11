using Contracts.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Product.API.Entities;
using Product.API.Persistence;

namespace Product.API.Controllers;

[ApiController]
[Route(template: "api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IRepositoryBaseAsync<CatalogProduct, long, ProductContext> _repository;

    public ProductsController(IRepositoryBaseAsync<CatalogProduct, long, ProductContext> repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var result = await _repository.FindAll().ToListAsync();
        return Ok(result);
    }
}