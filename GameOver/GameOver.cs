using Godot;

public class GameOver : Control
{

    public override void _Ready()
    {
        GetNode<Button>("RetryButton").Connect("pressed", this, "Retry");
    }

    private void Retry()
    {
        GetTree().ReloadCurrentScene();
    }
}
