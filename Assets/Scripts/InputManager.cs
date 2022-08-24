using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RomanTristan.Lab4
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private FPSMovement movement;

        private CSE3541Inputs inputScheme;
        private CSE3541Inputs.PlayerActions input;

        Vector2 horizontalInput;

        private void Awake()
        {
            inputScheme = new CSE3541Inputs();

            inputScheme.Player.Move.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();

            inputScheme.Player.Move.canceled += ctx => horizontalInput = ctx.ReadValue<Vector2>();

            inputScheme.Player.Jump.performed += _ => movement.OnJumpPressed();

        }

        private void Update()
        {
            movement.Input(horizontalInput);
        }

        private void OnEnable()
        {
            inputScheme.Enable();
            var _ = new QuitHandler(inputScheme.Player.Quit);

        }

        private void OnDestroy()
        {
            inputScheme.Disable();
        }
    }
}

