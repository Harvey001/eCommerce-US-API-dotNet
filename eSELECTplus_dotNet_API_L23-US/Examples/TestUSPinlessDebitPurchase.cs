namespace USMoneris
{
    using System;
	public class TestUSPinlessDebitPurchase
	{
	  public static void Main(string[] args)
	  {
			/******************* REQUEST VARIABLES*******************************/

	        string host = "esplusqa.moneris.com";
	        string store_id = "monusqa002";
	        string api_token = "qatoken";
		
			/****************** TRANSACTION VARIABLES *****************************/

	        string order_id = "pinlessdotnettest2"; 		
	        string amount = "1.00";
            string card = "4496270000164824";
	        string exp = "0411";
	        string presentation_type = "X";
	        string intended_use = "0";
	        string p_account_number = "123";
	        
			//Console.Write ("Please enter an order ID: ");   
			//order_id = Console.ReadLine();    	        
	
	       HttpsPostRequest mpgReq = new HttpsPostRequest(host, store_id, api_token,
	                       new USPinlessDebitPurchase(order_id, amount, card, exp,presentation_type, intended_use, p_account_number));

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
	    		Console.WriteLine("Message = " + receipt.GetMessage());
	    		Console.WriteLine("AuthCode = " + receipt.GetAuthCode());
	    		Console.WriteLine("Complete = " + receipt.GetComplete());
	    		Console.WriteLine("TransDate = " + receipt.GetTransDate());
	    		Console.WriteLine("TransTime = " + receipt.GetTransTime());
	    		Console.WriteLine("Ticket = " + receipt.GetTicket());
	    		Console.WriteLine("TimedOut = " + receipt.GetTimedOut());
	
	        }
	        catch (Exception e)
	        {
	            Console.WriteLine(e);
	        }
	  }
				
	} 
}
