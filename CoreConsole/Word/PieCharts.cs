using Aspose.Words.Drawing.Charts;
using Aspose.Words.Drawing;
using Aspose.Words;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CoreConsole.Word
{
    public class PieCharts
    {
        public static void Run()
        {
            execute();
        }

        private static void execute()
        {
            chartAdd();
        }

        private static void chartAdd()
        {
            Document doc = new Document();
            DocumentBuilder builder = new DocumentBuilder(doc);

            // Define chart dimensions and location in the document.
            double chartWidth = 250;  // Width of the chart.
            double chartHeight = 180; // Height of the chart.
            double posX = 100;        // X position of the chart.
            double posY = 100;        // Y position of the chart.

            // Insert the chart into the document at a specific position.
            Shape shape = builder.InsertChart(ChartType.Pie, chartWidth, chartHeight);

            // Set position of the chart in the document.
            shape.Left = posX;
            shape.Top = posY;


            // Accessing the chart to populate data.
            Chart chart = shape.Chart;

            // Clear the default chart data.
            chart.Series.Clear();

            // Add data for the pie chart.
            string[] categories = { "1 Data Point with long text here", "2 Data Point", "3 Data Point" };
            double[] values = { 30.0, 50.0, 20.0 };
            chart.Series.Add("Headers for the Chart", categories, values);
            //ChartTitle title = chart.Title;
            //Run titleRun = chart.Title.Paragraphs[0].Runs[0];
            //titleRun.Font.Size = 16;   // Set the font size to 16 points.
            //titleRun.Font.Bold = true; // Make the font bold.
            //titleRun.Font.Color = System.Drawing.Color.Blue; // Set the font color to blue.

            //chart.Legend.Position = LegendPosition.Bottom;
            //chart.Legend.Overlay = false;

            // Add a textbox as the chart title above the chart.
            Shape textBox = new Shape(doc, ShapeType.TextBox);
            textBox.Width = 300;  // Set width to match chart
            textBox.Height = 30;  // Height for the title box
            textBox.Left = shape.Left;  // Align it horizontally with the chart
            textBox.Top = shape.Top - 40;  // Position it above the chart

            // Access the text frame and insert title text.
            textBox.AppendChild(new Paragraph(doc));
            Paragraph para = textBox.FirstParagraph;
            Run run = new Run(doc, "My Custom Pie Chart Title");

            // Set font and styling for the chart title.
            run.Font.Size = 16;  // Font size 16 points
            run.Font.Bold = true;  // Make it bold
            run.Font.Color = Color.Blue;  // Set font color to blue
            para.AppendChild(run);

            // Add the textbox to the document.
            builder.InsertNode(textBox);


            // Save the document.
            doc.Save(@"C:\Users\vinay\Documents\files\PieChart4.docx");

            Console.WriteLine("Pie chart created successfully.");
        }
    }

    ///////////////////Start
    ///
    public enum CustomChartType
    {
        Pie,
        Column,
        Line,
        Bar,
        Area,
        Scatter
    }

    public class DataOptions
    {
        public string[] Categories { get; set; } = { "Category 1", "Category 2", "Category 3" };
        public double[] Values { get; set; } = { 30.0, 50.0, 20.0 };
    }

    public class ChartOptions
    {
        // Title Attributes
        public string TitleText { get; set; } = "Default Chart Title";
        public double TitleFontSize { get; set; } = 16;
        public bool TitleBold { get; set; } = true;
        public Color TitleFontColor { get; set; } = Color.Black;
        public bool TitleVisible { get; set; } = true;
        public ParagraphAlignment TitleAlignment { get; set; } = ParagraphAlignment.Center;

        // Chart Attributes
        public double ChartWidth { get; set; } = 300;
        public double ChartHeight { get; set; } = 200;
        public CustomChartType Type { get; set; } = CustomChartType.Pie;
        public BorderType BorderType { get; set; } = BorderType.Single;
        public Color BorderColor { get; set; } = Color.Black;
        public double BorderThickness { get; set; } = 1.0;

        // Legend Attributes
        public LegendPosition LegendPosition { get; set; } = LegendPosition.Bottom;
        public double LegendFontSize { get; set; } = 12;
        public bool LegendBold { get; set; } = false;
        public Color LegendFontColor { get; set; } = Color.Gray;

        // Data Options
        public DataOptions DataOptions { get; set; } = new DataOptions();

        // Method to convert custom chart type to Aspose chart type
        private ChartType GetAsposeChartType()
        {
            return Type switch
            {
                CustomChartType.Pie => ChartType.Pie,
                CustomChartType.Column => ChartType.Column,
                CustomChartType.Line => ChartType.Line,
                CustomChartType.Bar => ChartType.Bar,
                CustomChartType.Area => ChartType.Area,
                CustomChartType.Scatter => ChartType.Scatter,
                _ => throw new ArgumentOutOfRangeException(),
            };
        }

        // Method to apply the chart options to the actual chart
        public void ApplyToChart(Chart chart, Shape shape)
        {
            // Set the chart type
            chart.ChartType = GetAsposeChartType();

            // Set the chart dimensions
            shape.Width = this.ChartWidth;
            shape.Height = this.ChartHeight;

            // Set the chart border
            shape.StrokeColor = this.BorderColor;
            shape.StrokeWeight = this.BorderThickness;

            // Set the chart title and its properties
            chart.Title.Text = this.TitleText;
            chart.Title.Show = this.TitleVisible;

            // Add data to the chart
            chart.Series.Clear(); // Clear any default data
            chart.Series.Add("Series1", DataOptions.Categories, DataOptions.Values);

            // Set the legend properties
            chart.Legend.Position = this.LegendPosition;
            chart.Legend.Overlay = false; // Ensure it does not overlap the chart
                                          // Styling legend can be limited based on API availability
        }
    }

    // Usage Example
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize Aspose document and builder
            Document doc = new Document();
            DocumentBuilder builder = new DocumentBuilder(doc);

            // Create chart with a specific width and height
            Shape shape = builder.InsertChart(ChartType.Pie, 300, 200);

            // Access the chart
            Chart chart = shape.Chart;

            // Instantiate ChartOptions and set properties
            ChartOptions options = new ChartOptions
            {
                TitleText = "Sales Performance",
                TitleFontSize = 18,
                TitleBold = true,
                TitleFontColor = Color.DarkBlue,
                ChartWidth = 400,
                ChartHeight = 250,
                Type = CustomChartType.Column,
                DataOptions = new DataOptions
                {
                    Categories = new string[] { "Q1", "Q2", "Q3", "Q4" },
                    Values = new double[] { 45.0, 30.0, 20.0, 50.0 }
                },
                LegendPosition = LegendPosition.Bottom,
                LegendFontSize = 14,
                LegendFontColor = Color.DarkGreen,
                BorderColor = Color.DarkGray,
                BorderThickness = 2.0
            };

            // Apply the options to the chart
            options.ApplyToChart(chart, shape);

            // Save the document
            doc.Save("ChartWithCustomOptions.docx");
        }
    }
}
