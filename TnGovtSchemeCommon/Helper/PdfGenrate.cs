
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Security;

namespace TnGovtSchemeCommon.Helper
{
    public class PdfGenrate
    {
        public async Task GeneratePdf()
        {
            PdfDocument document = new PdfDocument();

            PdfPage page = document.Pages.Add();

            PdfGraphics graphics = page.Graphics;

            PdfStandardFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 20f, PdfFontStyle.Bold);

            PdfSecurity security = document.Security;

            security.KeySize = PdfEncryptionKeySize.Key256BitRevision6;
            security.Algorithm = PdfEncryptionAlgorithm.AES;

            security.Permissions = PdfPermissionsFlags.Print | PdfPermissionsFlags.FullQualityPrint;

            security.OwnerPassword = "SyncOPÜ256PDF";
            security.UserPassword = "SyncUP€99PDF";

            PointF point = new PointF(10, 10);
            graphics.DrawString($"<html><body><h5>Data</h5></body></html>{}", font, PdfBrushes.Black, point);

            string filePath = "C:\\Users\\visualapp\\Music\\PasswordProtecedPDFDoc\\EncryptedDocument.pdf";

            using (System.IO.FileStream fileStream = new System.IO.FileStream(filePath, System.IO.FileMode.Create))
            {
                document.Save(fileStream);
            }

            document.Close(true);

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
