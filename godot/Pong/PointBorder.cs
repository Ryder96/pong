using Godot;

namespace Pong;

public partial class PointBorder : StaticBody2D
{
    [Signal]
    public delegate void CpuScoredEventHandler();

    [Signal]
    public delegate void UserScoredEventHandler();

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }


    private void Hit()
    {
        if (Name == "left")
        {
            EmitSignal(SignalName.CpuScored);
        }

        if (Name == "right")
        {
            EmitSignal(SignalName.UserScored);
        }
    }
}
