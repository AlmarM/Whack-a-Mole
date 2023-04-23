using System.Collections.Generic;
using UnityEngine;

namespace WAM.WhackAMole.GameField.Layouts
{
    public class ZigzagLayoutGenerator : IFieldLayoutGenerator
    {
        public IList<Vector2> Generate(int columns, int rows)
        {
            var positions = new List<Vector2>();

            for (var row = 0; row < rows; row++)
            {
                var nextColumns = columns;
                var offset = 0f;

                if (IsOdd(row))
                {
                    nextColumns = columns - 1;
                    offset = 0.5f;
                }

                for (var col = 0; col < nextColumns; col++)
                {
                    var x = offset + col;
                    positions.Add(new Vector2(x, row));
                }
            }

            return positions;
        }

        private static bool IsOdd(int number)
        {
            return number % 2 != 0;
        }
    }
}