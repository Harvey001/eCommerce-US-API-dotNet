namespace USMoneris
{
    using System;
	using System.Text.RegularExpressions;
	public class TestTrack2Purchase
	{
	  public static void Main(string[] args)
	  {
			/******************* REQUEST VARIABLES*******************************/

            string host = "esplusqa.moneris.com";
            string store_id = "monusqa002";
            string api_token = "qatoken";
            //status = "true";
		
			/****************** TRANSACTION VARIABLES *****************************/

	        string order_id; 		//will prompt user for input
			string cust_id = "LBriggs";
	        string amount = "1.00";
		    string track1;			//not required for transaction
		    string track2;
            string pan = null;
	        string exp = null;		//must send '0000' if swiped
	        string pos_code = "00";
            string commcard_invoice = "INV98798";
            string commcard_tax_amount = "1.00";
	        
			Console.Write ("Please enter an order ID: ");   
			order_id = Console.ReadLine();    	        

			Console.WriteLine ("Please swipe card");
			track1 = Console.ReadLine();
		    track2 = Console.ReadLine();

    	    Console.WriteLine ("\nThe track1 is " + track1);
			Console.WriteLine ("\nThe track2 is " + track2);

            USTrack2Purchase P = new USTrack2Purchase(order_id,
														cust_id,
	                       								amount,
														 track2,
	                       								pan,
	                       						        exp,
                                                        pos_code,
	                       								commcard_invoice,
                                                        commcard_tax_amount                                                        
														);

            
	        HttpsPostRequest mpgReq =
	            new HttpsPostRequest(host, store_id, api_token, P);
           
           /*Status Check Example
            HttpsPostRequest mpgReq =
	            new HttpsPostRequest(host, store_id, status, api_token, P);
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
				
	} // end TestDrive Item
}
