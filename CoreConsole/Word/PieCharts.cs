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
}
