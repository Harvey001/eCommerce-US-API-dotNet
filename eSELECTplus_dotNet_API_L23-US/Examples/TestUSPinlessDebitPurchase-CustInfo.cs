namespace USMoneris
{
    using System;
	public class TestUSPinlessDebitPurchase
	{
	  public static void Main(string[] args)
	  {
			/******************* REQUEST VARIABLES*******************************/

	        string host = "esplusqa.moneris.com";
	        string store_id = "monusqa002";
	        string api_token = "qatoken";
		
			/****************** TRANSACTION VARIABLES *****************************/

	        string order_id = "pinlessdotnettest3"; 		
	        string amount = "1.00";
            string card = "4496270000164824";
	        string exp = "0411";
	        string presentation_type = "X";
	        string intended_use = "0";
	        string p_account_number = "123";

            /********************* Billing/Shipping Variables ****************************/

            string first_name = "Bob";
            string last_name = "Smith";
            string company_name = "ProLine Inc.";
            string address = "623 Bears Ave";
            string city = "Chicago";
            string province = "Illinois";
            string postal_code = "M1M2M1";
            string country = "Canada";
            string phone = "777-999-7777";
            string fax = "777-999-7778";
            string tax1 = "10.00";
            string tax2 = "5.78";
            string tax3 = "4.56";
            string shipping_cost = "10.00";

            /********************* Order Line Item Variables *****************************/

            string[] item_description = new string[] { "Chicago Bears Helmet", "Soldier Field Poster" };
            string[] item_quantity = new string[] { "1", "1" };
            string[] item_product_code = new string[] { "CB3450", "SF998S" };
            string[] item_extended_amount = new string[] { "150.00", "19.79" };

            /********************** Customer Information Object **************************/

            CustInfo customer = new CustInfo();

            /********************** Set Customer Billing Information **********************/

            customer.SetBilling(first_name, last_name, company_name, address, city,
                         province, postal_code, country, phone, fax, tax1, tax2,
                         tax3, shipping_cost);

            /******************** Set Customer Shipping Information ***********************/

            customer.SetShipping(first_name, last_name, company_name, address, city,
                         province, postal_code, country, phone, fax, tax1, tax2,
                         tax3, shipping_cost);

            /***************************** Order Line Items  ******************************/

            customer.SetItem(item_description[0], item_quantity[0],
                      item_product_code[0], item_extended_amount[0]);

            customer.SetItem(item_description[1], item_quantity[1],
                      item_product_code[1], item_extended_amount[1]);

          
          USPinlessDebitPurchase uspdp = new USPinlessDebitPurchase(order_id, amount, card, exp,presentation_type, intended_use, p_account_number);
          uspdp.SetCustInfo(customer);
	        
			//Console.Write ("Please enter an order ID: ");   
			//order_id = Console.ReadLine();    	        
	
	       HttpsPostRequest mpgReq = new HttpsPostRequest(host, store_id, api_token, uspdp);


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
	
	        }
	        catch (Exception e)
	        {
	            Console.WriteLine(e);
	        }
	  }
				
	}
}
