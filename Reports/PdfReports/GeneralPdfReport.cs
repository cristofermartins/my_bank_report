using System;

using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

using Microcharts;
using SkiaSharp;

using Processors;

namespace Reports.PdfReports
{
    public class GeneralPdfReport : PdfReport
    {
        public void Generate(in List<ProcessedBankData> processedBankDataList, in string outPdfFileName)
        {
            QuestPDF.Settings.License = LicenseType.Community;

                   // prepare data
                    var entries = new[]
                    {
                        new ChartEntry(212)
                        {
                            Label = "UWP",
                            ValueLabel = "112",
                            Color = SKColor.Parse("#2c3e50")
                        },
                        new ChartEntry(248)
                        {
                            Label = "Android",
                            ValueLabel = "648",
                            Color = SKColor.Parse("#77d065")
                        },
                        new ChartEntry(128)
                        {
                            Label = "iOS",
                            ValueLabel = "428",
                            Color = SKColor.Parse("#b455b6")
                        },
                        new ChartEntry(514)
                        {
                            Label = "Forms",
                            ValueLabel = "214",
                            Color = SKColor.Parse("#3498db")
                        },
                        new ChartEntry(514)
                        {
                            Label = "Forms",
                            ValueLabel = "214",
                            Color = SKColor.Parse("#3498db")
                        }
                    };
            
            // code in your main method
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(20));
                    
                    page.Header()
                        .Text("Hello PDF!")
                        .SemiBold().FontSize(36).FontColor(Colors.Blue.Medium);
                    
                    page.Content()
                        .PaddingVertical(1, Unit.Centimetre)
                        .Column(x =>
                        {
                            x.Spacing(20);
                            
                            //x.Item().Text(Placeholders.LoremIpsum());
                            //x.Item().Image(Placeholders.Image(200, 100));

                       var titleStyle = TextStyle
                            .Default
                            .FontSize(20)
                            .SemiBold()
                            .FontColor(Colors.Blue.Medium);

                            x
                                .Item()
                                .PaddingBottom(10)
                                .Text("Chart example")
                                .Style(titleStyle);
                            
                            x
                                .Item()
                                .Border(1)
                                .ExtendHorizontal()
                                .Height(300)
                                .Canvas((canvas, size) =>
                                {
                                    var chart = new BarChart
                                    {
                                        Entries = entries,

                                        LabelOrientation = Orientation.Horizontal,
                                        ValueLabelOrientation = Orientation.Horizontal,
                                        
                                        IsAnimated = false,
                                    };
                                    
                                    chart.DrawContent(canvas, (int)size.Width, (int)size.Height);
                                });
                        });


 
                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.Span("Page ");
                            x.CurrentPageNumber();
                        });
                });
            })
            .GeneratePdf(outPdfFileName);
        }
    }
}