using DhubSolutions.Reports.Domain.Services.InstructionProcessors;
using DhubSolutions.Reports.Domain.Services.InstructionProcessors.Factories;

namespace DhubSolutions.PerformanceParticipation.Domain.Services.InstructionProcessors.Factories
{
    /// <summary>
    /// 
    /// </summary>
    public class DataInstructionProcessorFactory : InstructionProcessorFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public DataInstructionProcessorFactory() : base()
        { }

        /// <summary>
        /// 
        /// </summary>
        public override InstructionProcessorType InstructionProcessorType => InstructionProcessorType.DATA;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override IInstructionProcessor GetInstructionProcessor() => new DataInstructionProcessor();
    }
}
