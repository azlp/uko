using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AngularMaterial2DotNetCoreSPA.Models.Auxiliary
{
    public class NullChecker
    {
       
            public int checkIntDBNull(Object obj)
            {
                return obj == DBNull.Value ? 0 : (int)obj;
            }

            public Object convertIntToObject(Object obj)
            {

                return  obj == DBNull.Value ? null : obj;

                  
                   
            }

           public String convertObjectToString(Object obj)
           {

             if(!obj.ToString().Equals("null"))
            {
              return  obj.ToString();
            }
             else
            {
                return String.Empty;
            }
           
           }

           

            public int checkIntNull(Object obj)
            {
                return obj == null ? 0 : (int)obj;
            }

            public string checkStringNull(String _string)
            {
                if(String.IsNullOrEmpty(_string))
                {
                return "Не задано";
                }
                else
            {
                return _string;
            }
               
            }

        public string checkStringNullReturnEmptyString(String _string)
        {
            if (String.IsNullOrEmpty(_string))
            {
                return String.Empty;
            }
            else
            {
                return _string;
            }
        }

        public string checkStringDBNull(Object _obj)
            {
                return _obj == DBNull.Value ? "Не задано" : _obj.ToString();
            }

            public string checkLastDateNull(Object _objfirsDate, Object _lastDate)
            {

                return _lastDate == DBNull.Value ? _objfirsDate.ToString() : " c " + _objfirsDate.ToString() + "  по  " + _lastDate.ToString();
            }

            public string assemblyDateForShow(DateTime _objfirsDate, int _hourseBegin, int _minutesBegin, DateTime _lastDate, int _horseEnd, int _minutesEnd)
            {

                return "";
            }

            public DateTime checkDateTimeNull(DateTime _date)
            {
               

                //В случае если дата не задана ставиться текующая дата, как дата рождения, создания Уко
                if (_date.Equals(DBNull.Value))
                {
                    _date = DateTime.UtcNow.Date;

                return _date;
                }
                else
                {

                    return _date;

                }


            }

        public DateTime checkDateTimeNullNotDb(DateTime _date)
        {
           
            //В случае если дата не задана ставиться текующая дата, как дата рождения, создания Уко
            if (_date.ToString().Contains("0001"))
            {
                _date = DateTime.UtcNow.Date;

                return _date;
            }
            else
            {

                return _date;

            }


        }

    }
}
