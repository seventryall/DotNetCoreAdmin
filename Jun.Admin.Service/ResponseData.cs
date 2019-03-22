using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jun.Admin.Service
{
    public class ResponseData<T>
    {
        public int code { get; set; } //为与layui异步接口保持一致，暂时默认0为返回正确，以后再做处理

        public string msg { get; set; }

        public int count { get; set; }

        public T data { get; set; }
    }
}
