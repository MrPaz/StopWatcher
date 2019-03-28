using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StopWatcher.Models;

namespace StopWatcher.Models
{
    public class ABCReportModel
    {
        public int OrderID { get; set; }
        public DateTime DateOrdered { get; set; }
        public string[] PhoneNumbers { get; set; }

        public ABCReportModelLineItem[] LineItems { get; set; }
    }

    public class ABCReportModelLineItem
    {
        public string ProductCode { get; set; }
    }
}

namespace StopWatcher.Controllers
{
    public class ABCReportController : Controller
    {
        private SqlConnection _connection;

        public ABCReportController(System.Data.SqlClient.SqlConnection connection)
        {
            this._connection = connection;
        }

        public IActionResult Index(int id = 1)
        {
            ABCReportModel model = new ABCReportModel();

            _connection.Open();

            System.Data.SqlClient.SqlCommand command = _connection.CreateCommand();

            command.CommandText = "SP_OrderReport";
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@orderID", id);
            System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter(command);
            System.Data.DataSet dataSet = new System.Data.DataSet();
            adapter.Fill(dataSet);

            model.OrderID = (int)dataSet.Tables[0].Rows[0][1];
            model.DateOrdered = (DateTime)dataSet.Tables[0].Rows[0][0];

            model.PhoneNumbers = new string[dataSet.Tables[1].Rows.Count];
            for (int i = 0; i < dataSet.Tables[1].Rows.Count; i++)
            {
                model.PhoneNumbers[i] = (string)dataSet.Tables[1].Rows[i][0];
            }

            //model.LineItems = new ABCReportModelLineItem[dataSet.Tables[2].Rows.Count];
            //for (int i = 0; i < dataSet.Tables[2].Rows.Count; i++)
            //{
            //    model.LineItems[i] = new ABCReportModelLineItem
            //    {
            //        ProductCode = (string)dataSet.Tables[2].Rows[i][0]
            //    };
            //}
            _connection.Close();
        
            return View(model);
        }
    }    
}