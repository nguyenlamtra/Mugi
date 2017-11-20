using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mugi.Web.Model.ViewModel;
using Mugi.Domain.Entities;
using Mugi.Web.Model;

namespace Mugi.Web.Extensions
{
    public static class SessionExtensions
    {

        public static SessionModel
           GetSession(this ISession session, string key)
        {
            var data = session.GetString(key);
            if (data == null)
            {
                return new SessionModel();
            }

            return JsonConvert.DeserializeObject<SessionModel>(data);
        }

        public static SessionStaffModel
           GetStaffSession(this ISession session, string key)
        {
            var data = session.GetString(key);
            if (data == null)
            {
                return new SessionStaffModel();
            }

            return JsonConvert.DeserializeObject<SessionStaffModel>(data);
        }

        public static void SetSession(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static Order
          GetOrder(this ISession session, string key)
        {
            var data = session.GetString(key);
            if (data == null)
            {
                return new Order();
            }

            return JsonConvert.DeserializeObject<Order>(data);
        }
        //public static CustomerModel
        //    GetCustomer(this ISession session, string key)
        //{
        //    var data = session.GetString(key);
        //    if (data == null)
        //    {
        //        return new CustomerModel();
        //    }

        //    return JsonConvert.DeserializeObject<CustomerModel>(data);
        //}

    }
}
