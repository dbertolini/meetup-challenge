using System;

namespace MeetupSantander.API.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public int Status { get; set; } = 500;
        public object Value { get; set; }

        public DomainException(String message) : base(message)
        {

        }
    }
}
