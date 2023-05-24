using Microsoft.AspNetCore.Mvc;

namespace PinPointCallerVersionOne.Controllers;

[Route("[controller]")]
public class PinPointsController : ControllerBase
{
    private readonly IPinPointHandler _pinPointHandler;
    public PinPointsController(IPinPointHandler pinPointHandler)
    {
        _pinPointHandler = pinPointHandler;
    }
    
    // POST api/values
    [HttpPost]
    [Route("call")]
    public void Post([FromBody]EventData eventData)
    {
        _pinPointHandler.Handler(eventData);
    }

   
}