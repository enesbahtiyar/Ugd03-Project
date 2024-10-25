public delegate void MovementDelegate(float inputX, float inputY, bool isWalking, bool isRunning, bool isIdle, bool isCarrying,
    ToolEffect toolEffect,
    bool isUsingToolDown, bool isUsingToolUp, bool isUsingToolRight, bool isUsingToolLeft,
    bool isLiftingToolDown, bool isLiftingToolUp, bool isLiftingToolRight, bool isLiftingToolLeft,
    bool isSwingingToolDown, bool isSwingingToolUp, bool isSwingingToolLeft, bool isSwingingToolRight,
    bool isPickingDown, bool isPickingUp, bool isPickingLeft, bool isPickingRight,
    bool idleUp, bool idleLeft, bool idleDown, bool idleRight);

public static class EventHandler
{
    //Movement Event
    public static event MovementDelegate MovementEvent;

    //Movement Event Call for publishers
    public static void CallMovementEvent(float inputX, float inputY, bool isWalking, bool isRunning, bool isIdle, bool isCarrying,
    ToolEffect toolEffect,
    bool isUsingToolDown, bool isUsingToolUp, bool isUsingToolRight, bool isUsingToolLeft,
    bool isLiftingToolDown, bool isLiftingToolUp, bool isLiftingToolRight, bool isLiftingToolLeft,
    bool isSwingingToolDown, bool isSwingingToolUp, bool isSwingingToolLeft, bool isSwingingToolRight,
    bool isPickingDown, bool isPickingUp, bool isPickingLeft, bool isPickingRight,
    bool idleUp, bool idleLeft, bool idleDown, bool idleRight)
    {
        if(MovementEvent != null)
        {
            MovementEvent( inputX, inputY, isWalking, isRunning, isIdle, isCarrying,
            toolEffect,
            isUsingToolDown,  isUsingToolUp,  isUsingToolRight,  isUsingToolLeft,
            isLiftingToolDown,  isLiftingToolUp,  isLiftingToolRight,  isLiftingToolLeft,
            isSwingingToolDown,  isSwingingToolUp,  isSwingingToolLeft,  isSwingingToolRight,
            isPickingDown,  isPickingUp,  isPickingLeft,  isPickingRight,
            idleUp,  idleLeft,  idleDown,  idleRight);
        }
    }
}
