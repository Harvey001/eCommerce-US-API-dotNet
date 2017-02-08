namespace USMoneris
{
    using System;
    using System.Text;
    using System.Collections;
    
	public class TestEncResUpdateCC
	{
	  public static void Main(string[] args)
	  {

		string host = "esplusqa.moneris.com";
        string store_id = "monusqa002";
        string api_token = "qatoken";

        string data_key = "32b55Q428ySjNBpbXw24128p5";
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

        USEncResUpdateCC usEncResUpdateCC = new USEncResUpdateCC(data_key);

        usEncResUpdateCC.SetAvsInfo(avsCheck);
        usEncResUpdateCC.SetCustId(cust_id);
        usEncResUpdateCC.SetEncTrack2(enc_track2);
        usEncResUpdateCC.SetDeviceType(device_type);
        usEncResUpdateCC.SetPhone(phone);
        usEncResUpdateCC.SetEmail(email);
        usEncResUpdateCC.SetNote(note);
        usEncResUpdateCC.SetCryptType(crypt_type);

        HttpsPostRequest mpgReq = new HttpsPostRequest(host, store_id, api_token, usEncResUpdateCC);
	                     
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
