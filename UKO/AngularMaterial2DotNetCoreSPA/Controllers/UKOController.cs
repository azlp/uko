using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AngularMaterial2DotNetCoreSPA.Requests.Resourses;
using AngularMaterial2DotNetCoreSPA.Models.UKO;
using AngularMaterial2DotNetCoreSPA.Models.Auxiliary;

namespace AngularMaterial2DotNetCoreSPA.Controllers
{

    [Route("api/[controller]")]
    public class UKOController : Controller
    {
        //UKORequest uko = new UKORequest();

        UKORequests uko = new UKORequests();
      
        [HttpPost("[action]")]
        public string AddNewUko([FromBody]UKOmodel _newuco)
        {

            return uko.AddNewUko(_newuco);
            
        }

        [HttpPost("[action]")]
        public int UpdateUkoName([FromBody]UKOmodel _uko)
        {

            return uko.UpdateUkoName(_uko);

        }


        [HttpPost("[action]")]
        public string AddNewUkoJur([FromBody]UKOmodel _newuco)
        {

            return uko.AddNewUkoJur(_newuco);

        }

        [HttpPost("[action]")]
        public int UpdateUkoJur([FromBody]UKOmodel _uko)
        {

            return uko.UpdateUkoJur(_uko);

        }

        [HttpPost("[action]")]
        public string AddNewUkoAdress([FromBody]Adress _newadress)
        {

            return uko.AddNewAdressOffUko(_newadress);

        }

        [HttpPost("[action]")]
        public string AddNewDocsOffUko([FromBody]Docs _newdocument)
        {

            return uko.AddNewDocsOffUko(_newdocument);

        }




        [HttpGet("[action]")]
        public List<UKOmodel> GetListOfAllUKO()
        {

            return uko.GetListOffAllUko();

        }

        [HttpPost("[action]")]
        public List<Adress> GetListOffAdress([FromBody]UKOmodel _uko)
        {

            return uko.GetListOffAdress(_uko);

        }

        [HttpPost("[action]")]
        public List<Docs> GetListOffDocs([FromBody]UKOmodel _uko)
        {

            return uko.GetListOffDocs(_uko);

        }

        [HttpPost("[action]")]
        public UKOmodel GetPersonalUkoInfo([FromBody]UKOmodel _uko)
        {

            return uko.GetPersonalUkoInfo(_uko);

        }

       

         [HttpPost("[action]")]
        public UKOmodel GetBuisinessEntityUkoInfo([FromBody]UKOmodel _uko)
        {

            return uko.GetBuisinessEntityUkoInfo(_uko);

        }

    }
}