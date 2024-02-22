using DungeonRPG.Scripts.Characters.Player;
using Godot;

namespace DungeonRPG.Scripts.Characters;

public partial class StateMachine : Node
{
    [Export]
    private Node _currentState;

    [Export]
    private Node[] _states;

    public override void _Ready()
    {
        _currentState.Notification(5001);
    }

    public void SwitchState<T>()
    {
        Node newState = null;

        foreach (var state in _states)
        {
            if (state is T)
            {
                newState = state;
            }
        }

        if (newState == null)
            return;

        _currentState = newState;
        _currentState.Notification(5001);
    }
}