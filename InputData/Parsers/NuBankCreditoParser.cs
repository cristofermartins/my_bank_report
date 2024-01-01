using System;
using System.Text;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;
using Tabula;
using Tabula.Detectors;
using Tabula.Extractors;

namespace BankData.Parsers
{
    public class TNuBankCreditParser : IBankParser
    {
        public List<BankDataEntry> ParseFiles(in List<string> inputFiles)
        {
            List<BankDataEntry> ret = new List<BankDataEntry>();
            foreach (string inputFile in inputFiles) 
            {
                string extension = Path.GetExtension(inputFile);
                if (extension == ".pdf")
                {
                    using (PdfDocument document = PdfDocument.Open(inputFile, new ParsingOptions() { ClipPaths = true }))
                    {
                        /*
                        Precisamos do ano das transções por que isso nao aparece na tabela
                        Depois precisamos identificar cada pagina que tem transação
                        Ai nessas paginas rodar o codigo que extrai as tabelas
                        É necessario perceber que algumas entradas nas tabelas saem do padrão, 
                        como por exemplo, compra internacional com IOF que mostra o custo em dolar.
                        É necessario ignorar elas.
                        Também é necessario transformar a sigla de um mês para numero.
                        Também é necessario perceber que pode haver extornos, não sei qual vai ser 
                        a estrategia em relação a estornos sendo que eles podem não acontecer no mesmo mês?
                        */
                        ObjectExtractor oe = new ObjectExtractor(document);
                        foreach (Page page in document.GetPages())
                        {
                            string pageText = page.Text;

                            if (pageText.Contains("TRANSAÇÕESDE")) 
                            {
                        
                                PageArea pageArea = oe.Extract(page.Number);
                        
                                // detect canditate table zones
                                SimpleNurminenDetectionAlgorithm detector = new SimpleNurminenDetectionAlgorithm();
                                var regions = detector.Detect(pageArea);
                                
                                IExtractionAlgorithm ea = new BasicExtractionAlgorithm();
                                List<Table> tables = ea.Extract(pageArea.GetArea(regions[0].BoundingBox)); // take first candidate area
                                var table = tables[0];
                                var rows = table.Rows;

                                foreach (var cell in rows)
                                {
                                    if (cell.Count == 3)
                                    {
                                        string stringID = cell[01].GetText();
                                        double value = 0D;
                                        if (Double.TryParse(cell[02].GetText(), out value))
                                        {
                                            BankDataEntry bankDataEntry = new BankDataEntry 
                                            {
                                                Value = -value,
                                                StringID = stringID
                                            };
                                            ret.Add(bankDataEntry);
                                        } 
                                        else 
                                        {
                                            foreach (var c in cell)
                                            {
                                                Console.WriteLine(c.GetText());
                                            }
                                        }
                                    }
 
                                }
                            }
                        }
                    }
                }
            }
 
            return ret;
        }
    }
}