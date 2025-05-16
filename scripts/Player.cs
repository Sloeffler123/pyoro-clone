using Godot;
using System;

public partial class Player : CharacterBody2D
{
    [Export] public int Speed = 75;

    public override void _PhysicsProcess(double delta)
    {
        Vector2 velocity = Velocity;

        // Get input (left/right)
        float direction = Input.GetActionStrength("ui_right") - Input.GetActionStrength("ui_left");

        // Move horizontally
        velocity.X = direction * Speed;
        velocity.Y = 0; // no vertical movement

        Velocity = velocity;
        MoveAndSlide();

        // Flip sprite if moving left
        if (GetNode<AnimatedSprite2D>("AnimatedSprite2D") is AnimatedSprite2D sprite)
        {
            if (direction != 0)
                GetNode<AnimatedSprite2D>("AnimatedSprite2D").FlipH = direction > 0;
        }

    }
}