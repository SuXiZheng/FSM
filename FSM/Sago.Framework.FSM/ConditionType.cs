namespace Sago.Framework.FSM
{
    /// <summary>
    /// 条件算数运算符
    /// </summary>
    public enum ConditionType
    {
        /// <summary>
        /// 等于
        /// </summary>
        Equals = 0,

        /// <summary>
        /// 不等于
        /// </summary>
        NotEquals = 1,

        /// <summary>
        /// 大于
        /// </summary>
        Greater = 2,

        /// <summary>
        /// 小于
        /// </summary>
        Less = 3,

        /// <summary>
        /// 大于等于
        /// </summary>
        GreaterEquals = 4,

        /// <summary>
        /// 小于等于
        /// </summary>
        LessEquals = 5,

        /// <summary>
        /// 包含，用于String
        /// </summary>
        Contains = 6
    }
}
