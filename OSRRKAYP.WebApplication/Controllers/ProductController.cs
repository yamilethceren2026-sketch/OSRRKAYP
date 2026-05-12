using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OSRRKAYP.BusinessLogic.UseCases.Products.Commands.CreateProduct;
using OSRRKAYP.BusinessLogic.UseCases.Products.Commands.UpdateProduct;
using OSRRKAYP.BusinessLogic.UseCases.Products.Queries.GetProduct;
using OSRRKAYP.BusinessLogic.UseCases.Products.Queries.GetProducts;
using System.Collections;

namespace OSRRKAYP.WebApplication.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: ProductController
        public async Task<IActionResult> Index()
        {
            var products = await _mediator.Send(new GetProductsQuery());

            return View(products);
        }

        // GET: ProductController/Create
        public async Task<IActionResult> Create()
        {
            var brands = await _mediator.Send(new GetBrandsQuery());

            ViewData["BrandId"] =
                new SelectList(brands, "BrandId", "BrandName");

            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create
            (CreateProductRequest createProductRequest)
        {
            try
            {
                var result = await _mediator
                    .Send(new CreateProductCommand(createProductRequest));

                if (result > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    throw new Exception
                        ("Sucedió un error al guardar el producto");
                }
            }
            catch (Exception ex)
            {
                var brands = await _mediator.Send(new GetBrandsQuery());

                ViewData["BrandId"] =
                    new SelectList(brands, "BrandId", "BrandName");

                ModelState.AddModelError("", ex.Message);

                return View(createProductRequest);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _mediator
                .Send(new GetProductQuery(id));

            var brands = await _mediator
                .Send(new GetBrandsQuery());

            ViewData["BrandId"] =
                new SelectList
                (
                    brands,
                    "BrandId",
                    "BrandName",
                    product.BrandId
                );

            return View(product.Adapt(new UpdateProductRequest()));
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit
            (UpdateProductRequest updateProductRequest)
        {
            try
            {
                var result = await _mediator
                    .Send(request: new UpdateProductCommand(updateProductRequest));

                if (result > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    throw new Exception
                        ("Sucedió un error al editar el producto");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

                var brands = await _mediator
                    .Send(new GetBrandsQuery());

                ViewData["BrandId"] =
                    new SelectList
                    (brands,
                     "BrandId",
                     "BrandName",
                     updateProductRequest.BrandId);

                return View(updateProductRequest);
            }
        }
    }

    internal class UpdateProductRequest
    {
        public UpdateProductRequest()
        {
        }
    }

    internal class GetBrandsQuery : IRequest<IEnumerable>
    {
    }
}
