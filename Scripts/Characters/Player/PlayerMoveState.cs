using DungeonRPG.Scripts.General;
using Godot;

namespace DungeonRPG.Scripts.Characters.Player;

public partial class PlayerMoveState : Node
{
    private Player _characterNode;

    public override void _Ready()
    {
        _characterNode = GetOwner<Player>();
        SetPhysicsProcess(false);
        SetProcessInput(false);
    }

    public override void _PhysicsProcess(double delta)
    {
        if (_characterNode.Direction == Vector2.Zero)
        {
            _characterNode.StateMachineNode.SwitchState<PlayerIdleState>();
            return;
        }
        
        _characterNode.Velocity = new Vector3(_characterNode.Direction.X, 0, _characterNode.Direction.Y);
        _characterNode.Velocity *= 5;

        _characterNode.MoveAndSlide();
        _characterNode.Flip();
    }

    public override void _Notification(int what)
    {
        base._Notification(what);

        switch (what)
        {
            case 5001:
                SetPhysicsProcess(true);
                SetProcessInput(true);
                _characterNode.AnimationPlayerNode.Play(GameConstants.AnimMove);
                break;
            case 5002:
                SetPhysicsProcess(false);
                SetProcessInput(false);
                break;
        }
    }

    public override void _Input(InputEvent @event)
    {
        if (Input.IsActionJustPressed(GameConstants.InputDash))
        {
            _characterNode.StateMachineNode.SwitchState<PlayerDashState>();
        }
    }
}