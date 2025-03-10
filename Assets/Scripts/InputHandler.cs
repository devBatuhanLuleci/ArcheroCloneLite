using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace ArcheroLite
{
#if ENABLE_INPUT_SYSTEM
    public class InputHandler : MonoBehaviour
    {
        public Vector2 move { get; private set; }
        private PlayerInput _playerInput;

        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
        }
     
        public void MoveInput(Vector2 virtualMoveDirection)
        {
            move = virtualMoveDirection;
        }
    }
#endif
}
