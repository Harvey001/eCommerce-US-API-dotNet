namespace USMoneris
{
    using System;
    
	public class TestPurchaseEfraud
	{
	  public static void Main(string[] args)
	  {
	  
	  	/********************** Post Request Variables *************************/

          	string host = "esplusqa.moneris.com";
          	string store_id = "monusqa138";
          	string api_token = "qatoken";
	        
	        /********************** Transactional Variables **********************/
	        
	        string order_id;		//will prompt for user input
	        string amount = "5.00";
	        string pan = "4005554444444403";
	        string expdate = "0812";
	        string crypt_type = "7";
	        string commcard_invoice = "INV98798";
	        string commcard_tax_amount = "1.00";
	        
		Console.Write ("Please enter an order ID: ");
		order_id = Console.ReadLine(); 	        
	        
	        /*************** Address Verification Service **********************/
	        
	       	AvsInfo avsCheck = new AvsInfo();	
	       	
	       	avsCheck.SetAvsStreetNumber ("212");
	       	avsCheck.SetAvsStreetName ("Payton Street");
	       	avsCheck.SetAvsZipCode ("M1M1M1");
	       	
	       	USPurchase purchaseTxn =
	       		new USPurchase(order_id, amount, pan, expdate, crypt_type, commcard_invoice, commcard_tax_amount);
	       		
	       	purchaseTxn.SetAvsInfo (avsCheck);       	
	       	
	       	/****************** Card Validation Digits *************************/
	       	
	       	CvdInfo cvdCheck = new CvdInfo();
	       	cvdCheck.SetCvdIndicator ("1");
	       	cvdCheck.SetCvdValue ("099");
	       	
	       	purchaseTxn.SetCvdInfo (cvdCheck);
	       	
	       	/****************** Convenience Fee ********************************/
		
		ConvFeeInfo convFeeInfo = new ConvFeeInfo();
		convFeeInfo.SetConvenienceFee("1.00");
		purchaseTxn.SetConvFeeInfo(convFeeInfo);      
	      
	       	/************************** Request *************************/	       	
	
	        HttpsPostRequest mpgReq =
	            new HttpsPostRequest(host, store_id, api_token,purchaseTxn);
	            
	        /************************** Receipt *************************/
	
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
	    		Console.WriteLine("TimedOut = " + receipt.GetTimedOut ()); 
			Console.WriteLine("CfSuccess = " + receipt.GetCfSuccess());
			Console.WriteLine("CfStatus = " + receipt.GetCfStatus());
			Console.WriteLine("FeeAmount = " + receipt.GetFeeAmount());
			Console.WriteLine("FeeRate = " + receipt.GetFeeRate());
			Console.WriteLine("FeeType = " + receipt.GetFeeType());
	    		Console.WriteLine("Avs Response = " + receipt.GetAvsResultCode());
	    		Console.WriteLine("Cvd Response = " + receipt.GetCvdResultCode());	    		
	
	        }
	        catch (Exception e)
	        {
	            Console.WriteLine(e);
	        }
	  }
				
	} 
}
