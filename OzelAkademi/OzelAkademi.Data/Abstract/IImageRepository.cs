using OzelAkademi.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelAkademi.Data.Abstract
{
    public interface IImageRepository: IGenericRepository<Image>
    {
        int ImageCount(int advertId);
    }
}
