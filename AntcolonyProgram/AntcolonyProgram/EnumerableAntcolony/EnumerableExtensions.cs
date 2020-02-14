using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AntcolonyProgram.EnumerableAntcolony
{
    public static class EnumerableExtensions
    {

        /// <summary>
        /// 动态反射集合资源
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="fields"> 指定哪些属性或字段需要进行实例 </param>
        /// <returns></returns>
        public static IEnumerable<ExpandoObject> ToDynamicIEnumerable<TSource>(this IEnumerable<TSource> source, string fields = null)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var expandoObjectList = new List<ExpandoObject>();
            var propertyInfoList = new List<PropertyInfo>();
            if (string.IsNullOrWhiteSpace(fields))
            {
                //获取类中所有的公共的字段与实例
                var propertyInfos = typeof(TSource).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                //添加到propertyInfoList集合中去
                propertyInfoList.AddRange(propertyInfos);
            }
            else
            {
                var fieldsAfterSplit = fields.Split(',').ToList();
                foreach (var field in fieldsAfterSplit)
                {
                    var propertyName = field.Trim();
                    if (string.IsNullOrEmpty(propertyName))
                    {
                        continue;
                    }
                    //获取属性
                    var propertyInfo = typeof(TSource).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                    if (propertyInfo == null)
                    {
                        throw new Exception($"Property {propertyName} wasn't found on {typeof(TSource)}");
                    }
                    //添加到集合中
                    propertyInfoList.Add(propertyInfo);
                }
            }
            //通过每一个类获取其中的属性,字段的值到List<ExpandoObject> expandoObjectList中
            foreach (TSource sourceObject in source)
            {
                var dataShapedObject = new ExpandoObject();
                foreach (var propertyInfo in propertyInfoList)
                {
                    var propertyValue = propertyInfo.GetValue(sourceObject);
                    ((IDictionary<string, object>)dataShapedObject).Add(propertyInfo.Name, propertyValue);
                }
                expandoObjectList.Add(dataShapedObject);
            }

            return expandoObjectList;

        }
    }
}
