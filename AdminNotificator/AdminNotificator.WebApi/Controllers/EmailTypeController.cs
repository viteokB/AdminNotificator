using AdminNotificator.Application.IServices;
using AdminNotificator.Application.Models.EmailType;
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
    public async Task<IActionResult> GetAll([FromQuery] int pageIndex, [FromQuery] int pageSize)
    {
        var result = await emailTypeService.GetAll(pageIndex, pageSize);
        logger.LogInformation($"EmailTypeController; Method: GetAll; StatusCode: {Results.Ok()}");
        return Ok(result);
    }

    [HttpGet]
    [Route("/api/emailType/{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var result = await emailTypeService.Get(id);
        logger.LogInformation($"EmailTypeController; Method: Get; StatusCode: {Results.Ok()}");
        return Ok(result);
    }

    [HttpDelete]
    [Route("/api/emailType")]
    public async Task<IActionResult> Delete([FromBody] EmailTypeDeleteDTO emailType)
    {
        await emailTypeService.Delete(emailType);
        logger.LogInformation($"EmailTypeController; Method: Delete; StatusCode: {Results.Ok()}");
        return Ok();
    }

    [HttpPut]
    [Route("/api/emailType")]
    public async Task<IActionResult> Update([FromBody] EmailTypeUpdateDTO emailType)
    {
        await emailTypeService.Update(emailType);
        logger.LogInformation($"EmailTypeController; Method: Update; StatusCode: {Results.Ok()}");
        return Ok();
    }

    [HttpPost]
    [Route("/api/emailType")]
    public async Task<IActionResult> Add([FromBody] EmailTypeAddDTO emailType)
    {
        var result = await emailTypeService.Add(emailType);
        logger.LogInformation($"EmailTypeController; Method: Add; StatusCode: {Results.Ok()}");
        return Ok(result);
    }
}