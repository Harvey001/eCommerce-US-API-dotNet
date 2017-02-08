namespace USMoneris
{
    using System;
    using System.Collections;

	public class TestPurchaseVBV
	{
	  public static void Main(string[] args)
	  {
	  
		/******************* REQUEST VARIABLES*******************************/

          	string host = "esplusqa.moneris.com";
          	string store_id = "monusqa138";
          	string api_token = "qatoken";
	        
		/****************** TRANSACTION VARIABLES *****************************/

		string order_id; 		//will prompt user for input
		string cust_id = "B_Urlac_54";
		string amount = "1.00";
		string pan = "4005554444444403";
		string expdate = "0812";
		string cavv = "AAABBJg0VhI0VniQEjRWAAAAAAA";
		string commcard_invoice = "COINV982";
		string commcard_tax_amount = "1.00";
	        
		Console.Write ("Please enter an order ID: ");
		order_id = Console.ReadLine();	        
	        
	        /************************ Transaction Object Option1 *************************/
	        
	       	USCavvPurchase cavvPurchase = new USCavvPurchase (order_id,
								    cust_id,
								    amount,
								    pan,
								    expdate,
								    cavv,
								    commcard_invoice,
								    commcard_tax_amount);	
	        
	        /************************ Transaction Object Option2 *************************/
	        
	        Hashtable cavvParams = new Hashtable();	//transaction hashtable option
		cavvParams.Add("order_id",order_id);
		cavvParams.Add("cust_id",cust_id);
		cavvParams.Add("amount",amount);
		cavvParams.Add("pan", pan);
		cavvParams.Add("expdate",expdate);
		cavvParams.Add("cavv",cavv);
		cavvParams.Add("commcard_invoice",commcard_invoice);
		cavvParams.Add("commcard_tax_amount",commcard_tax_amount);

	        USCavvPurchase cavvPurchase2 = new USCavvPurchase(cavvParams); //single paramater hashtable construtor
	        		
	        /*************** Address Verification Service **********************/
	        
	       	AvsInfo avsCheck = new AvsInfo();	
	       	
	       	avsCheck.SetAvsStreetNumber ("212");
	       	avsCheck.SetAvsStreetName ("Payton Street");
	       	avsCheck.SetAvsZipCode ("M1M1M1");
	       	       		
	       	cavvPurchase.SetAvsInfo (avsCheck); 
	       	
	       	/****************** Card Validation Digits *************************/
	       	
	       	CvdInfo cvdCheck = new CvdInfo();
	       	cvdCheck.SetCvdIndicator ("1");
	       	cvdCheck.SetCvdValue ("099");
	       	
	       	cavvPurchase.SetCvdInfo (cvdCheck);

            	/****************** Convenience Fee ********************************/

            	ConvFeeInfo convFeeInfo = new ConvFeeInfo();
            	convFeeInfo.SetConvenienceFee("1.00");
            	cavvPurchase.SetConvFeeInfo(convFeeInfo);

            	/*************************** Https Post Request *****************************/

	        HttpsPostRequest mpgReq =
	            new HttpsPostRequest(host, store_id, api_token, cavvPurchase);
	            
	        /****************************** Receipt *************************************/
	        
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
	    		Console.WriteLine("Avs Response = " + receipt.GetAvsResultCode());
	    		Console.WriteLine("Cvd Response = " + receipt.GetCvdResultCode());
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
