namespace USMoneris
{
    using System;
	public class TestTrack2Refund
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
		  string txn_number;
          string amount = "1.00";
          string dynamic_descriptor = "123456";

		  Console.Write ("Please enter an order ID: ");
		  order_id = Console.ReadLine(); 

		  Console.Write ("Please enter a txn number: ");
		  txn_number= Console.ReadLine(); 

          USTrack2Refund tr = new USTrack2Refund(order_id, amount, txn_number);

          tr.SetDynamicDescriptor(dynamic_descriptor);

		  HttpsPostRequest mpgReq = new HttpsPostRequest(host, store_id, api_token, tr);
	                       

          /* Status Check Example
		  HttpsPostRequest mpgReq =
	            new HttpsPostRequest(host, store_id, api_token, status,
	                       new USTrack2Refund(order_id, amount, txn_number));
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
