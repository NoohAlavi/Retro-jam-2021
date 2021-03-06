using Godot;

public class EndParticles : CPUParticles2D
{
    public override void _Ready()
    {
        GetNode<Timer>("Timer").Connect("timeout", this, "OnTimeout()");
        Emitting = true;
    }

    private void OnTimeout()
    {
        QueueFree();
    }
}
