using System.Collections.Generic;
using UnityEngine;
using WAM.Core.Behaviours;
using WAM.WhackAMole.Configs;
using WAM.WhackAMole.Creatures.Hole;

namespace WAM.WhackAMole.GameField.Behaviours
{
    public class GameFieldBehaviour : MonoView
    {
        [SerializeField] private Transform _holeContainer;

        /// <summary>
        /// Aligns the given creature holes with the game field.
        /// </summary>
        public void PlaceHoles(IList<ICreatureHolePresenter> creatureHoles, GameFieldConfig gameFieldConfig)
        {
            float distanceBetweenHoles = gameFieldConfig.DistanceBetweenHoles;
            float width = gameFieldConfig.Columns * distanceBetweenHoles - distanceBetweenHoles;
            float height = gameFieldConfig.Rows * distanceBetweenHoles - distanceBetweenHoles;

            foreach (ICreatureHolePresenter hole in creatureHoles)
            {
                hole.Transform.SetParent(_holeContainer);
                hole.Transform.localPosition -= new Vector3(width * 0.5f, 0f, height * 0.5f);
            }
        }
    }
}