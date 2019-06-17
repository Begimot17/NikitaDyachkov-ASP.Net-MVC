using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.ADO.Repositories
{
    public class BaseRepository
    {
        protected string ConnectionString => ConfigurationManager.ConnectionStrings["ADOConnection"].ConnectionString;
    }
}
