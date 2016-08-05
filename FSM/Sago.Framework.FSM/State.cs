using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sago.Framework.FSM
{
    /// <summary>
    /// 状态
    /// </summary>
    public class State
    {
        public State(string stateName, Action<object> function)
        {
            this.Name = stateName;
            this.FunctionWhenActived = function;
        }

        /// <summary>
        /// 状态名称
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 当状态被激活时执行的代码
        /// </summary>
        internal Action<object> FunctionWhenActived { get; private set; }

        /// <summary>
        /// 当状态被激活时执行的方法
        /// </summary>
        internal void Update()
        {
            if (this.FunctionWhenActived != default(Action<object>))
            {
                this.FunctionWhenActived(null);
            }
        }
    }
}
