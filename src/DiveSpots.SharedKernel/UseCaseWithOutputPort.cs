using MediatR;

namespace DiveSpots.SharedKernel
{
    public class UseCaseWithOutputPort<TInteractorOutput> : IRequest<UseCaseResult>
    {
        private readonly IOutputPort<TInteractorOutput> outputPort;

        public UseCaseWithOutputPort(IOutputPort<TInteractorOutput> outputPort)
        {
            this.outputPort = outputPort;
        }
        
        public void Output(TInteractorOutput interactorOutput)
        {
            outputPort.Output(interactorOutput);
        }
    }
}