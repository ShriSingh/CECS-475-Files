// Name: Shriyansh Singh
// CECS 475 Section 01
// Group #9 - Lab Assignment 1

// StockBroker.cs
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;

namespace Stock
{
    //!NOTE!: Class StockBroker had fields broker name and a list of stock named stocks.
    // addStock method registers the Notify listener with the stock(in addition to
    // adding it to the lsit of stocks held by the broker). This notify method outputs
    // to the console the name, value, and the number of changes of the stock whose
    // value is out of the range given the stock's notification threshold.
    public class StockBroker
    {
        public string BrokerName { get; set; }

        public List<Stock> stocks = new List<Stock>();

        readonly string docPath = @"C:\Users\Shriyansh Singh\repos\Stock\bin";

        readonly string destPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Lab1_output.txt");

        public string titles = "Broker".PadRight(10) + "Stock".PadRight(15) + "Value".PadRight(10) + "Changes".PadRight(10) + "Date and Time";

        // For checking whether the titles have been written
        private static bool titlesWritten = false;

        /// <summary>
        /// The stockbroker object
        /// </summary>
        /// <param name="brokerName">The stockbroker's name</param>
        public StockBroker(string brokerName)
        {
            BrokerName = brokerName;

            if (!titlesWritten) 
            {
                Console.WriteLine(titles);
                using (StreamWriter outputFile = new StreamWriter(destPath, true))
                {
                    outputFile.WriteLine(titles);
                }
                titlesWritten = true;
            }
        }

        /// <summary> 
        /// Adds stock objects to the stock list
        /// </summary>
        /// <param name="stock">Stock Object</param>
        public void AddStock(Stock stock)
        {
            stocks.Add(stock);
            stock.StockEvent += EventHandler;
        }

        /// <summary>
        /// The eventhandler that raises the event of a change
        /// </summary>
        /// <param name="sender">The sender that indicated a change</param>
        /// <param name="e">Event arguments</param>
        void EventHandler(Object sender, EventArgs e)
        {
            var stockNotify = e as StockNotification;
            _ = Helper(sender, stockNotify);
        }

        public async Task Helper(Object sender, StockNotification e)
        {
            Stock newStock = (Stock)sender;

            string message = $"{BrokerName.PadRight(16)}{e.StockName.PadRight(15)}" +
                             $"{e.CurrentValue.ToString().PadRight(10)}" +
                             $"{e.NumChanges.ToString().PadRight(10)}" + 
                             $"{DateTime.Now}";
            try
            {
                using (var outputFile = new StreamWriter(new FileStream(destPath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite)))
                {
                    await outputFile.WriteLineAsync(message);
                }
                await Console.Out.WriteLineAsync(message);
            }
            catch (IOException O)
            {
                Console.WriteLine("An error occurred " + O.Message);
            }
        }
    }
}
