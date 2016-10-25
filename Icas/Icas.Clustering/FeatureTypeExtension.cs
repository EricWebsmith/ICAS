using System;

namespace Icas.Clustering
{
    public static class FeatureTypeExtension
    {
        public static int[] GetLengths(this FeatureType dataType)
        {
            switch (dataType)
            {
                case FeatureType.Reactivity:
                    return new int[] { 21, 71, 121 };
                case FeatureType.RnaDistance:
                    return new int[] { 71, 121 };
            }
            throw new Exception("data type not found.");
        }

        public static FeatureType FromString(string s)
        {
            switch (s.ToUpper())
            {
                case "RNADISTANCE":
                case "RNA_DISTANCE":
                    return FeatureType.RnaDistance;
                default:
                    return FeatureType.Reactivity;
            }
        }
    }
}
