using Godot;

public class Enemy : PathFollow2D
{

    [Export] public float speed = 1f;
    [Export] public PackedScene endParticlesScn;

    public override void _PhysicsProcess(float delta)
    {
        Offset += speed;

        if (Offset >= 2730)
        {
            EndParticles endParticles = endParticlesScn.Instance() as EndParticles;
            GetParent().AddChild(endParticles);
            GD.Print("Enemy has gotten through");
            QueueFree();
        }
    }
}
