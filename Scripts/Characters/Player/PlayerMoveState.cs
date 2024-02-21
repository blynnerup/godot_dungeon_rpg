using DungeonRPG.Scripts.General;
using Godot;

namespace DungeonRPG.Scripts.Characters.Player;

public partial class PlayerMoveState : Node
{
    public override void _Notification(int what)
    {
        base._Notification(what);

        if (what == 5001)
        {
            GD.Print("Move");
            var characterNode = GetOwner<Player>();
            characterNode.AnimationPlayerNode.Play(GameConstants.AnimMove);
        }

    }
}