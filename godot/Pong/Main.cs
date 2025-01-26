using Godot;

namespace Pong;

public partial class Main : Node2D
{
    private Ball _ball;
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
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }

    private void OnCpuScored()
    {
        _cpuScore++;
        _cpuScoreLabel.Text = $"{_cpuScore}";
    }

    private void OnUserScored()
    {
        _userScore++;
        _userScoreLabel.Text = $"{_userScore}";
    }
}
