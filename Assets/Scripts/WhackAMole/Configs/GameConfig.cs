using UnityEngine;
using WAM.Core.Configs;

namespace WAM.WhackAMole.Configs
{
    [CreateAssetMenu(fileName = nameof(GameConfig), menuName = "Assessment/Create Game Config")]
    public class GameConfig : Config
    {
        [SerializeField] private float _roundLength;

        public float RoundLength => _roundLength;
    }
}