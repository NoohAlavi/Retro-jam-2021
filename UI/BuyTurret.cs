using Godot;

public class BuyTurret: Button
{
	[Export]
	public float price;
	[Export]
	public string turretName;

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

	private void OnButtonPressed()
	{
		float money = uI.money;
		if (money >= price)
		{
			money -= price;
			GD.Print(turretName + " bought for $" + price + ", $" + money + " remaining");
			uI.money = money;
		}
	}
}