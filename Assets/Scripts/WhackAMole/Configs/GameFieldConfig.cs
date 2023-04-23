using UnityEngine;
using WAM.Core.Configs;
using WAM.WhackAMole.GameField.Layouts;
using WAM.WhackAMole.PopUp;

namespace WAM.WhackAMole.Configs
{
    [CreateAssetMenu(fileName = nameof(GameFieldConfig), menuName = "Assessment/Create Game Field Config")]
    public class GameFieldConfig : Config
    {
        [SerializeField, Header("Layout")] private int _columns;
        [SerializeField] private int _rows;
        [SerializeField] private float _distanceBetweenHoles;
        [SerializeField] private float _holePrefabHeight;
        [SerializeField] private FieldLayoutType _fieldLayout;

        [SerializeField, Header("Pop Up")] private PopUpType _popUpType;

        public int Columns => _columns;

        public int Rows => _rows;

        public float DistanceBetweenHoles => _distanceBetweenHoles;

        public float HolePrefabHeight => _holePrefabHeight;

        public FieldLayoutType FieldLayoutType => _fieldLayout;

        public PopUpType PopUpType => _popUpType;
    }
}