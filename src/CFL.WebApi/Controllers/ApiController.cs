using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace CFL.WebApi.Controllers;

[ApiController]
public abstract class ApiController : Controller
{
    private IMediator _mediator;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

}