using System;
using System.Collections.Generic;

namespace day19
{
    public class Calculator
    {
        public List<Orientation> Orientations;

        public Calculator()
        {
            Orientations = Orientation.PossibleOrientations();
        }

        public void LookForMatches(Scanner s1, Scanner s2)
        {
            foreach(var o in Orientations)
            {
                var points = ApplyOrientation(o, s1.Points);
            }
        }

        public List<Vector3> ApplyOrientation(Orientation o, List<Vector3> points)
        {
            List<Vector3> newPoints = new List<Vector3>();

            foreach(var point in points)
            {
                Vector3 newPoint = o.Rotate(point);
                newPoints.Add(newPoint);
            }

            return newPoints;
        }

        public List<Vector3> ApplyTranslation(Vector3 trans, List<Vector3> points)
        {
            List<Vector3> newPoints = new List<Vector3>();

            foreach (var point in points)
            {
                Vector3 newPoint = trans.Add(point);
                newPoints.Add(newPoint);
            }

            return newPoints;
        }
    }
}
