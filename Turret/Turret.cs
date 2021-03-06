using Godot;

public class Turret : Node2D
{

    [Export]
    public int tier = 1;

    public override void _Process(float delta)
    {

        GetNode<Sprite>(tier.ToString()).Show();


        var enemies = GetTree().Root.GetNode<Node2D>("World/Path2D").GetChildren();
        float distance = Mathf.Inf;
        Enemy target = new Enemy();

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
}
