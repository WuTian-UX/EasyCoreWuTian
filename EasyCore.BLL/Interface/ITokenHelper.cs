using EasyCore.Unity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyCore.BLL
{
    public interface ITokenHelper
    {
        /// <summary>
        /// 根据一个对象通过反射提供负载生成token
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="user"></param>
        /// <returns></returns>
        TnToken CreateToken<T>(T user) where T : class;
        /// <summary>
        /// 根据键值对提供负载生成token
        /// </summary>
        /// <param name="keyValuePairs"></param>
        /// <returns></returns>
        TnToken CreateToken(Dictionary<string, string> keyValuePairs);
    }
}
