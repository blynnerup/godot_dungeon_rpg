using DungeonRPG.Scripts.General;
using Godot;

namespace DungeonRPG.Scripts.Characters;

public abstract partial class CharacterState : Node
{
    protected Character CharacterNode;

    public override void _Ready()
    {
        CharacterNode = GetOwner<Character>();
        SetPhysicsProcess(false); 
        SetProcessInput(false);
    }
    
    public override void _Notification(int what)
    {
        base._Notification(what);

        switch (what)
        { 
            case GameConstants.NotificationEnterState:
                EnterState();
                SetPhysicsProcess(true);
                SetProcessInput(true);
                break;
            case GameConstants.NotificationExitState:
                SetPhysicsProcess(false);
                SetProcessInput(false);
                break;
        }
    }
    
    protected virtual void EnterState() {}
}