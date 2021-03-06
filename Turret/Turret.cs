using Godot;

public class Turret : Node2D
{
    public override void _Process(float delta)
    {
        var enemies = GetTree().Root.GetNode<Node2D>("World/Path2D");
        Enemy target = enemies.GetChild<Enemy>(0);
        LookAt(target.GlobalPosition);
        GD.Print("Target: " + target.Name + ", Rotation: " + RotationDegrees);
    }
}
