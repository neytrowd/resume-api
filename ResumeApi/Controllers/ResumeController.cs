using Microsoft.AspNetCore.Mvc;
using ResumeApi.Contract.Api.Resume.Request;
using ResumeApi.Contract.Api.Resume.Response;
using ResumeApi.Services.Resume;

namespace ResumeApi.Controllers
{
    [Route("api/resume")]
    public class ResumeController : BaseController
    {
        private readonly IResumeService _resumeService;
        
        public ResumeController(IResumeService resumeService)
        {
            _resumeService = resumeService;
        }
        
        [HttpGet]
        public string GetResumes()
        {
            return "";
        }
        
        [HttpGet("{id}")]
        public string GetResume([FromQuery] long id)
        {
            return "";
        }
        
        [HttpPost]
        public CreateResumeResponse CreateResume([FromForm] CreateResumeRequest request)
        {
            var resume = _resumeService.CreateResume(request);

            return new CreateResumeResponse()
            {
                Resume = resume.Result
            };
        }
    }
}