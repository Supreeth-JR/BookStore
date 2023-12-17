using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class UserRegistration
    {
        public UserRegistrationOutput GetUserRegistration(UserRegistrationInput ObjInput)
        {
            if (ObjInput != null)
            {
                return new ECommerceDAL("ConnectionString").ExecuteSPWithOutputParam<UserRegistrationOutput, UserRegistrationInput>
                    ("[USR].[UserInformationInsert]", ObjInput);
            }
            return null;
        }
    }
}
