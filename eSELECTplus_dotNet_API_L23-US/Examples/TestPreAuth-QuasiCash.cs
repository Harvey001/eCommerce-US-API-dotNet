namespace USMoneris
{
	using System;
	
	public class TestPreAuth
	{
		public static void Main(string[] args)
		{

			string host = "esplusqa.moneris.com";
			string store_id = "monusqa002";
			string api_token = "qatoken";
	
			string order_id;		//will prompt for user input
			string amount = "9.00";
			string card = "4242424242424242";
			string exp_date = "1212";
			string crypt = "7";
	
			Console.Write ("Please enter an order ID: ");
			order_id = Console.ReadLine();	
			
			USPreAuth p = new USPreAuth(order_id, amount, card, exp_date, crypt);
			p.SetQuasiCash("Y");
		
			HttpsPostRequest mpgReq =
				new HttpsPostRequest(host, store_id, api_token, p);
	
			/**********************	 REQUEST	************************/

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
