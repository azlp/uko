using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AngularMaterial2DotNetCoreSPA.Requests.Resourses;
using AngularMaterial2DotNetCoreSPA.Models;
using AngularMaterial2DotNetCoreSPA.Models.Auxiliary;
using AngularMaterial2DotNetCoreSPA.Models.UKO;

namespace AngularMaterial2DotNetCoreSPA.Controllers
{

    [Route("api/[controller]")]
    public class DataController : Controller
    {

        ResourseRequest resourse = new ResourseRequest();

        [HttpPost("[action]")]
        
        public string AddNewResourse([FromBody]ResourseModel _newresourse)
       {

            return resourse.AddNewResourse(_newresourse);
            
       }

        [HttpPost("[action]")]
       
        public int UploadImage([FromBody]ResourseModel _formModel)
        {



            return resourse.UploadImage(_formModel);


        }

        [HttpPost("[action]")]
        
        public int AddResourseSpecification([FromBody]ResourseModel _newresourse)
        {
            
            return resourse.AddResourseSpecification(_newresourse);


        }

        [HttpGet("[action]")]
        
        public IEnumerable<ResourseModel> GetResoursesList()
        {

            return resourse.GetResoursesList();
        }

        [HttpPost("[action]")]
       
        public ResourseModel GetResourseInfo([FromBody]ResourseModel _resourseId)
        {

            return resourse.GetResourseInfo(_resourseId);
        }

        [HttpPost("[action]")]
       
        public int CountOffResourse([FromBody]ResourseModel _resoursecount)
        {

            return resourse.CountOffResourse(_resoursecount);
        }

        [HttpPost("[action]")]

        public int AddResoursesToUko([FromBody]ResourseModel _resourse)
        {

            return resourse.AddResoursesToUko(_resourse);
        }

        [HttpPost("[action]")]
        public int DeleteResoursesFromUko([FromBody]ResourseModel _resourse)
        {

            return resourse.DeleteResoursesFromUko(_resourse);
        }

        [HttpPost("[action]")]

        public IEnumerable<ResourseModel> GetListResoursesOfUko([FromBody]UKOmodel _ukoid)
        {

            return resourse.GetListResoursesOfUko(_ukoid);
        }
    }
}
