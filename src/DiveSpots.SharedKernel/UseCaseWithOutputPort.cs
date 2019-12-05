using MediatR;

namespace DiveSpots.SharedKernel
{
    public class UseCaseWithOutputPort<TInteractorOutput> : IRequest<UseCaseResult>
    {
        protected UseCaseWithOutputPort(IOutputPort<TInteractorOutput> outputPort)
        {
            this.OutputPort = outputPort;
        }
        
        public IOutputPort<TInteractorOutput> OutputPort { get; }
    }
}