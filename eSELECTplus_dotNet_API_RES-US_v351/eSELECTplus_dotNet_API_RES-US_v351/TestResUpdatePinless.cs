namespace USMoneris
{
    using System;
    using System.Text;
    using System.Collections;
    
	public class TestResUpdatePinless
	{
	  public static void Main(string[] args)
	  {

		string host = "esplusqa.moneris.com";
        string store_id = "monusqa002";
        string api_token = "qatoken";

        string data_key = "180298J12ku85m2u2gNC7Tk";
        string pan = "4242424242424242";
        string expdate = "1111";
		string phone = "0000000000";
        string email = "bob@smith.com";
        string note = "my note";
        string cust_id = "customer1";
        string presentation_type = "W";
        string p_account_number = "23456789";

        
        USResUpdatePinless usResUpdatePinless = new USResUpdatePinless(data_key);

        usResUpdatePinless.SetCustId(cust_id);
        usResUpdatePinless.SetPan(pan);
        usResUpdatePinless.SetExpdate(expdate);
        usResUpdatePinless.SetPhone(phone);
        usResUpdatePinless.SetEmail(email);
        usResUpdatePinless.SetNote(note);
        usResUpdatePinless.SetPresentationType(presentation_type);
        usResUpdatePinless.SetPAccountNumber(p_account_number);

        HttpsPostRequest mpgReq = new HttpsPostRequest(host, store_id, api_token, usResUpdatePinless);
	                     
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
                Console.WriteLine("Presentation Type = " + receipt.GetResDataPresentationType());
                Console.WriteLine("P Account Number = " + receipt.GetResDataPAccountNumber());
	        }
	        catch (Exception e)
	        {
	            Console.WriteLine(e);
	        }
	  }
				
	}
}
