namespace USMoneris
{
    using System;
    using System.Text;
    using System.Collections;
    
	public class TestResPurchaseCC
	{
	  public static void Main(string[] args)
	  {

		string host = "esplusqa.moneris.com";
        string store_id = "monusqa002";
        string api_token = "qatoken";
        string data_key = "X4oSM1d86871eEF20D856u2";
		string order_id = "nov7test1";
        string amount = "1.00";
        string cust_id = "customer1"; //if sent will be submitted, otherwise cust_id from profile will be used
        string crypt_type = "1";
        string commcard_invoice = "invoice";
        string commcard_tax_amount = "1.00";

        USResPurchaseCC usResPurchaseCC = new USResPurchaseCC(data_key, order_id, cust_id, amount, crypt_type);

        /**********************   OPTIONAL VARIABLES  ************************/
        usResPurchaseCC.SetCommcardInvoice(commcard_invoice);
        usResPurchaseCC.SetCommcardTaxAmount(commcard_tax_amount);
		
		//usResPurchaseCC.SetExpdate("1601"); //must be YYMM format

        /*************** Address Verification Service **********************/

        AvsInfo avsCheck = new AvsInfo();

        avsCheck.SetAvsStreetNumber("212");
        avsCheck.SetAvsStreetName("Payton Street");
        avsCheck.SetAvsZipCode("M1M1M1");

        usResPurchaseCC.SetAvsInfo(avsCheck);

        /****************** Card Validation Digits *************************/

        CvdInfo cvdCheck = new CvdInfo();
        cvdCheck.SetCvdIndicator("1");
        cvdCheck.SetCvdValue("099");

        usResPurchaseCC.SetCvdInfo(cvdCheck);	       	

        HttpsPostRequest mpgReq = new HttpsPostRequest(host, store_id, api_token, usResPurchaseCC);
	                     
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
                Console.WriteLine("AVSResponse = " + receipt.GetAvsResultCode());
                Console.WriteLine("CVDResponse = " + receipt.GetCvdResultCode());
                Console.WriteLine("ResSuccess = " + receipt.GetResSuccess());
                Console.WriteLine("PaymentType = " + receipt.GetPaymentType());

                //ResolveData
                Console.WriteLine("\nCust ID = " + receipt.GetResDataCustId());
                Console.WriteLine("Phone = " + receipt.GetResDataPhone());
                Console.WriteLine("Email = " + receipt.GetResDataEmail());
                Console.WriteLine("Note = " + receipt.GetResDataNote());
                Console.WriteLine("Masked Pan = " + receipt.GetResDataMaskedPan());
                Console.WriteLine("Exp Date = " + receipt.GetResDataExpdate());
                Console.WriteLine("Crypt Type = " + receipt.GetResDataCryptType());
                Console.WriteLine("Avs Street Number = " + receipt.GetResDataAvsStreetNumber());
                Console.WriteLine("Avs Street Name = " + receipt.GetResDataAvsStreetName());
                Console.WriteLine("Avs Zipcode = " + receipt.GetResDataAvsZipcode());
                
                	
	        }
	        catch (Exception e)
	        {
	            Console.WriteLine(e);
	        }
	  }
				
	} 
}
