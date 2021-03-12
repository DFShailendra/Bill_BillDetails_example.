using CustomerBillDetails.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CustomerBillDetails.Repository
{
    public class DetailRepository
    {
        private SqlConnection con;
        //To Handle connection related activities    
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);

        }
        //To Add Employee details    
        public bool AddDetail(DetailModel obj)
        {

            connection();
            SqlCommand com = new SqlCommand("SP_Detail_GetInsert", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ItemName", obj.ItemName);
            com.Parameters.AddWithValue("@Quantity", obj.Quantity);
            com.Parameters.AddWithValue("@ItemRate", obj.ItemRate);
            com.Parameters.AddWithValue("@Total", obj.Total);
            com.Parameters.AddWithValue("@BillId", obj.BillId);


            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }


        }
        //To view employee details with generic list     
        public List<DetailModel> GetAll()
        {
            connection();
            List<DetailModel> dlist = new List<DetailModel>();


            SqlCommand com = new SqlCommand("SP_Detail_GetAll", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
            //Bind EmpModel generic list using dataRow     
            foreach (DataRow dr in dt.Rows)
            {

                dlist.Add(

                    new DetailModel
                    {

                        BillDetailsId = Convert.ToInt32(dr["BillDetailsId"]),
                        ItemName = Convert.ToString(dr["ItemName"]),
                        Quantity = Convert.ToInt32(dr["Quantity"]),
                        ItemRate = Convert.ToInt32(dr["ItemRate"]),
                        Total = Convert.ToInt32(dr["Total"]),
                        BillId= Convert.ToInt32(dr["BillId"])

                    }
                    );
            }

            return dlist;
        }
        //To Update Employee details    
        public bool Update(DetailModel obj)
        {

            connection();
            SqlCommand com = new SqlCommand("SP_Detail_GetUpdate", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@BillDetailId", obj.BillDetailsId);
            com.Parameters.AddWithValue("@ItemName", obj.ItemName);
            com.Parameters.AddWithValue("@Quantity", obj.Quantity);
            com.Parameters.AddWithValue("@ItemRate", obj.ItemRate);
            com.Parameters.AddWithValue("@Total", obj.Total);
            com.Parameters.AddWithValue("@BillId", obj.BillId);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;
            }
            else
            {
                return false;
            }
        }
        //To delete Employee details    
        public bool Delete(int Id)
        {

            connection();
            SqlCommand com = new SqlCommand("SP_Detail_GetDelete", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@BillDetailsId", Id);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {

                return false;
            }
        }
    }
}