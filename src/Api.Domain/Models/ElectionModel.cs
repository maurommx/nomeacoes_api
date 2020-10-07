
using System.Collections.Generic;

namespace Api.Domain.Models
{
    public class ElectionModel : BaseModel
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private IEnumerable<OfficeModel> _offices;
        public IEnumerable<OfficeModel> Offices
        {
            get { return _offices; }
            set { _offices = value; }
        }


    }
}
