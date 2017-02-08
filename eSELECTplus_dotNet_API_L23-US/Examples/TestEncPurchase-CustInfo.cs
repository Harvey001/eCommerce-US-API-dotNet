namespace USMoneris
{
    using System;
	public class TestEncPurchase
	{
	  public static void Main(string[] args)
	  {
			/******************* REQUEST VARIABLES*******************************/

          string host = "esplusqa.moneris.com";
          string store_id = "monusqa002";
          string api_token = "qatoken";
          
			/****************** TRANSACTION VARIABLES *****************************/

	        string order_id; 		//will prompt user for input
	        string amount = "5.00";
	        string enc_track2 = "";
	        string device_type = "0812";
	        string crypt = "7";
	        string commcard_invoice = "INVC090";
	        string commcard_tax_amount = "1.00";
	        
			Console.Write ("Please enter an order ID: ");   
			order_id = Console.ReadLine();

           USEncPurchase P =  new USEncPurchase(order_id,
	                       		    amount,
	                       		    enc_track2,
	                       		    device_type,
	                       		    crypt,
	                       		    commcard_invoice,
	                       		    commcard_tax_amount);

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

           P.SetCustInfo(customer);

            HttpsPostRequest mpgReq =
                new HttpsPostRequest(host, store_id, api_token, P);
	                      

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
                Console.WriteLine("MaskedPan = " + receipt.GetMaskedPan());
	
	        }
	        catch (Exception e)
	        {
	            Console.WriteLine(e);
	        }
	  }
				
	} 
}
