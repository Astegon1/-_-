using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;
using Служба_страхования;
using System.Data;
using System.Data.SqlClient;


namespace TestStrax
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestOpenForm()
        {
            Form form = new Form();
            form.Show();
            Assert.IsTrue(form.Visible);
        }
        private string connectionString = "Data Source=DESKTOP-IG7NGDO\\SQLEXPRESS; Initial Catalog=Служба_страхования;Integrated Security = True";
        [TestMethod]
        public void TestDatabaseConnection()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Assert.AreEqual(ConnectionState.Open, connection.State);
                }
                catch (SqlException ex)
                {
                    Assert.Fail($"Failed to connect to database. Error: {ex.Message}");
                }
            }
        }
        [TestMethod]
        public void TestGridview() 
        { 
            Admin admin = new Admin();
            admin.Auto();
            admin.Zdorov();
            admin.Nedviz();
        }
    }
}
