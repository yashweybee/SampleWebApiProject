using SampleDAL.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleBLL.Interfaces
{
    public interface IBooksService
    {
        Task<IEnumerable<Book>> GetAllAsync();

    }
}
