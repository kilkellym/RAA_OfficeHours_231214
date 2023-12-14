using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace RAA_OfficeHours_231214
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1(string folderPath)
        {
            InitializeComponent();

            PopulateFilesAsLinks(folderPath);
        }
        private void PopulateFilesAsLinks(string folderPath)
        {
            if (Directory.Exists(folderPath))
            {
                foreach (var file in Directory.GetFiles(folderPath))
                {
                    var hyperlink = new Hyperlink
                    {
                        NavigateUri = new Uri(file),
                        Inlines = { System.IO.Path.GetFileName(file) }
                    };
                    hyperlink.RequestNavigate += Hyperlink_RequestNavigate;

                    stackPanelLinks.Children.Add(new TextBlock { Inlines = { hyperlink } });
                }
            }
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Uri.AbsoluteUri);
            e.Handled = true;
        }
    }
}
