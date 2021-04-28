using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularMaterial2DotNetCoreSPA.Models.Auxiliary
{
    public class GetFIO
    {
        public string Fio(String _name, String _secondname, String _fathersName)
        {
            if(_name.Equals("Не задано") && _secondname.Equals("Не задано"))
            {
                return  _fathersName;
            }
            else if(_secondname.Equals("Не задано"))
            {
              return  StringParse(_name) + "." + _fathersName;
            }
            else if(_fathersName.Equals("Не задано"))
            {
                return _name + " " + _secondname;
            }
            else
            {
                return StringParse(_name) + "." + StringParse(_secondname) + "." + _fathersName;
            }

            
            
            
        }

        private static string StringParse(String _inputString)
        {
            return _inputString.Substring(0,1);
        }
    }
}
