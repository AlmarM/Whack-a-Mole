using System.Collections.Generic;
using UnityEngine;

namespace WAM.WhackAMole.GameField.Layouts
{
    /// <summary>
    /// Interface used by the game field to generate different types of layouts.
    /// </summary>
    public interface IFieldLayoutGenerator
    {
        /// <summary>
        /// Generate positions on the field
        /// </summary>
        /// <param name="columns">The amount of columns to generate.</param>
        /// <param name="rows">The amount of rows to generate.</param>
        /// <returns>A list of positions representing the generated layout.</returns>
        IList<Vector2> Generate(int columns, int rows);
    }
}