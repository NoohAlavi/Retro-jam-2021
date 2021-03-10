using Godot;
using System;

public class Tutorial : Control
{

    [Export]
    public String nextScene;
    [Export]
    public String backScene;

    private Button backButton;
    private Button nextButton;

    public override void _Ready()
    {
        backButton = GetNode<Button>("BackButton");
        nextButton = GetNode<Button>("NextButton");

        backButton.Connect("pressed", this, "Back");
        nextButton.Connect("pressed", this, "Next");
    }

    private void Next()
    {
        GetTree().ChangeScene(nextScene);
    }

    private void Back()
    {
        GetTree().ChangeScene(backScene);
    }
}
