using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachineDemo
{
/// <summary>
/// 一只猫
/// </summary>
public class Cat : IStateObject 
{
    public void EnterState()
    {
        Console.WriteLine("小猫进来了");
    }

    public void ExitState()
    {
        Console.WriteLine("小猫出去了");
    }

    public void UpdateState()
    {
        Console.WriteLine("小猫在玩逗猫棒!");
    }
}
}
