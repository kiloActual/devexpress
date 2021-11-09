using Dapper;
using DevExpress.DashboardAspNetCore;
using DevExpress.DashboardWeb;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;
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

            using (var connection = new NpgsqlConnection("Host=localhost;Port=5432;Username=postgres;Password=admin;Database=test;"))
            {
                var orderDetail = connection.Query(sql).FirstOrDefault();
                System.Console.WriteLine(connection.Query(sql).Count());
                System.Console.WriteLine("data:",orderDetail);
            }
        }
    }
}