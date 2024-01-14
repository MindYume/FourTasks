using Godot;

public class Task4 : ColorRect
{
    private LineEdit[] _weights;
    private Label _outputLabel;

    public override void _Ready()
    {
        _weights = new LineEdit[8];
        _weights[0] = GetNode<LineEdit>("Weights/Weight1");
        _weights[1] = GetNode<LineEdit>("Weights/Weight2");
        _weights[2] = GetNode<LineEdit>("Weights/Weight3");
        _weights[3] = GetNode<LineEdit>("Weights/Weight4");
        _weights[4] = GetNode<LineEdit>("Weights/Weight5");
        _weights[5] = GetNode<LineEdit>("Weights/Weight6");
        _weights[6] = GetNode<LineEdit>("Weights/Weight7");
        _weights[7] = GetNode<LineEdit>("Weights/Weight8");
        
        _outputLabel = GetNode<Label>("OutputLabel");
    }

    public void _on_Calculate_pressed()
    {
        bool isInputCorrect = true;

        float[] weightsFloat = new float[8];
        for (int i = 0; i < 8; i++)
        {
            if (!float.TryParse(_weights[i].Text, out weightsFloat[i]))
            {
                isInputCorrect = false;
                break;
            }
        }

        if (isInputCorrect)
        {
            float commonWeightValue;
            if (weightsFloat[0] == weightsFloat[1] || weightsFloat[0] == weightsFloat[2])
            {
                commonWeightValue = weightsFloat[0];
            }
            else
            {
                commonWeightValue = weightsFloat[1];
            }

            int commonWeightsAmount = 0;
            for (int i = 0; i < 8; i++)
            {
                if (weightsFloat[i] == commonWeightValue)
                {
                    commonWeightsAmount++;
                }
            }

            if (commonWeightsAmount == 7)
            {
                int wCount;
                int wNum;
                bool isWeightHeavy;
                int firstWeight = 0;
                int wAmount = 8;

                wCount = Tasks.FindWeight(out wNum, out isWeightHeavy, firstWeight, wAmount, weightsFloat);

                _outputLabel.Text = $"Номер гири с отличным весом: {wNum}\n";
                if (isWeightHeavy)
                {
                    _outputLabel.Text += $"Данная гиря тяжелее остальных\n";
                }
                else
                {
                    _outputLabel.Text += $"Данная гиря легче остальных\n";
                }
                _outputLabel.Text += $"Количество взвешиваний: {wCount}";
            }
            else
            {
                _outputLabel.Text = "Все гири, кроме одной, должны иметь одинаковый вес";
            }
        }
        else
        {
            _outputLabel.Text = "Веса введены неправильно";
        }
    }
}
