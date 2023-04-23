using System;
using Random = UnityEngine.Random;

namespace WAM.Core
{
    [Serializable]
    public struct RandomRange
    {
        public float Min;
        public float Max;

        public float GetRandomValue()
        {
            return Random.Range(Min, Max);
        }
    }
}