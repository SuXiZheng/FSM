using System;

namespace Sago.Framework.FSM
{
    /// <summary>
    /// 校验类
    /// </summary>
    internal static class Validator
    {
        internal static bool CheckType(object value, FSMParameterType parameterType)
        {
            switch (parameterType)
            {
                case FSMParameterType.Int32:
                    return value is Int32;
                case FSMParameterType.Double:
                    return value is double || value is int;
                case FSMParameterType.Float:
                    return value is float || value is int;
                case FSMParameterType.Decimal:
                    return value is decimal || value is int;
                case FSMParameterType.String:
                    return value is string;
                default:
                    return true;
            }
        }
    }
}
