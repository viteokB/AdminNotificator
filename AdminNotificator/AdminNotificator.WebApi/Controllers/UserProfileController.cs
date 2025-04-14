using AdminNotificator.Application.Services;
using AdminNotificator.Core.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AdminNotificator.WebApi.Controllers;

[ApiController]
[Route("/api")]
public class UserProfileController(IUserProfileService userProfileService, ILogger logger) : Controller
{
    [HttpGet]
    [Route("/api/UserProfile")]
    public async Task<IActionResult> GetAll()
    {
        var result = await userProfileService.GetAll();
        logger.LogInformation($"UserProfileController; Method: GetAll; StatusCode: {Results.Ok()}");
        return Ok(result);
    }

    [HttpGet]
    [Route("/api/UserProfiles{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await userProfileService.Get(id);
        logger.LogInformation($"UserProfileController; Method: Get; StatusCode: {Results.Ok()}");
        return Ok(result);
    }

    [HttpDelete]
    [Route("/api/UserProfile")]
    public async Task<IActionResult> Delete([FromBody] UserProfile userProfile)
    {
        await userProfileService.Delete(userProfile);
        logger.LogInformation($"UserProfileController; Method: Delete; StatusCode: {Results.Ok()}");
        return Ok();
    }

    [HttpPut]
    [Route("/api/UserProfile")]
    public async Task<IActionResult> Update([FromBody] UserProfile userProfile)
    {
        await userProfileService.Update(userProfile);
        logger.LogInformation($"UserProfileController; Method: Update; StatusCode: {Results.Ok()}");
        return Ok();
    }

    [HttpPost]
    [Route("/api/UserProfile")]
    public async Task<IActionResult> Add([FromBody] UserProfile userProfile)
    {
        var result = await userProfileService.Add(userProfile);
        logger.LogInformation($"UserProfileController; Method: Add; StatusCode: {Results.Ok()}");
        return Ok(result);
    }
}