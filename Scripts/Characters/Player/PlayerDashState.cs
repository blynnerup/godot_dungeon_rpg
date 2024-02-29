using DungeonRPG.Scripts.General;
using Godot;

namespace DungeonRPG.Scripts.Characters.Player;

public partial class PlayerDashState : PlayerState
{
    [Export] private Timer _dashTimerNode;

    [Export(PropertyHint.Range, "0, 20, 0.1")]
    private float _speed = 10;


    public override void _Ready()
    {
        base._Ready();
        _dashTimerNode.Timeout += HandleTimeOut;
    }

    public override void _PhysicsProcess(double delta)
    {
        CharacterNode.MoveAndSlide();
        CharacterNode.Flip();
    }

    protected override void EnterState()
    {
        CharacterNode.AnimationPlayerNode.Play(GameConstants.AnimDash);
        CharacterNode.Velocity = new Vector3(CharacterNode.Direction.X, 0, CharacterNode.Direction.Y);

        if (CharacterNode.Velocity == Vector3.Zero)
        {
            CharacterNode.Velocity = CharacterNode.PlayerSprite3D.FlipH ? Vector3.Left : Vector3.Right;
        }

        CharacterNode.Velocity *= _speed;
        _dashTimerNode.Start();
    }

    private void HandleTimeOut()
    {
        CharacterNode.Velocity = Vector3.Zero;
        CharacterNode.StateMachineNode.SwitchState<PlayerIdleState>();
    }
}