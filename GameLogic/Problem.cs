using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame.GameLogic;

internal abstract class Problem
{
    protected readonly Random random = new();
    protected readonly int max = 100;
    protected int[] nums = [0, 0];
    protected int solution = 0;
    internal abstract (string problemString, int solution) NewProblem();
    internal void AssignRandomNumbers()
    {
        nums[0] = random.Next(0, max);
        nums[1] = random.Next(0, max);
    }

    internal void AssignRandomNumbers(int minNum, int maxNum)
    {
        if (minNum > maxNum)
        {
            throw new ArgumentException("min is greater than max");
        }

        nums[0] = random.Next(minNum, maxNum);
        nums[1] = random.Next(minNum, maxNum);
    }

    internal void RandomOrder()
    {
        int randomOrderNum = random.Next(0, 2);
        Array.Sort(nums);
        if (randomOrderNum == 0)
            Array.Reverse(nums);
    }
    internal void ReverseOrder()
    {
        Array.Sort(nums);
        Array.Reverse(nums);
    }

    internal string ProblemString(string OperatorType)
    {
        return $"{nums[0]} {OperatorType} {nums[1]}";
    }
}

internal class AdditionProblem : Problem
{
    internal override (string problemString, int solution) NewProblem()
    {
        do
        {
            AssignRandomNumbers();
        } while (nums[0] + nums[1] > max);

        RandomOrder();

        solution = nums[0] + nums[1];
        string problemString = ProblemString("+");
        return (problemString, solution);
    }
}

internal class SubtractionProblem : Problem
{
    internal override (string problemString, int solution) NewProblem()
    {
        do
        {
            AssignRandomNumbers();
        } while (nums[0] + nums[1] > max);

        ReverseOrder();

        solution = nums[0] - nums[1];

        string problemString = ProblemString("-");
        return (problemString, solution);
    }

}

internal class MultiplicationProblem : Problem
{
    internal override (string problemString, int solution) NewProblem()
    {
        do
        {
            AssignRandomNumbers(1, 20);
        } while (nums[0] * nums[1] > max);

        RandomOrder();

        solution = nums[0] * nums[1];

        string problemString = ProblemString("*");
        return (problemString, solution);
    }

}

internal class DivisionProblem : Problem
{
    internal override (string problemString, int solution) NewProblem()
    {
        do
        {
            AssignRandomNumbers(1, 20);
        } while (nums[0] * nums[1] > max);

        RandomOrder();

        int tempDividend = nums[0] * nums[1];
        solution = nums[0];
        nums[0] = tempDividend;
    

        string problemString = ProblemString("/");
        return (problemString, solution);
    }

}