using Dapper;
using DevExpress.DashboardAspNetCore;
using DevExpress.DashboardWeb;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace Devexpress.Controllers {
    public class DefaultDashboardController : DashboardController {
        

        public DefaultDashboardController(DashboardConfigurator configurator, IDataProtectionProvider dataProtectionProvider = null)
            : base(configurator, dataProtectionProvider) {
            
        }

        [Route("test")]
        public void test()
        {
            string sql = "SELECT * FROM dbo.coa";

            using (var connection = new SqlConnection("Server=localhost,5432;Database=test;User Id=postgres;Password=admin;"))
            {
                var orderDetail = connection.Query(sql).FirstOrDefault();
                System.Console.WriteLine("data:",orderDetail);
            }
        }
    }
}