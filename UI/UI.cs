using Godot;

public class UI : Control
{
    private Button button1;
    private Label  coinLabel;

    [Export]
    public float money = 15; 

    public override void _Ready()
    {
        button1 = GetNode<Button>("Buttons/Button_1");
        button1.Connect("pressed", this, "onButton1Pressed");

        coinLabel = GetNode<Label>("CoinsLabel");
    }

    public override void _Process(float delta)
    {
        coinLabel.Text = "Coins: $" + money;

        if (money < 5)
        {
            button1.Disabled = true;
        } else
        {
            button1.Disabled = false;
        }
    }

    private void onButton1Pressed()
    {   
        money -= 5f;
        GD.Print("Bought Level 1 Turret!");
    }
}
