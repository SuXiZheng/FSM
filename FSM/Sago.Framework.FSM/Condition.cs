using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Sago.Framework.FSM
{
    /// <summary>
    /// 状态变换条件
    /// </summary>
    public class Condition
    {
        public Condition(ConditionType conditionType, string parameterName, object destinationValue)
        {
            this.ConditionType = conditionType;
            this.ParameterName = parameterName;
            this.DestinationValue = destinationValue;
        }

        /// <summary>
        /// 条件所使算术运算符
        /// </summary>
        private ConditionType ConditionType { get; set; }

        /// <summary>
        /// 条件所使参数名
        /// </summary>
        private string ParameterName { get; set; }

        /// <summary>
        /// 目标条件值
        /// </summary>
        private object DestinationValue { get; set; }

        /// <summary>
        /// 执行算术运算
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        internal bool Execute(IDictionary<string, FSMParameter> parameters)
        {
            if (parameters.ContainsKey(this.ParameterName) == false)
            {
                Debug.WriteLine("Can't find parameter：{0}", this.ParameterName);
                return false;
            }

            FSMParameter parameter;
            if (parameters.TryGetValue(this.ParameterName, out parameter) == false
                || Validator.CheckType(this.DestinationValue, parameter.ParameterType) == false)
                return false;

            switch (parameter.ParameterType)
            {
                case FSMParameterType.Int32:
                    Int32 currentInt = 0, destinationValueInt = 0;
                    int.TryParse(parameter.Value.ToString(), out currentInt);
                    int.TryParse(this.DestinationValue.ToString(), out destinationValueInt);

                    return this.DoExecute(currentInt, destinationValueInt);

                case FSMParameterType.Double:
                    double currentDouble = 0.0, destinationValueDouble = 0;
                    double.TryParse(parameter.Value.ToString(), out currentDouble);
                    double.TryParse(this.DestinationValue.ToString(), out destinationValueDouble);

                    return this.DoExecute(currentDouble, destinationValueDouble);

                case FSMParameterType.Float:
                    float currentFloat = 0, destinationValueFloat = 0;
                    float.TryParse(parameter.Value.ToString(), out currentFloat);
                    float.TryParse(this.DestinationValue.ToString(), out destinationValueFloat);

                    return this.DoExecute(currentFloat, destinationValueFloat);

                case FSMParameterType.Decimal:
                    decimal currentDecimal = 0, destinationValueDecimal = 0;
                    decimal.TryParse(parameter.Value.ToString(), out currentDecimal);
                    decimal.TryParse(this.DestinationValue.ToString(), out destinationValueDecimal);

                    return this.DoExecute(currentDecimal, destinationValueDecimal);

                case FSMParameterType.String:
                    string currentString = parameter.Value.ToString(), destinationValueString = this.DestinationValue.ToString();
                    return this.DoExecute(currentString, destinationValueString);

                case FSMParameterType.Bool:
                    bool currentBool = false, destinationValueBool = false;
                    bool.TryParse(parameter.Value.ToString(), out currentBool);
                    bool.TryParse(this.DestinationValue.ToString(), out destinationValueBool);

                    return this.DoExecute(currentBool, destinationValueBool);

                default:
                    break;
            }
            return true;
        }

        /// <summary>
        /// 执行参数当前值是否与目标值的算数运算
        /// </summary>
        /// <param name="currentValue"></param>
        /// <param name="destinationValue"></param>
        /// <returns></returns>
        private bool DoExecute(int currentValue, int destinationValue)
        {
            var flag = false;
            switch (this.ConditionType)
            {
                case ConditionType.Equals:
                    flag = currentValue == destinationValue;
                    break;
                case ConditionType.NotEquals:
                    flag = currentValue != destinationValue;
                    break;
                case ConditionType.Greater:
                    flag = currentValue > destinationValue;
                    break;
                case ConditionType.Less:
                    flag = currentValue < destinationValue;
                    break;
                case ConditionType.GreaterEquals:
                    flag = currentValue >= destinationValue;
                    break;
                case ConditionType.LessEquals:
                    flag = currentValue <= destinationValue;
                    break;
                default:
                    break;
            }

            return flag;
        }

        /// <summary>
        /// 执行参数当前值是否与目标值的算数运算
        /// </summary>
        /// <param name="currentValue"></param>
        /// <param name="destinationValue"></param>
        /// <returns></returns>
        private bool DoExecute(double currentValue, double destinationValue)
        {
            var flag = false;
            switch (this.ConditionType)
            {
                case ConditionType.Equals:
                    flag = currentValue == destinationValue;
                    break;
                case ConditionType.NotEquals:
                    flag = currentValue != destinationValue;
                    break;
                case ConditionType.Greater:
                    flag = currentValue > destinationValue;
                    break;
                case ConditionType.Less:
                    flag = currentValue < destinationValue;
                    break;
                case ConditionType.GreaterEquals:
                    flag = currentValue >= destinationValue;
                    break;
                case ConditionType.LessEquals:
                    flag = currentValue <= destinationValue;
                    break;
                default:
                    break;
            }

            return flag;
        }

        /// <summary>
        /// 执行参数当前值是否与目标值的算数运算
        /// </summary>
        /// <param name="currentValue"></param>
        /// <param name="destinationValue"></param>
        /// <returns></returns>
        private bool DoExecute(float currentValue, float destinationValue)
        {
            var flag = false;
            switch (this.ConditionType)
            {
                case ConditionType.Equals:
                    flag = currentValue == destinationValue;
                    break;
                case ConditionType.NotEquals:
                    flag = currentValue != destinationValue;
                    break;
                case ConditionType.Greater:
                    flag = currentValue > destinationValue;
                    break;
                case ConditionType.Less:
                    flag = currentValue < destinationValue;
                    break;
                case ConditionType.GreaterEquals:
                    flag = currentValue >= destinationValue;
                    break;
                case ConditionType.LessEquals:
                    flag = currentValue <= destinationValue;
                    break;
                default:
                    break;
            }

            return flag;
        }

        /// <summary>
        /// 执行参数当前值是否与目标值的算数运算
        /// </summary>
        /// <param name="currentValue"></param>
        /// <param name="destinationValue"></param>
        /// <returns></returns>
        private bool DoExecute(decimal currentValue, decimal destinationValue)
        {
            var flag = false;
            switch (this.ConditionType)
            {
                case ConditionType.Equals:
                    flag = currentValue == destinationValue;
                    break;
                case ConditionType.NotEquals:
                    flag = currentValue != destinationValue;
                    break;
                case ConditionType.Greater:
                    flag = currentValue > destinationValue;
                    break;
                case ConditionType.Less:
                    flag = currentValue < destinationValue;
                    break;
                case ConditionType.GreaterEquals:
                    flag = currentValue >= destinationValue;
                    break;
                case ConditionType.LessEquals:
                    flag = currentValue <= destinationValue;
                    break;
                default:
                    break;
            }

            return flag;
        }

        /// <summary>
        /// 执行参数当前值是否与目标值的算数运算
        /// </summary>
        /// <param name="currentValue"></param>
        /// <param name="destinationValue"></param>
        /// <returns></returns>
        private bool DoExecute(bool currentValue, bool destinationValue)
        {
            var flag = false;
            switch (this.ConditionType)
            {
                case ConditionType.Equals:
                    flag = currentValue == destinationValue;
                    break;
                case ConditionType.NotEquals:
                    flag = currentValue != destinationValue;
                    break;
                default:
                    break;
            }

            return flag;
        }

        /// <summary>
        /// 执行参数当前值是否与目标值的算数运算
        /// </summary>
        /// <param name="currentValue"></param>
        /// <param name="destinationValue"></param>
        /// <returns></returns>
        private bool DoExecute(string currentValue, string destinationValue)
        {
            var flag = false;
            switch (this.ConditionType)
            {
                case ConditionType.Contains:
                    flag = destinationValue.Contains(currentValue);
                    break;
                default:
                    break;
            }

            return flag;
        }
    }
}