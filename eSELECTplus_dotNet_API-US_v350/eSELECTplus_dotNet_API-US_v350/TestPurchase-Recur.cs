namespace USMoneris
{
    using System;
	public class TestPurchase
	{
	  public static void Main(string[] args)
	  {
			/******************* REQUEST VARIABLES*******************************/

          string host = "esplusqa.moneris.com";
          string store_id = "monusqa002";
          string api_token = "qatoken";
          //string status = "true";
		
			/****************** TRANSACTION VARIABLES *****************************/

	        string order_id; 		//will prompt user for input
	        string amount = "5.00";
	        string card = "4242424242424242";
	        string exp = "1212";
	        string crypt = "7";
	        string commcard_invoice = "INVC090";
	        string commcard_tax_amount = "1.00";

            Console.Write("Please enter an order ID: ");
            order_id = Console.ReadLine();


            /************************* Recur Variables **********************************/

            string recur_unit = "month";
            string start_now = "true";
            string start_date = "2006/12/01";
            string num_recurs = "12";
            string period = "1";
            string recur_amount = "30.00";

            /************************* Recur Object Option1 ******************************/

            Recur recurring_cycle = new Recur(recur_unit, start_now, start_date,
                               num_recurs, period, recur_amount);
           
            USPurchase P = new USPurchase(order_id,
	                       		    amount,
	                       		    card,
	                       		    exp,
	                       		    crypt,
	                       		    commcard_invoice,
	                       		    commcard_tax_amount);
            P.SetRecur(recurring_cycle);

	        

            HttpsPostRequest mpgReq =
                new HttpsPostRequest(host, store_id, api_token, P);

          /*Status Check Example
           HttpsPostRequest mpgReq =
                new HttpsPostRequest(host, store_id, api_token, status, P);
           */
	                       		                          		    
	        try
	        {
	            Receipt receipt = mpgReq.GetReceipt();
	
	    		Console.WriteLine("CardType = " + receipt.GetCardType());
	    		Console.WriteLine("TransAmount = " + receipt.GetTransAmount());
	    		Console.WriteLine("TxnNumber = " + receipt.GetTxnNumber());
	    		Console.WriteLine("ReceiptId = " + receipt.GetReceiptId());
	    		Console.WriteLine("TransType = " + receipt.GetTransType());
	    		Console.WriteLine("ReferenceNum = " + receipt.GetReferenceNum());
	    		Console.WriteLine("ResponseCode = " + receipt.GetResponseCode());
	    		Console.WriteLine("ISO = " + receipt.GetISO());
	    		Console.WriteLine("BankTotals = " + receipt.GetBankTotals());
	    		Console.WriteLine("Message = " + receipt.GetMessage());
	    		Console.WriteLine("AuthCode = " + receipt.GetAuthCode());
	    		Console.WriteLine("Complete = " + receipt.GetComplete());
	    		Console.WriteLine("TransDate = " + receipt.GetTransDate());
	    		Console.WriteLine("TransTime = " + receipt.GetTransTime());
	    		Console.WriteLine("Ticket = " + receipt.GetTicket());
	    		Console.WriteLine("TimedOut = " + receipt.GetTimedOut());
                Console.WriteLine("Recur Success = " + receipt.GetRecurSuccess());
                Console.WriteLine("CardLevelResult = " + receipt.GetCardLevelResult());
                //Console.WriteLine("StatusCode = " + receipt.GetStatusCode());
                //Console.WriteLine("StatusMessage = " + receipt.GetStatusMessage());
	
	        }
	        catch (Exception e)
	        {
	            Console.WriteLine(e);
	        }
	  }
				
	} 
}
