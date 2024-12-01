using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : SingletonMonoBehaviour<Player>
{
    private Camera mainCamera;


    private float xInput;
    private float yInput;
    private bool isCarrying = false;
    private bool isIdle;
    private bool isLiftingToolDown;
    private bool isLiftingToolLeft;
    private bool isLiftingToolRight;
    private bool isLiftingToolUp;
    private bool isRunning;
    private bool isUsingToolDown;
    private bool isUsingToolLeft;
    private bool isUsingToolRight;
    private bool isUsingToolUp;
    private bool isSwingingToolDown;
    private bool isSwingingToolLeft;
    private bool isSwingingToolRight;
    private bool isSwingingToolUp;
    private bool isWalking;
    private bool isPickingUp;
    private bool isPickingDown;
    private bool isPickingLeft;
    private bool isPickingRight;
    private ToolEffect toolEffect = ToolEffect.none;

    private Rigidbody2D rb;
#pragma warning disable 414
    private Direction playerDirection;
#pragma warning restore 414
    private float movementSpeed;
    private bool _playerInputDisabled;
    public bool PlayerInputDisabled { get => _playerInputDisabled; set => _playerInputDisabled = value; }

    protected override void Awake()
    {
        base.Awake();

        rb = GetComponent<Rigidbody2D>();

        mainCamera = Camera.main;
    }

    private void Update()
    {
        #region Player Input

        if(!PlayerInputDisabled)
        {
            ResetAnimationTriggers();

            PlayerMovementInput();

            PlayerWalkInput();

            EventHandler.CallMovementEvent(xInput, yInput, isWalking, isRunning, isIdle, isCarrying,
            toolEffect,
            isUsingToolDown, isUsingToolUp, isUsingToolRight, isUsingToolLeft,
            isLiftingToolDown, isLiftingToolUp, isLiftingToolRight, isLiftingToolLeft,
            isSwingingToolDown, isSwingingToolUp, isSwingingToolLeft, isSwingingToolRight,
            isPickingDown, isPickingUp, isPickingLeft, isPickingRight,
            false, false, false, false);
        }


        #endregion
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        Vector2 move = new Vector2(xInput * movementSpeed * Time.deltaTime, yInput * movementSpeed * Time.deltaTime);
        rb.MovePosition(rb.position + move);
    }

    private void PlayerMovementInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");

        if (xInput != 0 && yInput != 0)
        {
            xInput = xInput * 0.71f;
            yInput = yInput * 0.71f;
        }

        if (xInput != 0 || yInput != 0)
        {
            isRunning = true;
            isWalking = false;
            movementSpeed = Settings.runningSpeed;

            //save etmek için
            if (xInput < 0) playerDirection = Direction.left;
            else if (xInput > 0) playerDirection = Direction.right;
            else if (yInput < 0) playerDirection = Direction.down;
            else if (yInput > 0) playerDirection = Direction.up;
        }
        else if(xInput == 0 && yInput == 0)
        {
            isRunning = false;
            isWalking = false;
            isIdle = true;
        }      
    }

    public void DisablePlayerInput()
    {
        PlayerInputDisabled = true;
    }
    public void EnablePlayerInput()
    {
        PlayerInputDisabled = false;
    }

    public void ResetMovement()
    {
        xInput = 0;
        yInput = 0;
        isRunning = false;
        isWalking = false;
        isIdle = true;
    }

    public void DisablePlayerInputAndResetMovement()
    {
        DisablePlayerInput();
        ResetMovement();


        EventHandler.CallMovementEvent(xInput, yInput, isWalking, isRunning, isIdle, isCarrying,
        toolEffect,
        isUsingToolDown, isUsingToolUp, isUsingToolRight, isUsingToolLeft,
        isLiftingToolDown, isLiftingToolUp, isLiftingToolRight, isLiftingToolLeft,
        isSwingingToolDown, isSwingingToolUp, isSwingingToolLeft, isSwingingToolRight,
        isPickingDown, isPickingUp, isPickingLeft, isPickingRight,
        false, false, false, false);
    }

    private void PlayerWalkInput()
    {
        if (Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift))
        {
            isRunning = false;
            isWalking = true;
            isIdle = false;
            movementSpeed = Settings.walkingSpeed;
        }
        else
        {
            isRunning = true;
            isWalking = false;
            isIdle = false;
            movementSpeed = Settings.runningSpeed;
        }
    }

    private void ResetAnimationTriggers()
    {
        isLiftingToolDown = false;
        isLiftingToolLeft = false;
        isLiftingToolRight = false;
        isLiftingToolUp = false;
        isUsingToolDown = false;
        isUsingToolLeft = false     ;
        isUsingToolRight = false;
        isUsingToolUp = false;
        isSwingingToolDown = false;
        isSwingingToolLeft = false;
        isSwingingToolRight = false;
        isSwingingToolUp = false;
        isPickingUp = false;
        isPickingDown = false;
        isPickingLeft = false;
        isPickingRight = false;
        toolEffect = ToolEffect.none;
    }

    public Vector3 GetPlayerViewPortPosition()
    {
        return mainCamera.WorldToViewportPoint(transform.position);
    }

}
