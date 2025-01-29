using Godot;
using Pong.Player;

namespace Pong;

public partial class Main : Node2D
{
    private PackedScene _ball = GD.Load<PackedScene>("res://ball.tscn");
    private CPU _cpu;
    private int _cpuScore;
    private Label _cpuScoreLabel;
    private int _userScore;

    private Label _userScoreLabel;


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _userScore = 0;
        _cpuScore = 0;

        _userScoreLabel = GetNode<Label>("HUD/PlayerScore");
        _userScoreLabel.Text = $"{_userScore}";

        _cpuScoreLabel = GetNode<Label>("HUD/CpuScore");
        _cpuScoreLabel.Text = $"{_cpuScore}";

        _cpu = GetNode<CPU>("CPU");
        ResetBall();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }

    private void ResetBall()
    {
        Ball b = (Ball)_ball.Instantiate();
        b.Start(GetViewportRect().Size / 2);
        GetTree().Root.CallDeferred("add_child", b);
        _cpu.SetBall(b);
    }

    private void OnCpuScored()
    {
        _cpuScore++;
        _cpuScoreLabel.Text = $"{_cpuScore}";
        ResetBall();
    }

    private void OnUserScored()
    {
        _userScore++;
        _userScoreLabel.Text = $"{_userScore}";
        ResetBall();
    }
}
