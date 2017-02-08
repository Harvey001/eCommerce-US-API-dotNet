namespace USMoneris
{
    using System;
    using System.Text;
    using System.Collections;
    
	public class TestResAddPinless
	{
	  public static void Main(string[] args)
	  {

		string host = "esplusqa.moneris.com";
        string store_id = "monusqa002";
        string api_token = "qatoken";

        string phone = "0000000000";
        string email = "bob@smith.com";
        string note = "my note";
        string cust_id = "customer1";
        string pan = "4242424242424242";
        string expdate = "1111";
        string presentation_type = "W";
        string p_account_number = "123123213123213213123123";

        USResAddPinless usResAddPinless = new USResAddPinless(pan, presentation_type, p_account_number);


        //************************OPTIONAL VARIABLES***************************

        usResAddPinless.SetCustId(cust_id);
        usResAddPinless.SetPhone(phone);
        usResAddPinless.SetEmail(email);
        usResAddPinless.SetNote(note);
        usResAddPinless.SetExpdate(expdate);

		/**********************   REQUEST  ************************/
        HttpsPostRequest mpgReq = new HttpsPostRequest(host, store_id, api_token, usResAddPinless);           
	      
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
