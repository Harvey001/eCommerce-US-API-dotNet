namespace USMoneris
{
    using System;
    using System.Text;
    using System.Collections;
    
	public class TestResPurchasePinless
	{
	  public static void Main(string[] args)
	  {

          string host = "esplusqa.moneris.com";
          string store_id = "monusqa002";
          string api_token = "qatoken";

          string data_key = "1X07zf118J5g7QESF421G27";
          string order_id = "res_purchase_pinless_4";
          string amount = "1.00";
          string cust_id = "customer1"; //if sent will be submitted, otherwise cust_id from profile will be used
          string intended_use = "1";
          string p_account_number = "23456789";

          USResPurchasePinless usResPurchasePinless = new USResPurchasePinless(data_key, order_id, cust_id, amount,
              intended_use);

          usResPurchasePinless.SetPAccountNumber(p_account_number);

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

        usResPurchasePinless.SetRecur(recurring_cycle);

        HttpsPostRequest mpgReq = new HttpsPostRequest(host, store_id, api_token, usResPurchasePinless);
	                     
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
                Console.WriteLine("RecurSuccess = " + receipt.GetRecurSuccess());
                Console.WriteLine("ResSuccess = " + receipt.GetResSuccess());
                Console.WriteLine("PaymentType = " + receipt.GetPaymentType());

                //ResolveData
                Console.WriteLine("\nCust ID = " + receipt.GetResDataCustId());
                Console.WriteLine("Phone = " + receipt.GetResDataPhone());
                Console.WriteLine("Email = " + receipt.GetResDataEmail());
                Console.WriteLine("Note = " + receipt.GetResDataNote());
                Console.WriteLine("Masked Pan = " + receipt.GetResDataMaskedPan());
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
