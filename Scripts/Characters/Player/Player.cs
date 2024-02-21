using DungeonRPG.Scripts.General;
using Godot;

namespace DungeonRPG.Scripts.Characters.Player;

public partial class Player : CharacterBody3D
{
    [ExportGroup("Required Nodes")]
    [Export]
    public AnimationPlayer AnimationPlayerNode;
    [Export]
    public Sprite3D PlayerSprite3D;
    
    private Vector2 _direction;

    public override void _PhysicsProcess(double delta)
    {
        Velocity = new Vector3(_direction.X, 0, _direction.Y);
        Velocity *= 5;

        MoveAndSlide();
    }
    
    public override void _Input(InputEvent @event)
    {
        // Get the input from the keyboard
        _direction = Input.GetVector(
            GameConstants.InputMoveLeft, GameConstants.InputMoveRight, GameConstants.InputMoveUp, GameConstants.InputMoveDown
        );
        
        // Play animation Idle or Move depending on input or no input
        AnimationPlayerNode.Play(_direction == Vector2.Zero ? GameConstants.AnimIdle : GameConstants.AnimMove);
        
        // Check move direction in relation to X, flip sprite accordingly
        PlayerSprite3D.FlipH = _direction.X switch
        {
            < 0 => true,
            > 0 => false,
            _ => PlayerSprite3D.FlipH
        };
    }
}