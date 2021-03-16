/*-------------------------------------------------------------------------
 * 作者：WuTian
 * 版本号：v1.0
 * 本类主要用途描述及食用方式：
 * Chole的OracleConnectionFactory
 *  -------------------------------------------------------------------------*/
using Chloe.Infrastructure;
using EasyCore.Unity;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;

namespace EasyCore.DA
{
    public class OracleConnectionFactory : IDbConnectionFactory
    {
        private readonly string _connString = null;
        public OracleConnectionFactory()
        {

            string PROTOCOL = AppConfigurtaionServices.Configuration["OracleSettings:PROTOCOL"];
            string HOST = AppConfigurtaionServices.Configuration["OracleSettings:HOST"];
            string PORT = AppConfigurtaionServices.Configuration["OracleSettings:PORT"];
            string SERVICE_NAME = AppConfigurtaionServices.Configuration["OracleSettings:SERVICE_NAME"];
            string UserId = AppConfigurtaionServices.Configuration["OracleSettings:UserId"];
            string Password = AppConfigurtaionServices.Configuration["OracleSettings:Password"];
            _connString =

                "Data Source = " +
                    "(DESCRIPTION = " +
                    "(ADDRESS_LIST = " +
                        "(ADDRESS = (PROTOCOL = " + PROTOCOL + ")(HOST = " + HOST + ")(PORT = " + PORT + "))" +
                    ")" +
                    "(CONNECT_DATA = (SERVICE_NAME = " + SERVICE_NAME + "))); User Id = " + UserId + "; Password = " + Password + "; ";

        }
        public IDbConnection CreateConnection()
        {
            OracleConnection oracleConnection = new OracleConnection(this._connString);
            OracleConnectionDecorator conn = new OracleConnectionDecorator(oracleConnection);
            return conn;
        }
    }


    internal sealed class OracleConnectionDecorator : IDbConnection
    {

        private readonly OracleConnection _oracleConnection;

        public OracleConnectionDecorator(OracleConnection oracleConnection)
        {
            _oracleConnection = oracleConnection ?? throw new Exception("Please call 911.");
        }

        public string ConnectionString
        {
            get { return _oracleConnection.ConnectionString; }
            set { _oracleConnection.ConnectionString = value; }
        }

        public int ConnectionTimeout
        {
            get { return _oracleConnection.ConnectionTimeout; }
        }

        public string Database
        {
            get { return _oracleConnection.Database; }
        }

        public ConnectionState State
        {
            get { return _oracleConnection.State; }
        }

        public IDbTransaction BeginTransaction()
        {
            return _oracleConnection.BeginTransaction();
        }

        public IDbTransaction BeginTransaction(IsolationLevel il)
        {
            return _oracleConnection.BeginTransaction(il);
        }

        public void ChangeDatabase(string databaseName)
        {
            _oracleConnection.ChangeDatabase(databaseName);
        }

        public void Close()
        {
            _oracleConnection.Close();
        }

        public IDbCommand CreateCommand()
        {
            var cmd = _oracleConnection.CreateCommand();
            cmd.BindByName = true;
            return cmd;
        }

        public void Open()
        {
            _oracleConnection.Open();
        }



        public void Dispose()
        {

            _oracleConnection.Dispose();
        }

    }
}
