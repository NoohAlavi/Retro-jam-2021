using Godot;

public class Bullet : Area2D
{

    [Export]
    public float speed = 3;
    [Export]
    public Vector2 direction;
    [Export]
    public int damage = 1;
    [Export]
    public Vector2 accuracy = new Vector2(-.25f, .25f);

    public Turret shooter;

    public override void _Ready()
    {
        Connect("area_entered", this, "OnAreaEntered");
        GetNode<Timer>("DespawnTimer").Connect("timeout", this, "Despawn");
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
            GetTree().Root.GetNode<UI>("World/UILayer/UI").money++;
            
            // if (GD.Randf() >= 0.95)
            // {
            //     shooter.QueueFree();
            // }
            
            QueueFree();
        }
    }

    private void Despawn()
    {
        QueueFree();
    }
}
