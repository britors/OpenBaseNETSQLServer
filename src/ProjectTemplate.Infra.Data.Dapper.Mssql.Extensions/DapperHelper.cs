using System.Text;
using Dapper;

namespace OpenBaseNET.Infra.Data.Dapper.Mssql.Extension;

public static class DapperHelper
{
    public static string BuildCommandWithParams(object? param, string command)
    {
        var sb = new StringBuilder();

        var args = param is not null ? (DynamicParameters)param : new DynamicParameters();
        foreach (var name in args.ParameterNames)
        {
            var value = args.Get<dynamic>(name);

            var type = value.GetType();
            if (type == typeof(DateTime))
                sb.AppendFormat("DECLARE @{0} DATETIME = '{1:yyyy-MM-dd HH:mm:ss.fff}';\n", name, value);
            else if (type == typeof(bool))
                sb.AppendFormat("DECLARE @{0} BIT = {1};\n", name, value ? 1 : 0);
            else if (type == typeof(int))
                sb.AppendFormat("DECLARE @{0} INT = {1};\n", name, value);
            else if (type == typeof(long))
                sb.AppendFormat("DECLARE @{0} BIGINT = {1};\n", name, value);
            else if (type == typeof(decimal))
                sb.AppendFormat("DECLARE @{0} DECIMAL(18, 2) = {1};\n", name, value);
            else if (type == typeof(double))
                sb.AppendFormat("DECLARE @{0} FLOAT = {1}\n;", name, value);
            else if (type == typeof(string))
                sb.AppendFormat("DECLARE @{0} NVARCHAR(MAX) = '{1}';\n", name, value);
            else
                sb.AppendFormat("DECLARE @{0} NVARCHAR(MAX) = '{1}';\n", name, value);
        }

        sb.Append("\n\n ");


        sb.Append(command);
        return sb.ToString();
    }
}