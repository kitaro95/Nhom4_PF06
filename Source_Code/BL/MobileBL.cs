using System;
using Persistion;
using DAL;
using System.Collections.Generic;

namespace BL
{
    public class MobileBL
    {
        private MobileDAL mobileDAL;

        public MobileBL()
        {
            mobileDAL = new MobileDAL();
        }
        public Mobile GetMobilebyId(int MobileID)
        {
            return mobileDAL.GetMobilebyId(MobileID);
        }
        public List<Mobile> GetListMobile()
        {
            return mobileDAL.GetListMobile();
        }
        public List<Mobile> GetMobilebyName(string MobileName)
        {
            return mobileDAL.GetMobilebyName(MobileName);
        }
    }
}
