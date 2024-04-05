using Godot;

namespace DungeonRPG.Scripts.Characters;

public abstract partial class Character : CharacterBody3D
{
    [ExportGroup("Required Nodes")] 
    [Export] public AnimationPlayer AnimationPlayerNode { get; private set; }
    [Export] public Sprite3D PlayerSprite3D { get; private set; }
    [Export] public StateMachine StateMachineNode { get; private set; }
    
    [ExportGroup("AI Nodes")]
    [Export] public Path3D PathNodes { get; private set; }
    [Export] public NavigationAgent3D Agent3D { get; private set; }
    
    public Vector2 Direction;
    public bool Grounded = false;
    public void Flip()
    {
        PlayerSprite3D.FlipH = Direction.X switch
        {
            < 0 => true,
            > 0 => false,
            _ => PlayerSprite3D.FlipH
        };
    }
}