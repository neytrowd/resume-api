using System.Text.Json;
using ResumeApi.Contract.Models;
using ResumeApi.Contract.Api.Resume.Request;

namespace ResumeApi.Services.Resume
{
    public class ResumeService: IResumeService
    {
        private string _dbPath;
        private IWebHostEnvironment _hostEnvironment;
        private IConfiguration _configuration;

        public ResumeService(
            IWebHostEnvironment environment,
            IConfiguration configuration)
        {
            _hostEnvironment = environment;
            _configuration = configuration;
            _dbPath = Path.Combine(_hostEnvironment.ContentRootPath, "db.txt");
        }
        
        public async Task<List<ResumeModel>> GetResumes()
        {
            var jsonData = File.ReadAllText(_dbPath);
            var resumeList = JsonSerializer.Deserialize<List<ResumeModel>>(jsonData);
            foreach (var resume in resumeList)
            {
                resume.Files = resume.Files.Select(x => Path.Combine(_configuration["LaunchUrl"], x)).ToList();
            }
            return resumeList;
        }

        public async Task<ResumeModel> GetResume(long id)
        {
            var jsonData = File.ReadAllText(_dbPath);
            var resumeList = JsonSerializer.Deserialize<List<ResumeModel>>(jsonData);
            var resume = resumeList.FirstOrDefault(item => item.Id == id);
            
            resume.Files = resume.Files.Select(x => Path.Combine(_configuration["LaunchUrl"], x)).ToList();

            return resume;
        }

        public async Task<ResumeModel> CreateResume(CreateResumeRequest request)
        {
            var resumeModel = new ResumeModel()
            {
                Id = DateTime.Now.Ticks,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Files = new List<string>()
            };

            if (request.Files.Count > 0)
            {
                foreach (var file in request.Files)
                {
                    var guid = Guid.NewGuid().ToString();
                    var fileExtension = Path.GetExtension(file.FileName);
                    var newFileName = $"{guid}{fileExtension}";
                    var filePath = Path.Combine(_hostEnvironment.WebRootPath, newFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    
                    resumeModel.Files.Add(newFileName);
                }
            }
            
            var jsonData = File.ReadAllText(_dbPath);
            var resumeList = JsonSerializer.Deserialize<List<ResumeModel>>(jsonData);
            resumeList.Add(resumeModel);
            File.WriteAllText(_dbPath, JsonSerializer.Serialize(resumeList));

            return resumeModel;
        }
    }
}