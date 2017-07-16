using ThreeLittlePigs.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeLittlePigs.Web.DAL
{
    public interface IHouseDAL
    {
        List<House> GetAllHouses();
        House GetHouse(string houseCode);
    }
}
