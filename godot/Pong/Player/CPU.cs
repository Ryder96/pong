using Godot;

namespace Pong.Player;

public partial class CPU : CharacterBody2D
{
    private const float Speed = 300.0f;

    private Ball _ball;
    private Vector2 _direction = Vector2.Down;
    private bool _isMoving;

    public override void _PhysicsProcess(double delta)
    {
        Vector2 velocity = Velocity;

        KinematicCollision2D collision = MoveAndCollide(velocity * (float)delta);

        if (collision != null && !_isMoving)
        {
            _direction = ChangeDirection();
            _isMoving = true;
        }

        {
            _isMoving = false;
        }

        velocity.Y = _direction.Y * Speed;
        Velocity = velocity;
        MoveAndSlide();
    }

    private Vector2 ChangeDirection() => _direction == Vector2.Down ? Vector2.Up : Vector2.Down;

    public void SetBall(Ball ball) => _ball = ball;
}
