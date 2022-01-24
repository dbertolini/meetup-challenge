using System;

namespace MeetupSantander.API.Data.Exceptions
{
    public class DataException : Exception
    {
        public int Status { get; set; } = 500;
        public object Value { get; set; }

        public DataException(String message) : base(message)
        {

        }
    }
}
