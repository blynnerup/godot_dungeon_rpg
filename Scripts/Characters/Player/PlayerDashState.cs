using DungeonRPG.Scripts.General;
using Godot;

namespace DungeonRPG.Scripts.Characters.Player;

public partial class PlayerDashState : Node
{
    [Export] private Timer _dashTimerNode;
    [Export] private float _speed = 10;

    private Player _characterNode;

    public override void _Ready()
    {
        _characterNode = GetOwner<Player>();
        _dashTimerNode.Timeout += HandleTimeOut;
        SetPhysicsProcess(false);
    }

    public override void _PhysicsProcess(double delta)
    {
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
                _characterNode.AnimationPlayerNode.Play(GameConstants.AnimDash);
                _characterNode.Velocity = new Vector3(_characterNode.Direction.X, 0, _characterNode.Direction.Y);

                if (_characterNode.Velocity == Vector3.Zero)
                {
                    _characterNode.Velocity = _characterNode.PlayerSprite3D.FlipH ? Vector3.Left : Vector3.Right;
                }
                _characterNode.Velocity *= _speed;
                _dashTimerNode.Start();
                break;
            case 5002:
                SetPhysicsProcess(false);
                break;
        }
    }

    private void HandleTimeOut()
    {
        _characterNode.Velocity = Vector3.Zero;
        _characterNode.StateMachineNode.SwitchState<PlayerIdleState>();
    }
}