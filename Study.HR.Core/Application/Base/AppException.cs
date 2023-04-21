using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.HR.Core.Application.Base
{
    /// <summary>
    /// 응용계층 예외
    /// </summary>
    public class AppException : Exception
    {
        /// <summary>
        /// 예외정보를 담고 있는 객체
        /// </summary>
        public object? Tag { get; }

        public AppException(string? message, object? tag = null) : base(message)
        {
            Tag = tag;
        }
    }
}
