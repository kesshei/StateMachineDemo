using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StateMachineDemo
{
    /// <summary>
    /// 状态机
    /// </summary>
    public class StateMachine
    {
        /// <summary>
        /// 运行 Update 时间间隔 毫秒
        /// </summary>
        public int RunInterval = 500;
        /// <summary>
        /// 当前状态
        /// </summary>
        private string CurrentState;
        /// <summary>
        /// 字典存放当前所有对象
        /// </summary>
        private Dictionary<string, IStateObject> Dic = new();
        /// <summary>
        /// 当前的线程对象
        /// </summary>
        private Thread thread;
        /// <summary>
        /// 是否已经在运行
        /// </summary>
        private bool IsRun = false;
        public StateMachine(int runInterval = 500)
        {
            this.RunInterval = runInterval;
        }
        /// <summary>
        /// 注册一个状态对象
        /// </summary>
        /// <param name="stateObject"></param>
        /// <param name="istateObject"></param>
        public void Register(string stateObject, IStateObject istateObject)
        {
            Dic.TryAdd(stateObject, istateObject);
        }
        /// <summary>
        /// 注册一个状态对象
        /// </summary>
        /// <param name="stateObject"></param>
        /// <param name="istateObject"></param>
        public void Register(Dictionary<string, IStateObject> stateObjects)
        {
            if (stateObjects?.Any() == true)
            {
                foreach (var item in stateObjects)
                {
                    Dic.TryAdd(item.Key, item.Value);
                }
            }
        }
        /// <summary>
        /// 设置当前状态
        /// </summary>
        /// <param name="stateObject"></param>
        public void SetState(string stateObject)
        {
            if (CurrentState != stateObject)
            {
                if (CurrentState != null && Dic.TryGetValue(CurrentState, out var oldObj))
                {
                    oldObj.ExitState();
                }
                CurrentState = stateObject;
                if (CurrentState != null && Dic.TryGetValue(CurrentState, out var newObj))
                {
                    newObj.EnterState();
                }
            }
        }
        /// <summary>
        /// 自己启动服务
        /// </summary>
        public void Start()
        {
            if (!IsRun)
            {
                IsRun = true;
                thread = new Thread(new ThreadStart(Run));
                thread.IsBackground = true;
                thread.Start();
                Console.WriteLine("状态机启动");
            }
        }
        /// <summary>
        /// 自己停止服务
        /// </summary>
        public void Close()
        {
            if (IsRun)
            {
                //最后一个状态直接退出
                if (CurrentState != null && Dic.TryGetValue(CurrentState, out var oldObj))
                {
                    oldObj.ExitState();
                }
                IsRun = false;
                try
                {
                    thread.Interrupt();
                }
                catch (Exception)
                {
                }
                Thread.Sleep(50);
                thread = null;
                Console.WriteLine("状态机关闭");
            }
        }
        /// <summary>
        /// 线程执行的任务
        /// </summary>
        private void Run()
        {
            try
            {
                while (IsRun)
                {
                    Updata();
                    SpinWait.SpinUntil(() => !IsRun, RunInterval);
                }
            }
            catch (Exception) { };
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        public void Updata()
        {
            if (CurrentState != null && Dic.TryGetValue(CurrentState, out var objobj))
            {
                objobj.UpdateState();
            }
        }
    }
}
