using UnityEngine;
using System.Collections;

/// <summary>
/// Implementation of player movement, jumping, running and camera rotation
/// </summary>
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 4f;
    [SerializeField] private float runSpeed = 8f;
    [SerializeField] private float jumpPower = 4f;
    [SerializeField] private float gravity = 9.81f;
    [SerializeField] private float lookSpeed = 2.5f;
    [SerializeField] private float lookXLimit = 60f;

    [SerializeField] private bool canMove = true;
    [SerializeField] private bool canJump = true;
    [SerializeField] private bool canRun = true;

    private Camera playerCamera;
    private CharacterController characterController;

    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;
    private float verticalVelocity = 0f;

    public bool CanMove
    {
        get => canMove;
        set => canMove = value;
    }

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        playerCamera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        CheckMoveAndJump();
        RotateCamera();
    }

    private void CheckMoveAndJump()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float currentSpeedX = (isRunning && canRun ? runSpeed : walkSpeed) * Input.GetAxis("Vertical");
        float currentSpeedY = (isRunning && canRun ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal");
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * currentSpeedX) + (right * currentSpeedY);

        if (Input.GetKey(KeyCode.Space) && canJump && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }
        moveDirection.y += verticalVelocity;

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        characterController.Move(canMove ? moveDirection * Time.deltaTime : Vector3.zero);
    }

    private void RotateCamera()
    {
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }

    public void ApplyImpulseForceToPlayer(Vector3 direction, float force)
    {
        direction = direction.normalized;

    }

    public IEnumerator ThrowUpPlayer(float verticalVelocity)
    {
        moveDirection.y = 0f;
        this.verticalVelocity = verticalVelocity;
        yield return null;
        this.verticalVelocity = 0f;
    }
}
