using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Core
{
    public class Error : IEquatable<Error>
    {
        public string Message { get; }
        public Error(string message) 
        {
            ArgumentNullException.ThrowIfNull(message);    
            Message = message;
        }

        public bool Equals(Error? other)
        {
            return other?.Message == Message;
        }

        public static bool operator ==(Error? left, Error? right)
        {
            if(left is null && right is null) return true;
            if(left is null || right is null) return false;
            return left.Equals(right);
        }

        public static bool operator !=(Error? left, Error? right)
        {
            return !(left == right);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Error);
        }

        public override int GetHashCode()
        {
            return Message.GetHashCode();
        }
    }
}
