namespace USMoneris
{
    using System;
	public class TestTrack2ForcePost
	{
		public static void Main(string[] args)
		{
            string host = "esplusqa.moneris.com";
            string store_id = "monusqa002";
            string api_token = "qatoken";
            //string status = "true";

            string order_id;
			string amount = "10.00";
            string track1;
            string track2;
            string pan = "4242424242424242";
			string expiry_date = "1212";
            string pos_code = "00";
            string auth_code = "AU4R6";

			Console.Write ("Please enter an order ID: ");   
			order_id = Console.ReadLine();    	        

			Console.WriteLine ("Please swipe card");
			track1 = Console.ReadLine();
            track2 = Console.ReadLine();
	
			HttpsPostRequest mpgReq =
				new HttpsPostRequest(host, store_id, api_token,
					new USTrack2ForcePost(order_id, amount, track2, pan, expiry_date, pos_code, auth_code));

            /*Status Check Example
             HttpsPostRequest mpgReq =
				new HttpsPostRequest(host, store_id, api_token, status,
					new USTrack2ForcePost(order_id, amount, track2, pan, expiry_date, pos_code, auth_code));
             */
	
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
				Console.WriteLine("ISO = " + receipt.GetISO());
				Console.WriteLine("BankTotals = " + receipt.GetBankTotals());
				Console.WriteLine("Message = " + receipt.GetMessage());
				Console.WriteLine("AuthCode = " + receipt.GetAuthCode());
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
