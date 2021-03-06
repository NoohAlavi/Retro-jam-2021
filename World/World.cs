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
    }

    private void spawnEnemies()
    {
        Enemy enemy = enemyScene.Instance() as Enemy;
        GetNode<Path2D>("Path2D").AddChild(enemy);
    }
}
