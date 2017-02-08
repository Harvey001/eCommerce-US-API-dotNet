namespace USMoneris
{
	using System;
	public class TestL23Refund
	{
		public static void Main(string[] args)
		{
			/******************* REQUEST VARIABLES*******************************/

			string host = "esplusqa.moneris.com";
			string store_id = "monusqa002";
			string api_token = "qatoken";
					//string status = "true";

			/****************** TRANSACTION VARIABLES *****************************/

			string order_id; 		//will prompt user for input
			string amount = "1.00";
			string txn_number;
			string crypt = "7";
					string dynamic_descriptor = "123456";

			Console.Write ("Please enter an order ID: ");
			order_id = Console.ReadLine(); 

			Console.Write ("Please enter a txn number: ");
			txn_number= Console.ReadLine(); 

			/********************* Addendum1  ****************************/
			string customer_code = "ID12345";
			string local_tax_amount = "1.00";
			string discount_amount = "0.50";
			string freight_amount = "0.50";
			string duty_amount = "0.50";
			string national_tax_amount = "0.00";
			string other_tax_amount = "0.00";
			string vat_invoice_ref_num = "123456789012345";
			string customer_vat_registration_num = "1234567890123";
			string vat_tax_amount = "1.00";
			string vat_tax_rate = "0.00";
			string destination_zip = "90210";
			string ship_from_zip = "90210";

			Addendum1 addendum1 = new Addendum1 (customer_code, local_tax_amount, discount_amount, freight_amount, 
				duty_amount, national_tax_amount, other_tax_amount, vat_invoice_ref_num,
				customer_vat_registration_num, vat_tax_amount, vat_tax_rate, destination_zip, ship_from_zip);

			/********************* Addendum2  ****************************/
			string item_description1 = "Item1";
			string product_code1 = "PROD00001";
			string commodity_code1 = "IT1";
			string quantity1 = "1.00";
			string unit_cost1 = "1.00";
			string ext_amount1 = "1.00";
			string uom1 = "EA";
			string tax_collected_ind1 = "Y";
			string item_discount_amount1 = "0.25";
			string item_local_tax_amount1 = "1.00";
			string item_other_tax_amount1 = "1.00";
			string item_other_tax_type1 = "0.00";
			string item_other_tax_rate1 = "0.00";
			string item_other_tax_id1 = "VAT";

			Addendum2 addendum2 = new Addendum2 (item_description1, product_code1, commodity_code1, quantity1, 
				unit_cost1, ext_amount1, uom1, tax_collected_ind1, item_discount_amount1, 
				item_local_tax_amount1, item_other_tax_amount1, item_other_tax_type1, 
				item_other_tax_rate1, item_other_tax_id1);
			
			string item_description2 = "Item2";
			string product_code2 = "PROD00002";
			string commodity_code2 = "IT2";
			string quantity2 = "2.00";
			string unit_cost2 = "2.00";
			string ext_amount2 = "2.00";
			string uom2 = "EA";
			string tax_collected_ind2 = "Y";
			string item_discount_amount2 = "0.25";
			string item_local_tax_amount2 = "2.00";
			string item_other_tax_amount2 = "2.00";
			string item_other_tax_type2 = "0.00";
			string item_other_tax_rate2 = "0.00";
			string item_other_tax_id2 = "VAT";

			addendum2.AddAddendum2 (item_description2, product_code2, commodity_code2, quantity2, 
				unit_cost2, ext_amount2, uom2, tax_collected_ind2, item_discount_amount2, 
				item_local_tax_amount2, item_other_tax_amount2, item_other_tax_type2, 
				item_other_tax_rate2, item_other_tax_id2);

			USL23Refund r = new USL23Refund(order_id, amount, txn_number, crypt, addendum1, addendum2);		

			r.SetDynamicDescriptor(dynamic_descriptor);

			HttpsPostRequest mpgReq = new HttpsPostRequest(host, store_id, api_token, r);
													

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
				Console.WriteLine("Corporate Card = " + receipt.GetIsCorporateCard());
	
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}
		
	} 
}
