using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sago.Framework.FSM
{
    /// <summary>
    /// 状态转换类
    /// </summary>
    public class Transition
    {
        public Transition(State fromState, State toState)
        {
            this.fromState = fromState;
            this.toState = toState;
        }

        /// <summary>
        /// 原始状态
        /// </summary>
        internal State fromState;

        /// <summary>
        /// 目的状态
        /// </summary>
        internal State toState;

        /// <summary>
        /// 执行算数运算
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        internal bool Execute(IDictionary<string, FSMParameter> parameters)
        {
            //任一条件为真
            foreach (var pipeline in this.pipelines)
            {
                if (pipeline.Execute(parameters))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// 状态切换管线，多个pipeline之前是或者的关系
        /// </summary>
        private List<Pipeline> pipelines = new List<Pipeline>();

        public void AddPipeline(params Pipeline[] pipelines)
        {
            this.pipelines.AddRange(pipelines);
        }

        public void RemovePipeline(Pipeline pipeline)
        {
            if (this.pipelines.Contains(pipeline))
                this.pipelines.Remove(pipeline);
        }
    }
}
