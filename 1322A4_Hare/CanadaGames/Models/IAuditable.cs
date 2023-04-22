using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CanadaGames.Models
{
    internal interface IAuditable
    {
        string CreatedBy { get; set; }
        DateTime? CreatedOn { get; set; }
        string UpdatedBy { get; set; }
        DateTime? UpdatedOn { get; set; }
    }
}
