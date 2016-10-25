using System;

namespace Icas.Common
{
    /// <summary>
    /// Exceptions of this class and its subclass are considered application exceptions and can be displayed to the end user.
    /// </summary>
    public class MiClusterException : Exception
    {
        public MiClusterException(string message) : base(message)
        {

        }
    }
}
