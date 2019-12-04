namespace DiveSpots.SharedKernel
{
    public interface IOutputPort<in TInteractorOutput>
    {
        void Output(TInteractorOutput interactorOutput);
    }
}