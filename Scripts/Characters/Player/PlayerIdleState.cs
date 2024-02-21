using DungeonRPG.Scripts.General;
using Godot;

namespace DungeonRPG.Scripts.Characters.Player;

public partial class PlayerIdleState : Node
{
    public override void _Notification(int what)
    {
        base._Notification(what);

        if (what == 5001)
        {
            GD.Print("Idle");
            var characterNode = GetOwner<Player>();
            characterNode.AnimationPlayerNode.Play(GameConstants.AnimIdle);
        }

    }
}