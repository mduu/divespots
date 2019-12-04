namespace DiveSpots.InterfaceAdapters.Api.Core
{
    public class ObjectPresenter<T> : IObjectPresenter<T>
    {
        private T outputObject;
        
        public T GetOutputModel() => outputObject;

        protected void SetOutputObject(T obj)
        {
            outputObject = obj;
        }
    }
}