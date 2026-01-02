using FileFormatConverter.Services;
using System.Windows;

namespace FileFormatConverter
{
    public partial class MainWindow : Window
    {
        private string _filePath;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                _filePath = files[0];
                MessageBox.Show($"Файл загружен:\n{_filePath}");
            }
        }

        private void Convert_Click(object sender, RoutedEventArgs e)
        {
            if (_filePath == null)
            {
                MessageBox.Show("Перетащи файл!");
                return;
            }

            var selected = (FormatBox.SelectedItem as System.Windows.Controls.ComboBoxItem)?.Content.ToString();

            if (selected == "TXT → PDF")
                PdfService.TxtToPdf(_filePath);

            if (selected == "PNG → JPG")
                ImageService.PngToJpg(_filePath);

            MessageBox.Show("Готово!");
        }
    }
}
