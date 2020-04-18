using HSL_Infra_Dev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSL_Infra_Dev.Interfaces
{
    public interface ILocation
    {
        List<Location> GetLocation();
        Location GetLocation(int LocationId);
        string CreateLocation(Location location);
        int DeleteLocation(int location_id);
        string UpdateLocation(Location location_id);
    }
}
