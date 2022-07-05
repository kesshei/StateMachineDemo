using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachineDemo
{
/// <summary>
/// 一只狗
/// </summary>
public class Dog : IStateObject 
{
    public void EnterState()
    {
        Console.WriteLine("小狗进来了");
    }

    public void ExitState()
    {
        Console.WriteLine("小狗出去了");
    }

    public void UpdateState()
    {
        Console.WriteLine("小狗在玩耍!");
    }
}
}
