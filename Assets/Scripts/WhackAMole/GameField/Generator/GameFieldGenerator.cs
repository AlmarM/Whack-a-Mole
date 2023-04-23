using System.Collections.Generic;
using UnityEngine;
using WAM.WhackAMole.Configs;
using WAM.WhackAMole.Creatures.Factory;
using WAM.WhackAMole.Creatures.Hole;
using WAM.WhackAMole.GameField.Layouts;

namespace WAM.WhackAMole.GameField.Generator
{
    public class GameFieldGenerator : IGameFieldGenerator
    {
        private readonly ICreatureFactory _creatureFactory;
        private readonly GameFieldConfig _gameFieldConfig;
        private readonly IFieldLayoutGenerator _layoutGenerator;

        public GameFieldGenerator(GameFieldConfig gameFieldConfig,
            ICreatureFactory creatureFactory,
            IFieldLayoutGenerator layoutGenerator)
        {
            _gameFieldConfig = gameFieldConfig;
            _creatureFactory = creatureFactory;
            _layoutGenerator = layoutGenerator;
        }

        public IList<ICreatureHolePresenter> CreateHoles()
        {
            IList<Vector2> positions = GeneratePositions();

            return SpawnHoleObjects(positions);
        }

        private IList<Vector2> GeneratePositions()
        {
            int columns = _gameFieldConfig.Columns;
            int rows = _gameFieldConfig.Rows;

            return _layoutGenerator.Generate(columns, rows);
        }

        private IList<ICreatureHolePresenter> SpawnHoleObjects(IEnumerable<Vector2> positions)
        {
            var holes = new List<ICreatureHolePresenter>();

            foreach (Vector2 position in positions)
            {
                var projectedPosition = new Vector3(position.x, _gameFieldConfig.HolePrefabHeight, position.y);

                ICreatureHolePresenter hole = _creatureFactory.CreateCreatureHole();
                hole.Transform.localPosition = projectedPosition * _gameFieldConfig.DistanceBetweenHoles;

                holes.Add(hole);
            }

            return holes;
        }
    }
}