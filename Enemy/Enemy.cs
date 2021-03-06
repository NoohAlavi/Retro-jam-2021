using Godot;

public class Enemy : PathFollow2D
{

    [Export] public float speed = 1f;

    public override void _PhysicsProcess(float delta)
    {
        Offset += speed;

        if (Offset >= 2730)
        {
            QueueFree();
            GD.Print("Enemy has gotten through");
        }
    }
}
