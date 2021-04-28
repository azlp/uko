using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

   

namespace AngularMaterial2DotNetCoreSPA.Models
{
    public class ResourseModel
    {
        public string ResourceId { get; set; }

        public string Name { get; set; }
        public string Code { get; set; }

        public string Param { get; set; }

        public int HaveFree { get; set; }

        public int HaveRezerve { get; set; }

        public int Substitution { get; set; }

        public int Total { get; set; }

        public string Image { get; set; }

            

        public Byte[] ImageByteArray { get; set; }


        public string Number { get; set; }

        public string Argo { get; set; }

        public string Developer { get; set; }

        public string Units { get; set; }

        public string Wieight { get; set; }

        public string Lenght { get; set; }

        public string With { get; set; }

        public string Height { get; set; }

        public string Color { get; set; }

        public XmlDocument Specification { get; set; }

        public XDocument SpecificationDoc { get; set; }

        public string Deffects { get; set; }

        public string Comment { get; set; }

        public decimal FutureProbablityMore { get; set; }

        public decimal FutureProbablityMuch { get; set; }

       // public String Specification { get; set; }

        public String Functions { get; set; }

        public String Using { get; set; }

        public string Data { get; set; }

    }
}
