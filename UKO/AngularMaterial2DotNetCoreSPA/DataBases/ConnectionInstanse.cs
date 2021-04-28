using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace KisOffUko.DataBases
{
    //singleton connection на девелопменте так
    //дебагер при отладке будет шариться по всему блоку безопасности,
    //валерий просил что бы ему было удобно админить роли и сертификаты. 
    //Всё убираем в конфиг перед заливкой в облако. 
    public class ConnectionInstanse
    {
        private static volatile SqlConnection instance;

        private static volatile SqlConnection instanceResourses;

        private static object syncRoot = new object();
        
        // не забыть до выкладки на Azure всё потереть
        /*connection string for uko  below*/
        private const string connectionString = "data source=DP109\\DELICATEMOVE;initial catalog=uko; User ID = emo; Password=123456";
        private const string connectionStringResourses = "data source=DP109\\DELICATEMOVE;initial catalog=resourses; User ID = emo; Password=123456";
        /*connection string for resourses abow*/

        /*connection string for uko prode below*/
       // private const string connectionString = "data source=DP109\\DELICATEMOVE;initial catalog=uko_prode; User ID = emo; Password=123456";
     // private const string connectionStringResourses = "data source=DP109\\DELICATEMOVE;initial catalog=resousres_prode; User ID = emo; Password=123456";
        ///*connection string for uko prode abow*/
        public ConnectionInstanse() { }

        public static SqlConnection GetInstance()
        {

            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new SqlConnection(connectionString);
                }
            }

            return instance;

        }

        public static SqlConnection GetResoursesConnection()
        {

            if (instanceResourses == null)
            {
                lock (syncRoot)
                {
                    if (instanceResourses == null)
                        instanceResourses = new SqlConnection(connectionStringResourses);
                }
            }

            return instanceResourses;

        }
    }
}
