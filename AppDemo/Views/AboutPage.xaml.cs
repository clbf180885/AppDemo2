using AppDemo.ViewModels;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Xamarin.Forms;

namespace AppDemo.Views
{
    public partial class AboutPage : ContentPage
    {
        WebView webView = new WebView();
        public AboutPage()
        {
            InitializeComponent();            
            webView.Source = LoadHTMLFileFromResource();
        }
        HtmlWebViewSource LoadHTMLFileFromResource()
        {
            var source = new HtmlWebViewSource();

            // Carga el archivo HTML embebido como un recurso en el PCL
            var assembly = typeof(AboutPage).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream("AppDemo.test.html");
            using (var reader = new StreamReader(stream))
            {
                source.Html = reader.ReadToEnd();
            }
            return source;
        }
        async void OnbtnCallJSClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNumber.Text))
            {
                return;
            }
            //int number = int.Parse(txtNumber.Text);
            //webView.Eval(string.Format("printFactorial({0})", number));
            int number = int.Parse(txtNumber.Text);
            string result = await webView.EvaluateJavaScriptAsync($"printFactorial({number})");
            //var result = await this.HybridWebView.EvaluateJavascript("printFactorial(5);");
            //HybridWebView.Eval(string.Format("printFactorial({0})", number));
            //string result = await webView.EvaluateJavaScriptAsync($"printFactorial({number})");
            _resultLabel.Text = $"Factorial of {number} is {result}.";
            //await webView.EvaluateJavaScriptAsync($"test()");
            //webView.Eval(string.Format("printFactorial({0})", number));

          

            // var url = "http:\\" + urlEntry.Text;
            //Browser.Source = url;
        }
    }
}