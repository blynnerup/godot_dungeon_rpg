using System;
using DungeonRPG.Scripts.General;
using Godot;

namespace DungeonRPG.Scripts.Characters.Player;

public partial class Player : CharacterBody3D
{
    [ExportGroup("Required Nodes")] 
    [Export] public AnimationPlayer AnimationPlayerNode { get; private set; }
    [Export] public Sprite3D PlayerSprite3D { get; private set; }
    [Export] public StateMachine StateMachineNode { get; private set; }

    public Vector2 Direction;
    public bool Grounded = false; 
    private float _gravity = -0.1f;
    private float _fallSpeed = -0.8f;

    public override void _Input(InputEvent @event)
    {
        // Get the input from the keyboard
        Direction = Input.GetVector(
            GameConstants.InputMoveLeft,
            GameConstants.InputMoveRight,
            GameConstants.InputMoveUp,
            GameConstants.InputMoveDown
        );
    }

    public override void _PhysicsProcess(double delta)
    {
        GD.Print(_fallSpeed);
        if (IsOnFloor())
            Grounded = true;
        else
        {
            Grounded = false;
            // Velocity += new Vector3(0, -_gravity, 0);
            _fallSpeed += (float)Mathf.Clamp(_gravity * delta, -10, 0);
            GD.Print(_fallSpeed);
            Velocity += new Vector3(0, _fallSpeed, 0);
            MoveAndSlide();   
        }
    }
    
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