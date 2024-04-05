using DungeonRPG.Scripts.General;
using Godot;

namespace DungeonRPG.Scripts.Characters.Enemy;

public partial class EnemyReturnState : EnemyState
{
    private Vector3 _destination;

    public override void _Ready()
    {
        base._Ready();

        var localPos = CharacterNode.PathNodes.Curve.GetPointPosition(0);
        var globalPos = CharacterNode.PathNodes.GlobalPosition;
        _destination = localPos + globalPos;
    }

    public override void _PhysicsProcess(double delta)
    {
        // if (!CharacterNode.Agent3D.IsNavigationFinished()) return;
        if (!CharacterNode.Agent3D.IsNavigationFinished())
        {
            CharacterNode.GlobalPosition.DirectionTo(_destination);
            CharacterNode.MoveAndSlide();
        }
        else
        {
            CharacterNode.StateMachineNode.SwitchState<EnemyPatrolState>();
        }

    }

    protected override void EnterState()
    {
        CharacterNode.AnimationPlayerNode.Play(GameConstants.AnimMove);
        CharacterNode.Agent3D.TargetPosition = _destination;
    }
}