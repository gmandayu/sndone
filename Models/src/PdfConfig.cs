namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
        // Configuration
        public static partial class Config
        {
            // Export PDF CSS stylesheet (relative to wwwroot)
            public static string PdfStylesheetFilename = "css/ewpdf.css";

            public static int PdfMaxImageWidth = 800;

            public static int PdfMaxImageHeight = 0;
        }
} // End Partial class
