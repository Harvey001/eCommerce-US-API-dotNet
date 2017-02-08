namespace USMoneris
{
    using System;
    using System.Text;
    using System.Collections;
    
	public class TestResPurchaseAch
	{
	  public static void Main(string[] args)
	  {

		string host = "esplusqa.moneris.com";
        string store_id = "monusqa002";
        string api_token = "qatoken";

        string data_key = "1sZH2p215HdQV6l6909x217";
		string order_id = "res_puchase_ach_3";
        string amount = "1.00";
        string cust_id = "customer1";
        
        USResPurchaseAch usResPurchaseAch = new USResPurchaseAch(data_key, order_id, cust_id, amount);

        /************************* Recur Variables **********************************/

        string recur_unit = "month";
        string start_now = "true";
        string start_date = "2008/12/01";
        string num_recurs = "12";
        string period = "1";
        string recur_amount = "30.00";

        /************************* Recur Object Option1 ******************************/

        Recur recurring_cycle = new Recur(recur_unit, start_now, start_date,
                           num_recurs, period, recur_amount);

        usResPurchaseAch.SetRecur(recurring_cycle);

        HttpsPostRequest mpgReq = new HttpsPostRequest(host, store_id, api_token, usResPurchaseAch);
	                     
		/**********************   REQUEST  ************************/	                     
	      
	        try
	        {
	            Receipt receipt = mpgReq.GetReceipt();

                Console.WriteLine("DataKey = " + receipt.GetDataKey());
                Console.WriteLine("ReceiptId = " + receipt.GetReceiptId());
                Console.WriteLine("ReferenceNum = " + receipt.GetReferenceNum());
                Console.WriteLine("ResponseCode = " + receipt.GetResponseCode());
                Console.WriteLine("AuthCode = " + receipt.GetAuthCode());
                Console.WriteLine("Message = " + receipt.GetMessage());
                Console.WriteLine("TransDate = " + receipt.GetTransDate());
                Console.WriteLine("TransTime = " + receipt.GetTransTime());
                Console.WriteLine("TransType = " + receipt.GetTransType());
                Console.WriteLine("Complete = " + receipt.GetComplete());
                Console.WriteLine("TransAmount = " + receipt.GetTransAmount());
                Console.WriteLine("CardType = " + receipt.GetCardType());
                Console.WriteLine("TxnNumber = " + receipt.GetTxnNumber());
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
