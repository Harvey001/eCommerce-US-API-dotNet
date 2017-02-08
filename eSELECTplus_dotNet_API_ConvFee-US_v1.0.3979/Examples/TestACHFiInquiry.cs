namespace USMoneris
{
    using System;

    public class TestACHFiInquiry
    {
        public static void Main(string[] args)
        {
            string host = "esplusqa.moneris.com";
            string store_id = "monusqa138";
            string api_token = "qatoken";

            string routing_num = "11000015";

            ACHFiInquiry achfiinquiry = new ACHFiInquiry(routing_num);

            ACHHttpsPostRequest mpgReq = new ACHHttpsPostRequest(host, store_id, api_token, achfiinquiry);  
            
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
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}