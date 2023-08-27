namespace ResumeApi.Contract.Api.Resume.Request
{
    public class CreateResumeRequest
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Email { get; set; }
        
        public List<IFormFile> Files { get; set; }
    }
}