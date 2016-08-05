using System;
using System.Collections.Generic;

namespace Sago.Framework.FSM
{
    /// <summary>
    /// 状态机
    /// </summary>
    public class FSM
    {
        public FSM(State defaultState)
        {
            this.CurrentState = defaultState;
        }

        /// <summary>
        /// 状态集合
        /// </summary>
        private Dictionary<string, State> states = new Dictionary<string, State>();

        /// <summary>
        /// 状态切换集合
        /// </summary>
        private List<Transition> transitions = new List<Transition>();

        private Dictionary<string, FSMParameter> parameters = new Dictionary<string, FSMParameter>();

        /// <summary>
        /// 当前状态
        /// </summary>
        public State CurrentState { get; private set; }

        /// <summary>
        /// 状态发生改变事件
        /// </summary>
        public EventHandler<OnStateChangedEventArgs> OnStateChanged;

        #region 状态机参数

        /// <summary>
        /// 添加状态机参数
        /// </summary>
        /// <param name="parameter"></param>
        public void AddParameter(FSMParameter parameter)
        {
            if (this.parameters.ContainsKey(parameter.Name))
                this.parameters.Remove(parameter.Name);

            this.parameters.Add(parameter.Name, parameter);
        }

        /// <summary>
        /// 获取状态机参数
        /// </summary>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        public FSMParameter GetFSMParameter(string parameterName)
        {
            FSMParameter parameter;
            this.parameters.TryGetValue(parameterName, out parameter);

            return parameter;
        }

        /// <summary>
        /// 设置状态机参数值
        /// </summary>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        public bool SetParameterValue(string parameterName, object value)
        {
            var parameter = this.GetFSMParameter(parameterName);

            if (parameter != default(FSMParameter))
            {
                parameter.Value = value;
                //遍历Transition，检查是否需要被触发
                this.ChangeState();
                return true;
            }
            return false;
        }

        #endregion

        #region 状态机状态切换

        /// <summary>
        /// 添加状态转换
        /// </summary>
        /// <param name="transition"></param>
        public void AddTransition(Transition transition)
        {
            if (this.transitions.Contains(transition))
                this.transitions.Remove(transition);

            this.transitions.Add(transition);
        }

        /// <summary>
        /// 切换状态
        /// </summary>
        public void ChangeState()
        {
            foreach (var transition in this.transitions)
            {
                if (transition.Execute(this.parameters))
                {
                    if (this.OnStateChanged != default(EventHandler<OnStateChangedEventArgs>))
                        this.OnStateChanged(this, new OnStateChangedEventArgs(this.CurrentState, transition.toState));
                    this.CurrentState = transition.toState;
                    break;
                }
            }

            this.CurrentState.Update();
        }

        #endregion
    }
}