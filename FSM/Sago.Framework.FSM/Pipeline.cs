using System.Collections.Generic;

namespace Sago.Framework.FSM
{
    /// <summary>
    /// 状态变换管线
    /// </summary>
    public class Pipeline
    {
        /// <summary>
        /// 条件，多个条件之间是并且的关系
        /// </summary>
        private List<Condition> conditions = new List<Condition>();

        /// <summary>
        /// 条件条件
        /// </summary>
        /// <param name="conditionType"></param>
        /// <param name="parameterName"></param>
        public void AddCondition(ConditionType conditionType, string parameterName, object destinationValue)
        {
            this.conditions.Add(new Condition(conditionType, parameterName, destinationValue));
        }

        public void RemoveCondition(Condition condition)
        {
            if (this.conditions.Contains(condition))
                this.conditions.Remove(condition);
        }

        /// <summary>
        /// 执行算术运算
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        internal bool Execute(IDictionary<string, FSMParameter> parameters)
        {
            //所有条件必须都为真
            foreach (var condition in this.conditions)
            {
                if (condition.Execute(parameters) == false)
                    return false;
            }

            return true;
        }
    }
}
