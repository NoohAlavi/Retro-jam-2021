using Godot;

public class World : Node2D
{
    [Export]
    public PackedScene enemyScene;

    private Timer spawnTimer;

    public override void _Ready()
    {
        spawnTimer = GetNode<Timer>("Timer");
        spawnTimer.Connect("timeout", this, "spawnEnemies");

        GD.Randomize();
    }

    public override void _PhysicsProcess(float delta)
    {
        if (GetNode<Path2D>("Path2D").GetChildren().Count == 0f)
        {
            spawnEnemies();
        }
    }

    private void spawnEnemies()
    {
        Enemy enemy = enemyScene.Instance() as Enemy;
        enemy.health = (int) Mathf.Round(GD.Randf() * 2f + 1f);
        enemy.speed = Mathf.Round(GD.Randf() * 3f + 1f);
        GetNode<Path2D>("Path2D").AddChild(enemy);
    }
}
