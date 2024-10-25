using UnityEngine;

public class PlayerAnimationTest : MonoBehaviour
{
    public float inputX;
    public float inputY; 
    public bool isWalking; 
    public bool isRunning; 
    public bool isIdle;
    public bool isCarrying;
    public ToolEffect toolEffect;
    public bool isUsingToolDown;
    public bool isUsingToolUp;
    public bool isUsingToolRight;
    public bool isUsingToolLeft;
    public bool isLiftingToolDown;
    public bool isLiftingToolUp;
    public bool isLiftingToolRight;
    public bool isLiftingToolLeft;
    public bool isSwingingToolDown;
    public bool isSwingingToolUp;
    public bool isSwingingToolLeft;
    public bool isSwingingToolRight;
    public bool isPickingDown;
    public bool isPickingUp;
    public bool isPickingLeft;
    public bool isPickingRight;
    public bool idleUp;
    public bool idleLeft;
    public bool idleDown;
    public bool idleRight;

    private void Update()
    {
        EventHandler.CallMovementEvent(inputX, inputY, isWalking, isRunning, isIdle, isCarrying,
            toolEffect,
            isUsingToolDown, isUsingToolUp, isUsingToolRight, isUsingToolLeft,
            isLiftingToolDown, isLiftingToolUp, isLiftingToolRight, isLiftingToolLeft,
            isSwingingToolDown, isSwingingToolUp, isSwingingToolLeft, isSwingingToolRight,
            isPickingDown, isPickingUp, isPickingLeft, isPickingRight,
            idleUp, idleLeft, idleDown, idleRight);


    }
}
