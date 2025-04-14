using AdminNotificator.Application.Services;
using AdminNotificator.Core.Domain;
using Microsoft.AspNetCore.Mvc;

namespace AdminNotificator.WebApi.Controllers;

[ApiController]
[Route("/api")]
public class EmailTypeController(IEmailTypeService emailTypeService) : Controller
{
    [HttpGet]
    [Route("/api/emailTypes")]
    public IActionResult GetAll()
    {
        var result = emailTypeService.GetAll();
        return Ok(result);
    }
    
    [HttpGet]
    [Route("/api/emailType")]
    public IActionResult Get(int id)
    {
        var result = emailTypeService.Get(id);
        return Ok(result);
    }
    
    [HttpDelete]
    [Route("/api/emailType")]
    public IActionResult Delete([FromBody] EmailType emailType)
    {
        var result = emailTypeService.Delete(emailType);
        return Ok(result);
    }
    
    [HttpPut]
    [Route("/api/emailType")]
    public IActionResult Update([FromBody] EmailType emailType)
    {
        var result = emailTypeService.Update(emailType);
        return Ok(result);
    }
    
    [HttpPost]
    [Route("/api/emailType")]
    public IActionResult Add([FromBody] EmailType emailType)
    {
        var result = emailTypeService.Add(emailType);
        return Ok(result);
    }
}