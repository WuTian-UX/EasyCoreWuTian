/*-------------------------------------------------------------------------
 * 作者：WuTian
 * 版本号：v1.0
 * 本类主要用途描述及食用方式：
 * 所有业务层服务实例实例化时，构造DbContext
 *  -------------------------------------------------------------------------*/
using EasyCore.DA;
using Microsoft.EntityFrameworkCore;

namespace EasyCore.BLL
{
    public class ServiceBase
    {

        DbContext _dbContext;

        public DbContext DbContext
        {
            get
            {
                if (this._dbContext == null)
                    this._dbContext = DbContextFactory.CreateContext();
                return this._dbContext;
            }
            set
            {
                this._dbContext = value;
            }
        }

    }
}
