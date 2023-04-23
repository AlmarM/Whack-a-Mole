using System;
using UnityEngine;

namespace WAM.WhackAMole.Player.Inputs
{
    public class AndroidInputStrategy : IInputStrategy
    {
        public event Action<Vector2> ScreenTappedEvent;

        public void Update(float deltaTime)
        {
            if (Input.touchCount != 1)
            {
                return;
            }

            Touch touch = Input.touches[0];

            if (touch.phase != TouchPhase.Began)
            {
                return;
            }

            ScreenTappedEvent?.Invoke(touch.position);
        }
    }
}