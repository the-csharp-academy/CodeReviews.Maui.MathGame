using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame.UserInterface;

internal readonly struct Selection<TEnum> where TEnum : struct, Enum
{
    public readonly TEnum SelectionEnum { get; }
    public string DisplayString { get;  }
    internal Selection(TEnum value, string displayString)
    {
        SelectionEnum = value;
        DisplayString = displayString;
    }
    public override string ToString()
    {
        return DisplayString;
    }
}
