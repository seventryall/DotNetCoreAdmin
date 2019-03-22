using System;
using System.Collections.Generic;
using System.Text;

namespace Jun.Admin.Service
{
   public class BaseService
    {
        public ResponseData<T> DoInvoke<T>(Action<ResponseData<T>> action)
        {
            var result = new ResponseData<T>();
            try
            {
                action(result);
            }
            catch (Exception ex)
            {
                result.msg = "error";
            }
            return result;
        }
    }
}
