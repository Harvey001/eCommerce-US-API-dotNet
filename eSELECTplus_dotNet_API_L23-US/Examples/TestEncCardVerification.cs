namespace USMoneris
{
    using System;
	public class TestEncCardVerification
	{
	  public static void Main(string[] args)
	  {
			/******************* REQUEST VARIABLES*******************************/

	        string host = "esplusqa.moneris.com";
	        string store_id = "monusqa002";
	        string api_token = "qatoken";
		
			/****************** TRANSACTION VARIABLES *****************************/

	        string order_id; 		//will prompt user for input
            string cust_id = "customer1";
            string enc_track2 = "";
            string device_type = "idtech";
	        
            Console.Write("Please enter an order ID: ");
            order_id = Console.ReadLine();

            /*************** Address Verification Service **********************/

            AvsInfo avsCheck = new AvsInfo();

            avsCheck.SetAvsStreetNumber("212");
            avsCheck.SetAvsStreetName("Payton Street");
            avsCheck.SetAvsZipCode("M1M1M1");

            USEncCardVerification encCardVerification =
                new USEncCardVerification(order_id, cust_id, enc_track2, device_type);

            encCardVerification.SetAvsInfo(avsCheck);

            /****************** Card Validation Digits *************************/

            CvdInfo cvdCheck = new CvdInfo();
            cvdCheck.SetCvdIndicator("1");
            cvdCheck.SetCvdValue("099");

            encCardVerification.SetCvdInfo(cvdCheck);	       	

	
	       HttpsPostRequest mpgReq =
	            new HttpsPostRequest(host, store_id, api_token, encCardVerification);
                 		               		    
	                       		                          		    
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
                Console.WriteLine("CardLevelResult = " + receipt.GetCardLevelResult());
	
	        }
	        catch (Exception e)
	        {
	            Console.WriteLine(e);
	        }
	  }
				
	} 
}
