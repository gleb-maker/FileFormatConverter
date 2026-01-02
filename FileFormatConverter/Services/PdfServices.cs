using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.IO;
using System.Reflection.Metadata;
using System.Windows.Documents;

namespace FileFormatConverter.Services
{
    public static class PdfService
    {
        public static void TxtToPdf(string path)
        {
            string text = File.ReadAllText(path);
            string output = Path.ChangeExtension(path, ".pdf");

            using (var writer = new iText.Kernel.Pdf.PdfWriter(output))
            using (var pdf = new iText.Kernel.Pdf.PdfDocument(writer))
            using (var document = new iText.Layout.Document(pdf))
            {
                document.Add(new iText.Layout.Element.Paragraph(text));
            }
        }

    }
}
