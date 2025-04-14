using AdminNotificator.Application.Models.UserProfile;
using AdminNotificator.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdminNotificator.WebApi.Controllers;

[ApiController]
[Route("/api")]
public class UserProfileController(IUserProfileService userProfileService, ILogger logger) : Controller
{
    [HttpGet]
    [Route("/api/UserProfile")]
    public async Task<IActionResult> GetAll([FromQuery] int pageIndex, [FromQuery] int pageSize)
    {
        var result = await userProfileService.GetAll(pageIndex, pageSize);
        logger.LogInformation($"UserProfileController; Method: GetAll; StatusCode: {Results.Ok()}");
        return Ok(result);
    }

    [HttpGet]
    [Route("/api/UserProfiles{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var result = await userProfileService.Get(id);
        logger.LogInformation($"UserProfileController; Method: Get; StatusCode: {Results.Ok()}");
        return Ok(result);
    }

    [HttpDelete]
    [Route("/api/UserProfile")]
    public async Task<IActionResult> Delete([FromBody] UserProfileDeleteDTO userProfile)
    {
        await userProfileService.Delete(userProfile);
        logger.LogInformation($"UserProfileController; Method: Delete; StatusCode: {Results.Ok()}");
        return Ok();
    }

    [HttpPut]
    [Route("/api/UserProfile")]
    public async Task<IActionResult> Update([FromBody] UserProfileUpdateDTO userProfile)
    {
        await userProfileService.Update(userProfile);
        logger.LogInformation($"UserProfileController; Method: Update; StatusCode: {Results.Ok()}");
        return Ok();
    }

    [HttpPost]
    [Route("/api/UserProfile")]
    public async Task<IActionResult> Add([FromBody] UserProfileAddDTO userProfile)
    {
        var result = await userProfileService.Add(userProfile);
        logger.LogInformation($"UserProfileController; Method: Add; StatusCode: {Results.Ok()}");
        return Ok(result);
    }
}