using Godot;

public class Main : ColorRect
{
    public void _on_Task1_pressed()
    {
        GetTree().ChangeScene("res://Scenes/Task1.tscn");
    }

    public void _on_Task2_pressed()
    {
        GetTree().ChangeScene("res://Scenes/Task2.tscn");
    }

    public void _on_Task3_pressed()
    {
        GetTree().ChangeScene("res://Scenes/Task3.tscn");
    }

    public void _on_Task4_pressed()
    {
        GetTree().ChangeScene("res://Scenes/Task4.tscn");
    }
}
