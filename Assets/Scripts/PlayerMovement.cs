using UnityEngine;
using UnityEngine.EventSystems;

#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace ArcheroLite
{
    [RequireComponent(typeof(CharacterController))]
#if ENABLE_INPUT_SYSTEM
    [RequireComponent(typeof(PlayerInput))]
#endif
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Player Settings")]
        public float moveSpeed = 2.0f;
        [SerializeField] private float rotationSpeed = 10f;
        public AudioClip[] footstepSounds;
        [Range(0, 1)] public float footstepVolume = 0.5f;

        private CharacterController _controller;
        private InputHandler _input;
        private AudioSource _audioSource;
        [SerializeField]
        private Animator animator;
        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
            _input = GetComponent<InputHandler>();
            _audioSource = gameObject.AddComponent<AudioSource>();
        }

        private void Update()
        {
            HandleMovement();
            HandleRotation();
            HandleAnimations();
        }

        private void HandleMovement()
        {
            Vector3 moveDirection = new Vector3(_input.move.x, 0f, _input.move.y).normalized;
            if (moveDirection.magnitude >= 0.1f)
            {
                _controller.Move(moveDirection * (moveSpeed * Time.deltaTime));
            }
        }
        private void HandleRotation()
        {
            Vector3 moveDirection = new Vector3(_input.move.x, 0f, _input.move.y).normalized;
            if (moveDirection.sqrMagnitude > 0.01f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }

        private void HandleAnimations()
        {
            Vector3 moveDirection = new Vector3(_input.move.x, 0f, _input.move.y).normalized;
            bool isMoving = moveDirection.magnitude > 0.1f;
            animator.SetBool("Run", isMoving);
        }
        private void OnFootstep(AnimationEvent animationEvent)
        {
            PlayFootstepSound();
        }
        private void PlayFootstepSound()
        {
            if (footstepSounds.Length > 0)
            {
                _audioSource.PlayOneShot(footstepSounds[Random.Range(0, footstepSounds.Length)], footstepVolume);
            }
        }
    }

#if ENABLE_INPUT_SYSTEM
#endif
}
