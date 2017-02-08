namespace USMoneris
{
    using System;
    using System.Text;
    using System.Collections;
    
	public class TestResAddToken
	{
	  public static void Main(string[] args)
	  {

		string host = "esplusqa.moneris.com";
        string store_id = "monusqa002";
        string api_token = "qatoken";

        string data_key = "ot-QOAnydyWYYw79pApkS5ROBzX9";
        string phone = "0000000000";
        string email = "bob@smith.com";
        string note = "my note";
        string cust_id = "customer1";
        string crypt_type = "7";

        AvsInfo avsCheck = new AvsInfo();

        avsCheck.SetAvsStreetNumber("212");
        avsCheck.SetAvsStreetName("Payton Street");
        avsCheck.SetAvsZipCode("M1M1M1");

        
        USResAddToken usResAddToken = new USResAddToken(data_key, crypt_type);

        //************************OPTIONAL VARIABLES***************************

        usResAddToken.SetCustId(cust_id);
        usResAddToken.SetPhone(phone);
        usResAddToken.SetEmail(email);
        usResAddToken.SetNote(note);
        usResAddToken.SetAvsInfo(avsCheck);

        HttpsPostRequest mpgReq = new HttpsPostRequest(host, store_id, api_token, usResAddToken);
	                     
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
	        }
	        catch (Exception e)
	        {
	            Console.WriteLine(e);
	        }
	  }
				
	} 
}
