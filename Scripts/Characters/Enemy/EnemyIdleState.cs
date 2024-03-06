using DungeonRPG.Scripts.General;

namespace DungeonRPG.Scripts.Characters.Enemy;

public partial class EnemyIdleState : EnemyState
{
    protected override void EnterState()
    {
        CharacterNode.AnimationPlayerNode.Play(GameConstants.AnimIdle);
    }
}