using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.HR.Core.Domain.Exceptions
{
    public class DomainException : Exception
    {
        /// <summary>
        /// 예외정보를 담고 있는 객체
        /// </summary>
        public object? Tag { get; }

        public DomainException(string? message, object? tag = null) : base(message)
        {
            Tag = tag;
        }
    }
}
