namespace USMoneris
{
    using System;

	public class TestBatchClose
	{
	  public static void Main(string[] args)
	  {
          string host = "esplusqa.moneris.com";
          string store_id = "monusqa002";
          string api_token = "qatoken";

            string ecr_no = "64000001";//ecr within store  "64000001"

            
	        
	
	        HttpsPostRequest mpgReq =
	            new HttpsPostRequest(host,store_id, api_token, new USBatchClose (ecr_no));
	            
	        try
	        {
	            Receipt receipt = mpgReq.GetReceipt();
	
	            if ( (receipt.GetReceiptId()).Equals("Global Error Receipt") ) 
	            {
	
	    		    Console.WriteLine("CardType = " + receipt.GetCardType());
	    		    Console.WriteLine("TransAmount = " + receipt.GetTransAmount());
	    		    Console.WriteLine("TxnNumber = " + receipt.GetTxnNumber());
	    		    Console.WriteLine("ReceiptId = " + receipt.GetReceiptId());
	    		    Console.WriteLine("TransType = " + receipt.GetTransType());
	    		    Console.WriteLine("ReferenceNum = " + receipt.GetReferenceNum());
	    		    Console.WriteLine("ResponseCode = " + receipt.GetResponseCode());
	    		    Console.WriteLine("ISO = " + receipt.GetISO());
	    		    Console.WriteLine("BankTotals = null");
	    		    Console.WriteLine("Message = " + receipt.GetMessage());
	    		    Console.WriteLine("AuthCode = " + receipt.GetAuthCode());
	    		    Console.WriteLine("Complete = " + receipt.GetComplete());
	    		    Console.WriteLine("TransDate = " + receipt.GetTransDate());
	    		    Console.WriteLine("TransTime = " + receipt.GetTransTime());
	    		    Console.WriteLine("Ticket = " + receipt.GetTicket());
	    		    Console.WriteLine("TimedOut = " + receipt.GetTimedOut());
	            }
	            else
	            {    
		            foreach ( string ecr in receipt.GetTerminalIDs() )
		            {
		                Console.WriteLine("ECR: " + ecr);
		                foreach ( string cardType in receipt.GetCreditCards(ecr) )
		                {
		                    Console.WriteLine("\tCard Type: " + cardType);
		
		                    Console.WriteLine("\t\tPurchase: Count = "
		                                        + receipt.GetPurchaseCount(ecr,cardType)
		                                        + " Amount = "
		                                        + receipt.GetPurchaseAmount(ecr,
                                                                              cardType));
		
		                    Console.WriteLine("\t\tRefund: Count = "
		                                        + receipt.GetRefundCount(ecr,cardType)
		                                        + " Amount = "
		                                        + receipt.GetRefundAmount(ecr,cardType));
		  
		                    Console.WriteLine("\t\tCorrection: Count = "
		                                        + receipt.GetCorrectionCount(ecr,cardType)
		                                        + " Amount = "
		                                        + receipt.GetCorrectionAmount(ecr,
                                                                               cardType));
		
		                }
		            }
	            }
	        }
	        catch (Exception e)
	        {
	            Console.WriteLine(e);
	        }
		}
				
	} 
}
