using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;


namespace Common
{
    public class ECommerceDAL
    {
        private string StrConnectionString;
        private SqlDataAdapter ObjDataAdapter;
        private DataTable ObjDataTable;
        public ECommerceDAL(string Input)
        {
            StrConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection(Input).Value.ToString();
            ObjDataAdapter = new SqlDataAdapter();
            ObjDataTable = new DataTable();
        }

        #region Common Input Configuration
        private void InputConfig<T>(SqlCommand cmd, T ObjInput) where T : class, new()
        {
            Type type = ObjInput.GetType();
            PropertyInfo[] properties = type.GetProperties();
            properties.ToList().ForEach(a =>
            {
                cmd.Parameters.AddWithValue("@" + a.Name, a.GetValue(ObjInput));
                a.CustomAttributes.ToList().ForEach(x =>
                {
                    if (x.AttributeType.Name == "NotMapped")
                    {
                        cmd.Parameters.Remove(a.Name);
                    }
                });
            });

        }
        #endregion

        #region ExecuteSPWithOutputParam
        public T1 ExecuteSPWithOutputParam<T1, T2>(string SP, T2 ObjInput) where T1 : class, new() where T2 : class, new()
        {
            T1 ObjOutput = null;
            using (SqlConnection con = new SqlConnection(StrConnectionString))
            {
                SqlCommand cmd = new SqlCommand(SP, con);
                cmd.CommandType = CommandType.StoredProcedure;
                InputParamConfigWithOutputParam(cmd, ObjInput);
                con.Open();
                int Output = cmd.ExecuteNonQuery();
                ObjOutput = Activator.CreateInstance<T1>();
                GetOutputWithOutputParam<T1>(ObjOutput, cmd);
                con.Close();
            }
            return ObjOutput;
        }
        #region Input  and Output Configuration for SP with output param
        private void InputParamConfigWithOutputParam<T>(SqlCommand cmd, T ObjInput) where T : class, new()
        {
            Type type = ObjInput.GetType();
            PropertyInfo[] properties = type.GetProperties();
            MethodInfo[] methods = type.GetMethods();

            properties.ToList().ForEach(a =>
            {
                cmd.Parameters.AddWithValue("@" + a.Name, a.GetValue(ObjInput));// Adds all the param to the SQLCommand from the given Object 
                a.CustomAttributes.ToList().ForEach(x =>
                {
                    if (x.AttributeType.Name == "SQLOutputParam")// Making parameter as output paramter with attribute SQLOutputParam
                    {
                        cmd.Parameters["@" + a.Name].Direction = ParameterDirection.Output;
                    }
                    if (x.AttributeType.Name == "NotMappedAttribute")// Removes the paramters with NotMapped attribute
                    {                        
                        cmd.Parameters.Remove(cmd.Parameters["@"+a.Name]);
                    }
                });
            });
        }
        private void GetOutputWithOutputParam<T>(T ObjOutput, SqlCommand cmd) where T : class, new()
        {
            Type type = ObjOutput.GetType();
            PropertyInfo[] properties = type.GetProperties();
            properties.ToList().ForEach(a =>
            {
                a.CustomAttributes.ToList().ForEach(x =>
                {
                    if (x.AttributeType.Name == "SQLOutputParam")
                    {
                        a.SetValue(ObjOutput, cmd.Parameters["@" + a.Name].Value);
                    }
                });
            });
        }
        #endregion
        #endregion

        #region ExecuteFirstModel
        public T1 ExecuteFirstModel<T1, T2>(string SP, T2 ObjInput) where T1 : class, new() where T2 : class, new()
        {
            using (SqlConnection con = new SqlConnection(StrConnectionString))
            {
                SqlCommand cmd = new SqlCommand(SP, con);
                InputConfig<T2>(cmd, ObjInput);
                cmd.CommandType = CommandType.StoredProcedure;
                ObjDataAdapter.SelectCommand = cmd;
                ObjDataAdapter.Fill(ObjDataTable);
            }
            T1 ObjOutput = Activator.CreateInstance<T1>();
            OutputConfiguration<T1>(ObjOutput);
            return ObjOutput;
        }
        #region ExecuteFirstModel Output configuration 
        private void OutputConfiguration<T>(T ObjOutput) where T : class, new()
        {
            Type type = ObjOutput.GetType();
            PropertyInfo[] properties = type.GetProperties();

            foreach (DataRow dr in this.ObjDataTable.Rows)
            {
                int i = 0;
                properties.ToList().ForEach(a =>
                {
                    if (this.ObjDataTable.Columns.Contains(a.Name))
                    {
                        a.SetValue(ObjOutput, dr[i++]);
                    }
                });
            }
        }
        #endregion
        #endregion

        #region ExeccuteSingleModel
        public List<T2> ExeccuteSingleModel<T2, T1>(string SP, T1 ObjInput) where T1 : class, new() where T2 : class, new()
        {
            using (SqlConnection con = new SqlConnection(StrConnectionString))
            {
                SqlCommand cmd = new SqlCommand(SP, con);
                cmd.CommandType = CommandType.StoredProcedure;
                InputConfig<T1>(cmd, ObjInput);
                ObjDataAdapter.SelectCommand = cmd;
                ObjDataAdapter.Fill(ObjDataTable);
            }
            List<T2> ObjOutput = Activator.CreateInstance<List<T2>>();
            ExeccuteSingleModelOutputConfiguration<T2>(ObjOutput);
            return ObjOutput;
        }
        private void ExeccuteSingleModelOutputConfiguration<T>(List<T> ObjOutput) where T : class, new()
        {
            Type type = Activator.CreateInstance<T>().GetType();
            PropertyInfo[] properties = type.GetProperties();

            foreach (DataRow dr in ObjDataTable.Rows)
            {
                T Output = Activator.CreateInstance<T>();
                foreach (DataColumn dc in ObjDataTable.Columns)
                {
                    properties.ToList().ForEach(a =>
                    {
                        if (dc.ColumnName == a.Name)
                        {
                            if (dr[dc.ColumnName] != null)
                            {
                                if (!dr.IsNull(a.Name))
                                {
                                    a.SetValue(Output, dr[dc.ColumnName]);
                                }                                
                            }
                        }
                    });
                }
                ObjOutput.Add(Output);
            }
        }
        #endregion

        #region ExecuteSingleModelWithoutInput
        public List<T> ExecuteSingleModelWithoutInput<T>(string SP) where T: class, new()
        {
            using (SqlConnection con = new SqlConnection(StrConnectionString))
            {
                SqlCommand cmd = new SqlCommand(SP, con);
                cmd.CommandType = CommandType.StoredProcedure;
                ObjDataAdapter.SelectCommand = cmd;
                ObjDataAdapter.Fill(ObjDataTable);
            }
            List<T> ObjOutput = Activator.CreateInstance<List<T>>();
            ExeccuteSingleModelOutputConfiguration<T>(ObjOutput);
            return ObjOutput;
        }
        #endregion ExecuteSingleModelWithoutInput
    }
}
