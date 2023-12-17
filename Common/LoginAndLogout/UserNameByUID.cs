using Common.CommonModel;
using Common.ECommerceDapper;

namespace Common.LoginAndLogout
{
    public class UserNameByUID
    {
        public UserNameOutput GetUserByUID(UserNameInput ObjInput) => new ECommmerceDapper().GetUserByUID(ObjInput);        
    }
}
