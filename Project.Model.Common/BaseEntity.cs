using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model.Common
{
    //would use properties here that could be inherited in models but
    //there is no point in putting them because we only have two models,
    //this is used in case we have more models in order to write less code
    public abstract class BaseEntity
    {
        //public int Id { get; set; }
        //public DateTime? DateCreated { get; set; }
        //public DateTime? DateModified { get; set; }
    }
}
