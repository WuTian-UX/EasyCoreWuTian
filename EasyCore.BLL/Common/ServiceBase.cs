/*-------------------------------------------------------------------------
 * 作者：WuTian
 * 版本号：v1.0
 * 本类主要用途描述及食用方式：
 * 所有业务层服务实例实例化时，构造DbContext
 *  -------------------------------------------------------------------------*/
using Chloe;
using EasyCore.DA;

namespace EasyCore.BLL
{
    public class ServiceBase
    {

        private IDbContext _dbContext;
        public IDbContext DbContext
        {
            get
            {
                if (_dbContext == null)
                    _dbContext = CholeDbContextFactory.CreateContext();
                return _dbContext;
            }
            set
            {
                _dbContext = value;
            }
        }

    }
}
