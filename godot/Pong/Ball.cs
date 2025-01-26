using System;
using Godot;

namespace Pong;

public partial class Ball : CharacterBody2D
{
    [Export] public int Speed = 600;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready() => Velocity = new Vector2(Speed, 0).Rotated((float)Math.PI / 15);

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _PhysicsProcess(double delta)
    {
        KinematicCollision2D collision = MoveAndCollide(Velocity * (float)delta);
        if (collision == null)
        {
            return;
        }

        GodotObject collider = collision.GetCollider();
        if (collider is StaticBody2D border)
        {
            if (border.IsInGroup("leftBorder") || border.IsInGroup("rightBorder"))
            {
                border.Call("Hit");
            }
        }

        Velocity = Velocity.Bounce(collision.GetNormal());
    }
}
