using System;

namespace centauri
{
    
    public struct CVec2 
    {
        public static CVec2 Invalid = new CVec2(-1, -1);
        public static CVec2 NegativeOne = new CVec2(-1, -1);
        public static CVec2 Zero = new CVec2(0, 0);
        public static CVec2 One = new CVec2(1, 1);
        public int x;
        public int y;

        public CVec2(int inX, int inY)
        {
            x = inX;
            y = inY;
        }
        public CVec2(int inWide)
        {
            y = inWide % 1000;
            inWide /= 1000;
            x = inWide % 1000;
        }

        public override bool Equals(object other)
        {
            if (other is CVec2 vecOther)
            {
                return vecOther.x == x && vecOther.y == y;
            }

            return false;
        }

        public bool Equals(CVec2 other)
        {
            return x == other.x && y == other.y;
        }

        public static  bool operator ==(CVec2 a, CVec2 b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(CVec2 a, CVec2 b)
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

        public static CVec2 operator -(CVec2 a, CVec2 b)
        {
            return new CVec2(a.x- b.x, a.y - b.y);
        }

        public static CVec2 operator +(CVec2 a, CVec2 b)
        {
            return new CVec2(a.x + b.x, a.y + b.y);
        }

        public static CVec2 operator -(CVec2 val)
        {
            return new CVec2(-val.x, -val.y);
        }

        public static CVec2 operator *(CVec2 val, int multiplier)
        {
            return new CVec2(val.x * multiplier, val.y * multiplier);
        }
        
        public float DistanceSqrTo(CVec2 o)
        {
            return (float)(Math.Pow(x - o.x, 2) + Math.Pow(y - o.y, 2));
        }

        public float DistanceTo(CVec2 o)
        {
            return (float)Math.Sqrt(DistanceSqrTo(o));
        }


        public float Distance(CVec2 a, CVec2 b)
        {
            return a.DistanceTo(b);
        }


        public float SqrMagnitude => x * x + y * y;
        public float Magnitude => (float)Math.Sqrt(SqrMagnitude);

        public override string ToString()
        {
            return $"({x}, {y})";
        }
        public string ToWideNumberString()
        {
            int byteX = (x%256)*1000000;
            int byteY = (y%256)*1000;
            return (byteX+byteY).ToString();
        }
        public static CVec2 Parse(string text)
        {
            if(text.Length < 1)
            {
                return CVec2.Zero;
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
                return new CVec2(x, y);
            }
            return CVec2.Zero;
        }

    }


    
    public struct CVec3 
    {
        public static CVec3 Invalid = new CVec3(-1, -1, -1);
        public static CVec3 NegativeOne = new CVec3(-1, -1, -1);
        public static CVec3 Zero = new CVec3(0, 0, 0);
        public static CVec3 One = new CVec3(1, 1, 1);
        public int x;
        public int y;
        public int z;

        public CVec3(int inX, int inY, int inZ)
        {
            x = inX;
            y = inY;
            z = inZ;
        }
        public CVec3(int inWide)
        {
            z = inWide % 1000;
            inWide /= 1000;
            y = inWide % 1000;
            inWide /= 1000;
            x = inWide % 1000;
        }


        public override bool Equals(object other)
        {
            if (other is CVec3 vecOther)
            {
                return vecOther.x == x && vecOther.y == y && vecOther.z == z;
            }

            return false;
        }

        public bool Equals(CVec3 other)
        {
            return x == other.x && y == other.y && z == other.z;
        }

        public static  bool operator ==(CVec3 lhs, CVec3 rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(CVec3 lhs, CVec3 rhs)
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

        public static CVec3 operator -(CVec3 lhs, CVec3 rhs)
        {
            return new CVec3(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);
        }

        public static CVec3 operator +(CVec3 lhs, CVec3 rhs)
        {
            return new CVec3(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);
        }

        public static CVec3 operator -(CVec3 val)
        {
            return new CVec3(-val.x, -val.y, -val.z);
        }

        public static CVec3 operator *(CVec3 val, int multiplier)
        {
            return new CVec3(val.x * multiplier, val.y * multiplier, val.z * multiplier);
        }
        public float DistanceSqrTo(CVec3 o)
        {
            return (float)(Math.Pow(x - o.x, 2) + Math.Pow(y - o.y, 2) + Math.Pow(z - o.z, 2));
        }

        public float DistanceTo(CVec3 o)
        {
            return (float)Math.Sqrt(DistanceSqrTo(o));
        }

        public float Distance(CVec3 a, CVec3 b)
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
        public string ToWideNumberString()
        {
            int byteX = (x%256)*1000000;
            int byteY = (y%256)*1000;
            int byteZ = (z%256);
            return (byteX+byteY+byteZ).ToString();
        }


        public static CVec3 Parse(string text)
        {
            if(text.Length < 1)
            {
                return CVec3.Invalid;
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
                return new CVec3(x, y, z);
            }
            return CVec3.Invalid;
        }

    }
}