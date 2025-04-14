using AdminNotificator.Application.Services;
using AdminNotificator.Core.Domain;
using Microsoft.AspNetCore.Mvc;

namespace AdminNotificator.WebApi.Controllers;

[ApiController]
[Route("/api")]
public class EmailTypeController(IEmailTypeService emailTypeService, ILogger logger) : Controller
{
    [HttpGet]
    [Route("/api/emailTypes")]
    public IActionResult GetAll()
    {
        var result = emailTypeService.GetAll();
        logger.LogInformation($"Method: GetAll; StatusCode: {Results.Ok()}");
        return Ok(result);
    }
    
    [HttpGet]
    [Route("/api/emailType")]
    public IActionResult Get(int id)
    {
        var result = emailTypeService.Get(id);
        logger.LogInformation($"Method: Get; StatusCode: {Results.Ok()}");
        return Ok(result);
    }
    
    [HttpDelete]
    [Route("/api/emailType")]
    public IActionResult Delete([FromBody] EmailType emailType)
    {
        var result = emailTypeService.Delete(emailType);
        logger.LogInformation($"Method: Delete; StatusCode: {Results.Ok()}");
        return Ok(result);
    }
    
    [HttpPut]
    [Route("/api/emailType")]
    public IActionResult Update([FromBody] EmailType emailType)
    {
        var result = emailTypeService.Update(emailType);
        logger.LogInformation($"Method: Update; StatusCode: {Results.Ok()}");
        return Ok(result);
    }
    
    [HttpPost]
    [Route("/api/emailType")]
    public IActionResult Add([FromBody] EmailType emailType)
    {
        var result = emailTypeService.Add(emailType);
        logger.LogInformation($"Method: Add; StatusCode: {Results.Ok()}");
        return Ok(result);
    }
}