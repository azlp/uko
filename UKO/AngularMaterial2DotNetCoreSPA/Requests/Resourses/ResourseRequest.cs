using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularMaterial2DotNetCoreSPA.DataBases;
using System.Data.SqlClient;
using System.Data;
using AngularMaterial2DotNetCoreSPA.Models;
using System.Security.Cryptography;
using System.Text;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Linq;
using System.Xml;
using System.Xml.Serialization;
//using static System.Net.Mime.MediaTypeNames;
using AngularMaterial2DotNetCoreSPA.Models.Auxiliary;
using AngularMaterial2DotNetCoreSPA.Models.UKO;

namespace AngularMaterial2DotNetCoreSPA.Requests.Resourses
{
    public class ResourseRequest
    {
        SqlConnection con;

        //SqlConnection resourseconnection;

        SqlConnection conResourse;

        String colorsOffResourse;

        public ResourseRequest()
        {
            con = ConnectionInstanse.GetInstance();

            conResourse = ConnectionInstanse.GetResoursesConnection();
        }


        public string AddNewResourse(ResourseModel _resourse)
        {
           string _resorseId =   getHash(_resourse.Code + _resourse.Name + getRandomForSol(_resourse.Name.Length,true));


            try
            {

                SqlCommand cmd = new SqlCommand("CreateResourse", con);

                cmd.CommandType = CommandType.StoredProcedure;

               

                cmd.Parameters.AddWithValue("@resourseId", _resorseId);
                cmd.Parameters.AddWithValue("@code", _resourse.Code);
                cmd.Parameters.AddWithValue("@name", _resourse.Name);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                return _resorseId;
            }
            catch
            {
                con.Close();

                throw;
            }
        }

        public int UploadImage(ResourseModel _formModel)
        {
           


            try
            {

                SqlCommand cmd = new SqlCommand("AddImageToResorseDescription", con);

                cmd.CommandType = CommandType.StoredProcedure;



                cmd.Parameters.AddWithValue("@resourseId", _formModel.ResourceId);
                //cmd.Parameters.AddWithValue("@resourseImage", ConvertToBytes(_formModel.Image));
                cmd.Parameters.AddWithValue("@resourseImage",_formModel.Image);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                return 0;
            }
            catch
            {
                con.Close();

                throw;
            }
        }


        public static byte[] ConvertToBytes(String _image)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(_image);
            //byte[] bytes = Encoding.UTF8.GetBytes(_image);
            return bytes;
        }

       

        public int AddResourseSpecification(ResourseModel _resourse)
        {
           
            try
            {

                SqlCommand cmd = new SqlCommand("AddResourseSpecification", con);

                cmd.CommandType = CommandType.StoredProcedure;



                cmd.Parameters.AddWithValue("@resourseId", _resourse.ResourceId);
                //cmd.Parameters.AddWithValue("@resourseImage", getImageFromString( _resourse.Image));
                cmd.Parameters.AddWithValue("@name", _resourse.Name);
                cmd.Parameters.AddWithValue("@number", _resourse.Code);
                cmd.Parameters.AddWithValue("@argo", _resourse.Argo);
                cmd.Parameters.AddWithValue("@developer", _resourse.Developer);
                cmd.Parameters.AddWithValue("@units", _resourse.Units);
                cmd.Parameters.AddWithValue("@weight", _resourse.Wieight);
                cmd.Parameters.AddWithValue("@lenght", _resourse.Lenght);
                cmd.Parameters.AddWithValue("@with", _resourse.With);
                cmd.Parameters.AddWithValue("@height", _resourse.Height);
                cmd.Parameters.AddWithValue("@color", _resourse.Color);
                cmd.Parameters.AddWithValue("@deffects", _resourse.Deffects);
                cmd.Parameters.AddWithValue("@comment", _resourse.Comment);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                return 0;
            }
            catch
            {
                con.Close();

                throw;
            }
        }

        public int CountOffResourse(ResourseModel _resourse)
        {

            try
            {

                SqlCommand cmd = new SqlCommand("TotalCountOffResourse", con);

                cmd.CommandType = CommandType.StoredProcedure;



                cmd.Parameters.AddWithValue("@resourseId", _resourse.ResourceId);
                
                cmd.Parameters.AddWithValue("@count", _resourse.Total);
                
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                return 0;
            }
            catch
            {
                con.Close();

                throw;
            }
        }

        public IEnumerable<ResourseModel> GetResoursesList()
        {
            try
            {

                List<ResourseModel> _resourses = new List<ResourseModel>();



               
                    SqlCommand cmd = new SqlCommand("GetListOffAllResourses", conResourse);


                   cmd.CommandType = CommandType.StoredProcedure;

                //con.Close();

                conResourse.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    

                    while (rdr.Read())
                    {

                        ResourseModel _resourse = new ResourseModel();

                        _resourse.ResourceId = rdr["resourseId"].ToString();
                        _resourse.Name = rdr["name"].ToString();
               

                    _resourses.Add(_resourse);

                    }

                conResourse.Close();
                
                return GetSortedListOffResures(_resourses);
            }
            catch
            {
                conResourse.Close();

                throw;
            }
        }

        //Здесь объединяем дубликаты ресурсов в один так хранимка возвращает дублирующие значения из-за jont
        private IEnumerable<ResourseModel> GetSortedListOffResures(IEnumerable<ResourseModel> _inputList)
        {


            List<ResourseModel> _resourses = new List<ResourseModel>();


            var _groupedByName = _inputList.GroupBy(p => p.Name).ToList();



            int _count = _groupedByName.Count();




            for (int i = 0; i < _count; i++)
            {
                ResourseModel _newResourse = new ResourseModel();

                StringBuilder _classNames = new StringBuilder();

                var _dictionary = _groupedByName[i].ToList();

                int _countForClasses = _dictionary.Count;

                int _innerCount = _countForClasses - (_countForClasses - 1);



                for (int j = 0; j < _innerCount; j++)
                {
                    _newResourse.ResourceId = _dictionary[j].ResourceId;
                    _newResourse.Name = _dictionary[j].Name;
                    //Добавляем к ресурсу список его классификаторов
                    


                }



                _resourses.Add(_newResourse);



            }



            return _resourses;
        }


        public IEnumerable<ResourseModel> GetListResoursesOfUko(UKOmodel _uko)
        {
            try
            {

                List<ResourseModel> _resourses = new List<ResourseModel>();




                SqlCommand cmd = new SqlCommand("GetResourseList", conResourse);

                cmd.Parameters.AddWithValue("@userId",_uko.Id);
                cmd.CommandType = CommandType.StoredProcedure;

                conResourse.Open();

                SqlDataReader rdr = cmd.ExecuteReader();



                while (rdr.Read())
                {

                    ResourseModel _resourse = new ResourseModel();

                    _resourse.ResourceId = rdr["resourseId"].ToString();
                    _resourse.Name = rdr["name"].ToString();
                    _resourse.Data = rdr["ownerId"].ToString();
                   
                    _resourses.Add(_resourse);
                }

                conResourse.Close();

                return _resourses;
            }
            catch
            {
                conResourse.Close();

                throw;
            }
        }

        public int AddResoursesToUko(ResourseModel _resourse)
        {
           
                try
                {

                    SqlCommand cmd = new SqlCommand("AddResourseToUko", conResourse);

                    cmd.CommandType = CommandType.StoredProcedure;



                    cmd.Parameters.AddWithValue("@ownerId", _resourse.Argo);

                    cmd.Parameters.AddWithValue("@resourseId", _resourse.ResourceId);

                conResourse.Open();
                    cmd.ExecuteNonQuery();
                conResourse.Close();

                    return 0;
                }
                catch
                {
                conResourse.Close();

                    throw;
                }
            }

        public int DeleteResoursesFromUko(ResourseModel _resourse)
        {

            try
            {

                SqlCommand cmd = new SqlCommand("DeleteResourseFromUko", conResourse);

                cmd.CommandType = CommandType.StoredProcedure;



                cmd.Parameters.AddWithValue("@ownerId", _resourse.Argo);

                cmd.Parameters.AddWithValue("@resourseId", _resourse.ResourceId);

                conResourse.Open();
                cmd.ExecuteNonQuery();
                conResourse.Close();

                return 0;
            }
            catch
            {
                conResourse.Close();

                throw;
            }
        }

        // удаляем время из даты времени, поскольку из базы приходят нули вместо часов минут и секунд
        private string DateTimeRemover(String _inputString)
        {
            String _result = _inputString;

            int lenght = _inputString.Length;

            if(lenght > 0)
            {
                return _result.Remove(11);
            }
            else
            {
                return _result;
            }

               
        }

        public ResourseModel GetResourseInfo(ResourseModel _resourseId)
        {

            ResourseModel _resourse = new ResourseModel();

            try
            {

                SqlCommand cmd = new SqlCommand("GetResourseInfo", con);


                cmd.Parameters.AddWithValue("@resoureId", _resourseId.ResourceId);


                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();



                while (rdr.Read())
                {

                    

                    _resourse.ResourceId = rdr["resourseId"].ToString();
                   // _resourse.Name = rdr["name"].ToString();
                 

                    String specdoc = rdr["specification"].ToString();

                    // если есть спецификация, то парсим её
                    if (specdoc!="")

                    {

                        StringReader reader = new StringReader(specdoc);

                        XDocument doc = XDocument.Load(reader);
                        _resourse.SpecificationDoc = doc;
                        //_resourse.Color = getColors(doc,_resourse);
                        this.getName(doc, _resourse);
                        this.getColors(doc, _resourse);
                        this.getNumber(doc, _resourse);
                        this.getArgo(doc, _resourse);
                        this.getDeveloper(doc, _resourse);
                        this.getUnits(doc, _resourse);
                        this.getLenght(doc, _resourse);
                        this.getWith(doc, _resourse);
                        this.getWeight(doc, _resourse);
                        this.getColorsList(doc, _resourse);
                        this.getDeffect(doc, _resourse);
                        this.getComment(doc, _resourse);
                        this.getHeight(doc, _resourse);

                    }

                    _resourse.Image = rdr["resourseview"].ToString();

                    //обазятельно Encoding.ASC!! иначе не будет строка транскодироваться в image. 
                    // _resourse.Image = RemoveExcessString(Encoding.UTF8.GetString(ObjectToByteArray(rdr["resourseview"])));
                    // _resourse.Image = Encoding.ASCII.GetString(ObjectToByteArray(rdr["resourseview"]));
                    // _resourse.Image = RemoveExcessString(Convert.ToBase64String(ObjectToByteArray(rdr["resourseview"])));

                }

                con.Close();

               // this.getImageOffResourse(_resourse, _resourseId);

                return _resourse;
            }
            catch
            {
                con.Close();

                throw;
            }
        }

        // конвертируем полученные из базы object чтобы получит image
        byte[] ObjectToByteArray(object obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }


        // remove excess first  bytes которые почему-то получаются при сохранении image из string в базу данных varbinary(max)
        private string RemoveExcessString(String _oldstring)
        {
            string _s;

            int index = _oldstring.IndexOf("data:image");

            if(_oldstring.IndexOf("data:image") > 0)
            {
                 _s = _oldstring.Substring(_oldstring.IndexOf("data:image"));
            }
            else
            {
                _s = _oldstring;
            }


            return _s;
        }



        static private string getHash(String _input)
        {

            var hash = (new SHA1Managed()).ComputeHash(Encoding.UTF8.GetBytes(_input));

            return string.Join("", hash.Select(b => b.ToString("x2")).ToArray());


        }

        static private string getRandomForSol(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        private string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        private int checkIntNull(Object obj)
        {
            return obj == DBNull.Value ? 0 : (int)obj;
        }

        private byte[] getImageFromString(String _inputString)
        {
            // byte[] array = Encoding.ASCII.GetBytes(_inputString);



            //parameters[10] = new OleDbParameter("@LONG_DESCRIPTION", array);
            // parameters[10].OleDbType = OleDbType.LongVarBinary;

            byte[] array = new byte[_inputString.Length * sizeof(char)];


            System.Buffer.BlockCopy(_inputString.ToCharArray(), 0, array, 0, array.Length);





            //Image temp = new Bitmap(_inputString);


            //array = _inputString.To

            //FileInfo fInfo = new FileInfo(_inputString);

            //long numBytes = fInfo.Length;

            //Open FileStream to read file
            //FileStream fStream = new FileStream(_inputString, FileMode.Open, FileAccess.Read);

            //Use BinaryReader to read file stream into byte array.
            //BinaryReader br = new BinaryReader(fStream);

            //When you use BinaryReader, you need to supply number of bytes 
            //to read from file.
            //In this case we want to read entire file. 
            //So supplying total number of bytes.
            //array = br.ReadBytes((int)numBytes);

            return array;

            //System.Drawing.Image bmp = new Bitmap(_inputString);

        }

        private byte[] getBytesFromDataBase(object obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }


        private ResourseModel getImageOffResourse(ResourseModel _resourse, ResourseModel _resourseId)
        {

            try
            {
                SqlCommand cmdSelect = new SqlCommand("SELECT resourseview  " +
                      " from description where reosorseId=@ID", con);
                cmdSelect.Parameters.Add("@ID", SqlDbType.NVarChar,50);
                cmdSelect.Parameters["@ID"].Value = _resourse.ResourceId;

                this.con.Open();
                byte[] barrImg = (byte[])cmdSelect.ExecuteScalar();
                // string strfn = Convert.ToString(DateTime.Now.ToFileTime());

                _resourse.ImageByteArray = barrImg;

                //FileStream fs = new FileStream(strfn,
                //                  FileMode.CreateNew, FileAccess.Write);
                //fs.Write(barrImg, 0, barrImg.Length);
                //fs.Flush();
                //fs.Close();
               
            }
            catch (Exception ex)
            {
                this.con.Close();
            }
            finally
            {
                this.con.Close();
            }

            return _resourse;
        }

        private ResourseModel getColors(XDocument xdoc, ResourseModel _resourse)
        {
            

            foreach(XElement element in xdoc.Element("Specification").Elements("color"))
            {

                //XAttribute _colors = element.Value("color");



                //colorsOffResourse = element.Value.ToString();

                _resourse.Color = element.Value.ToString();

              //  if(_colors != null)
               // {
                  //  colorsOffResourse = _colors.ToString();
               // }

            }


            return _resourse;

        }

        private ResourseModel getName(XDocument xdoc, ResourseModel _resourse)
        {


            foreach (XElement element in xdoc.Element("Specification").Elements("name"))
            {


                _resourse.Name = element.Value.ToString();



            }


            return _resourse;

        }

        private ResourseModel getNumber(XDocument xdoc, ResourseModel _resourse)
        {


            foreach (XElement element in xdoc.Element("Specification").Elements("number"))
            {

               
                _resourse.Number = element.Value.ToString();

             

            }


            return _resourse;

        }


        private ResourseModel getArgo(XDocument xdoc, ResourseModel _resourse)
        {


            foreach (XElement element in xdoc.Element("Specification").Elements("argoname"))
            {

             

                _resourse.Argo = element.Value.ToString();

               
            }


            return _resourse;

        }

        private ResourseModel getDeveloper(XDocument xdoc, ResourseModel _resourse)
        {


            foreach (XElement element in xdoc.Element("Specification").Elements("developer"))
            {

                

                _resourse.Developer = element.Value.ToString();

              

            }


            return _resourse;

        }

        private ResourseModel getUnits(XDocument xdoc, ResourseModel _resourse)
        {


            foreach (XElement element in xdoc.Element("Specification").Elements("units"))
            {



                _resourse.Units = element.Value.ToString();



            }


            return _resourse;

        }

        private ResourseModel getWeight(XDocument xdoc, ResourseModel _resourse)
        {


            foreach (XElement element in xdoc.Element("Specification").Elements("weight"))
            {



                _resourse.Wieight = element.Value.ToString();



            }


            return _resourse;

        }

        private ResourseModel getLenght(XDocument xdoc, ResourseModel _resourse)
        {


            foreach (XElement element in xdoc.Element("Specification").Elements("lenght"))
            {



                _resourse.Lenght = element.Value.ToString();



            }


            return _resourse;

        }

        private ResourseModel getWith(XDocument xdoc, ResourseModel _resourse)
        {


            foreach (XElement element in xdoc.Element("Specification").Elements("with"))
            {



                _resourse.With = element.Value.ToString();



            }


            return _resourse;

        }

        private ResourseModel getHeight(XDocument xdoc, ResourseModel _resourse)
        {


            foreach (XElement element in xdoc.Element("Specification").Elements("height"))
            {



                _resourse.Height = element.Value.ToString();



            }


            return _resourse;

        }

        private ResourseModel getColorsList(XDocument xdoc, ResourseModel _resourse)
        {


            foreach (XElement element in xdoc.Element("Specification").Elements("color"))
            {



                _resourse.Color = element.Value.ToString();



            }


            return _resourse;

        }

        private ResourseModel getDeffect(XDocument xdoc, ResourseModel _resourse)
        {


            foreach (XElement element in xdoc.Element("Specification").Elements("deffects"))
            {



                _resourse.Deffects = element.Value.ToString();



            }


            return _resourse;

        }


        private ResourseModel getComment(XDocument xdoc, ResourseModel _resourse)
        {


            foreach (XElement element in xdoc.Element("Specification").Elements("comment"))
            {



                _resourse.Comment = element.Value.ToString();



            }


            return _resourse;

        }


        private static XDocument DocumentToXDocuemtn(XmlDocument doc)
        {
            return XDocument.Parse(doc.OuterXml);
        }


    }


    
}

