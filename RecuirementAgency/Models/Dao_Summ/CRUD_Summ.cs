using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq;
using System.Data.SqlClient;

namespace RecuirementAgency.Models.Dao_Summ
{
    public class CRUD_Summ : DAO
    {
        public List<VO_Summ> GetAllSumm()
        {
            SqlConnection connection = getConnection();

            List<VO_Summ> summs = new List<VO_Summ>();

            SqlCommand sq = new SqlCommand("Select Id, Name, Age, IdOfAuthor, DateOfPublication, Info from Summaries", connection);
            SqlDataReader dr = sq.ExecuteReader();
            while (dr.Read())
            {
                VO_Summ item = new VO_Summ();
                item.id = dr.GetInt32(0);
                item.name = dr.GetString(1);
                item.age = dr.GetInt32(2);
                item.idOfAuthor = dr.GetInt32(3);
                item.date = dr.GetDateTime(4).Date;
                item.info = dr.GetString(5);
                SqlCommand scmd = new SqlCommand("Select p.Name from " +
                    "Professions as p join Education as e on p.id=e.IdOfProfession where e.IdOfSummary=@id", connection);
                scmd.Parameters.Add(new SqlParameter("@id", item.id));
                /*SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                {
                    item.professions.Add(sdr.GetString(0));
                }
                sdr.Close();
                scmd = new SqlCommand("Select p.Name, e.CountOfMonths from " +
                    "Professions as p join Experience as e on p.id=e.IdOfProfession where e.IdOfSummary=@id", connection);
                scmd.Parameters.Add(new SqlParameter("@id", item.id));
                sdr = scmd.ExecuteReader();
                while (sdr.Read())
                {
                    Experience exp = new Experience();
                    exp.countOfMonths = sdr.GetInt32(1);
                    exp.profession = sdr.GetString(0);
                    item.experience.Add(exp);
                }
                sdr.Close();*/
                summs.Add(item);
            }


            closeConnection(connection);
            return summs;
        }


        public VO_Summ Get_Summ(int id)
        {
            SqlConnection connection = getConnection();
            VO_Summ item = new VO_Summ();
            SqlCommand sq = new SqlCommand("Select Id, Name, Age, IdOfAuthor, DateOfPublication, Info from Summaries where Id=@id", connection);
            sq.Parameters.Add("@id", id);
            SqlDataReader dr = sq.ExecuteReader();
            while (dr.Read())
            {
                item.id = dr.GetInt32(0);
                item.name = dr.GetString(1);
                item.age = dr.GetInt32(2);
                item.idOfAuthor = dr.GetInt32(3);
                item.date = dr.GetDateTime(4).Date;
                item.info = dr.GetString(5);
            }
            SqlCommand scmd = new SqlCommand("Select p.Name from " +
                    "Professions as p join Education as e on p.id=e.IdOfProfession where e.IdOfSummary=@id", connection);
            scmd.Parameters.Add(new SqlParameter("@id", item.id));
            dr.Close();
            SqlDataReader sdr = scmd.ExecuteReader();
            while (sdr.Read())
            {
                item.professions.Add(sdr.GetString(0));
            }
            sdr.Close();
            scmd = new SqlCommand("Select p.Name, e.CountOfMonths from " +
                "Professions as p join Experience as e on p.id=e.IdOfProfession where e.IdOfSummary=@id", connection);
            scmd.Parameters.Add(new SqlParameter("@id", item.id));
            sdr = scmd.ExecuteReader();
            while (sdr.Read())
            {
                Experience exp = new Experience();
                exp.countOfMonths =  sdr.GetInt32(1);
                exp.profession = sdr.GetString(0);
                item.experience.Add(exp);
            }
            sdr.Close();
            closeConnection(connection);
            return item;

        }
    }
}
