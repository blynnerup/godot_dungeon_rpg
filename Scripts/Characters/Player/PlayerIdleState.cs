using DungeonRPG.Scripts.General;
using Godot;

namespace DungeonRPG.Scripts.Characters.Player;

public partial class PlayerIdleState : Node
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
        if (_characterNode.Direction != Vector2.Zero)
        {
            _characterNode.StateMachineNode.SwitchState<PlayerMoveState>();
        }
    }

    public override void _Notification(int what)
    {
        base._Notification(what);

        switch (what)
        {
            case 5001:
                SetPhysicsProcess(true);
                SetProcessInput(true);
                _characterNode.AnimationPlayerNode.Play(GameConstants.AnimIdle);
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