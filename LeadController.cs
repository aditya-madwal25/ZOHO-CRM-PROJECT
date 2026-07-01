using Microsoft.AspNetCore.Mvc;
using ZohoIntegration.Models;
using ZohoIntegration.Services;

namespace ZohoIntegration.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LeadController : ControllerBase
{
    private readonly ZohoService _zohoService;

    public LeadController(ZohoService zohoService)
    {
        _zohoService = zohoService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateLead([FromBody] Lead lead)
    {
        string accessToken = "1000.c9da74dee4bd4f160bc2ec0a4b14c7e2.7410bcf46973dfc60279bb72ab95ba9a";

        var result = await _zohoService.SendLeadAsync(accessToken, lead);

        return Ok(result);
    }
}