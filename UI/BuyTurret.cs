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
	[Export]
	public Texture mouseCursor;

	private UI uI;

    public override void _Ready()
    {
        Connect("pressed", this, "OnButtonPressed");
		uI = GetParent().GetParent().GetParent<UI>();
		Text = turretName + " [$" + price + "]";
		
    }

    public override void _Process(float delta)
    {
        Disabled =  (uI.money < price);

		if (isEditMode)
		{
			Input.SetCustomMouseCursor(mouseCursor);
		}
    }

    public override void _PhysicsProcess(float delta)
    {
        if (Input.IsActionJustPressed("PlaceTurret") && isEditMode)
		{
			Vector2 mousePos = GetGlobalMousePosition();
			SpawnTurret(mousePos);
		}

		if (Input.IsActionJustPressed("CancelTurret") && isEditMode)
		{
			isEditMode = false;
			Input.SetCustomMouseCursor(null, Input.CursorShape.Arrow);
		}
    }
    

	private void OnButtonPressed()
	{
		float money = uI.money;
		if (money >= price && !isEditMode)
		{
			isEditMode = true;
		}
	}

	private void SpawnTurret(Vector2 pos)
	{
		Node turretsHolder = GetTree().Root.GetNode("World/Turrets");
		var turrets = turretsHolder.GetChildren();
		if (pos.y > 500f) return;
		for (int i = 0; i < turrets.Count; i++)
		{
			if (pos.DistanceTo((turrets[i] as Turret).Position) < 100) 
				return;
		}
		Turret turret = turretScene.Instance() as Turret;
		turret.Position = pos;
		turret.tier = targetTier;
		turret.price = price;
		turretsHolder.AddChild(turret);

		float money = uI.money;
		money -= price;
		GD.Print(turretName + " bought for $" + price + ", $" + money + " remaining");
		uI.money = money;

		GD.Print("Placed Turret at " + pos.x + ", " + pos.y);
		isEditMode = false;
		Input.SetCustomMouseCursor(null, Input.CursorShape.Arrow);
	}
}