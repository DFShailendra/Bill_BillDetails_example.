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
    public class ItemRepository
    {
        private SqlConnection con;
        //To Handle connection related activities    
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);

        }
        //To Add Employee details    
        public bool AddItem(ItemModel obj)
        {

            connection();
            SqlCommand com = new SqlCommand("SP_Item_GetInsert", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ItemName", obj.ItemName);
            com.Parameters.AddWithValue("@ItemRate", obj.ItemRate);

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
        public List<ItemModel> GetItem()
        {
            connection();
            List<ItemModel> ItemList = new List<ItemModel>();


            SqlCommand com = new SqlCommand("SP_Item_GetAll", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
            //Bind EmpModel generic list using dataRow     
            foreach (DataRow dr in dt.Rows)
            {

                ItemList.Add(

                    new ItemModel
                    {

                        ItemId = Convert.ToInt32(dr["ItemId"]),
                        ItemName = Convert.ToString(dr["ItemName"]),
                        ItemRate = Convert.ToInt32(dr["ItemRate"])

                    }
                    );
            }

            return ItemList;
        }
        //To Update Employee details    
        public bool UpdateItem(ItemModel obj)
        {

            connection();
            SqlCommand com = new SqlCommand("SP_Item_GetUpdate", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ItemId", obj.ItemId);
            com.Parameters.AddWithValue("@ItemName", obj.ItemName);
            com.Parameters.AddWithValue("@ItemRate", obj.ItemRate);
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
        public bool DeleteItem(int Id)
        {

            connection();
            SqlCommand com = new SqlCommand("SP_Item_GetDelete", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ItemId", Id);

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
