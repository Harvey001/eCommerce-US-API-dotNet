namespace USMoneris
{
    using System;
    using System.Text;
    using System.Collections;
    
	public class TestResGetExpiring
	{
	  public static void Main(string[] args)
	  {
		string host = "esplusqa.moneris.com";
        string store_id = "monusqa002";
        string api_token = "qatoken";
                
        USResGetExpiring usResGetExpiring = new USResGetExpiring();

        HttpsPostRequest mpgReq = new HttpsPostRequest(host, store_id, api_token, usResGetExpiring);
	                     
		/**********************   REQUEST  ************************/	                     
	      
	        try
	        {
	            Receipt receipt = mpgReq.GetReceipt();

                Console.WriteLine("DataKey = " + receipt.GetDataKey());
                Console.WriteLine("ResponseCode = " + receipt.GetResponseCode());
                Console.WriteLine("Message = " + receipt.GetMessage());
                Console.WriteLine("TransDate = " + receipt.GetTransDate());
                Console.WriteLine("TransTime = " + receipt.GetTransTime());
                Console.WriteLine("Complete = " + receipt.GetComplete());
                Console.WriteLine("TimedOut = " + receipt.GetTimedOut());
                Console.WriteLine("ResSuccess = " + receipt.GetResSuccess());
                Console.WriteLine("PaymentType = " + receipt.GetPaymentType());

                //ResolveData
                foreach (string dataKey in receipt.GetDataKeys())
                {
                    Console.WriteLine("\nDataKey = " + dataKey);
                    Console.WriteLine("Payment Type = " + receipt.GetExpPaymentType(dataKey));
                    Console.WriteLine("Cust ID = " + receipt.GetExpCustId(dataKey));
                    Console.WriteLine("Phone = " + receipt.GetExpPhone(dataKey));
                    Console.WriteLine("Email = " + receipt.GetExpEmail(dataKey));
                    Console.WriteLine("Note = " + receipt.GetExpNote(dataKey));
                    Console.WriteLine("Masked Pan = " + receipt.GetExpMaskedPan(dataKey));
                    Console.WriteLine("Exp Date = " + receipt.GetExpExpdate(dataKey));
                    Console.WriteLine("Crypt Type = " + receipt.GetExpCryptType(dataKey));
                    Console.WriteLine("Avs Street Number = " + receipt.GetExpAvsStreetNumber(dataKey));
                    Console.WriteLine("Avs Street Name = " + receipt.GetExpAvsStreetName(dataKey));
                    Console.WriteLine("Avs Zipcode = " + receipt.GetExpAvsZipCode(dataKey));
                    Console.WriteLine("Presentation Type = " + receipt.GetExpPresentationType(dataKey));
                    Console.WriteLine("P Account Number = " + receipt.GetExpPAccountNumber(dataKey));
                }
                	
	        }
	        catch (Exception e)
	        {
	            Console.WriteLine(e);
	        }
	  }
				
	} 
}
