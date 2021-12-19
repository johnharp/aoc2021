using System;
using System.Collections.Generic;

namespace day19
{
    public class Scanner
    {
        public int Id = -1;
        public Vector3 Origin;

        public Vector3 XDirection;
        public Vector3 YDirection;
        public Vector3 ZDirection;

        public List<Vector3> Points = new List<Vector3>();

        public Scanner()
        {
        }
    }
}
