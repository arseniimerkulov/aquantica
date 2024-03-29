using Aquantica.BLL.Interfaces;
using Aquantica.Contracts.Extensions;
using Aquantica.Contracts.Requests.Rulesets;
using Aquantica.Contracts.Responses.Ruleset;
using Aquantica.Core.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aquantica.API.Controllers;

[ApiController]
[Route("api/[controller]")]
// [Authorize]
public class RuleSetController : ControllerBase
{
    private readonly IRuleSetService _ruleSetService;

    public RuleSetController(IRuleSetService ruleSetService)
    {
        _ruleSetService = ruleSetService;
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetRuleSets(CancellationToken cancellationToken)
    {
        try
        {
            var result = await _ruleSetService.GetAllRuleSetsAsync();

            if (result == null)
            {
                return NotFound(Resources.Get("RULE_SETS_NOT_FOUND").ToApiErrorResponse());
            }

            var response = result.Select(x => new RuleSetResponse
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                IsEnabled = x.IsEnabled,
                WaterConsumptionThreshold = x.WaterConsumptionThreshold,
                IsIrrigationDurationEnabled = x.IsIrrigationDurationEnabled,
                MaxIrrigationDuration = x.MaxIrrigationDuration,
                RainAvoidanceEnabled = x.RainAvoidanceEnabled,
                RainProbabilityThreshold = x.RainProbabilityThreshold,
                RainAmountThreshold = x.RainAmountThreshold,
                HumidityGrowthPerRainMm = x.HumidityGrowthPerRainMm,
                RainAvoidanceDurationThreshold = x.RainAvoidanceDurationThreshold,
                TemperatureThreshold = x.TemperatureThreshold,
                MinSoilHumidityThreshold = x.MinSoilHumidityThreshold,
                OptimalSoilHumidity = x.OptimalSoilHumidity,
                WaterConsumptionPerMinute = x.WaterConsumptionPerMinute,
                HumidityGrowthPerLiterConsumed = x.HumidityGrowthPerLiterConsumed,
            });

            return Ok(response.ToApiListResponse());
        }
        catch (Exception e)
        {
            return BadRequest(Resources.Get("FAILED_TO_GET_RULESETS").ToApiErrorResponse());
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRuleSetById(int id, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _ruleSetService.GetRuleSetByIdAsync(id);

            if (result == null)
            {
                return NotFound(Resources.Get("RULE_SET_NOT_FOUND").ToApiErrorResponse());
            }

            var response = new RuleSetResponse
            {
                Id = result.Id,
                Name = result.Name,
                Description = result.Description,
                IsEnabled = result.IsEnabled,
                WaterConsumptionThreshold = result.WaterConsumptionThreshold,
                IsIrrigationDurationEnabled = result.IsIrrigationDurationEnabled,
                MaxIrrigationDuration = result.MaxIrrigationDuration,
                RainAvoidanceEnabled = result.RainAvoidanceEnabled,
                RainProbabilityThreshold = result.RainProbabilityThreshold,
                RainAmountThreshold = result.RainAmountThreshold,
                HumidityGrowthPerRainMm = result.HumidityGrowthPerRainMm,
                RainAvoidanceDurationThreshold = result.RainAvoidanceDurationThreshold,
                TemperatureThreshold = result.TemperatureThreshold,
                MinSoilHumidityThreshold = result.MinSoilHumidityThreshold,
                OptimalSoilHumidity = result.OptimalSoilHumidity,
                WaterConsumptionPerMinute = result.WaterConsumptionPerMinute,
                HumidityGrowthPerLiterConsumed = result.HumidityGrowthPerLiterConsumed,
            };

            return Ok(response.ToApiResponse());
        }
        catch (Exception e)
        {
            return BadRequest(Resources.Get("FAILED_TO_GET_RULESET").ToApiErrorResponse());
        }
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateRuleSet(CreateRuleSetRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _ruleSetService.CreateRuleSetAsync(request);

            return Ok(result.ToApiResponse());
        }
        catch (Exception e)
        {
            return BadRequest(Resources.Get("FAILED_TO_CREATE_RULESET").ToApiErrorResponse());
        }
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateRuleSet(UpdateRuleSetRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _ruleSetService.UpdateRuleSetAsync(request);

            return Ok(result.ToApiResponse());
        }
        catch (Exception e)
        {
            return BadRequest(Resources.Get("FAILED_TO_UPDATE_RULESET").ToApiErrorResponse());
        }
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteRuleSet(int id)
    {
        try
        {
            var result = await _ruleSetService.DeleteRuleSetAsync(id);

            return Ok(result.ToApiResponse());
        }
        catch (Exception e)
        {
            return BadRequest(Resources.Get("FAILED_TO_DELETE_RULESET").ToApiErrorResponse());
        }
    }

    [HttpGet("section/{sectionId}")]
    public async Task<IActionResult> GetRuleSetsBySectionId(int sectionId)
    {
        try
        {
            var result = await _ruleSetService.GetRuleSetsBySectionIdAsync(sectionId);

            if (result == null)
            {
                return NotFound(Resources.Get("RULE_SETS_NOT_FOUND").ToApiErrorResponse());
            }

            var response = new RuleSetResponse
            {
                Id = result.Id,
                Name = result.Name,
                Description = result.Description,
                IsEnabled = result.IsEnabled,
                WaterConsumptionThreshold = result.WaterConsumptionThreshold,
                IsIrrigationDurationEnabled = result.IsIrrigationDurationEnabled,
                MaxIrrigationDuration = result.MaxIrrigationDuration,
                RainAvoidanceEnabled = result.RainAvoidanceEnabled,
                RainProbabilityThreshold = result.RainProbabilityThreshold,
                RainAmountThreshold = result.RainAmountThreshold,
                HumidityGrowthPerRainMm = result.HumidityGrowthPerRainMm,
                RainAvoidanceDurationThreshold = result.RainAvoidanceDurationThreshold,
                TemperatureThreshold = result.TemperatureThreshold,
                MinSoilHumidityThreshold = result.MinSoilHumidityThreshold,
                OptimalSoilHumidity = result.OptimalSoilHumidity,
                WaterConsumptionPerMinute = result.WaterConsumptionPerMinute,
                HumidityGrowthPerLiterConsumed = result.HumidityGrowthPerLiterConsumed,
            };

            return Ok(response.ToApiResponse());
        }
        catch (Exception e)
        {
            return BadRequest(Resources.Get("FAILED_TO_GET_RULESETS").ToApiErrorResponse());
        }
    }

    [HttpPost("assign")]
    public async Task<IActionResult> AssignRuleSetToSection(AssignRuleSetToSectionRequest request)
    {
        try
        {
            var result = await _ruleSetService.AssignRuleSetToSectionAsync(request.RuleSetId, request.SectionId);

            return Ok(result.ToApiResponse());
        }
        catch (Exception e)
        {
            return BadRequest(Resources.Get("FAILED_TO_ASSIGN_RULESET").ToApiErrorResponse());
        }
    }
}