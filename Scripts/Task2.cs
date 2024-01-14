using Godot;

public class Task2 : ColorRect
{
    private LineEdit _numberA;
    private LineEdit _numberB;
    private Label _outputLabel;
    public override void _Ready()
    {
        _numberA = GetNode<LineEdit>("NumberA");
        _numberB = GetNode<LineEdit>("NumberB");
        _outputLabel = GetNode<Label>("OutputLabel");
    }

    public void _on_Calculate_pressed()
    {
        int intA = 0;
        int intB = 0;

        if (!int.TryParse(_numberA.Text, out intA) || !int.TryParse(_numberB.Text, out intB) || intA < 0 || intB < 0)
        {
            _outputLabel.Text = "Числа введены неправильно";
        }
        else if (intA >= intB)
        {
            _outputLabel.Text = "Число A должно быть меньше, чем B";
        }
        else
        {
            _outputLabel.Text = Tasks.Task2(intA, intB);
        }
    }
}
