using System;

namespace Common
{
    public class SQLOutputParam : Attribute
    {
        private string Param;
        public SQLOutputParam(string Param)
        {
            this.Param = Param;
        }
    }    
}
