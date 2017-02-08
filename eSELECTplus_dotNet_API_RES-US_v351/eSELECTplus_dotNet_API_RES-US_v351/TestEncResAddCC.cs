namespace USMoneris
{
    using System;
    using System.Text;
    using System.Collections;
    
	public class TestEncResAddCC
	{
	  public static void Main(string[] args)
	  {

		string host = "esplusqa.moneris.com";
        string store_id = "monusqa002";
        string api_token = "qatoken";

        string enc_track2 = "";
        string device_type = "idtech";
        string phone = "0000000000";
        string email = "bob@smith.com";
        string note = "my note";
        string cust_id = "customer1";
        string crypt_type = "7";

        AvsInfo avsCheck = new AvsInfo();

        avsCheck.SetAvsStreetNumber("212");
        avsCheck.SetAvsStreetName("Payton Street");
        avsCheck.SetAvsZipCode("M1M1M1");

        
        USEncResAddCC usEncResAddCC = new USEncResAddCC(enc_track2, device_type, crypt_type);

        //************************OPTIONAL VARIABLES***************************

        usResAddCC.SetCustId(cust_id);
        usResAddCC.SetPhone(phone);
        usResAddCC.SetEmail(email);
        usResAddCC.SetNote(note);
        usResAddCC.SetAvsInfo(avsCheck);

        HttpsPostRequest mpgReq = new HttpsPostRequest(host, store_id, api_token, usEncResAddCC);
	                     
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
