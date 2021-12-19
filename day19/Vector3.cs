﻿using System;
namespace day19
{
    public class Vector3
    {
        public int x;
        public int y;
        public int z;

        public Vector3(int nx, int ny, int nz)
        {
            x = nx;
            y = ny;
            z = nz;
        }

        public Vector3(string str)
        {
            // This is only really used when loading the puzzle
            // input so it isn't necessary to be efficient or
            // even really bullet-proof since we're guaranteed to
            // have well-formatted input.
            //
            // However, we may want to construct vectors from
            // strings in the test cases, so handle a few things
            // to make human typed vectors likely to be parsable.
            //
            // allow optional whitespace before/after
            str = str.Trim();
            // allow optional starting "(" and ending ")"
            str = str.TrimStart('(');
            str = str.TrimEnd(')');

            string[] parts = str.Split(",");
            int nx = int.Parse(parts[0].Trim());
            int ny = int.Parse(parts[1].Trim());
            int nz = int.Parse(parts[2].Trim());

            x = nx;
            y = ny;
            z = nz;
        }

        public override bool Equals(object obj)
        {
            // If the other object is null, can't be equal
            if (obj == null) return false;
            // If the two objects are of different types can't be equal
            if (!this.GetType().Equals(obj.GetType())) return false;


            Vector3 v = (Vector3)obj;

            return x == v.x &&
                   y == v.y &&
                   z == v.z;
        }

        //
        // https://stackoverflow.com/questions/263400/what-is-the-best-algorithm-for-overriding-gethashcode/263416#263416
        //
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + x.GetHashCode();
            hash = hash * 23 + y.GetHashCode();
            hash = hash * 23 + z.GetHashCode();

            return hash;
        }

        public override string ToString()
        {
            return $"{x,4},{y,4},{z,4}";
        }

    }
}