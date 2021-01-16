using Dapper;
using DhubSolutions.PerformanceParticipation.Domain.Repositories.DataUploader;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Reflection;

namespace DhubSolutions.PerformanceParticipation.Infrastructure.Data.Repositories.DataUploader
{
    public class DataUploaderRepository : IDataUploaderRepository
    {
        private readonly IConfiguration configuration;
        private readonly string _connectionString;

        public DataUploaderRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            _connectionString = configuration.GetConnectionString("performanceParticipation");
        }

        public void Delete<T>(string organizationId, string periodId) where T : class, new()
        {

            using (IDbConnection connection = GetConnection())
            {
                Type entityType = typeof(T);
                var parameters = new
                {
                    PeriodID = periodId,
                    OrganisatioID = organizationId
                };
                var query = $"DELETE from [rmg].[{entityType.Name}] WHERE OrganisationID=@OrganisationID  AND  PeriodID=@PeriodID ";
                var result = connection.Query<T>(query, parameters);
            }
        }

        public void Delete<T>() where T : class, new()
        {
            using (IDbConnection connection = GetConnection())
            {
                Type entityType = typeof(T);
                var query = $"DELETE from [ppart].[{entityType.Name}]";
                var result = connection.Query<T>(query);
            }

        }

        public object GetDataUploadChecks(string organisationId, string periodId)
        {
            using (IDbConnection connection = GetConnection())
            {
                var parameters = new { PerioID = periodId, OrganisationID = organisationId };
                var query = $"SELECT distinct * FROM [rmg].[DataUploadChecks] (@OrganisationID, @PeriodID) ORDER BY Period, AccountID, ExcelID";
                return connection.Query<dynamic>(query, parameters, commandTimeout: 600);
            }


        }


        public object GetAccountsByOrganisationID(string organisationId)
        {
            using (IDbConnection connection = GetConnection())
            {
                var parameters = new { OrganisationID = organisationId };
                var query = $"SELECT DISTINCT AccountName,AccountID,OrganisationID,(CASE WHEN AccountID=OrganisationID THEN 'true' ELSE 'false' END ) AS Consolidated FROM [lnet].[SumaryField] where OrganisationID=@OrganisationID ";
                return connection.Query<dynamic>(query, parameters);
            }

        }

        public object GetExcelFields()
        {
            throw new NotImplementedException();
        }

        public object GetOrganisations()
        {
            throw new NotImplementedException();
        }

        public object GetAllPeriods()
        {
            throw new NotImplementedException();
        }

        public void Select<T>(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Insert<T>(T entity) where T : class, new()
        {

            using (IDbConnection connection = GetConnection())
            {

                Type entityType = typeof(T);
                PropertyInfo[] props = entityType.GetProperties();
                string Columns = "";
                string aColumns = "";
                foreach (var prop in props)
                {
                    Columns += $"[{prop.Name}] ,";
                    aColumns += $"@{prop.Name} ,";
                }
                Columns = Columns.Remove(Columns.Length - 1);
                aColumns = aColumns.Remove(aColumns.Length - 1);

                string query = $"Insert into [ppart].[{entityType.Name}] ({Columns}) values ({aColumns})";
                connection.Execute(query, entity);

            }


        }

        public IEnumerable<object> GetExcelRefItems()
        {
            //string query = @"SELECT
            //                     rmg.ExcelRefID.ExcelID,
            //                     rmg.ExcelRefID.[Account Name-Excel],
            //                     rmg.ExcelRefID.IsFormula,
            //                     rmg.ExcelRefID.ReportType 
            //                    FROM
            //                     rmg.ExcelRefID";

            //return _unitOfWork.ExecuteQuery<dynamic>(query, commandTimeout: 600);

            throw new NotImplementedException();
        }

        public IEnumerable<object> GetAccounts(int? organization = null)
        {
            //string query = @"SELECT DISTINCT
            //                     lnet.SumaryField.AccountName,
            //                     lnet.SumaryField.AccountID,
            //                     lnet.SumaryField.OrganisationID,
            //                     ( CASE WHEN lnet.SumaryField.AccountID = lnet.SumaryField.OrganisationID THEN 'true' ELSE 'false' END ) AS Consolidated 
            //                    FROM
            //                     lnet.SumaryField";

            //return _unitOfWork.ExecuteQuery<dynamic>(query, commandTimeout: 600);

            throw new NotImplementedException();
        }


        #region Private Property

        private IDbConnection GetConnection() => new SqlConnection(_connectionString);

        #endregion
    }
}
