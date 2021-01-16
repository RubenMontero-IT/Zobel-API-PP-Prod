using DhubSolutions.Reports.Domain.Services.Components;
using System.Threading.Tasks;

namespace DhubSolutions.Reports.Domain.Services.InstructionProcessors
{
    public interface IInstructionProcessor
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameters"></param>
        void AddParameters(params (string name, dynamic value)[] parameters);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameters"></param>
        void AddLocalParameters(params (string name, dynamic @object)[] parameters);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reportDataSegment"></param>
        /// <returns></returns>
        Task<object> ReadDataSegment(ReportDataSegment reportDataSegment);




    }
}
