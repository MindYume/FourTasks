using Godot;

public class BackButton : Button
{
    public void _on_BackButton_pressed()
    {
        GetTree().ChangeScene("res://Scenes/Main.tscn");
    }
}
