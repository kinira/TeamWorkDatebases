namespace PDFReporter
{
    using sharpPDF;
    using sharpPDF.Enumerators;

    // not finished
    public sealed class PDFCreator
    {
        private const string PDFName = "Report.pdf";

        public PDFCreator(string title, string author, string firstPageText)
        {
            this.title = title;
            this.author = author;
            this.firstPageText = firstPageText;
            //PrintPDF();
        }

        public void PrintPDF()
        {
            pdfDocument myDoc = new pdfDocument(this.title, this.author, false);
            pdfPage myFirstPage = myDoc.addPage();
            myFirstPage.addText(this.firstPageText, 100, 660, predefinedFont.csHelveticaOblique, 30, new pdfColor(predefinedColor.csCyan));

            /*Table's creation*/
            pdfTable myTable = new pdfTable();

            //Set table's border
            myTable.borderSize = 1;
            myTable.borderColor = new pdfColor(predefinedColor.csDarkBlue);

            CreateHeaderRow(myTable);

            /*Create table's rows*/
            pdfTableRow myRow = myTable.createRow();
            myRow[0].columnValue = "1";
            myRow[1].columnValue = "Andrew Red";
            myRow[2].columnValue = "898-0210989";
            myRow[3].columnValue = "Andrew.red@sharppdf.net";
            myTable.addRow(myRow);

            myRow = myTable.createRow();
            myRow[0].columnValue = "2";
            myRow[1].columnValue = "Andrew Green";
            myRow[2].columnValue = "298-55109";
            myRow[3].columnValue = "Andrew.green@sharppdf.net";
            myTable.addRow(myRow);

            myRow = myTable.createRow();
            myRow[0].columnValue = "3";
            myRow[1].columnValue = "Andrew White";
            myRow[2].columnValue = "24-5510943";
            myRow[3].columnValue = "Andrew.white@sharppdf.net";

            /*Set Header's Style*/
            myTable.tableHeaderStyle = new pdfTableRowStyle(predefinedFont.csCourierBoldOblique, 12, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csLightCyan));

            /*Set Row's Style*/
            myTable.rowStyle = new pdfTableRowStyle(predefinedFont.csCourier, 8, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite));

            /*Set Alternate Row's Style*/
            myTable.alternateRowStyle = new pdfTableRowStyle(predefinedFont.csCourier, 8, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csLightYellow));

            /*Set Cellpadding*/
            myTable.cellpadding = 20;

            /*Put the table on the page object*/
            myFirstPage.addTable(myTable, 100, 600);
            myTable = null;
            myDoc.createPDF(PDFName);

        }

        public static void CreateHeaderRow(pdfTable myTable)
        {
            myTable.tableHeader.addColumn(new pdfTableColumn("id", predefinedAlignment.csLeft, 50));
            myTable.tableHeader.addColumn(new pdfTableColumn("user", predefinedAlignment.csLeft, 150));
            myTable.tableHeader.addColumn(new pdfTableColumn("tel", predefinedAlignment.csLeft, 80));
            myTable.tableHeader.addColumn(new pdfTableColumn("email", predefinedAlignment.csLeft, 150));
        }

        public string title { get; set; }

        public string author { get; set; }

        public string firstPageText { get; set; }
    }
}
