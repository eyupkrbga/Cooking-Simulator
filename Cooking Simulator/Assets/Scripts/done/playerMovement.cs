using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    private PlayerInput playerInput;
    [SerializeField] private float walkSpeed,runSpeed,turnSpeed;

    Vector2 movementInput;
    Vector3 currentMovement;
    bool isMovementPressed, isRunPressed;
    
    Animator animator;

    int isWalkingHash;
    int isRunningHash;

    PlayerInput input;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        animator = GetComponent<Animator>();

        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
    }

    private void Awake()
    {
        playerInput = new PlayerInput();

        playerInput.PlayerController.Movement.started += OnMove;
        playerInput.PlayerController.Movement.performed += OnMove;
        playerInput.PlayerController.Movement.canceled += OnMove;

        playerInput.PlayerController.Run.started += OnRun;
        playerInput.PlayerController.Run.canceled += OnRun;

    }

    private void OnMove (InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();

        currentMovement.x = movementInput.x;
        currentMovement.z = movementInput.y;
        isMovementPressed = movementInput.x !=0 || movementInput.y != 0;
    }

    private void OnRun(InputAction.CallbackContext context)
    {
        isRunPressed = context.ReadValueAsButton();
    }

    private void FixedUpdate()
    {
        PlayerMove();
    }

    private void Update()
    {
        RotationProcess();
        handleMovement();
    }

    private void PlayerMove()
    {
        if (!isRunPressed)
        {
            rb.MovePosition(transform.position + currentMovement.normalized * walkSpeed * Time.deltaTime);
        }
        else
        {
            rb.MovePosition(transform.position + currentMovement.normalized * runSpeed * Time.deltaTime);
        }
    }

    private void RotationProcess()
    {
        if(!isMovementPressed) return;
        Quaternion targetRotation = Quaternion.LookRotation(currentMovement, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation,targetRotation, turnSpeed * Time.deltaTime);
    }

    private void handleMovement()
    {
        bool isRunning = animator.GetBool(isRunningHash);
        bool isWalking = animator.GetBool(isWalkingHash);

        if (isMovementPressed && !isWalking){
            animator.SetBool(isWalkingHash, true);
        }
        if (!isMovementPressed && isWalking){
            animator.SetBool(isWalkingHash, false);
        }
        if ((isMovementPressed && isRunPressed) && !isRunning){
            animator.SetBool(isRunningHash, true);
        }
        if ((!isMovementPressed && !isRunPressed) && isRunning){
            animator.SetBool(isRunningHash, false);
        }
        if ((isMovementPressed && !isRunPressed) && isWalking){
            animator.SetBool(isRunningHash, false);
        }
        if ((!isMovementPressed && isRunPressed) && !isWalking){
            animator.SetBool(isRunningHash, false);
        }
    }

    private void OnEnable()
    {
        playerInput.PlayerController.Enable();
    }

    private void OnDisabled()
    {
        playerInput.PlayerController.Disable();
    }

}