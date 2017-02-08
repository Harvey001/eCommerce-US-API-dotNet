namespace USMoneris
{
    using System;
	public class TestPurchase
	{
	  public static void Main(string[] args)
	  {
		/******************* REQUEST VARIABLES*******************************/

	        string host = "esplusqa.moneris.com";
	        string store_id = "monusqa138";
	        string api_token = "qatoken";
		
		/****************** TRANSACTION VARIABLES *****************************/

	        string order_id; 		//will prompt user for input
	        string amount = "1.00";
	        string pan = "4242424242424242";
	        string expdate = "0812";
	        string crypt_type = "7";
	        string commcard_invoice = "INVC090";
	        string commcard_tax_amount = "1.00";

		Console.Write ("Please enter an order ID: ");   
		order_id = Console.ReadLine();    	        
	
	        USPurchase usPurchase = new USPurchase(order_id,
	                       		    amount,
	                       		    pan,
	                       		    expdate,
	                       		    crypt_type,
	                       		    commcard_invoice,
	                       		    commcard_tax_amount);

            /****************** Convenience Fee ********************************/

            ConvFeeInfo convFeeInfo = new ConvFeeInfo();
            convFeeInfo.SetConvenienceFee("1.00");
            usPurchase.SetConvFeeInfo(convFeeInfo);

            HttpsPostRequest mpgReq =
	            new HttpsPostRequest(host, store_id, api_token, usPurchase);
	                       		                          		    
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
                Console.WriteLine("CfSuccess = " + receipt.GetCfSuccess());
                Console.WriteLine("CfStatus = " + receipt.GetCfStatus());
                Console.WriteLine("FeeAmount = " + receipt.GetFeeAmount());
                Console.WriteLine("FeeRate = " + receipt.GetFeeRate());
                Console.WriteLine("FeeType = " + receipt.GetFeeType());
	    }
	    catch (Exception e)
	    {
	        Console.WriteLine(e);
	    }
	  }
				
	} 
}
