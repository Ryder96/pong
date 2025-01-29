using Godot;

namespace Pong;

public partial class Ball : CharacterBody2D
{
    private AudioStreamPlayer2D _hitSound;
    [Export] public int Speed = 400;
    public Vector2 TravelingDirection = Vector2.Zero;

    public void Start(Vector2 startPos)
    {
        Position = startPos;
        float randomRotation = GD.Randf() * (Mathf.Pi * 2f);
        Velocity = new Vector2(Speed, 0).Rotated(randomRotation);
    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready() => _hitSound = GetNode<AudioStreamPlayer2D>("WallSound");

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _PhysicsProcess(double delta)
    {
        KinematicCollision2D collision = MoveAndCollide(Velocity * (float)delta);
        if (collision == null)
        {
            return;
        }

        TravelingDirection = collision.GetRemainder();
        GodotObject collider = collision.GetCollider();
        if (collider is StaticBody2D border)
        {
            if (border.IsInGroup("leftBorder") || border.IsInGroup("rightBorder"))
            {
                border.Call("Hit");
                QueueFree();
            }
        }

        _hitSound.PitchScale = UpAndDownPitchScale();
        _hitSound.Play();
        Velocity = Velocity.Bounce(collision.GetNormal());
    }

    private float UpAndDownPitchScale()
    {
        float pitch = _hitSound.PitchScale;
        float newPitch = 0.0f;
        float newPitchScale = GD.Randf() * 0.20f;
        uint fifty = GD.Randi() % 100;
        if (fifty < 50)
        {
            newPitch = pitch + newPitchScale;
            return newPitch > 1.20f ? pitch : newPitch;
        }

        newPitch = pitch - newPitchScale;
        return newPitch < 0.80f ? pitch : newPitch;
    }
}
