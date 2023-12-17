using Common.CommonModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.ECommerceDapper
{
    public interface IECommmerceDapper
    {
        UserNameOutput GetUserByUID(UserNameInput ObjInput);
    }
}
