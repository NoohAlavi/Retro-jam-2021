using Godot;

public class MainMenu : Control
{

    public override void _Ready()
    {
        GetNode<Button>("Play").Connect("pressed", this, "Play");
        GetNode<Button>("Credits").Connect("pressed", this, "Credits");
    }

    private void Play()
    {
        GetTree().ChangeScene("res://World/World.tscn");
    }

    private void Credits()
    {
        GetTree().ChangeScene("res://Credits/Credits.tscn");
    }
}
