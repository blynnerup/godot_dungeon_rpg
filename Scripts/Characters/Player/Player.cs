using DungeonRPG.Scripts.General;
using Godot;

namespace DungeonRPG.Scripts.Characters.Player;

public partial class Player : CharacterBody3D
{
    [ExportGroup("Required Nodes")] 
    [Export] public AnimationPlayer AnimationPlayerNode { get; private set; }
    [Export] public Sprite3D PlayerSprite3D { get; private set; }
    [Export] public StateMachine StateMachineNode { get; private set; }

    public Vector2 Direction;

    public override void _Input(InputEvent @event)
    {
        // Get the input from the keyboard
        Direction = Input.GetVector(
            GameConstants.InputMoveLeft,
            GameConstants.InputMoveRight,
            GameConstants.InputMoveUp,
            GameConstants.InputMoveDown
        );
    }

    public void Flip()
    {
        PlayerSprite3D.FlipH = Direction.X switch
        {
            < 0 => true,
            > 0 => false,
            _ => PlayerSprite3D.FlipH
        };
    }
}