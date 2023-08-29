﻿namespace ResumeApi.Contract.Models
{
    public class ResumeModel
    {
        public string Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Email { get; set; }
        
        public List<string> Files { get; set; }
    }
}