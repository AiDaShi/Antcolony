using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;

namespace AntcolonyProgram.Log
{
    public class SerilogConfigurationLog
    {
        /// <summary>
        /// 创建全局Logger
        /// </summary>
        [System.Obsolete]
        public static void CreateLogger(string _connectionString, string _tableName)
        {
            // 这一部分是配置Sql Server的Sink
            // 数据库连接字符串
            string connectionString = _connectionString;
            // 表名
            string tableName = _tableName;
            // 自定义字段
            var columnOptions = new ColumnOptions
            {
                AdditionalDataColumns = new Collection<DataColumn>
                {
                    new DataColumn {DataType = typeof (string), ColumnName = "User"},
                    new DataColumn {DataType = typeof (string), ColumnName = "Class"},
                }
            };
            // Sql Server的表中加入Json格式Log Event的数据字段
            //columnOptions.Store.Add(StandardColumn.Level);
            // 输出模板，Sql Server不能用这个
            const string outputTemplate = "[{Timestamp:HH:mm:ss.FFF} {Level}] {Message} ({SourceContext:l}){NewLine}{Exception}";
            Serilog.Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose() // 所有Sink的最小记录级别
                .Enrich.WithProperty("SourceContext", null) //加入属性SourceContext，也就运行时是调用Logger的具体类
                                                            //.Enrich.FromLogContext() //动态加入属性，主要是针对上面的自定义字段User和Class，当然也可以随时加入别的属性。
                //.WriteTo.Debug(outputTemplate: outputTemplate) // 写到VS Output 窗口
                .WriteTo.File("logs\\Antcolony日志—{date}.log", shared: true, restrictedToMinimumLevel: LogEventLevel.Debug,
                    outputTemplate: outputTemplate) // 写到文件，每天一个，最小记录级别是Debug，文件格式是 yyyyMMdd.log
                                                    // 记录到Sql Server，最小级别是Information
                .WriteTo.MSSqlServer(connectionString, tableName, columnOptions: columnOptions, autoCreateSqlTable: true, restrictedToMinimumLevel: LogEventLevel.Debug)
                .CreateLogger();
            //.net Core 需添加
            //Serilog.Debugging.SelfLog.Enable(msg =>
            //{
            //    Debug.Print(msg);
            //    //Debugger.Break();
            //});
        }
    }
}
