using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Tesseract;

namespace SSReader.ConsoleApp
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            ProcessImage();
        }

        private static void ProcessImage()
        {
            Image rawImageFromClipboard = Clipboard.GetImage();
            Bitmap bitmap = new Bitmap(rawImageFromClipboard);
            Pix imageCompatibleWithTesseract = PixConverter.ToPix(bitmap);
            using var engine = new TesseractEngine(@"./tessdata", "eng+jpn");
            using var page = engine.Process(imageCompatibleWithTesseract);
            var text = page.GetText();
            Clipboard.SetText(text);

        }
    }
}
