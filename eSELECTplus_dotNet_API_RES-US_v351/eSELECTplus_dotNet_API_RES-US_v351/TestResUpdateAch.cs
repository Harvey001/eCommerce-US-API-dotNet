namespace USMoneris
{
    using System;
    using System.Text;
    using System.Collections;
    
	public class TestResUpdateAch
	{
	  public static void Main(string[] args)
	  {

		string host = "esplusqa.moneris.com";
        string store_id = "monusqa002";
        string api_token = "qatoken";

        string data_key = "180298J12ku85m2u2gNC7Tk";
		string phone = "0000000000";
        string email = "bob@smith.com";
        string note = "my note";
        string cust_id = "customer1";
        
        //ACHInfo Variables
		string sec = "ppd";
		string cust_first_name = "Christian";
		string cust_last_name = "M";
        string cust_address1 = "3300 Bloor St W";
        string cust_address2 = "4th floor west tower";
        string cust_city = "Toronto";
        string cust_state = "ON";
        string cust_zip = "M1M1M1";
        string routing_num = "490000018";
        string account_num = "222222";
        string check_num = "11";
        string account_type = "checking";
        
      
        ACHInfo achinfo = new ACHInfo();
          
        achinfo.SetSec(sec);
        achinfo.SetCustFirstName(cust_first_name);
        achinfo.SetCustLastName(cust_last_name);
        achinfo.SetCustAddress1(cust_address1);
        achinfo.SetCustAddress2(cust_address2);
        achinfo.SetCustCity(cust_city);
        achinfo.SetCustState(cust_state);
        achinfo.SetCustZip(cust_zip);
        achinfo.SetRoutingNum(routing_num);
        achinfo.SetAccountNum(account_num);
        achinfo.SetCheckNum(check_num);
        achinfo.SetAccountType(account_type);
        

        USResUpdateAch usResUpdateAch = new USResUpdateAch(data_key);

        usResUpdateAch.SetAchInfo(achinfo);
        usResUpdateAch.SetCustId(cust_id);
        usResUpdateAch.SetPhone(phone);
        usResUpdateAch.SetEmail(email);
        usResUpdateAch.SetNote(note);
        

        HttpsPostRequest mpgReq = new HttpsPostRequest(host, store_id, api_token, usResUpdateAch);
	                     
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
