using System;
using System.Net;
using DiveSpots.InterfaceAdapters.Api.Core;
using DiveSpots.SharedKernel;
using Microsoft.AspNetCore.Mvc;

namespace DiveSpots.Web.Core
{
    public abstract class ApiControllerBase : Controller
    {
        protected IActionResult CreateResult<T>(UseCaseResult useCaseResult, IObjectPresenter<T> presenter) =>
            useCaseResult.ResultCategory switch
            {
                ResultCategory.Success => (IActionResult) Ok(presenter.GetOutputModel()),
                ResultCategory.GeneralFailure => StatusCode((int) HttpStatusCode.InternalServerError),
                ResultCategory.ValidationFailed => BadRequest(),
                ResultCategory.NotFound => NotFound(),
                ResultCategory.AccessDenied => Forbid(),
                _ => StatusCode((int) HttpStatusCode.InternalServerError)
            };
    }
}