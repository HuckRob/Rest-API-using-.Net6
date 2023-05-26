using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BuberBreakfast.Controllers;

[ApiController]

//[Route("breakfast")] //this allows me to not have to have /breakfast in every route
[Route("[controller]")] //this works like above, but takes the name of the controller and uses that as the route minus the controller in the name
public class ApiController : ControllerBase
{
    protected IActionResult Problem(List<Error> errors)
    {
        if(errors.All(e => e.Type == ErrorType.Validation))
        {   
            var modelStateDictionary = new ModelStateDictionary();
            foreach(var error in errors)
            {
                modelStateDictionary.AddModelError(error.Code, error.Description);
            }
            return ValidationProblem(modelStateDictionary);
        }

        if(errors.Any(e => e.Type == ErrorType.Unexpected)){
            return Problem();
        }
        var firstError = errors[0];
        var statusCode = firstError.Type switch
        {
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            _ => StatusCodes.Status500InternalServerError
        };
        return Problem(statusCode: statusCode, title: firstError.Description);
    }
}