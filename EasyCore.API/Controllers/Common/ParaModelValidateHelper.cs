/*-------------------------------------------------------------------------
 * 作者：WuTian
 * 版本号：v1.0
 * 本类主要用途及食用方式：
 * 根据参数上的特性进行不同类型的参数校验
 *  -------------------------------------------------------------------------*/
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace EasyCore.API.Controllers
{

    public static class ParaModelValidateHelper
    {
        /// <summary>
        /// 参数模型校验
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static void Validate<T>(T entity) where T : class
        {
            Type type = entity.GetType();
            PropertyInfo[] properties = type.GetProperties();

            //循环模型的所有参数
            foreach (var item in properties)
            {

                //校验必填参数
                if (item.IsDefined(typeof(RequiredAttribute), true))//判断该参数是否有Required(RequiredAttribute)特性
                {

                    var value = item.GetValue(entity);//获取值
                    if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                    {

                        throw new Exception(string.Format("缺少必填参数{0}", item.Name));

                    }
                }

                //增加其他类型的校验的话接着写IF
                //System.ComponentModel.DataAnnotations


            }

        }
    }
}
