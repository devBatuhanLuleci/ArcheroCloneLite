using SimpleInputNamespace;
using UnityEngine;
using UnityEngine.Events;

namespace ArcheroLite
{
    public class TouchscreenInput : MonoBehaviour
    {
        [Header("Settings")]
        [Tooltip("Move joystick magnitude is in [-1;1] range, this multiplies it before sending it to move event")]
        public float MoveMagnitudeMultiplier = 1.0f;

        [Header("Events")]
        public UnityEvent<Vector2> MoveEvent;

        [SerializeField]
        private Joystick _moveJoystick;



        private void Update()
        {
            if (_moveJoystick != null)
            {

            // Using the Joystick class for input
            Vector2 moveInput = _moveJoystick.Value; // Get joystick movement
            MoveEvent.Invoke(moveInput * MoveMagnitudeMultiplier);
            }
        }
    }
}
