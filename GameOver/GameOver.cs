using Godot;

public class GameOver : Control
{

    private AudioStreamPlayer music;

    public override void _Ready()
    {
        GetNode<Button>("RetryButton").Connect("pressed", this, "Retry");
        music = GetNode<AudioStreamPlayer>("Music");
        // music.Connect("finished", this, "SwitchMusic");
    }

    public void StartGameOver()
    {
        // music.Stream = GD.Load<AudioStream>("res://GameOver/Intro_to_gameover_theme.wav");
        music.VolumeDb = -30;
    }

    public override void _Process(float delta)
    {
        World w = GetTree().Root.GetNode<World>("World");
        
        if (!IsInstanceValid(w) || !IsInstanceValid(w.GetNode("GameMusic")) || w.GetNode<UI>("UILayer/UI").health > 0) return;
        
        w.GetNode<AudioStreamPlayer>("GameMusic").VolumeDb = -100f;

        foreach (Node t in w.GetNode("Turrets").GetChildren())
        {
            t.QueueFree();
        }
        foreach (Node e in w.GetNode("Path2D").GetChildren())
        {
            e.QueueFree();
        }
    }

    private void Retry()
    {
        GetTree().ChangeScene("res://Menu/MainMenu.tscn");
    }

    private void SwitchMusic()
    {
        music.Stream = GD.Load<AudioStream>("res://GameOver/gameover_theme.wav");
        music.Play();
    }
}
