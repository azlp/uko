using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularMaterial2DotNetCoreSPA.Models.Auxiliary
{
    public class FormModel
    {
        public int Id { get; set; }

        public string ResourseId { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public bool IsDeleted { get; set; }
        public IFormFile File { get; set; }
    }
}
