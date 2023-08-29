using ResumeApi.Contract.Api.Resume.Request;
using ResumeApi.Contract.Models;

namespace ResumeApi.Services.Resume
{
    public interface IResumeService
    {
        Task<List<ResumeModel>> GetResumes();

        Task<ResumeModel> GetResume(string id);

        Task<ResumeModel> CreateResume(CreateResumeRequest request);
    }
}