namespace DiveSpots.InterfaceAdapters.Api.Core
{
    public interface IObjectPresenter<T>
    {
        T GetOutputModel();
    }
}