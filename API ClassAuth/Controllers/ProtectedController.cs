using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_ClassAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProtectedController : ControllerBase
    {
        // GET: api/protected
        [HttpGet]
        [Authorize]
        public IActionResult GetProtectedData()
        {
            // You can access the authenticated user's information via User.Identity.Name, User.Identity.IsAuthenticated, etc.
            var username = User.Identity.Name;

            // In a real application, you might retrieve protected data from the database or perform other actions.
            // For this example, we'll just return a simple response.
            return Ok(new { Message = "Protected data accessed successfully!" });
        }



        // GET: api/protected/custom-authorization
        [HttpGet("custom-authorization")]
        public IActionResult GetProtectedDataCustomAuth([FromHeader] string authorization)
        {
            if (string.IsNullOrWhiteSpace(authorization))
            {
                return Unauthorized();
            }

            if (!authorization.StartsWith("Bearer "))
            {
                return Unauthorized();
            }

            var token = authorization.Substring("Bearer ".Length).Trim();

            try
            {
                // You should use the same validation logic as in the Startup.cs file to validate the JWT token.
                // In a real application, you would typically use a service to handle token validation and authorization.
                // For this example, we'll just demonstrate the basic idea.
                // Token validation logic here...
            }
            catch (Exception)
            {
                return Unauthorized();
            }

            // Token is valid, you can proceed with your protected logic.
            // For this example, we'll just return a simple response.
            return Ok(new { Message = "Protected data accessed successfully using custom authorization" });
        }
    }
}
