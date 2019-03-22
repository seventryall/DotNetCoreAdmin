using Jun.Admin.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jun.Admin.EntityFramework
{
   public static class CommonCondition
    {
        /// <summary>
        /// 过滤掉已删除掉数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IQueryable<T> FilterByValidation<T>(this IQueryable<T> input)
            where T : BaseEntity
        {
            return input.Where(entity =>entity.IsDelete == false);
        }
    }
}
