namespace USMoneris
{
    using System;
    using System.Text;
    using System.Collections;
    
	public class TestACHDebit
	{
	  public static void Main(string[] args)
	  {

		string host = "esplusqa.moneris.com";
		string order_id = "dotnetachdebittest236";
		string store_id = "monusqa002";
		string api_token = "qatoken";
        //string status = "true";


		string amount = "1.00";
        
        //ACHInfo Variables
		string sec = "pop";
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
        string micr = "t071000013t742941347o128";
        string dl_num = "CO-12312312";
        string magstripe = "no";
        string image_front = "";
        string image_back = "";

        ACHInfo achinfo = new ACHInfo(sec, cust_first_name, cust_last_name, 
            cust_address1, cust_address2, cust_city, cust_state, cust_zip, 
            routing_num, account_num, check_num, account_type, micr);


        achinfo.SetImgFront(image_front);
        achinfo.SetImgBack(image_back);
        achinfo.SetDlNum(dl_num);
        achinfo.SetMagstripe(magstripe);
        ACHDebit achdebit = new ACHDebit(order_id, amount, achinfo);

        //************************OPTIONAL VARIABLES***************************

        //Cust_id Variable
        string cust_id = "customer1";
        achdebit.SetCustId(cust_id);
       
        ACHHttpsPostRequest mpgReq = new ACHHttpsPostRequest(host, store_id, api_token, achdebit);

        /*Status Check Example
         ACHHttpsPostRequest mpgReq = new ACHHttpsPostRequest(host, store_id, api_token, status, achdebit);
         */
	                     
		/**********************   REQUEST  ************************/

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
	    		Console.WriteLine("Message = " + receipt.GetMessage());
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
				
	} 
}
