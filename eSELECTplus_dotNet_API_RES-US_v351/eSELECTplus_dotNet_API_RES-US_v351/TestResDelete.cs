namespace USMoneris
{
    using System;
    using System.Text;
    using System.Collections;
    
	public class TestResDelete
	{
	  public static void Main(string[] args)
	  {

		string host = "esplusqa.moneris.com";
        string store_id = "monusqa002";
        string api_token = "qatoken";
        string data_key = "F9X268oHsX115o521OJ11t9";

        USResDelete usResDelete = new USResDelete(data_key);

        HttpsPostRequest mpgReq = new HttpsPostRequest(host, store_id, api_token, usResDelete);
	                     
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
                Console.WriteLine("\nCust ID = " + receipt.GetResDataCustId());
                Console.WriteLine("Phone = " + receipt.GetResDataPhone());
                Console.WriteLine("Email = " + receipt.GetResDataEmail());
                Console.WriteLine("Note = " + receipt.GetResDataNote());
                Console.WriteLine("MaskedPan = " + receipt.GetResDataMaskedPan());
                Console.WriteLine("Exp Date = " + receipt.GetResDataExpdate());
                Console.WriteLine("Crypt Type = " + receipt.GetResDataCryptType());
                Console.WriteLine("Avs Street Number = " + receipt.GetResDataAvsStreetNumber());
                Console.WriteLine("Avs Street Name = " + receipt.GetResDataAvsStreetName());
                Console.WriteLine("Avs Zipcode = " + receipt.GetResDataAvsZipcode());
                Console.WriteLine("Presentation Type = " + receipt.GetResDataPresentationType());
                Console.WriteLine("P Account Number = " + receipt.GetResDataPAccountNumber());
                Console.WriteLine("Sec = " + receipt.GetResDataSec());
                Console.WriteLine("Cust First Name = " + receipt.GetResDataCustFirstName());
                Console.WriteLine("Cust Last Name = " + receipt.GetResDataCustLastName());
                Console.WriteLine("Cust Address 1 = " + receipt.GetResDataCustAddress1());
                Console.WriteLine("Cust Address 2 = " + receipt.GetResDataCustAddress2());
                Console.WriteLine("Cust City = " + receipt.GetResDataCustCity());
                Console.WriteLine("Cust State = " + receipt.GetResDataCustState());
                Console.WriteLine("Cust Zip = " + receipt.GetResDataCustZip());
                Console.WriteLine("Routing Num = " + receipt.GetResDataRoutingNum());
                Console.WriteLine("Masked Account Num = " + receipt.GetResDataMaskedAccountNum());
                Console.WriteLine("Check Num = " + receipt.GetResDataCheckNum());
                Console.WriteLine("Account Type = " + receipt.GetResDataAccountType());
	        }
	        catch (Exception e)
	        {
	            Console.WriteLine(e);
	        }
	  }
				
	}
}
