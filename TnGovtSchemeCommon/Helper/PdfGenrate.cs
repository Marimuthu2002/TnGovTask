
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Security;
using System.Reflection.Metadata;
using TnGovtSchemeCommon.Model;

namespace TnGovtSchemeCommon.Helper
{
    public class PdfGenrate
    {
       

        public byte[] GeneratePdf(RegisterModel data)
        {
            PdfDocument document = new PdfDocument();

            PdfPage page = document.Pages.Add();

            PdfGraphics graphics = page.Graphics;

            PdfStandardFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 30f, PdfFontStyle.Bold);

            PdfSecurity security = document.Security;

            security.KeySize = PdfEncryptionKeySize.Key256BitRevision6;
            security.Algorithm = PdfEncryptionAlgorithm.AES;

            security.Permissions = PdfPermissionsFlags.Print | PdfPermissionsFlags.FullQualityPrint;

            security.OwnerPassword = data.DateOfBirth.ToString("yyyy");
            security.UserPassword = "SyncUP€99PDF";


            PointF point = new PointF(10, 10);
            graphics.DrawString($"UserName: {data.UserName}\nPassWord: {data.PassWord}", font, PdfBrushes.Black, point);

            // Create a memory stream to hold the PDF content
            using (MemoryStream memoryStream = new MemoryStream())
            {
                document.Save(memoryStream);
                memoryStream.Position = 0;

                // Get the byte array from the memory stream
                byte[] pdfBytes = memoryStream.ToArray();

                document.Close(true);

                return pdfBytes;
            }
        }

    }
    public static class StringExtensions
    {
        public static byte[] GetBytes(this string str)
        {
            return System.Text.Encoding.UTF8.GetBytes(str);
        }
    }

}
