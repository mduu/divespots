using System;
using System.Globalization;
using System.Reflection;
using DiveSpots.DependencyManagment;
using SimpleInjector;
using Xamarin.Forms;

namespace DiveSpots.ViewModels.Base
{
    public static class ViewModelLocator
    {
        private static readonly Container Container;

        static ViewModelLocator()
        {
            Container = new Container();
            IoCRegistrations.RegisterDependencies(Container);
        }

        public static readonly BindableProperty AutoWireViewModelProperty =
            BindableProperty.CreateAttached(
                "AutoWireViewModel",
                typeof(bool),
                typeof(ViewModelLocator),
                default(bool),
                propertyChanged: OnAutoWireViewModelChanged);
        
        public static bool GetAutoWireViewModel(BindableObject bindable)
            => (bool)bindable.GetValue(AutoWireViewModelProperty);

        public static void SetAutoWireViewModel(BindableObject bindable, bool value)
            => bindable.SetValue(AutoWireViewModelProperty, value);

        public static void RegisterSingleton<TInterface, T>() where TInterface : class where T : class, TInterface
            => Container.RegisterSingleton<TInterface, T>();

        public static T Resolve<T>() where T : class
            => Container.GetInstance<T>();

        private static void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as Element;
            
            var viewType = view?.GetType();
            if (viewType?.FullName == null)
            {
                return;
            }
            
            var viewName = viewType.FullName.Replace(".Views.", ".ViewModels.");
            var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
            var viewModelName = string.Format(CultureInfo.InvariantCulture, "{0}ViewModel, {1}", viewName, viewAssemblyName);

            var viewModelType = Type.GetType(viewModelName);
            if (viewModelType == null)
            {
                return;
            }
            
            var viewModel = Container.GetInstance(viewModelType);
            view.BindingContext = viewModel;
        }
    }
}