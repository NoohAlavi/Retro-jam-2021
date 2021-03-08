using Godot;

public class UI : Control
{
    private Label  coinLabel;
    private Label hpLabel;

    [Export]
    public float money = 15; 
    [Export]
    public float health = 500f;

    public override void _Ready()
    {

        coinLabel = GetNode<Label>("CoinsLabel");
        hpLabel = GetNode<Label>("HealthLabel");
    }

    public override void _Process(float delta)
    {
        coinLabel.Text = "Coins: $" + money;
        hpLabel.Text = "Health: " + (health / 500f) * 100f  + "%";

        if (Input.IsActionJustPressed("ToggleCRT"))
        {
            GetNode<ColorRect>("CRT").Visible = !GetNode<ColorRect>("CRT").Visible;
        }

        if (health <= 0f)
        {
            GetTree().ChangeScene("res://GameOver/GameOver.tscn");
        }
    }
}

