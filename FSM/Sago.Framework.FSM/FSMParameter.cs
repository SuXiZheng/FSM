using System;

namespace Sago.Framework.FSM
{


    /// <summary>
    /// 状态机参数
    /// </summary>
    public class FSMParameter
    {
        public FSMParameter(string name, FSMParameterType parameterType)
        {
            this.Name = name;
            this.ParameterType = parameterType;
        }

        /// <summary>
        /// 参数名
        /// </summary>
        internal string Name { get; set; }

        /// <summary>
        /// 参数值
        /// </summary>
        internal object Value { get; set; }

        /// <summary>
        /// 参数类型
        /// </summary>
        internal FSMParameterType ParameterType { get; set; }
    }
}
