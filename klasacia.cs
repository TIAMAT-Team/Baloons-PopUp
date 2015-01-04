using System;

namespace BalloonPopsGame
{
    public class klasacia : IComparable<klasacia>
    {
        public int Value;
        public string Name;

        public klasacia(int value, string name)
        {
            Value = value;
            Name = name;
        }

        public int CompareTo(klasacia other)
        {
            return Value.CompareTo(other.Value);
        }
    }
}