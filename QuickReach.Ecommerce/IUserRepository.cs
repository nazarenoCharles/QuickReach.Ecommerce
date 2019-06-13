using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReach.Ecommerce
{
    public interface IUserRepository
    {
        void Save(User user);
        
    }
}
