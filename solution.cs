[HttpPost("delete/{id}")]
public IActionResult Delete(uint id)
{
    var user = _context.Users.FirstOrDefault(u => u.id == id);
    if (user == null)
    {
        return NotFound();
    }

    _context.Users.Remove(user);
    try
    {
        _context.SaveChanges();
    }
    catch (Exception ex)
    {
        
        return StatusCode(500, "Internal server error");
    }

    
    Debug.WriteLine($"The User with Login = {user.Login} has been deleted.");
    return Ok();
}