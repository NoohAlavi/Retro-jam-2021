using Godot;

public class UI : Control
{
    private Label  coinLabel;

    [Export]
    public float money = 15; 
    [Export]
    public float health = 100f;

    public override void _Ready()
    {

        coinLabel = GetNode<Label>("CoinsLabel");
    }

    public override void _Process(float delta)
    {
        coinLabel.Text = "Coins: $" + money;

        if (Input.IsActionJustPressed("ToggleCRT"))
        {
            GetNode<ColorRect>("CRT").Visible = !GetNode<ColorRect>("CRT").Visible;
        }
    }
}

