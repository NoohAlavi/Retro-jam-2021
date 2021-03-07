using Godot;

public class Turret : Area2D
{

    [Export]
    public int tier = 1;
    [Export]
    public PackedScene bulletScene;

    private Timer shootTimer;
    private Enemy target = new Enemy();

    public override void _Ready()
    {
        shootTimer = GetNode<Timer>("ShootTimer");

        shootTimer.Connect("timeout", this, "Shoot");
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
    }

    private void Shoot()
    {
        if (!Object.IsInstanceValid(target)) return;

        Bullet bullet = bulletScene.Instance() as Bullet;
        bullet.Position = Position;
        bullet.direction = (target.Position - Position).Normalized();
        GetTree().Root.GetNode("World/Bullets").AddChild(bullet);
    }
}
