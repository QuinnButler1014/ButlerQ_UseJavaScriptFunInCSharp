using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;


namespace ButlerQ_UseJavaScriptFunInCSharp
{
    [ComVisible(true)]
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);
            this.webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);
            //Used for calling C# code in JS
            webBrowser1.ObjectForScripting = this;
            webBrowser1.ScriptErrorsSuppressed = false;
            //Usef  for disabling rightclick on web browser control
            webBrowser1.IsWebBrowserContextMenuEnabled = false;
            webBrowser1.AllowWebBrowserDrop = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Get current directory of app
            string CurrentDirectory = Directory.GetCurrentDirectory();
            //Call HTML page using navigate methodto fire web browser document completed event
            webBrowser1.Navigate(Path.Combine(CurrentDirectory, "HTMLPageForJavaScript.html"));
        }

        private void Report()
        {
            //Get HTML page div from id of Div
            HtmlElement div = webBrowser1.Document.GetElementById("reportContent");
            //Create simple html content
            StringBuilder sb = new StringBuilder();
            sb.Append("<table>");
            sb.Append("<tr><td><B> Hi this is my report demo</B></td></tr>");
            sb.Append("</table>");
            //Assign content to HTML page div to display browser control
            div.InnerHtml = sb.ToString();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //Focus cursor when loaded
            webBrowser1.Focus();
            //Call report method
            Report();
        }
        public void PrintReport()
        {
            //Show pring dialog and call print method
            DialogResult dr = printDialog1.ShowDialog();
            if (dr.ToString() == "OK")
            {
                webBrowser1.Print();
            }
            else
            {
                return;
            }
        }
    }
}
