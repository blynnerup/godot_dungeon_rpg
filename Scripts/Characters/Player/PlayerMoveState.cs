using DungeonRPG.Scripts.General;
using Godot;

namespace DungeonRPG.Scripts.Characters.Player;

public partial class PlayerMoveState : Node
{
    public override void _Ready()
    {
        var characterNode = GetOwner<Player>();
        characterNode.AnimationPlayerNode.Play(GameConstants.AnimMove);
    }
}