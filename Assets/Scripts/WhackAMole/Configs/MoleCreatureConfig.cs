using UnityEngine;
using WAM.Core;
using WAM.Core.Configs;

namespace WAM.WhackAMole.Configs
{
    [CreateAssetMenu(fileName = nameof(MoleCreatureConfig), menuName = "Assessment/Create Mole Config")]
    public class MoleCreatureConfig : Config
    {
        [SerializeField] private RandomRange _disappearInterval;

        public RandomRange DisappearInterval => _disappearInterval;
    }
}