using Godot;

public class Bullet : Area2D
{

    [Export]
    public float speed = 3;
    [Export]
    public Vector2 direction;

    public override void _Ready()
    {
        Connect("area_entered", this, "OnAreaEntered");
    }

    public override void _PhysicsProcess(float delta)
    {
        Position += direction * speed;
    }

    private void OnAreaEntered(Area area) 
    {
        if (area.GetParent() is Enemy)
        {
            area.GetParent().QueueFree();
            QueueFree();
        }
    }
}
