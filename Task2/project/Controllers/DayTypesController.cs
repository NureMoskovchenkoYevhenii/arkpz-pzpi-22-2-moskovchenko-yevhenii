using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class DayTypesController : ControllerBase
{
    private readonly DayTypeService _dayTypeService;
    private readonly DayTypeMapper _dayTypeMapper;

    public DayTypesController(DayTypeService dayTypeService, DayTypeMapper dayTypeMapper)
    {
        _dayTypeService = dayTypeService;
        _dayTypeMapper = dayTypeMapper;
    }

    [HttpGet]
    public IActionResult GetAllDayTypes()
    {
        var dayTypes = _dayTypeService.GetAllDayTypes();
        var dayTypeDtos = dayTypes.Select(dayType => _dayTypeMapper.MapToDto(dayType));
        return Ok(dayTypeDtos);
    }

    [HttpGet("{id}")]
    public IActionResult GetDayTypeById(int id)
    {
        var dayType = _dayTypeService.GetDayTypeById(id);
        if (dayType == null)
        {
            return NotFound();
        }
        var dayTypeDto = _dayTypeMapper.MapToDto(dayType);
        return Ok(dayTypeDto);
    }

    [HttpPost]
    public IActionResult AddDayType(DayTypeDto dayTypeDto)
    {
        var dayType = _dayTypeMapper.MapToEntity(dayTypeDto);
        _dayTypeService.AddDayType(dayType);
        return CreatedAtAction(nameof(GetDayTypeById), new { id = dayType.DayTypeId }, dayTypeDto);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateDayType(int id, DayTypeDto updatedDayTypeDto)
    {
        var updatedDayType = _dayTypeMapper.MapToEntity(updatedDayTypeDto);
        _dayTypeService.UpdateDayType(id, updatedDayType);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteDayType(int id)
    {
        _dayTypeService.DeleteDayType(id);
        return NoContent();
    }
}
