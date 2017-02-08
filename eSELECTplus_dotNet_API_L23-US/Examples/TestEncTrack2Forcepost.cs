namespace USMoneris
{
    using System;
	public class TestEncTrack2Forcepost
	{
	  public static void Main(string[] args)
	  {

		  /******************* REQUEST VARIABLES*******************************/

          string host = "esplusqa.moneris.com";
          string store_id = "monusqa002";
          string api_token = "qatoken";
		
		  /****************** TRANSACTION VARIABLES *****************************/

          string order_id = "testenctrack2";
		  string cust_id = "Ced_Benson32";
		  string amount = "5.00";
          string enc_track2 = "";
		  string pos_code = "00";
          string device_type = "idtech";
          string auth_code = "";

          USEncTrack2Forcepost F = new USEncTrack2Forcepost(order_id, cust_id, amount, enc_track2, pos_code, device_type, auth_code);

          //F.SetDynamicDescriptor("FromQA");
	      
          HttpsPostRequest mpgReq = new HttpsPostRequest(host, store_id, api_token, F);

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
                Console.WriteLine("MaskedPan = " + receipt.GetMaskedPan());
                Console.WriteLine("CardLevelResult = " + receipt.GetCardLevelResult());
	
	        }
	        catch (Exception e)
	        {
	            Console.WriteLine(e);
	        }
	  }
				
	} 
}
