using UnityEngine;
using UnityEngine.InputSystem;

namespace CubeInput
{
    public class CubeActionInput : MonoBehaviour
    {
        public static CubeActionInput instance;

        private PlayerInput _playerInput;
        private InputActionMap _currentMap;

        private InputAction MoveAction;

        public Vector2 _moveInput {  get; private set; }

        private InputAction VerticalMove;

        public Vector2 _yMovement { get; private set; }


        private void Awake()
        {
            instance = this;    
            _playerInput = GetComponent<PlayerInput>();
            _currentMap = _playerInput.currentActionMap;

            MoveAction = _currentMap.FindAction("Move");
            VerticalMove = _currentMap.FindAction("Y");
            MoveAction.started += OnMove;
            MoveAction.performed += OnMove;
            MoveAction.canceled += OnMove;

            VerticalMove.started += OnY;
            VerticalMove.performed += OnY;
            VerticalMove.canceled += OnY;
        }

        private void OnMove(InputAction.CallbackContext context)
        {
            _moveInput = context.ReadValue<Vector2>();
        }

        private void OnY(InputAction.CallbackContext context)
        {
            _yMovement = context.ReadValue<Vector2>();
        }

        private void OnEnable()
        {
            MoveAction.Enable();
            VerticalMove.Enable();
        }

        private void OnDisable()
        {
            MoveAction.Disable();
            VerticalMove.Disable();
        }
    }
}


