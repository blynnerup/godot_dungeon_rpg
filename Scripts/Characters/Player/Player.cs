using System;
using DungeonRPG.Scripts.General;
using Godot;

namespace DungeonRPG.Scripts.Characters.Player;

public partial class Player : Character
{
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
            _fallSpeed += (float)Mathf.Clamp(_gravity * delta, -10, 0);
            GD.Print(_fallSpeed);
            Velocity += new Vector3(0, _fallSpeed, 0);
            MoveAndSlide();   
        }
    }
}