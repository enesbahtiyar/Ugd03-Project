using UnityEngine;

public static class Settings
{
    //Player Movement
    public const float runningSpeed = 6f;
    public const float walkingSpeed = 3f;

    //Obscuring Settings
    public const float fadeInSeconds = 0.25f;
    public const float fadeOutSeconds = 0.25f;
    public const float targetAlpha = 0.55f;


    //Player Animation Parameters
    public static int xInput;
    public static int yInput;
    public static int isWalking;
    public static int isRunning;
    public static int toolEffect;
    public static int isUsingToolDown;
    public static int isUsingToolUp;
    public static int isUsingToolRight;
    public static int isUsingToolLeft;
    public static int isLiftingToolDown;
    public static int isLiftingToolUp;
    public static int isLiftingToolRight;
    public static int isLiftingToolLeft;
    public static int isSwingingToolDown;
    public static int isSwingingToolUp;
    public static int isSwingingToolLeft;
    public static int isSwingingToolRight;
    public static int isPickingDown;
    public static int isPickingUp;
    public static int isPickingLeft;
    public static int isPickingRight;

    //Shared Animations
    public static int idleUp;
    public static int idleLeft;
    public static int idleDown;
    public static int idleRight;

    static Settings()
    {
        //Player Animation Parameters
        xInput = Animator.StringToHash("xInput");
        yInput = Animator.StringToHash("yInput");
        isWalking = Animator.StringToHash("isWalking");
        isRunning = Animator.StringToHash("isRunning");
        toolEffect = Animator.StringToHash("toolEffect");
        isUsingToolDown = Animator.StringToHash("isUsingToolDown");
        isUsingToolUp = Animator.StringToHash("isUsingToolUp");
        isUsingToolRight = Animator.StringToHash("isUsingToolRight");
        isUsingToolLeft = Animator.StringToHash("isUsingToolLeft");
        isLiftingToolDown = Animator.StringToHash("isLiftingToolDown");
        isLiftingToolUp = Animator.StringToHash("isLiftingToolUp");
        isLiftingToolLeft = Animator.StringToHash("isLiftingToolLeft");
        isLiftingToolRight = Animator.StringToHash("isLiftingToolRight");
        isSwingingToolUp = Animator.StringToHash("isSwingingToolUp");
        isSwingingToolDown = Animator.StringToHash("isSwingingToolDown");
        isSwingingToolRight = Animator.StringToHash("isSwingingToolRight");
        isSwingingToolLeft = Animator.StringToHash("isSwingingToolLeft");
        isPickingUp = Animator.StringToHash("isPickingUp");
        isPickingDown = Animator.StringToHash("isPickingDown");
        isPickingRight = Animator.StringToHash("isPickingRight");
        isPickingLeft = Animator.StringToHash("isPickingLeft");

        //Shared Animation Parameters
        idleUp = Animator.StringToHash("idleUp");
        idleDown = Animator.StringToHash("idleDown");
        idleLeft = Animator.StringToHash("idleLeft");
        idleRight = Animator.StringToHash("idleRight");
    }
}
