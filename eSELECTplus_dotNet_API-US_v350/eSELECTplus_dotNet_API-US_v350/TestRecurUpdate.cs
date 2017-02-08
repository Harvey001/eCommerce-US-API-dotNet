namespace USMoneris
{
    using System;
	public class TestRecurUpdate
	{
	  public static void Main(string[] args)
	  {
	        string host = "esplusqa.moneris.com";
	        string store_id = "monusqa002";
	        string api_token = "qatoken";

            string order_id = "usrecur_test001";
            //string cust_id = "bob";
	        //string recur_amount = "45.00";
	        string pan = "5454545454545454";
	        string expiry_date = "1111";
            //string p_account_number = "123123123";
            //string presentation_type = "X";
            //string add_num = "";
            //string total_num = "";
            //string hold = "";
            string terminate = "false";

            USRecurUpdate recurUpdate = new USRecurUpdate(order_id);
            
            //recurUpdate.setCustId(cust_id);
            //recurUpdate.setRecurAmount(recur_amount);
            recurUpdate.setPan(pan);
            recurUpdate.setExpiryDate(expiry_date);
            //recurUpdate.setPAccountNumber(p_account_number);
            //recurUpdate.setPresentationType(presentation_type);
            //recurUpdate.setAddNumRecurs(add_num);
            //recurUpdate.setTotalNumRecurs(total_num);
            //recurUpdate.setHold(hold);
            recurUpdate.setTerminate(terminate);

            HttpsPostRequest mpgReq =
	            new HttpsPostRequest(host, store_id, api_token, recurUpdate);
	
            
	        try
	        {
	            Receipt receipt = mpgReq.GetReceipt();
	
	    		Console.WriteLine("ReceiptId = " + receipt.GetReceiptId());
	    		Console.WriteLine("ResponseCode = " + receipt.GetResponseCode());
	    		Console.WriteLine("Message = " + receipt.GetMessage());
	    		Console.WriteLine("Complete = " + receipt.GetComplete());
	    		Console.WriteLine("TransDate = " + receipt.GetTransDate());
	    		Console.WriteLine("TransTime = " + receipt.GetTransTime());
	    		Console.WriteLine("TimedOut = " + receipt.GetTimedOut());
                Console.WriteLine("RecurUpdateSuccess = " + receipt.GetRecurUpdateSuccess());
                Console.WriteLine("NextRecurDate = " + receipt.GetNextRecurDate());
                Console.WriteLine("RecurEndDate = " + receipt.GetRecurEndDate());
	
	        }
	        catch (Exception e)
	        {
	            Console.WriteLine(e);
	        }
	  }
				
	} 
}
