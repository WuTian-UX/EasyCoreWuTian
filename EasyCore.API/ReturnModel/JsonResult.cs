using System.ComponentModel;

namespace EasyCore.API
{
    public class JsonResult
    {
        public StatuCode Code { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }
    }

    public static class ErrorCodeHelper
    {
        public static string Description(this StatuCode enumName)
        {
            return EnumHelper.GetDescriptionByName(enumName);
        }
    }

    public enum StatuCode
    {
        [Description("成功")]
        Success = 00000000,
        [Description("失败")]
        Fail = 00000001
    }


}
