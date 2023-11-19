using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Data.Common;

namespace RubiconTask.Middlewares
{
  public class SqlConnectionHealthCheck : IHealthCheck
  {
    private readonly IConfiguration _config;
    public SqlConnectionHealthCheck(IConfiguration configuration)
    {
      _config = configuration;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
      string? connectionString = _config.GetConnectionString("DefaultConnection");
      if (connectionString == null)
      {
        return new HealthCheckResult(context.Registration.FailureStatus);
      }
      using (var connection = new SqlConnection(connectionString))
      {
        try
        {
          await connection.OpenAsync(cancellationToken);
          var command = connection.CreateCommand();
          command.CommandText = "select 1";
          await command.ExecuteNonQueryAsync(cancellationToken);

        }
        catch (DbException ex)
        {
          return new HealthCheckResult(status: context.Registration.FailureStatus, exception: ex);
        }
      }

      return HealthCheckResult.Healthy();
    }
  }
}
