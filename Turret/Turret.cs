using Godot;

public class Turret : Area2D
{

    [Export]
    public int tier = 1;
    [Export]
    public PackedScene bulletScene;
    [Export]
    public float price;

    private Timer shootTimer;
    private Enemy target = new Enemy();

    private bool mouseHover = false;

    public override void _Ready()
    {
        shootTimer = GetNode<Timer>("ShootTimer");

        Connect("mouse_entered", this, "OnMouseEntered");
        Connect("mouse_exited", this, "OnMouseExited");
        shootTimer.Connect("timeout", this, "Shoot");

        GD.Randomize();
    }

    public override void _Process(float delta)
    {

        GetNode<Sprite>(tier.ToString()).Show();

        var enemies = GetTree().Root.GetNode<Node2D>("World/Path2D").GetChildren();
        float distance = Mathf.Inf;

        if (enemies.Count > 0)
        {

            for (int i = 0; i < enemies.Count; i++)
            {
                if (Object.IsInstanceValid(enemies[i] as Enemy))
                {
                    Enemy enemy = enemies[i] as Enemy;
                    var enemyDist = Position.DistanceTo(enemy.Position);

                    distance = Mathf.Min(distance, enemyDist);

                    if (enemyDist == distance)
                    {   
                        target = enemy;
                    }
                }
            }
            LookAt(target.GlobalPosition);
        }

        // GD.Print(Name + " Is Mouse Hovering: " + mouseHover);
    }

    public override void _PhysicsProcess(float delta)
    {
        if (Input.IsActionJustPressed("RemoveTurret") && mouseHover)
        {
            GD.Print("Remove Turret Pressed");
            QueueFree();
            GetTree().Root.GetNode<UI>("World/UILayer/UI").money += Mathf.Floor(price / 2);
        }
    }

    private void Shoot()
    {
        if (!Object.IsInstanceValid(target)) return;

        Bullet bullet = bulletScene.Instance() as Bullet;
        bullet.Position = Position;
        bullet.direction = (target.Position - Position).Normalized();
        bullet.direction.x += (float) GD.RandRange(-1f, 1f);
        GetTree().Root.GetNode("World/Bullets").AddChild(bullet);
    }

    private void OnMouseEntered()
    {
        GD.Print("Mouse Entered! " + mouseHover);
        mouseHover = true;
    }

    private void OnMouseExited()
    {
        GD.Print("Mouse Exited! " + mouseHover);
        mouseHover = false;
    }
}
