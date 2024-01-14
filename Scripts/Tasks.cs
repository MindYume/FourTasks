public class Tasks
{
    /// Задача 2
    public static string Task2(int A, int B)
    {
        string output = "";

        int numbersMultiply = A * B;
        for (int i = 100; i < 1000; i++)
        {
            int numSum = i/100 + (i%100)/10 +i%10;

            if (numSum == numbersMultiply)
            {
                output += i + ", ";
            }
        }

        // Убрать последнюю запятую для красоты
        if (output.EndsWith(", "))
        {
            output = output.Substring(0, output.Length-2);
        }
        
        if (output == "")
        {
            return "Нет подходящих чисел";
        }

        return output;
    }

    // Задача 3
    public static string Task3(int steps)
    {
        string output = "";
        
        // true  - место очищено от снега
        // false - место засыпано снегом
        bool[] spots = new bool[100];

        for (int i = 0; i < steps; i++)
        {
            if (i%2 == 0)
            {
                for (int j = 1; j < 100; j++)
                {
                    if (j%2 == 1)
                    {
                        spots[j] = true;
                    }
                }
            }
            else
            {
                for (int j = 2; j < 100; j++)
                {
                    if (j%3 == 2)
                    {
                        spots[j] = !spots[j];
                    }
                }
            }
        }

        for (int i = 0; i < 100; i++)
        {
            if (!spots[i])
            {
                output += (i+1) + ", ";
            }
        }

        // Убрать последнюю запятую для красоты
        if (output.EndsWith(", "))
        {
            output = output.Substring(0, output.Length-2);
        }

        return output;
    }



    // Задача 4
    public static string Task4(float[] weights)
    {
        string output = "";

        int wCount; // Количество взвешиваний
        int wNum; // Номер гири с отличным весом
        bool isWeightHeavy; // Тяжелее ли найденная гиря остальных гирь

        wCount = FindWeight(out wNum, out isWeightHeavy, 0, 8, weights);

        output = $"Номер гири с отличным весом: {wNum}\n";
        if (isWeightHeavy)
        {
            output += $"Данная гиря тяжелее остальных\n";
        }
        else
        {
            output += $"Данная гиря легче остальных\n";
        }
        output += $"Количество взвешиваний: {wCount}";

        return output;
    }

    /// <summary>
    /// Данный метод рекурсивно ищет гирю, вес которой отличается от остальных, а также подсчитывает количество сделанных взвешиваний.
    /// </summary>
    /// <param name="wNum">Номер найденной гири</param>
    /// <param name="isWeightHeavy">Тяжелее ли найденная гиря остальных гирь</param>
    /// <param name="firstWeight">Первая гиря, от которой нужно начать поиск</param>
    /// <param name="wAmount">Количесто гирь, среди которых стоит проводить поиск</param>
    /// <param name="weights">Веса всех гирь</param>
    /// <returns> Возвращает количество сделанных взвешиавний</returns>
    public static int FindWeight(out int wNum, out bool isWeightHeavy, int firstWeight, int wAmount, float[] weights)
    {
        // Количество взвешиваний
        int wCount = 0;

        // Сначала разделим все гири на три группы, а также посчитаем количество гирь в каждой группе
        float[] group = new float[3];
        int[] wightsInGroup = new int[3];
        int[] lastWeightInGroup = new int[3]; // Последняя гиря в каждой группе. Эта информация пригодится в будущем

        int divider = wAmount/3;
        int remain = wAmount%3;
        int nextWeight = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < divider; j++)
            {
                group[i] += weights[firstWeight+nextWeight];
                wightsInGroup[i] += 1;
                lastWeightInGroup[i] = firstWeight+nextWeight;
                nextWeight++;
            }

            if (i < remain)
            {
                group[i] += weights[firstWeight+nextWeight];
                wightsInGroup[i] += 1;
                lastWeightInGroup[i] = firstWeight+nextWeight;
                nextWeight++;
            }
        }

        // Найдём две группы с одинковым количеством гирь и оставшуюся группу. Эта информация понадобится в дальнейшем.
        // g1 и g1 - группы с одинковым количеством гирь
        // g3 - оставшаяся группа
        int g1, g2, g3;

        if (wightsInGroup[0] == wightsInGroup[1])
        {
            g1 = 0;
            g2 = 1;
            g3 = 2;
        }
        else
        {
            g1 = 1;
            g2 = 2;
            g3 = 0;
        }

        // Сравним веса в двух группах, в которых одинковое количество гирь (+ взвешивание).
        wCount++;
        if (group[g1] == group[g2]) // Если веса в первой и второй группе одинаковы, занчит гиря с отличным весом находится в третьей группе
        {
            if (wightsInGroup[g3] == 1) // Если в третьей группе всего одна гиря, значит, это и есть гиря с отличным весом
            {
                // Номер найденной гири
                wNum = lastWeightInGroup[g3] + 1;

                wCount++;
                if (weights[wNum-1] > weights[lastWeightInGroup[g1]]) // Если вес найденной гири больше, чем у другой гири (+1 взвешивание)
                {
                    isWeightHeavy = true;
                }
                else
                {
                    isWeightHeavy = false;
                }
            }
            else if (wightsInGroup[g3] == 2) // Если в третьей группе всего две гири
            {
                // Сравним одну из гирь в третьей группе с любой гирей из другой группы, чтобы определить, какая гиря в третьей группе имеет оличный вес (+1 взвешиание)
                wCount++;
                if (weights[lastWeightInGroup[g3]] == weights[lastWeightInGroup[g1]])
                {
                    wNum = lastWeightInGroup[g3];
                }
                else
                {
                    wNum = lastWeightInGroup[g3] + 1;
                }
                
                wCount++;
                if (weights[wNum-1] > weights[lastWeightInGroup[g1]]) // Если вес найденной гири больше, чем у другой гири (+1 взвешиание)
                {
                    isWeightHeavy = true;
                }
                else
                {
                    isWeightHeavy = false;
                }
            }
            else // Если гирь в третьей группе больше 2, то рекурсивно применим метод FindWeight к этой группе, чтобы найти нужную гирю в ней
            {
                wCount += FindWeight(out wNum, out isWeightHeavy, (firstWeight + wAmount - wightsInGroup[g3]-1), wightsInGroup[g3], weights);
            }
        }
        else // Если веса в первой и второй группе разные, занчит гиря с отличным весом находится в одной из них
        {
            if (wightsInGroup[g1] + wightsInGroup[g2] == 2)
            {
                // Сравним одну из гирь во второй группе с гирей из третьей группы, чтобы определить, какая гиря имеет оличный вес (+1 взвешиание)
                wCount++;
                if (weights[lastWeightInGroup[g2]] == weights[lastWeightInGroup[g3]])
                {
                    wNum = lastWeightInGroup[g1] + 1;
                }
                else
                {
                    wNum = lastWeightInGroup[g2] + 1;
                }
                
                wCount++;
                if (weights[wNum-1] > weights[lastWeightInGroup[g3]]) // Если вес найденной гири больше, чем у другой гири (+1 взвешиание)
                {
                    isWeightHeavy = true;
                }
                else
                {
                    isWeightHeavy = false;
                }
            }
            else
            {
                wCount += FindWeight(out wNum, out isWeightHeavy, firstWeight, wAmount - wightsInGroup[g3], weights);
            }
        }

        return wCount;
    }
}