using Common.LoginAndLogout;

namespace Common
{
    public class UserLogout
    {
        public LogoutOutput GetLogout(LogoutInput ObjInput)
        {
            return new ECommerceDAL("ConnectionString").ExecuteSPWithOutputParam<LogoutOutput, LogoutInput>("USR.Logout", ObjInput);
        }
    }
}
