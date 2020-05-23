using System;

namespace centauri
{
    
    public struct Vec2 
    {
        public static Vec2 Invalid = new Vec2(-1, -1);
        public static Vec2 NegativeOne = new Vec2(-1, -1);
        public static Vec2 Zero = new Vec2(0, 0);
        public static Vec2 One = new Vec2(1, 1);
        public int x;
        public int y;

        public Vec2(int inX, int inY)
        {
            x = inX;
            y = inY;
        }

        public override bool Equals(object other)
        {
            if (other is Vec2 vecOther)
            {
                return vecOther.x == x && vecOther.y == y;
            }

            return false;
        }

        public bool Equals(Vec2 other)
        {
            return x == other.x && y == other.y;
        }

        public static  bool operator ==(Vec2 a, Vec2 b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Vec2 a, Vec2 b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (x * 397) ^ y;
            }
        }

        public static Vec2 operator -(Vec2 a, Vec2 b)
        {
            return new Vec2(a.x- b.x, a.y - b.y);
        }

        public static Vec2 operator +(Vec2 a, Vec2 b)
        {
            return new Vec2(a.x + b.x, a.y + b.y);
        }

        public static Vec2 operator -(Vec2 val)
        {
            return new Vec2(-val.x, -val.y);
        }

        public static Vec2 operator *(Vec2 val, int multiplier)
        {
            return new Vec2(val.x * multiplier, val.y * multiplier);
        }
        
        public float DistanceSqrTo(Vec2 o)
        {
            return (float)(Math.Pow(x - o.x, 2) + Math.Pow(y - o.y, 2));
        }

        public float DistanceTo(Vec2 o)
        {
            return (float)Math.Sqrt(DistanceSqrTo(o));
        }


        public float Distance(Vec2 a, Vec2 b)
        {
            return a.DistanceTo(b);
        }


        public float SqrMagnitude => x * x + y * y;
        public float Magnitude => (float)Math.Sqrt(SqrMagnitude);

        public override string ToString()
        {
            return $"({x}, {y})";
        }

        public static Vec2 Parse(string text)
        {
            if(text.Length < 1)
            {
                return Vec2.Zero;
            }
            if (text[0] == '(' && text[text.Length-1] == ')')
            {
                text = text.Remove(0, 1).Remove(text.Length - 1, 1);
            }
            string[] words = text.Split(new char[] {' ', ';', ','});
            if (words.Length == 2)
            {
                int x = int.Parse(words[0]);
                int y = int.Parse(words[1]);
                return new Vec2(x, y);
            }
            return Vec2.Zero;
        }

    }


    
    public struct Vec3 
    {
        public static Vec3 Invalid = new Vec3(-1, -1, -1);
        public static Vec3 NegativeOne = new Vec3(-1, -1, -1);
        public static Vec3 Zero = new Vec3(0, 0, 0);
        public static Vec3 One = new Vec3(1, 1, 1);
        public int x;
        public int y;
        public int z;

        public Vec3(int inX, int inY, int inZ)
        {
            x = inX;
            y = inY;
            z = inZ;
        }

        public override bool Equals(object other)
        {
            if (other is Vec3 vecOther)
            {
                return vecOther.x == x && vecOther.y == y && vecOther.z == z;
            }

            return false;
        }

        public bool Equals(Vec3 other)
        {
            return x == other.x && y == other.y && z == other.z;
        }

        public static  bool operator ==(Vec3 lhs, Vec3 rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Vec3 lhs, Vec3 rhs)
        {
            return !(lhs == rhs);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (z + x * 397) ^ y;
            }
        }

        public static Vec3 operator -(Vec3 lhs, Vec3 rhs)
        {
            return new Vec3(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);
        }

        public static Vec3 operator +(Vec3 lhs, Vec3 rhs)
        {
            return new Vec3(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);
        }

        public static Vec3 operator -(Vec3 val)
        {
            return new Vec3(-val.x, -val.y, -val.z);
        }

        public static Vec3 operator *(Vec3 val, int multiplier)
        {
            return new Vec3(val.x * multiplier, val.y * multiplier, val.z * multiplier);
        }
        public float DistanceSqrTo(Vec3 o)
        {
            return (float)(Math.Pow(x - o.x, 2) + Math.Pow(y - o.y, 2) + Math.Pow(z - o.z, 2));
        }

        public float DistanceTo(Vec3 o)
        {
            return (float)Math.Sqrt(DistanceSqrTo(o));
        }

        public float Distance(Vec3 a, Vec3 b)
        {
            return (float)Math.Sqrt(a.DistanceSqrTo(b));
        }


        public float SqrMagnitude => x * x + y * y + z * z;
        public float Magnitude => (float)Math.Sqrt(SqrMagnitude);

        public override string ToString()
        {
            return $"({x}, {y}, {z})";
        }
        
        public string ToHexString()
        {
            string hexX = (x % 256).ToString("X2");
            string hexY = (y % 256).ToString("X2");
            string hexZ = (z % 256).ToString("X2");
            return $"#{hexX}{hexY}{hexZ}";
        }

        public static Vec3 Parse(string text)
        {
            if(text.Length < 1)
            {
                return Vec3.Invalid;
            }
            if (text[0] == '(' && text[text.Length-1] == ')')
            {
                text = text.Remove(0, 1).Remove(text.Length - 1, 1);
            }
            string[] words = text.Split(new char[] {' ', ';', ','});
            if (words.Length == 3)
            {
                int x = int.Parse(words[0]);
                int y = int.Parse(words[1]);
                int z = int.Parse(words[2]);
                return new Vec3(x, y, z);
            }
            return Vec3.Invalid;
        }

    }
}