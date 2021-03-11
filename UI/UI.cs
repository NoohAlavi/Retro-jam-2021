using Godot;

public class UI : Control
{
    private Label  coinLabel;
    private Label hpLabel;
    private Label scoreLabel;
    [Export]
    public float money = 15; 
    [Export]
    public float maxHp = 750f;
    [Export]
    public int score = 0;

    [Export]
    public float health;

    public override void _Ready()
    {

        health = maxHp;

        coinLabel = GetNode<Label>("CoinsLabel");
        hpLabel = GetNode<Label>("HealthLabel");
        scoreLabel = GetNode<Label>("ScoreLabel");

        GetNode<Timer>("ScoreTimer").Connect("timeout", this, "AddScore");
    }

    public override void _Process(float delta)
    {
        coinLabel.Text = "Coins: $" + money;
        hpLabel.Text = "Health: " + Mathf.Round((health / maxHp) * 100f)  + "%";
        scoreLabel.Text = "Score: " + score;

        if (Input.IsActionJustPressed("ToggleCRT"))
        {
            GetNode<ColorRect>("CRT").Visible = !GetNode<ColorRect>("CRT").Visible;
        }

        if (Input.IsActionJustPressed("Reset"))
        {
            GetTree().ReloadCurrentScene();
        }

        if (health <= 0f)
        {
            GetNode<GameOver>("GameOver").Show();
            GetNode<GameOver>("GameOver").StartGameOver();
            GetNode<HBoxContainer>("Buttons/HBoxContainer").Hide();
        }
    }

    private void AddScore()
    {
        if (health > 0f)
        score++;
    }
}

