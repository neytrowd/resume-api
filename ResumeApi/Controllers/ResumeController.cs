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
        public async Task<GetResumesResponse> GetResumes()
        {
            var resumes = await _resumeService.GetResumes();
            
            return new GetResumesResponse()
            {
                Resumes = resumes
            };
        }
        
        [HttpGet("{id}")]
        public async Task<GetResumeResponse> GetResume([FromRoute] long id)
        {
            var resume = await _resumeService.GetResume(id);
            
            return new GetResumeResponse()
            {
                Resume = resume
            };
        }
        
        [HttpPost]
        public async Task<CreateResumeResponse> CreateResume([FromForm] CreateResumeRequest request)
        {
            var resume = await _resumeService.CreateResume(request);

            return new CreateResumeResponse()
            {
                Resume = resume
            };
        }
    }
}