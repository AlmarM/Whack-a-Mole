using System;
using UnityEngine;
using WAM.Core;

namespace WAM.WhackAMole.Player.Inputs
{
    public interface IInputStrategy : IUpdatable
    {
        event Action<Vector2> ScreenTappedEvent;
    }
}