namespace USMoneris
{
    using System;
    
	public class TestEncPreauth
	{
	  public static void Main(string[] args)
	  {

		string host = "esplusqa.moneris.com";
		string store_id = "monusqa002";
		string api_token = "qatoken";

        string order_id;		//will prompt for user input
		string amount = "9.00";
		string enc_track2 = "";
		string device_type = "idtech";
		string crypt = "7";

		Console.Write ("Please enter an order ID: ");
		order_id = Console.ReadLine();  
		
	        HttpsPostRequest mpgReq =
	            new HttpsPostRequest(host, store_id, api_token,
	                       new USEncPreauth(order_id, amount, enc_track2, device_type, crypt));

	                     
          /**********************   REQUEST  ************************/

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
	    		Console.WriteLine("BankTotals = " + receipt.GetBankTotals());
	    		Console.WriteLine("Message = " + receipt.GetMessage());
	    		Console.WriteLine("AuthCode = " + receipt.GetAuthCode());
	    		Console.WriteLine("Complete = " + receipt.GetComplete());
	    		Console.WriteLine("TransDate = " + receipt.GetTransDate());
	    		Console.WriteLine("TransTime = " + receipt.GetTransTime());
	    		Console.WriteLine("Ticket = " + receipt.GetTicket());
	    		Console.WriteLine("TimedOut = " + receipt.GetTimedOut());
                Console.WriteLine("CardLevelResult = " + receipt.GetCardLevelResult());
                Console.WriteLine("MaskedPan = " + receipt.GetMaskedPan());	
	        }
	        catch (Exception e)
	        {
	            Console.WriteLine(e);
	        }
	  }
				
	} 
}
