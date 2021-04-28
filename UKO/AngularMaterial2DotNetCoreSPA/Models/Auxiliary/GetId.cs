using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AngularMaterial2DotNetCoreSPA.Models.Auxiliary
{
    public class GetId
    {
        public string getHash(String _input)
        {
            var hash = (new SHA1Managed()).ComputeHash(Encoding.UTF8.GetBytes(_input));
            
            return string.Join("", hash.Select(b => b.ToString("x2")).ToArray()) + GetRandom(_input);
        }

        private string GetRandom(String _input)
        {
            Random rnd = new Random();

            return rnd.Next(1,_input.Length).ToString();
        }
    }
}
