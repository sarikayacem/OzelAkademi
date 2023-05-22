using Microsoft.EntityFrameworkCore;
using OzelAkademi.Data.Abstract;
using OzelAkademi.Data.Concrete.EfCore.Context;
using OzelAkademi.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelAkademi.Data.Concrete.EfCore
{
    public class EfCoreImageRepository : EfCoreGenericRepository<Image>, IImageRepository
    {
        public EfCoreImageRepository(OzelAkademiContext _appContext) : base(_appContext)
        {
        }
        OzelAkademiContext AppContext
        {
            get { return _dbContext as OzelAkademiContext; }
        }

        public int ImageCount(int advertId)
        {
            throw new NotImplementedException();
        }
    }
}
