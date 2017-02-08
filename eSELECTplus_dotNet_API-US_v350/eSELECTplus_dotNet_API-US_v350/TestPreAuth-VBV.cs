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
          string store_id = "monusqa002";
          string api_token = "qatoken";
	        
		  /****************** TRANSACTION VARIABLES *****************************/

		  string order_id; 		//will prompt user for input
		  string cust_id = "B_Urlac_54";
		  string amount = "10.42";
		  string pan = "4242424242424242";
		  string exp = "1212";
		  string cavv = "AAABBJg0VhI0VniQEjRWAAAAAAA";
	        
		  Console.Write ("Please enter an order ID: ");
		  order_id = Console.ReadLine();	        
	        
	        /************************ Transaction Object Option1 *************************/
	        
	       	USCavvPreAuth cavvPreAuth 
					= new USCavvPreAuth (order_id,
								        cust_id,
								        amount,
										pan,
										exp,
										cavv);
								
	        
	        /************************ Transaction Object Option2 *************************/
	        
	        Hashtable cavvParams = new Hashtable();	//transaction hashtable option
			cavvParams.Add("order_id",order_id);
			cavvParams.Add("cust_id",cust_id);
			cavvParams.Add("amount",amount);
			cavvParams.Add("pan",pan);
			cavvParams.Add("expdate",exp);
			cavvParams.Add("cavv",cavv);

	        USCavvPreAuth cavvPreAuth2 
	        		= new USCavvPreAuth(cavvParams); //single paramater hashtable construtor
	        		
	        /*************** Address Verification Service **********************/
	        
	       	AvsInfo avsCheck = new AvsInfo();	
	       	
	       	avsCheck.SetAvsStreetNumber ("212");
	       	avsCheck.SetAvsStreetName ("Payton Street");
	       	avsCheck.SetAvsZipCode ("M1M1M1");
	       	       		
	       	cavvPreAuth.SetAvsInfo (avsCheck); 
	       	
	       	/****************** Card Validation Digits *************************/
	       	
	       	CvdInfo cvdCheck = new CvdInfo();
	       	cvdCheck.SetCvdIndicator ("1");
	       	cvdCheck.SetCvdValue ("099");
	       	
	       	cavvPreAuth.SetCvdInfo (cvdCheck);		       	
		
		/*************************** Https Post Request *****************************/

	        HttpsPostRequest mpgReq =
	            new HttpsPostRequest(host, store_id, api_token, cavvPreAuth);
	            
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
	    		Console.WriteLine("ISO = " + receipt.GetISO());
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
                Console.WriteLine("CardLevelResult = " + receipt.GetCardLevelResult());
                Console.WriteLine("CavvResultCode = " + receipt.GetCavvResultCode());
	        }
	        catch (Exception e)
	        {
	            Console.WriteLine(e);
	        }
	  }
				
	} 
}
