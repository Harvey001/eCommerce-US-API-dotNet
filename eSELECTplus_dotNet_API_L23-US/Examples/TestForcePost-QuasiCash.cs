namespace USMoneris
{
	using System;

	public class TestForcePost
	{
		public static void Main(string[] args)
		{
			string host = "esplusqa.moneris.com";
			string store_id = "monusqa002";
			string api_token = "qatoken";

			string order_id;
			string cust_id = "customer1";
			string amount = "10.00";
			string pan = "4242424242424242";
			string expiry_date = "1212";
			string auth_code = "AU4R6";
			string crypt_type = "1";

			Console.Write ("Please enter an order ID: ");	 
			order_id = Console.ReadLine();				
			
			USForcePost fp = new USForcePost(order_id, cust_id, amount, pan, expiry_date, auth_code, crypt_type);
			fp.SetQuasiCash("Y");

			HttpsPostRequest mpgReq =
				new HttpsPostRequest(host, store_id, api_token,fp);

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
				Console.WriteLine("CardLevelResult = " + receipt.GetCardLevelResult());
 
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}
	}
}
