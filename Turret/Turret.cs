using Godot;

public class Turret : Node2D
{
    public override void _Process(float delta)
    {
        var enemies = GetTree().Root.GetNode<Node2D>("World/Path2D");
        LookAt((enemies.GetChild<Node2D>(enemies.GetChildren().Count - 1).GlobalPosition - GlobalPosition));
    }
}
