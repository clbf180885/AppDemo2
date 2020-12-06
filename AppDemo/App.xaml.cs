using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppDemo.Services;
using AppDemo.Views;
using AppDemo.ViewModels;
using System.Reflection;
using System.IO;

namespace AppDemo
{
    public partial class App : Application
    {
        public static HybridWebView HybridWebView = new HybridWebView();
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            HybridWebView.Source = LoadHTMLFileFromResource();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        HtmlWebViewSource LoadHTMLFileFromResource()
        {
            var source = new HtmlWebViewSource();

            // Carga el archivo HTML embebido como un recurso en el PCL
            var assembly = typeof(App).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream("AppDemo.test.html");
            using (var reader = new StreamReader(stream))
            {
                source.Html = reader.ReadToEnd();
            }
            return source;
        }
    }
}
