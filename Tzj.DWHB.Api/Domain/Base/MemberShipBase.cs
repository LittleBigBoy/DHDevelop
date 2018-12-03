using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tzj.DWHB.Api.Domain.Interface;
using Tzj.DWHB.Api.Domain.Service;

namespace Tzj.DWHB.Api.Domain.Base
{
    public static class MemberShipBase
    {
        public static IMemberShipService GetMemberShipServiceInstance()
        {
            return MemberShipService.GetInstance();
        }
    }
}