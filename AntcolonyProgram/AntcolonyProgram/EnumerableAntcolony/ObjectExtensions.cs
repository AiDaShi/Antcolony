using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AntcolonyProgram.EnumerableAntcolony
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// 动态返回单个资源
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="fields"> 反射所需要的字段（用逗号分隔） </param>
        /// <returns></returns>
        public static ExpandoObject ToDynamic<TSource>(this TSource source, string fields = null)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var dataShapedObject = new ExpandoObject();
            //当为空时表示返回所有字段
            if (string.IsNullOrWhiteSpace(fields))
            {
                var propertyInfos = typeof(TSource).GetProperties(BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                foreach (var propertyInfo in propertyInfos)
                {
                    var propertyValue = propertyInfo.GetValue(source);
                    ((IDictionary<string, object>)dataShapedObject).Add(propertyInfo.Name, propertyValue);
                }
                return dataShapedObject;
            }
            //返回指定字段或属性
            var fieldsAfterSplit = fields.Split(',').ToList();
            foreach (var field in fieldsAfterSplit)
            {
                var propertyName = field.Trim();
                var propertyInfo = typeof(TSource).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (propertyInfo == null)
                {
                    throw new Exception($"Can't found property ??{typeof(TSource)}?ˉ on ??{propertyName}?ˉ");
                }
                var propertyValue = propertyInfo.GetValue(source);
                ((IDictionary<string, object>)dataShapedObject).Add(propertyInfo.Name, propertyValue);
            }

            return dataShapedObject;
        }
    }
}
