using DungeonRPG.Scripts.General;
using Godot;

namespace DungeonRPG.Scripts.Characters.Enemy;

public partial class EnemyReturnState : EnemyState
{
    private Vector3 _destination;

    public override void _Ready()
    {
        base._Ready();

        _destination = CharacterNode.PathNodes.Curve.GetPointPosition(0);
    }

    protected override void EnterState()
    {
        CharacterNode.AnimationPlayerNode.Play(GameConstants.AnimMove);
        CharacterNode.GlobalPosition = _destination;
    }
}