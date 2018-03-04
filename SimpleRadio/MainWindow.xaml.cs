
using SimpleRadio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows;

namespace SimpleRadio
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainContext _context;
        public MainWindow()
        {
            InitializeComponent();
            this._context = new MainContext();
            this.DataContext = this._context;
            this.Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this._context.Dispose();
            this._context = null;
        }
    }
}
