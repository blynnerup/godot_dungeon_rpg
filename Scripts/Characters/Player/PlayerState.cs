using DungeonRPG.Scripts.General;
using Godot;

namespace DungeonRPG.Scripts.Characters.Player;

public abstract partial class PlayerState : CharacterState
{
    public override void _Ready()
    {
        base._Ready();
        CharacterNode = GetOwner<Character>();
    }
}