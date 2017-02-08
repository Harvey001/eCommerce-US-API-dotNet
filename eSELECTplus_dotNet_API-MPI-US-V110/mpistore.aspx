<%@Page Language="C#"%>
<%@ Import Namespace="System.Data" %>  
<%@ Import Namespace="System.Collections" %>  
<%@ Import Namespace="System.Text" %>  
<%@ Import Namespace="USMoneris" %>  
<script language="C#" runat="server">

public static Hashtable parse_md(string md)        
{
    Hashtable keyValueHash = new Hashtable();

    string [] keyAndValuesArr = md.Split( "&".ToCharArray());

    foreach (string keyAndValueStr in keyAndValuesArr)
    {
        string [] tmp = keyAndValueStr.Split( "=".ToCharArray() );
        keyValueHash.Add(tmp[0],tmp[1]);
            
    }

    return keyValueHash;
}

string generateNumber(int numLen )
{
    Random r = new Random();
     
    StringBuilder sb = new StringBuilder();

    for(int i=0; i< numLen; i++)
    {
        sb.Append(r.Next(0,9));
    }
    return(sb.ToString());
}

</script>

<%

string storeid ="monusqa002";
string apitoken="qatoken";
string merchUrl="https://YourStoreSite/mpistore.aspx";
string gwhost="esplus.moneris.com or esplusqa.moneris.com";

if( Request.Form["amount"] != null)  
{
    	string xid = generateNumber(20); 
	 
	string HTTP_ACCEPT = Request.ServerVariables["HTTP_ACCEPT"]; 
	string HTTP_USER_AGENT = Request.ServerVariables["HTTP_USER_AGENT"];
    
    	string amount = Request.Form["amount"];
	string expdate = Request.Form["expdate"];
	string pan = Request.Form["pan"];
	string MD = "xid=" + xid 
        	+ "&amp;pan=" + pan
                + "&amp;expdate=" + expdate
                + "&amp;amount=" + amount;  

	MpiTxn mpiTxn =
             new MpiTxn(xid,amount,pan,expdate,MD,merchUrl,HTTP_ACCEPT,HTTP_USER_AGENT);
    
	MpiHttpsPostRequest mpiHttpPost  = new 
                        MpiHttpsPostRequest(gwhost,storeid,apitoken,mpiTxn);

	MpiReceipt mpiReceipt = mpiHttpPost.GetReceipt();
 
    if( mpiReceipt.GetSuccess() == "true" )
	{
		string vbvPopUpWindowForm = mpiReceipt.GetInLineForm();
	  	Response.Write(vbvPopUpWindowForm);
	}
	else
	{
        Response.Write("<br>Success = " + mpiReceipt.GetSuccess() );
        Response.Write("<br>Message = " + mpiReceipt.GetMessage() );
   
        //merchant at this point may send a regular purchase/preauth
        //with crypt type 7 
	}
	
}
else if( Request.Form["PaRes"] != null)
{
    string PaRes = Request.Form["PaRes"];
    string MD = Request.Form["MD"];

    MpiAcs mpiAcs = new MpiAcs(PaRes,MD);

    MpiHttpsPostRequest mpiHttpsPostRequest  = new MpiHttpsPostRequest(gwhost,storeid,apitoken,mpiAcs);

    MpiReceipt mpiReceipt = mpiHttpsPostRequest.GetReceipt();

    Hashtable mdValues = parse_md(MD);
    
    string amount = (string)mdValues["amount"];
    string pan = (string)mdValues["pan"]; 
    string expdate = (string)mdValues["expdate"];  
   
    if( mpiReceipt.GetSuccess() == "true" )
    {
        string orderid = generateNumber(20);
        
        string cavv = mpiReceipt.GetCavv();
        string commcard_invoice = "";
        string commcard_tax_amount = "";

         USCavvPurchase cavvPurchase = new USCavvPurchase(orderid,amount,pan,expdate,cavv,commcard_invoice,commcard_tax_amount);
       
         HttpsPostRequest mpgHttpsPost  = new HttpsPostRequest(gwhost,storeid,apitoken,cavvPurchase);

         Receipt receipt = mpgHttpsPost.GetReceipt();
        
         Response.Write("<br>The message is "  +  (receipt.GetMessage()));
    }
    else
    {

        //At this point the merchant should deny this transaction

        Response.Write("<br>Success = " + (mpiReceipt.GetSuccess()) );
        Response.Write("<br>Message = " + (mpiReceipt.GetMessage()) );
    }
}
else
{
%> 
    <html>
    <form method=post action="">
    <table> 
      <tr>
        <td>Credit Card Number:</td>
        <td colspan><input type=text name=pan size=16 value="4242424242424242"></td>
      </tr>
      <tr>
        <td>Expiry Date:</td>
        <td colspan><input type=text  name=expdate size=4 value="0404"></td>
      </tr>
      <tr>
        <td>Amount:</td>
        <td colspan><input type=text  name=amount size=4 value="1.01"></td>
      </tr>
      <tr>
      <td colspan=2 align=center><input type=submit  name=submit value='Buy'></td>
      </tr>
     </table>
    </form>
    </html>    
   
<%
}
%>
