using DhubSolutions.Reports.Domain.Services.InstructionProcessors;
using DhubSolutions.Reports.Domain.Services.InstructionProcessors.Factories;
using Microsoft.Extensions.Configuration;

namespace DhubSolutions.PerformanceParticipation.Domain.Services.InstructionProcessors.Factories
{
    /// <summary>
    /// 
    /// </summary>
    public class MethodInstructionProcessorFactory : InstructionProcessorFactory
    {
        private readonly IConfiguration configuration;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public MethodInstructionProcessorFactory(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        public override InstructionProcessorType InstructionProcessorType => InstructionProcessorType.METHOD;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override IInstructionProcessor GetInstructionProcessor() => new MethodInstructionProcessor(configuration);
    }
}
