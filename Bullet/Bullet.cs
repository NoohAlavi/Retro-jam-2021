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
    public Vector2 accuracy = new Vector2(-.15f, .15f);

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

            Enemy hit = area.GetParent<Enemy>();
            if (hit.health == 4)
            {
                if (hit.anim.Animation == "pink")
                {
                    GetTree().Root.GetNode<World>("World").Split(hit.Offset);
                    hit.QueueFree();
                    QueueFree();
                    return;
                } else if (hit.anim.Animation == "sploder")
                {
                    hit.QueueFree();
                    shooter.QueueFree();
                    QueueFree();
                }
            }

            hit.health -= damage;
            hit.speed = Mathf.Round(GD.Randf() * 3f + 1f);
            GetTree().Root.GetNode<UI>("World/UILayer/UI").money++; 

            QueueFree();
        }
    }

    private void Despawn()
    {
        QueueFree();
    }
}
