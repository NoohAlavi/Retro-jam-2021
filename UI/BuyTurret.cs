using Godot;

public class BuyTurret: Button
{
	[Export]
	public float price;
	[Export]
	public string turretName;
	[Export]
	public int targetTier = 1;

	[Export]
	public bool isEditMode = false;
	[Export]
	public PackedScene turretScene;

	private UI uI;

    public override void _Ready()
    {
        Connect("pressed", this, "OnButtonPressed");
		uI = GetParent().GetParent().GetParent<UI>();
		Text = turretName + " ($" + price + ")";
		
    }

    public override void _Process(float delta)
    {
        if (uI.money < price)
		{
			Disabled = true;
		} else
		{
			Disabled = false;
		}
    }

    public override void _PhysicsProcess(float delta)
    {
        if (Input.IsActionJustPressed("PlaceTurret") && isEditMode)
		{
			Vector2 mousePos = GetGlobalMousePosition();
			SpawnTurret(mousePos);
		}
    }
    

	private void OnButtonPressed()
	{
		float money = uI.money;
		if (money >= price)
		{
			money -= price;
			GD.Print(turretName + " bought for $" + price + ", $" + money + " remaining");
			uI.money = money;
		}

		isEditMode = true;
	}

	private void SpawnTurret(Vector2 pos)
	{
		Node turretsHolder = GetTree().Root.GetNode("World/Turrets");
		var turrets = turretsHolder.GetChildren();
		for (int i = 0; i < turrets.Count; i++)
		{
			if (pos.DistanceTo((turrets[i] as Turret).Position) < 100) 
				return;
		}
		Turret turret = turretScene.Instance() as Turret;
		turret.Position = pos;
		turret.tier = targetTier;
		turretsHolder.AddChild(turret);

		GD.Print("Placed Turret at " + pos.x + ", " + pos.y);
		isEditMode = false;
	}
}