using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Markdown;

namespace md2pdf
{
    // TODO: Consider adding command line options for page customization
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Usage: md2pdf <filename>");
                return;
            }

            var filePath = args[0];

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Error: File '{filePath}' does not exist.");
                return;
            }

            try
            {
                QuestPDF.Settings.License = LicenseType.Community;

                var markdownContent = File.ReadAllText(filePath);
                var outputFilePath = Path.ChangeExtension(filePath, ".pdf");

                GeneratePdf(markdownContent, outputFilePath);

                Console.WriteLine($"PDF generated successfully: {outputFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private static void GeneratePdf(string markdownContent, string outputFilePath)
        {
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(0.5f, Unit.Centimetre);

                    // Example of adding a header
                    //
                    // page.Header()
                    //    .Text("Technical Documentation")
                    //    .FontSize(16)
                    //    .Bold()
                    //    .AlignCenter();

                    page.Content()
                        .PaddingVertical(0.5f, Unit.Centimetre)
                        .DefaultTextStyle(text =>
                        {
                            text.FontSize(12);
                            text.FontFamily("Arial", "Helvetica", "Times New Roman");
                            text.LineHeight(1.5f);

                            return text;
                        })
                        .Scale(0.9f)
                        .Markdown(markdownContent);

                    page.Footer()
                        .AlignCenter()
                        .Text(text =>
                        {
                            text.Span("Page ");
                            text.CurrentPageNumber();
                            text.Span(" of ");
                            text.TotalPages();
                        });
                });
            }).GeneratePdf(outputFilePath);
        }
    }
}