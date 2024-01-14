using Godot;

public class Task3 : ColorRect
{
    private LineEdit _steps;
    private Label _outputLabel;
    public override void _Ready()
    {
        _steps = GetNode<LineEdit>("Steps");
        _outputLabel = GetNode<Label>("OutputLabel");
    }

    public void _on_Calculate_pressed()
    {
        int stepsInt;
        if (int.TryParse(_steps.Text, out stepsInt) && stepsInt >= 0)
        {
            _outputLabel.Text = Tasks.Task3(stepsInt);
        }
        else
        {
            _outputLabel.Text = "Число введено неправильно";
        }
    }
}
