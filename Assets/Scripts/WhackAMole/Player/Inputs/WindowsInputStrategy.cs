using System;
using UnityEngine;

namespace WAM.WhackAMole.Player.Inputs
{
    public class WindowsInputStrategy : IInputStrategy
    {
        public event Action<Vector2> ScreenTappedEvent;

        public void Update(float deltaTime)
        {
            if (!Input.GetMouseButtonDown(0))
            {
                return;
            }

            ScreenTappedEvent?.Invoke(Input.mousePosition);
        }
    }
}