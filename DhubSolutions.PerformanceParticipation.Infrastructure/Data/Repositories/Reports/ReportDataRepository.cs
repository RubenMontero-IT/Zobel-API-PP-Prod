using Dapper;
using DhubSolutions.PerformanceParticipation.Domain.Repositories.Reports;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DhubSolutions.PerformanceParticipation.Infrastructure.Data.Repositories.Reports
{
    public class ReportDataRepository : IReportDataRepository
    {
        private readonly IConfiguration _configuration;
        private readonly int? _commandTimeout;
        private readonly string _connectionString;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="connectionId"></param>
        public ReportDataRepository(IConfiguration configuration, string connectionId)
        {
            _connectionString = configuration.GetConnectionString(connectionId);
            if (string.IsNullOrEmpty(_connectionString) || string.IsNullOrWhiteSpace(_connectionString))
                throw new NullReferenceException(nameof(_connectionString));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public ReportDataRepository(IConfiguration configuration)
            : this(configuration, connectionId: "performanceParticipation")
        {
            _configuration = configuration;
            _commandTimeout = configuration.GetValue<int?>("commandTimeout", defaultValue: default);
        }

        /// <summary>
        /// 
        /// </summary>        
        /// <returns></returns>
        public async Task<string> GetOrganizations()
        {
            using (IDbConnection connection = GetConnection())
            {
                string query = @"SELECT DISTINCT OrganizationID organizationId
                                       ,OrganizationName        organizationName
                                 FROM  ppart.YearSummaryFieldSetting ysfs
                                       LEFT JOIN userm.Organization o   ON o.LucanetId = ysfs.OrganizationID";

                connection.Open();

                dynamic result = await connection.QueryAsync(query, commandTimeout: _commandTimeout);

                return JsonConvert.SerializeObject(result);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="initialYear"></param>
        /// <param name="endYear"></param>
        /// <returns></returns>
        public async Task<string> GetPerformanceDetails(int? initialYear, int? endYear)
        {
            using (IDbConnection connection = GetConnection())
            {
                var @params = new { initialYear, endYear };

                string query = @"SELECT *  FROM [ppart].[GetPerformanceDetails] (@initialYear, @endYear)  
                                 ORDER BY OrganizationName, Year, MainCategory";

                connection.Open();

                var result = (await connection.QueryAsync(query, @params, commandTimeout: _commandTimeout))
                               .GroupBy(r => new { r.OrganizationID, r.OrganizationName })
                               .Select(g => new
                               {
                                   organizationName = g.Key.OrganizationName,
                                   organizationId = g.Key.OrganizationID,
                                   data = g.GroupBy(t => new { t.Year })
                                                    .Select(rowYear => new
                                                    {
                                                        year = rowYear.Key.Year,
                                                        items = rowYear.Select(entry => new
                                                        {
                                                            category = entry.MainCategory,
                                                            amount = entry.Amount
                                                        })
                                                    })
                               }).ToArray();

                return JsonConvert.SerializeObject(result);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="initialYear"></param>
        /// <param name="endYear"></param>
        /// <param name="mainCategory"></param>
        /// <param name="accountLevelID"></param>
        /// <returns></returns>
        public async Task<string> GetNormalizationDetails(int? initialYear, int? endYear, string mainCategory, string accountLevelID)
        {
            using (IDbConnection connection = GetConnection())
            {
                var @params = new { initialYear, endYear, mainCategory, accountLevelID };

                string query = @"SELECT *  FROM [ppart].[GetNormalizationDetails] (@initialYear, @endYear, @mainCategory, @accountLevelID) 
                                 ORDER BY OrganizationName, Year, ItemDescription, SubCategory";

                connection.Open();

                var result = (await connection.QueryAsync(query, @params, commandTimeout: _commandTimeout))
                            .GroupBy(r => new { r.OrganizationID, r.OrganizationName })
                            .Select(g => new
                            {
                                organizationName = g.Key.OrganizationName,
                                organizationId = g.Key.OrganizationID,
                                data = g.GroupBy(t => new { t.Year })
                                       .Select(rowYear => new
                                       {
                                           year = rowYear.Key.Year,
                                           items = rowYear.Select(entry => new
                                           {
                                               description = entry.ItemDescription,
                                               subCategory = entry.SubCategory,
                                               amount = entry.Amount
                                           })
                                       })
                            }).ToArray();

                return JsonConvert.SerializeObject(result);
            }
        }


        #region Private Property

        private IDbConnection GetConnection() => new SqlConnection(_connectionString);

        #endregion
    }
}
