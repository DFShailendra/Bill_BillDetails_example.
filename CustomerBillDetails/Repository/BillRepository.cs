using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using CustomerBillDetails.Models;
using System.Data;

namespace CustomerBillDetails.Repository
{
    public class BillRepository
    {
        private SqlConnection con;
        //To Handle connection related activities    
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);

        }
        //To Add Bill    
        public bool AddBill(BillModel obj)
        {

            connection();
            SqlCommand com = new SqlCommand("SP_Bill_GetInsert", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@BillNumber", obj.BillNumber);
            com.Parameters.AddWithValue("@BillDate", obj.BillDate);
            com.Parameters.AddWithValue("@CustomerName", obj.CustomerName);
            com.Parameters.AddWithValue("@ContactNumber", obj.ContactNumber);
            com.Parameters.AddWithValue("@Total", obj.Total);

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
        //To view Bill details with generic list     
        public List<BillModel> GetBill()
        {
            connection();
            List<BillModel> bill = new List<BillModel>();


            SqlCommand com = new SqlCommand("SP_Bill_GetAll", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
            //Bind BillModel generic list using dataRow     
            foreach (DataRow dr in dt.Rows)
            {

                bill.Add(

                    new BillModel
                    {

                        BillId = Convert.ToInt32(dr["BillId"]),
                        BillNumber = Convert.ToInt32(dr["BillNumber"]),
                        BillDate = Convert.ToDateTime(dr["BillDate"]),
                        CustomerName = Convert.ToString(dr["CustomerName"]),
                        ContactNumber = Convert.ToInt32(dr["ContactNumber"]),
                        Total = Convert.ToInt32(dr["Total"])

                    }
                    );
            }

            return bill;
        }
        //Get Bill By Id
        public bool GetBillById(int Id)
        {

            connection();
            SqlCommand com = new SqlCommand("SP_Bill_GetById", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@BillId", Id);

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
        //To Update Employee details    
        public bool UpdateBill(BillModel obj)
        {

            connection();
            SqlCommand com = new SqlCommand("SP_Bill_GetUpdate", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@BillId", obj.BillId);
            com.Parameters.AddWithValue("@BillNumber", obj.BillNumber);
            com.Parameters.AddWithValue("@BillDate", obj.BillDate);
            com.Parameters.AddWithValue("@CustomerName", obj.CustomerName);
            com.Parameters.AddWithValue("@ContactNumber", obj.ContactNumber);
            com.Parameters.AddWithValue("@Total", obj.Total);
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
        public bool DeleteBill(int Id)
        {

            connection();
            SqlCommand com = new SqlCommand("SP_Bill_GetDelete", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@BillId", Id);

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