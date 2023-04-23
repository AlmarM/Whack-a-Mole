using System.Collections.Generic;
using UnityEngine;

namespace WAM.WhackAMole.GameField.Layouts
{
    public class GridLayoutGenerator : IFieldLayoutGenerator
    {
        public IList<Vector2> Generate(int columns, int rows)
        {
            var positions = new List<Vector2>();

            for (var row = 0; row < rows; row++)
            {
                for (var col = 0; col < columns; col++)
                {
                    positions.Add(new Vector2(col, row));
                }
            }

            return positions;
        }
    }
}