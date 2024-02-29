namespace DungeonRPG.Scripts.General;

public abstract class GameConstants
{
    // Animations
    public const string AnimIdle = "Idle";
    public const string AnimMove = "Move";
    public const string AnimDash = "Dash";
    
    // Inputs
    public const string InputMoveLeft = "MoveLeft";
    public const string InputMoveUp = "MoveForward";
    public const string InputMoveDown = "MoveBackward";
    public const string InputMoveRight = "MoveRight";
    public const string InputDash = "Dash";
    
    // Notifications
    public const int NotificationEnterState = 5001;
    public const int NotificationExitState = 5002;
}