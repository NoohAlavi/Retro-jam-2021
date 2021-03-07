using Godot;

public class Bullet : Area2D
{

    [Export]
    public float speed = 3;
    [Export]
    public Vector2 direction;
    [Export]
    public float damage = 1f;
    [Export]
    public Vector2 accuracy = new Vector2(-1, 1);

    public override void _Ready()
    {
        Connect("area_entered", this, "OnAreaEntered");
        GD.Randomize();

        direction.x += (float) GD.RandRange(accuracy.x, accuracy.y);
    }

    public override void _PhysicsProcess(float delta)
    {
        Position += direction * speed;
    }

    private void OnAreaEntered(Area area) 
    {
        if (area.GetParent() is Enemy)
        {
            area.GetParent<Enemy>().health -= damage;
            QueueFree();
        }
    }
}
