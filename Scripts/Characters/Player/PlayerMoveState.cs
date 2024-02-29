using DungeonRPG.Scripts.General;
using Godot;

namespace DungeonRPG.Scripts.Characters.Player;

public partial class PlayerMoveState : PlayerState
{
    public override void _PhysicsProcess(double delta)
    {
        if (CharacterNode.Direction == Vector2.Zero)
        {
            CharacterNode.StateMachineNode.SwitchState<PlayerIdleState>();
            return;
        }
        
        CharacterNode.Velocity = new Vector3(CharacterNode.Direction.X, 0, CharacterNode.Direction.Y);
        CharacterNode.Velocity *= 5;

        CharacterNode.MoveAndSlide();
        CharacterNode.Flip();
    }

    public override void _Input(InputEvent @event)
    {
        if (Input.IsActionJustPressed(GameConstants.InputDash))
        {
            CharacterNode.StateMachineNode.SwitchState<PlayerDashState>();
        }
    }

    protected override void EnterState()
    {
        base.EnterState();
        CharacterNode.AnimationPlayerNode.Play(GameConstants.AnimMove);
    }
}