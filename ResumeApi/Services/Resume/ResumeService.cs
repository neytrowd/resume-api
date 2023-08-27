using ResumeApi.Contract.Api.Resume.Request;
using ResumeApi.Contract.Models;

namespace ResumeApi.Services.Resume
{
    public class ResumeService: IResumeService
    {
        private string _dbPath;
        private IWebHostEnvironment _hostEnvironment;

        public ResumeService(IWebHostEnvironment environment)
        {
            _hostEnvironment = environment;
            _dbPath = Path.Combine(_hostEnvironment.ContentRootPath, "db.txt");
        }
        
        public Task<List<ResumeModel>> GetResumes()
        {
            throw new NotImplementedException();
        }

        public Task<ResumeModel> GetResume(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ResumeModel> CreateResume(CreateResumeRequest request)
        {
            throw new NotImplementedException();
        }
    }
}