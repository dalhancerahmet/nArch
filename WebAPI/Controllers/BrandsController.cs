using Application.Features.Brands.Commands.CreateBrand;
using Application.Features.Brands.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBrandCommand createBrandCommand)
        {
            //Add metoduna bir istek geldiği zaman MEdiator.Send ile ilgili class'a(createBrandCommand) sevk ediyor(Gönderiyor/yolluyor).
           CreatedBrandDto results= await Mediator.Send(createBrandCommand);
            return Created("",results);
        }
    }
}
