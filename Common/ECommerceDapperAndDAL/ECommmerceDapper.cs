using Common.CommonModel;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Common.ECommerceDapper
{
    public class ECommmerceDapper : IECommmerceDapper
    {
        private IDbConnection db;
        public ECommmerceDapper()
        {
            db = new SqlConnection();
            db.ConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionString").Value.ToString();
        }
        public UserNameOutput GetUserByUID(UserNameInput ObjInput)
        {
            string StrQuery = @"SELECT USR_User_Name[StrUserName],USR_User_ID[IntUserId],USR_User_Role[StrUserRole] 
                                FROM 
                                USR.User_Info 
                                WHERE USR_User_ID = @IntUserId";
            return db.QueryFirstOrDefault<UserNameOutput>(StrQuery, ObjInput);
        }
    }
}
