using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly UserService _userService;
    private readonly UserMapper _userMapper;

    public UsersController(UserService userService, UserMapper userMapper)
    {
        _userService = userService;
        _userMapper = userMapper;
    }

    [HttpGet]
    public IActionResult GetAllUsers()
    {
        var users = _userService.GetAllUsers();
        var userDtos = users.Select(user => _userMapper.MapToDto(user));
        return Ok(userDtos);
    }

    [HttpGet("{id}")]
    public IActionResult GetUserById(int id)
    {
        var user = _userService.GetUserById(id);
        if (user == null)
        {
            return NotFound();
        }
        var userDto = _userMapper.MapToDto(user);
        return Ok(userDto);
    }

    [HttpPost]
    public IActionResult AddUser(UserDto userDto)
    {
        var user = _userMapper.MapToEntity(userDto);
        _userService.AddUser(user);
        return CreatedAtAction(nameof(GetUserById), new { id = user.UserId }, userDto);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, UserDto updatedUserDto)
    {
        var updatedUser = _userMapper.MapToEntity(updatedUserDto);
        _userService.UpdateUser(id, updatedUser);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        _userService.DeleteUser(id);
        return NoContent();
    }
}
