﻿using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace ECommerce.Infrastructure.DBContext;
public class DapperDBContext
{
    private readonly IConfiguration _configuration;
    private readonly IDbConnection _connection;
    public DapperDBContext(IConfiguration configuration)
    {
        _configuration = configuration;
        string? connectionStringTemplate = _configuration.GetConnectionString("PostgresConnection")!;
        string connectionString = connectionStringTemplate.Replace("$POSTGRES_HOST", Environment.GetEnvironmentVariable("POSTGRES_HOST"))
            .Replace("$POSTGRES_PASSWORD", Environment.GetEnvironmentVariable("POSTGRES_PASSWORD"));

        _connection = new NpgsqlConnection(connectionString);
    }
    public IDbConnection dbConnection => _connection;
}
