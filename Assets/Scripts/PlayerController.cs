using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour {
    public float walkSpeed = 5f;
    private Animator _animator;
    private bool _isMoving;
    private Vector2 _moveInput;
    private Rigidbody _rigidbody;

    public bool IsMoving {
        get {
            Debug.Log("Im here to turn off auto convert");
            return _isMoving;
        }
        private set {
            _isMoving = value;
            _animator.SetBool(AnimatorStrings.IsMoving, value);
        }
    }

    private void Awake() {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    // For physics calculation
    private void FixedUpdate() {
        _rigidbody.linearVelocity =
            new Vector3(_moveInput.x * walkSpeed, _rigidbody.linearVelocity.y, _moveInput.y * walkSpeed);
    }

    public void OnMove(InputAction.CallbackContext context) {
        _moveInput = context.ReadValue<Vector2>();
        IsMoving = _moveInput != Vector2.zero;
    }
}