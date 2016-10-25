using System;
using System.Runtime.Serialization;

namespace Ezfx.Csv
{
    [Serializable]
    public class DataTypeNotSupportedException : CsvException
    {
        public DataTypeNotSupportedException() : base() { }
        public DataTypeNotSupportedException(string message) : base(message) { }
        public DataTypeNotSupportedException(string message, Exception innerException) : base(message, innerException) { }
        protected DataTypeNotSupportedException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
