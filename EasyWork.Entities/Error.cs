using System;

namespace EasyWork.Entities
{
    public class Error
    {
        public int ID { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
