using ResumeApi.Contract.Models;

namespace ResumeApi.Contract.Api.Resume.Response
{
    public class GetResumesResponse
    {
        public List<ResumeModel> Resumes { get; set; }
    }
}