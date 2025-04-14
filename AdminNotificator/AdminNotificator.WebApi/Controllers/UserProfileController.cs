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
    public IActionResult GetAll()
    {
        var result = userProfileService.GetAll();
        logger.LogInformation($"UserProfileController; Method: GetAll; StatusCode: {Results.Ok()}");
        return Ok(result);
    }

    [HttpGet]
    [Route("/api/UserProfiles")]
    public IActionResult Get(int id)
    {
        var result = userProfileService.Get(id);
        logger.LogInformation($"UserProfileController; Method: Get; StatusCode: {Results.Ok()}");
        return Ok(result);
    }

    [HttpDelete]
    [Route("/api/UserProfile")]
    public IActionResult Delete(UserProfile userProfile)
    {
        var result = userProfileService.Delete(userProfile);
        logger.LogInformation($"UserProfileController; Method: Delete; StatusCode: {Results.Ok()}");
        return Ok(result);
    }

    [HttpPut]
    [Route("/api/UserProfile")]
    public IActionResult Update(UserProfile userProfile)
    {
        var result = userProfileService.Update(userProfile);
        logger.LogInformation($"UserProfileController; Method: Update; StatusCode: {Results.Ok()}");
        return Ok(result);
    }

    [HttpPost]
    [Route("/api/UserProfile")]
    public IActionResult Add(UserProfile userProfile)
    {
        var result = userProfileService.Add(userProfile);
        logger.LogInformation($"UserProfileController; Method: Add; StatusCode: {Results.Ok()}");
        return Ok(result);
    }
}