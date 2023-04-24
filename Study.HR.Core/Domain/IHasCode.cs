using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.HR.Core.Domain
{
    /// <summary>
    /// Code 속성을 가진다
    /// </summary>
    public interface IHasCode
    {
        string Code { get; }
    }
}
