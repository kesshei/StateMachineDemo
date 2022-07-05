using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachineDemo
{
    /// <summary>
    /// 状态对象
    /// </summary>
    public interface IStateObject
    {
        /// <summary>
        /// 进入状态
        /// </summary>
        void EnterState();
        /// <summary>
        /// 离开状态
        /// </summary>
        void ExitState();
        /// <summary>
        /// 更新状态
        /// </summary>
        void UpdateState();
    }
}
