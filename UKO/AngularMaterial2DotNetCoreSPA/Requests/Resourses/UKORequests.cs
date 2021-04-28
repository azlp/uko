using AngularMaterial2DotNetCoreSPA.DataBases;
using AngularMaterial2DotNetCoreSPA.Models.Auxiliary;
using AngularMaterial2DotNetCoreSPA.Models.UKO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AngularMaterial2DotNetCoreSPA.Requests.Resourses
{
    public class UKORequests
    {
        SqlConnection con;
        SqlConnection conname;
        SqlConnection conbuisiness;
        SqlTransaction transaction;

        NullChecker nullCheck;

        public UKORequests()
        {
            con = ConnectionInstanse.GetInstance();

          

            nullCheck = new NullChecker();
        }

        public string AddNewUko(UKOmodel  _uko)
        {
            

            string _ukoId = new GetId().getHash(nullCheck.checkStringNullReturnEmptyString(_uko.Name) + nullCheck.checkStringNullReturnEmptyString(_uko.SecondName) + nullCheck.checkStringNullReturnEmptyString(_uko.FathersName) + _uko.Date);

            

            try
            {

               

                SqlCommand cmd = new SqlCommand("AddUKO", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@entitytype",_uko.Type);
                cmd.Parameters.AddWithValue("@ID",_ukoId);
                cmd.Parameters.AddWithValue("@Name", nullCheck.checkStringNull(_uko.Name));
                cmd.Parameters.AddWithValue("@SecondName", nullCheck.checkStringNull(_uko.SecondName));
                cmd.Parameters.AddWithValue("@FathersName", nullCheck.checkStringNull(_uko.FathersName));
                cmd.Parameters.AddWithValue("@DateOffBirth",nullCheck.checkDateTimeNullNotDb(_uko.Date));
                cmd.Parameters.AddWithValue("@FIO",new GetFIO().Fio(nullCheck.checkStringNullReturnEmptyString(_uko.Name), nullCheck.checkStringNullReturnEmptyString(_uko.SecondName),nullCheck.checkStringNullReturnEmptyString(_uko.FathersName)));
                cmd.Parameters.AddWithValue("@Photo",nullCheck.checkStringNull(_uko.Photo));
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

               
                return _ukoId;

               
            }
            catch
            {
                con.Close();

                throw;
            }
        }

        public int UpdateUkoName(UKOmodel _uko)
        {


            try
            {

                SqlCommand cmd = new SqlCommand("UpdateNameUKOName", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@entitytype", _uko.Type.ToString());
                cmd.Parameters.AddWithValue("@ID",_uko.Id);
                cmd.Parameters.AddWithValue("@Name", nullCheck.checkStringNull(_uko.Name));
                cmd.Parameters.AddWithValue("@SecondName", nullCheck.checkStringNull(_uko.SecondName));
                cmd.Parameters.AddWithValue("@FathersName", nullCheck.checkStringNull(_uko.FathersName));
                cmd.Parameters.AddWithValue("@DateOffBirth", nullCheck.checkDateTimeNullNotDb(_uko.Date));
                cmd.Parameters.AddWithValue("@Nickname", nullCheck.checkStringNull(_uko.NickName));
                cmd.Parameters.AddWithValue("@FIO", new GetFIO().Fio(nullCheck.checkStringNullReturnEmptyString(_uko.Name), nullCheck.checkStringNullReturnEmptyString(_uko.SecondName), nullCheck.checkStringNullReturnEmptyString(_uko.FathersName)));
                cmd.Parameters.AddWithValue("@Photo", nullCheck.checkStringNull(_uko.Photo));
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

        public string AddNewUkoJur(UKOmodel _uko)
        {
            string _ukoId = new GetId().getHash(nullCheck.checkStringNullReturnEmptyString(_uko.Name) + nullCheck.checkStringNullReturnEmptyString(_uko.SecondName) + nullCheck.checkStringNullReturnEmptyString(_uko.FathersName) + _uko.Date);

            try
            {

                SqlCommand cmd = new SqlCommand("AddUKOJur", con);

                cmd.CommandType = CommandType.StoredProcedure;

               
                cmd.Parameters.AddWithValue("@ID", _ukoId);
                cmd.Parameters.AddWithValue("@Name", nullCheck.checkStringNullReturnEmptyString(_uko.Name));
                cmd.Parameters.AddWithValue("@JurName", nullCheck.checkStringNullReturnEmptyString(_uko.SecondName));
                cmd.Parameters.AddWithValue("@INN", nullCheck.checkStringNullReturnEmptyString(_uko.INN));
                cmd.Parameters.AddWithValue("@Comment", nullCheck.checkStringNullReturnEmptyString(_uko.Comment));
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

              

                return _ukoId;


            }
            catch
            {
                con.Close();


                throw;
            }
        }


        public int UpdateUkoJur(UKOmodel _uko)
        {

            try
            {

                SqlCommand cmd = new SqlCommand("UpdateUKOJur", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@entitytype", _uko.Type);
                cmd.Parameters.AddWithValue("@ID", _uko.Id);
                cmd.Parameters.AddWithValue("@Name", nullCheck.checkStringNull(_uko.Name));
                cmd.Parameters.AddWithValue("@JurName", nullCheck.checkStringNull(_uko.JurName));
                cmd.Parameters.AddWithValue("@INN", nullCheck.checkStringNull(_uko.INN));
                cmd.Parameters.AddWithValue("@Comment", nullCheck.checkStringNull(_uko.Comment));
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


        public string AddNewAdressOffUko(Adress _adress)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("AddAdressOffUko", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Type", _adress.Type );
                cmd.Parameters.AddWithValue("@ID", _adress.Id);
                cmd.Parameters.AddWithValue("@PostCode", _adress.Index);
                cmd.Parameters.AddWithValue("@City", nullCheck.checkStringNull(_adress.City));
                cmd.Parameters.AddWithValue("@Street", nullCheck.checkStringNull(_adress.Street));
                cmd.Parameters.AddWithValue("@Building", nullCheck.checkIntNull(_adress.HouseNumber));
                cmd.Parameters.AddWithValue("@BuildingCode", nullCheck.checkIntNull(_adress.BuildingCode));
                cmd.Parameters.AddWithValue("@Block", nullCheck.checkIntNull(_adress.Block));
                cmd.Parameters.AddWithValue("@Flat", nullCheck.checkIntNull(_adress.Flat));
                cmd.Parameters.AddWithValue("@Floor", nullCheck.checkIntNull(_adress.Floor));
                cmd.Parameters.AddWithValue("@Entrance",_adress.Entrance);
                cmd.Parameters.AddWithValue("@Comment", nullCheck.checkStringNull(_adress.Comment));
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                return "Адрес добавлен";
                
            }
            catch
            {
                con.Close();

                throw;
            }
        }

        public string AddNewDocsOffUko(Docs _newdoc)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("AddDocumentToUko", con);

                cmd.CommandType = CommandType.StoredProcedure;

               
                cmd.Parameters.AddWithValue("@ID",_newdoc.Id);
                cmd.Parameters.AddWithValue("@DocName", nullCheck.checkStringNull(_newdoc.Name));
                cmd.Parameters.AddWithValue("@DocFile", nullCheck.checkStringNull(_newdoc.File));
               
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                return "Документ добавлен";

            }
            catch
            {
                con.Close();

                throw;
            }
        }

        public List<UKOmodel> GetListOffAllUko()
        {
            List<UKOmodel> _list = new List<UKOmodel>();


            GetPersonalUko(_list);

            GetBuisinessEntityUko(_list);


            return _list;

        }

        public List<Adress> GetListOffAdress(UKOmodel _uko)
        {
            List<Adress> _listOffAdress = new List<Adress>();

            GetListOffAdressPersonalUko(_uko,_listOffAdress);

            AddUkoNames(_listOffAdress);


            return _listOffAdress;

        }

        private List<Adress> GetListOffAdressPersonalUko(UKOmodel _uko, List<Adress> _listOffAdress)
        {
         

            try
            {

                SqlCommand cmd = new SqlCommand("GetListOffAdressOffUco", con);
                // SqlCommand buisinessUkoName = new SqlCommand("GetUkoBussinesEntityName",con);
                //SqlCommand personUkoName = new SqlCommand("GetUkoNameEntityName", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ukoId", _uko.Id);

                //buisinesUkoName.Parameters.AddWithValue("@ukoId", _uko.Id);
                //personUkoName.Parameters.AddWithValue("@ukoId", _uko.Id);

               
             
                con.Open();

               

                SqlDataReader rdr = cmd.ExecuteReader();



                while (rdr.Read())
                {

                    

                    Adress _adress = new Adress();

                    _adress.Id = nullCheck.checkStringDBNull(rdr["ID"]);

                    _adress.AdressTotal = "" + nullCheck.checkStringDBNull(rdr["PostCode"]) + "" +
                        "" + nullCheck.checkStringDBNull(rdr["City"]) + "" + nullCheck.checkStringDBNull(rdr["Street"]) + "" +
                      nullCheck.convertObjectToString(nullCheck.convertIntToObject(rdr["Bulding"])) + "" + nullCheck.convertObjectToString(nullCheck.convertIntToObject(rdr["Block"])) + "" + nullCheck.convertObjectToString(nullCheck.convertIntToObject(rdr["Flat"]));

                    _adress.City = rdr["City"].ToString();

                    _adress.AdressType = rdr["Type"].ToString();


                    _listOffAdress.Add(_adress);
                }

                con.Close();

                rdr.Close();

                return _listOffAdress;
            }
            catch
            {

                

                con.Close();

                throw;
            }
           
           
        }

        private String AdreesTypeSet(String _adressTypeCode)
        {

            //String _retrunTypeText = "не задано";

            switch(_adressTypeCode)
            {
                case "0":
                    _adressTypeCode = "зарегистрирован";
                break;
                case "1":
                    _adressTypeCode = "проживает";
                    break;
                case "2":
                    _adressTypeCode = "прописан";
                    break;
                case "3":
                    _adressTypeCode = "юридический адрес";
                    break;

                case "4":
                    _adressTypeCode = "склад";
                    break;

            }

            return _adressTypeCode;
        }


        private List<Adress> AddUkoNames(List<Adress> _listOffAdress)
        {
            int _count = _listOffAdress.Count;

            for(int i=0; i<_count;i++)
            {
                String _ukoId = _listOffAdress[i].Id;

               String _ukoName =  getBuissinessEntity(_ukoId);

                 _listOffAdress[i].UkoName = _ukoName;
               

            }


            return _listOffAdress;
        }

        private String getBuissinessEntity(String _ukoId)
        {
            String _ukoName = "не задано";

            try
            {

                SqlCommand cmd = new SqlCommand("GetUkoBussinesEntityName", con);
               

                cmd.Parameters.AddWithValue("@ukoId",_ukoId);

                //buisinesUkoName.Parameters.AddWithValue("@ukoId", _uko.Id);
                //personUkoName.Parameters.AddWithValue("@ukoId", _uko.Id);

                cmd.CommandType = CommandType.StoredProcedure;


                con.Open();


                SqlDataReader rdr = cmd.ExecuteReader();


                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {

                        _ukoName = nullCheck.checkStringDBNull(rdr.GetString(0));

                    }

                }

                con.Close();

                rdr.Close();

                    return _ukoName;

               
            }
            catch
            {


                con.Close();

               
                throw;
            }
        }

        public List<Docs> GetListOffDocs(UKOmodel _uko)
        {
            List<Docs> _listOffDocs = new List<Docs>();

            GetListOffDocsUko(_uko, _listOffDocs);

            AddUkoNamesDocs(_listOffDocs);


            return _listOffDocs;

        }


        private List<Docs> GetListOffDocsUko(UKOmodel _uko, List<Docs> _listOffDocs)
        {


            try
            {

                SqlCommand cmd = new SqlCommand("GetListOffDocsOffUco", con);
                // SqlCommand buisinessUkoName = new SqlCommand("GetUkoBussinesEntityName",con);
                //SqlCommand personUkoName = new SqlCommand("GetUkoNameEntityName", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ukoId", _uko.Id);

                //buisinesUkoName.Parameters.AddWithValue("@ukoId", _uko.Id);
                //personUkoName.Parameters.AddWithValue("@ukoId", _uko.Id);



                con.Open();



                SqlDataReader rdr = cmd.ExecuteReader();



                while (rdr.Read())
                {



                    Docs _docs = new Docs();

                    _docs.Id = nullCheck.checkStringDBNull(rdr["ID"]);

                    _docs.Name = nullCheck.checkStringDBNull(rdr["Type_off_doc"]);

                    _docs.File = nullCheck.checkStringDBNull(rdr["DocFile"]);

                    _listOffDocs.Add(_docs);
                }

                con.Close();

               

                return _listOffDocs;
            }
            catch
            {



                con.Close();

                throw;
            }


        }

        private List<Docs> AddUkoNamesDocs(List<Docs> _listOffDocs)
        {
            int _count = _listOffDocs.Count;

            for (int i = 0; i < _count; i++)
            {
                String _ukoId = _listOffDocs[i].Id;

                String _ukoName = getBuissinessEntity(_ukoId);

                _listOffDocs[i].UkoName = _ukoName;


            }

            return _listOffDocs;
        }

        public List<UKOmodel> GetPersonalUko(List<UKOmodel> _listUko)
        {


            try
            {
                SqlCommand cmd = new SqlCommand("GetListoffPersonUko", con);


                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();



                while (rdr.Read())
                {

                    UKOmodel _uko = new UKOmodel();


                    _uko.Id = rdr["ID"].ToString();
                    _uko.Name = rdr["fio"].ToString();
                    _uko.Comment = "физ.лицо";


                    _listUko.Add(_uko);
                }

                con.Close();

                return _listUko;
            }
            catch
            {
                con.Close();

                throw;
            }
        }

        public List<UKOmodel> GetBuisinessEntityUko(List<UKOmodel> _listUko)
        {


            try
            {
                SqlCommand cmd = new SqlCommand("getListOffBuisinessEntity", con);


                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();



                while (rdr.Read())
                {

                    UKOmodel _uko = new UKOmodel();


                    _uko.Id = rdr["ID"].ToString();
                    _uko.Name = rdr["Name"].ToString();
                    _uko.Comment = "юр.лицо";



                    _listUko.Add(_uko);
                }

                con.Close();

                return _listUko;
            }
            catch
            {
                con.Close();

                throw;
            }
        }


        //public List<Docs> GetListOffDocsUko(UKOmodel _uko)
        //{


        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("GetListOffDocsOffUco", con);




        //        cmd.CommandType = CommandType.StoredProcedure;

        //        cmd.Parameters.AddWithValue("@ukoid",_uko.Id);

        //        con.Open();

        //        SqlDataReader rdr = cmd.ExecuteReader();

        //        List<Docs> _docsList = new List<Docs>();

        //        while (rdr.Read())
        //        {

        //            Docs _ukoDoc = new Docs();


        //            _ukoDoc.Id = rdr["ID"].ToString();
        //            _ukoDoc.Name = rdr["Type_off_doc"].ToString();
        //            _ukoDoc.File = rdr["DocFile"].ToString(); 

        //            _docsList.Add(_ukoDoc);
        //        }

        //        con.Close();

        //        return _docsList;
        //    }
        //    catch
        //    {
        //        con.Close();

        //        throw;
        //    }
        //}

        public UKOmodel GetPersonalUkoInfo(UKOmodel _uko)
        {


            try
            {
                SqlCommand cmd = new SqlCommand("GetPersonUkoInfo", con);

                cmd.Parameters.AddWithValue("@ukoid", _uko.Id);

                UKOmodel _ukoInfo = new UKOmodel();

                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();



                while (rdr.Read())
                {




                    _ukoInfo.Id = _uko.Id;
                    _ukoInfo.FIO = rdr["fio"].ToString();
                    _ukoInfo.SecondName = rdr["SecondName"].ToString();
                    _ukoInfo.FathersName = rdr["FathersName"].ToString();
                    _ukoInfo.Name = rdr["Name"].ToString();
                    _ukoInfo.Dateoffbirth = DateTime.Parse(rdr["DateOffBirth"].ToString()).ToString("yyyy/MM/dd").Replace(".","-");
                    _ukoInfo.Photo = rdr["Photo"].ToString();
                    _ukoInfo.NickName = rdr["Nickname"].ToString();
                    _ukoInfo.INN = rdr["INN"].ToString();



                }

                con.Close();

                return _ukoInfo;
            }
            catch
            {
                con.Close();

                throw;
            }
        }


        public UKOmodel GetBuisinessEntityUkoInfo(UKOmodel _uko)
        {


            try
            {
                SqlCommand cmd = new SqlCommand("GetBuisinessUkoInfo", con);

                cmd.Parameters.AddWithValue("@ukoid", _uko.Id);

                UKOmodel _ukoInfo = new UKOmodel();

                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();



                while (rdr.Read())
                {




                    _ukoInfo.Id = rdr["ID"].ToString();
                    _ukoInfo.JurName = rdr["JurName"].ToString();
                    _ukoInfo.Name = rdr["Name"].ToString();
                    _ukoInfo.Comment = rdr["Comment"].ToString();
                    _ukoInfo.INN = rdr["INN"].ToString();



                }

                con.Close();

                return _ukoInfo;
            }
            catch
            {
                con.Close();

                throw;
            }
        }
    }
}
