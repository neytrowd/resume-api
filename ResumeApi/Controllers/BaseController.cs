using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ResumeApi.Controllers
{
    [ApiController]
    [AllowAnonymous]
    public class BaseController : Controller
    {
        
    }
}