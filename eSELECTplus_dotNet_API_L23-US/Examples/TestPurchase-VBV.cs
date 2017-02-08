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
          //string status = "true";
	        
		  /****************** TRANSACTION VARIABLES *****************************/

		  string order_id; 		//will prompt user for input
		  string cust_id = "B_Urlac_54";
		  string amount = "10.42";
		  string pan = "4005554444444403";
		  string exp = "0812";
		  string cavv = "AAABBJg0VhI0VniQEjRWAAAAAAA";
		  string commcard_invoice = "COINV982";
		  string commcard_tax_amount = "1.00";
	        
			Console.Write ("Please enter an order ID: ");
			order_id = Console.ReadLine();	        
	        
	        /************************ Transaction Object Option1 *************************/
	        
	       	USCavvPurchase cavvPurchase 
			= new USCavvPurchase (order_id,
					    cust_id,
					    amount,
					    pan,
					    exp,
					    cavv,
					    commcard_invoice,
					    commcard_tax_amount);	
	        
	        /************************ Transaction Object Option2 *************************/
	        
	        Hashtable cavvParams = new Hashtable();	//transaction hashtable option
			cavvParams.Add("order_id",order_id);
			cavvParams.Add("cust_id",cust_id);
			cavvParams.Add("amount",amount);
			cavvParams.Add("pan", pan);
			cavvParams.Add("expdate",exp);
			cavvParams.Add("cavv",cavv);
			cavvParams.Add("commcard_invoice",commcard_invoice);
			cavvParams.Add("commcard_tax_amount",commcard_tax_amount);

	        USCavvPurchase cavvPurchase2 
	        		= new USCavvPurchase(cavvParams); //single paramater hashtable construtor
	        		
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
		
		/*************************** Https Post Request *****************************/

	        HttpsPostRequest mpgReq =
	            new HttpsPostRequest(host, store_id, api_token, cavvPurchase);

            /*Status Check Example
             HttpsPostRequest mpgReq =
                  new HttpsPostRequest(host, store_id, api_token, status, cavvPurchase);
             */
	            
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
