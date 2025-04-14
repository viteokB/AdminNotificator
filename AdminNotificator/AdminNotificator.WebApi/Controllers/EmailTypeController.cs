using AdminNotificator.Application.Services;
using AdminNotificator.Core.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AdminNotificator.WebApi.Controllers;

[ApiController]
[Route("/api")]
public class EmailTypeController(IEmailTypeService emailTypeService, ILogger logger) : Controller
{
    [HttpGet]
    [Route("/api/emailTypes")]
    public async Task<IActionResult> GetAll()
    {
        var result = await emailTypeService.GetAll();
        logger.LogInformation($"EmailTypeController; Method: GetAll; StatusCode: {Results.Ok()}");
        return Ok(result);
    }

    [HttpGet]
    [Route("/api/emailType")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await emailTypeService.Get(id);
        logger.LogInformation($"EmailTypeController; Method: Get; StatusCode: {Results.Ok()}");
        return Ok(result);
    }

    [HttpDelete]
    [Route("/api/emailType")]
    public async Task<IActionResult> Delete([FromBody] EmailType emailType)
    {
        await emailTypeService.Delete(emailType);
        logger.LogInformation($"EmailTypeController; Method: Delete; StatusCode: {Results.Ok()}");
        return Ok();
    }

    [HttpPut]
    [Route("/api/emailType")]
    public async Task<IActionResult> Update([FromBody] EmailType emailType)
    {
        await emailTypeService.Update(emailType);
        logger.LogInformation($"EmailTypeController; Method: Update; StatusCode: {Results.Ok()}");
        return Ok();
    }

    [HttpPost]
    [Route("/api/emailType")]
    public async Task<IActionResult> Add([FromBody] EmailType emailType)
    {
        var result = await emailTypeService.Add(emailType);
        logger.LogInformation($"EmailTypeController; Method: Add; StatusCode: {Results.Ok()}");
        return Ok(result);
    }
}