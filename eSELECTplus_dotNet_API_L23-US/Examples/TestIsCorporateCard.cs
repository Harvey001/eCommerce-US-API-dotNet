namespace USMoneris
{
	using System;
	public class TestL23IsCorporateCard
	{
		public static void Main(string[] args)
		{
			/******************* REQUEST VARIABLES*******************************/

			string host = "esplusqa.moneris.com";
			string store_id = "monus00001";
			string api_token = "montoken";
		
			/****************** TRANSACTION VARIABLES *****************************/

			string pan = "5454545442424242";
			string expiry_date = "1212";

			USL23IsCorporateCard corpCard =
				new USL23IsCorporateCard(pan, expiry_date);


			HttpsPostRequest mpgReq =
					new HttpsPostRequest(host, store_id, api_token, corpCard);
																					
																														
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
				Console.WriteLine("AuthCode = " + receipt.GetAuthCode());
				Console.WriteLine("Complete = " + receipt.GetComplete());
				Console.WriteLine("TransDate = " + receipt.GetTransDate());
				Console.WriteLine("TransTime = " + receipt.GetTransTime());
				Console.WriteLine("Ticket = " + receipt.GetTicket());
				Console.WriteLine("TimedOut = " + receipt.GetTimedOut());
				Console.WriteLine("Corporate Card = " + receipt.GetIsCorporateCard());

			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}
	} 
}
