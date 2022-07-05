using System;
using System.Threading;

namespace StateMachineDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "C# 状态机 by 蓝创精英团队";
            StateMachine stateMachine = new StateMachine(1500);
            //状态机
            //根据当前的不同的状态，做出不同的事件操作
            stateMachine.Register(nameof(Cat), new Cat());
            stateMachine.Register(nameof(Dog), new Dog());
            //启动状态机
            stateMachine.Start();
            //开始执行状态机
            //设置当前状态
            stateMachine.SetState(nameof(Cat));
            Thread.Sleep(2000);
            stateMachine.SetState(nameof(Dog));
            Thread.Sleep(2000);
            stateMachine.SetState(nameof(Cat));
            Thread.Sleep(2000);
            //状态机停止
            stateMachine.Close();
            Console.WriteLine("状态机执行完毕!");
            Console.ReadLine();
        }
    }
}
