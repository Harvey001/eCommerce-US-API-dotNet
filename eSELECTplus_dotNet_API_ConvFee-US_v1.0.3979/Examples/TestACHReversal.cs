namespace USMoneris
{
    using System;

    public class TestACHReversal
    {
        public static void Main(string[] args)
        {
            string host = "esplusqa.moneris.com";
            string order_id = "dotnetachdebitcustinfotest1";
            string store_id = "monusqa138";
            string api_token = "qatoken";
            string txn_number = "132-0_5";

            ACHReversal achreversal = new ACHReversal(order_id, txn_number);

            ACHHttpsPostRequest mpgReq = new ACHHttpsPostRequest(host, store_id, api_token, achreversal);  
            
            /**********************   REQUEST  ************************/

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
                Console.WriteLine("Complete = " + receipt.GetComplete());
                Console.WriteLine("TransDate = " + receipt.GetTransDate());
                Console.WriteLine("TransTime = " + receipt.GetTransTime());
                Console.WriteLine("Ticket = " + receipt.GetTicket());
                Console.WriteLine("TimedOut = " + receipt.GetTimedOut());
                Console.WriteLine("CfSuccess = " + receipt.GetCfSuccess());
                Console.WriteLine("CfStatus = " + receipt.GetCfStatus());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}