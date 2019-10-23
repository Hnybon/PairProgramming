using System.Collections.Generic;
using System.Data.SqlClient;
using PairProgramming.model;

namespace PairRest.DBUtil
{
    public class ManageRecords
    {
        private string _conStr =
            "Data Source=henr280wserver.database.windows.net;Initial Catalog=Henr280W;User ID=Henr280w;Password=Hen124Kir;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private string _getAll = "SELECT * FROM Record";
        private string _getOne = "SELECT * FROM Record WHERE Id = @ID";
        private string _post = "INSERT INTO Record VALUES (@ID, @ARTIST, @TITLE, @DURATION, @YEAROPUB, @PUBLISHER)";
        private string _put = "Update Record SET Id = @ID, Artist = @ARTIST, Title = @TITLE, Duration = @DURATION, YearOPub = @YEAROPUB, Publisher = @PUBLISHER WHERE Id = @OLDID";
        private string _delete = "DELETE FROM Record WHERE Id = @ID";

        public IEnumerable<MRecord> Get()
        {
            List<MRecord> liste = new List<MRecord>();
            using (SqlConnection conn = new SqlConnection(_conStr))
            using (SqlCommand cmd = new SqlCommand(_getAll, conn))
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    MRecord record = ReadNE(reader);
                    liste.Add(record);
                }
                reader.Close();
            }

            return liste;
        }

        public MRecord Get(string id)
        {
            MRecord record = new MRecord();

            using (SqlConnection conn = new SqlConnection(_conStr))
            using (SqlCommand cmd = new SqlCommand(_getOne, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@ID", id);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    record = ReadNE(reader);
                }


                reader.Close();
            }

            return record;
        }

        public void Post(MRecord value)
        {
            using (SqlConnection conn = new SqlConnection(_conStr))
            using (SqlCommand cmd = new SqlCommand(_post, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@ID", value.Id);
                cmd.Parameters.AddWithValue("@ARTIST", value.Artist);
                cmd.Parameters.AddWithValue("@TITLE", value.Title);
                cmd.Parameters.AddWithValue("@DURATION", value.Duration);
                cmd.Parameters.AddWithValue("@YEAROPUB", value.YearOPub);
                cmd.Parameters.AddWithValue("@PUBLISHER", value.Publisher);

                cmd.ExecuteNonQuery();
            }
        }

        public void Put(MRecord value, string id)
        {
            using (SqlConnection conn = new SqlConnection(_conStr))
            using (SqlCommand cmd = new SqlCommand(_put, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@ID", value.Id);
                cmd.Parameters.AddWithValue("@ARTIST", value.Artist);
                cmd.Parameters.AddWithValue("@TITLE", value.Title);
                cmd.Parameters.AddWithValue("@DURATION", value.Duration);
                cmd.Parameters.AddWithValue("@YEAROPUB", value.YearOPub);
                cmd.Parameters.AddWithValue("@PUBLISHER", value.Publisher);

                cmd.Parameters.AddWithValue("@OLDID", id);

                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string id)
        {
            using (SqlConnection conn = new SqlConnection(_conStr))
            using (SqlCommand cmd = new SqlCommand(_delete, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@ID", id);

                cmd.ExecuteNonQuery();
            }
        }


        protected MRecord ReadNE(SqlDataReader reader)
        {
            MRecord record = new MRecord();

            record.Id = reader.GetString(0);
            record.Artist = reader.GetString(1);
            record.Title = reader.GetString(2);
            record.Duration = reader.GetString(3);
            record.YearOPub = reader.GetInt32(4);
            record.Publisher = reader.GetString(5);

            return record;
        }
    }
}