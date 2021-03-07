using Godot;

public class Credits : Control
{
    public override void _Ready()
    {
        GetNode<LinkButton>("Nooh").Connect("pressed", this, "NoohSocials");
        GetNode<LinkButton>("Nash").Connect("pressed", this, "NashSocials");
    }

    private void NoohSocials()
    {
        OS.ShellOpen("https://twitch.tv/opsci");
        OS.ShellOpen("https://noohalavi.itch.io");
        OS.ShellOpen("https://www.youtube.com/channel/UC2W0dJwYSOHm4Rn1p17P6qg");
        OS.ShellOpen("https://www.github.com/NoohAlavi");
    }
    
    private void NashSocials()
    {
        OS.ShellOpen("https://soundcloud.com/prodnishy");
        OS.ShellOpen("https://twitch.tv/prodnishy");
        OS.ShellOpen("https://www.youtube.com/channel/UCATENuBKkVByd3tiJsCYw1A");
    }
}
