using UnityEngine;
using WAM.Core;
using WAM.Core.Configs;

namespace WAM.WhackAMole.Configs
{
    [CreateAssetMenu(fileName = nameof(RandomPopUpConfig), menuName = "Assessment/Create Random Pop Up Config")]
    public class RandomPopUpConfig : Config
    {
        [SerializeField] private RandomRange _popUpInterval;

        public RandomRange PopUpInterval => _popUpInterval;
    }
}