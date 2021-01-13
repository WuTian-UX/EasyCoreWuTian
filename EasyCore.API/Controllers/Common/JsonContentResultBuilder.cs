/*-------------------------------------------------------------------------
 * 作者：WuTian
 * 版本号：v1.0
 * 本类主要用途及食用方式：
 * 格式化接口返回值ContentResult（并转为JSON格式）
 *  -------------------------------------------------------------------------*/
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EasyCore.API.Controllers
{
    
    public class JsonContentResultBuilder
    {

        public static ContentResult BuildViewJsonResult(dynamic data, StatuCode statuCode= StatuCode.Success, string errorMessage = null)
        {
            string statuDescription = statuCode.Description();
            string separator = !string.IsNullOrEmpty(statuDescription) ? "：" : string.Empty;

            JsonResult result = new JsonResult
            {
                Code = statuCode,
                Message = !string.IsNullOrEmpty(errorMessage)
                    ? $"{statuDescription}{separator}{errorMessage}"
                    : statuDescription,
                Data = data,
            };

            return new ContentResult
            {

                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(result)

            };
        }



    }
}
