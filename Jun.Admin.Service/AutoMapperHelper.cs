using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jun.Admin.Service
{
    public static class AutoMapperHelper
    {
        /// <summary>
        ///  类型映射
        /// </summary>
        public static T MapTo<T>(this object obj)
        {
            if (obj == null) return default(T);
            var sourceType = obj.GetType();
            Mapper.Initialize(cfg => cfg.CreateMap(sourceType, typeof(T)));
            return Mapper.Map<T>(obj);
        }
    }
}
