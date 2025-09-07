using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace MathGame.UserInterface;

internal abstract class UserInterface
{
    internal abstract Enums.InterfaceName DisplayAndTakeInput();
}
