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
        GD.Print(CharacterNode.PathNodes.Curve.GetPointPosition(0));
    }

    protected override void EnterState()
    {
        CharacterNode.AnimationPlayerNode.Play(GameConstants.AnimMove);
        CharacterNode.GlobalPosition = _destination;
        GD.Print(CharacterNode.GlobalPosition);
    }
}