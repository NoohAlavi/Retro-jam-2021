using Godot;

public class Enemy : PathFollow2D
{

    [Export] public float speed = 1f;
    [Export]
    public int health = 2;
    [Export] public PackedScene endParticlesScn;

    private AnimatedSprite anim;

    public override void _Ready()
    {
        anim = GetNode<AnimatedSprite>("AnimatedSprite");
    }

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


        if (health == 3)
        {
            anim.Animation = "green";
        }
        if (health == 2)
        {
            anim.Animation = "red";
        }
        if (health == 1)
        {
            anim.Animation = "blue";
        }
        if (health <= 0)
        {
            QueueFree();
        }
    }
}
