namespace USMoneris
{
    using System;
	public class TestRefund
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
		  string amount = "1.00";
		  string txn_number;
		  string crypt = "7";
          string dynamic_descriptor = "123456";

		  Console.Write ("Please enter an order ID: ");
		  order_id = Console.ReadLine(); 

		  Console.Write ("Please enter a txn number: ");
		  txn_number= Console.ReadLine(); 

	      USRefund r = new USRefund(order_id, amount, txn_number, crypt);		

          r.SetDynamicDescriptor(dynamic_descriptor);

          HttpsPostRequest mpgReq = new HttpsPostRequest(host, store_id, api_token, r);
	                         

          /*Status Check Example
           HttpsPostRequest mpgReq =
	            new HttpsPostRequest(host, store_id, api_token, status,
	                       new USRefund(order_id, amount, txn_number, crypt));
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
