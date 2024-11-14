<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReflectedCrossSiteScripting.aspx.cs" Inherits="ReflectedCrossSiteScripting" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reflected Cross Site Scripting Test</title>
</head>
<body>
    <h1>Reflected Cross Site Scripting Test</h1>
    <p>Test for reflected XSS by passing a "user" query parameter in the URL.</p>

    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>

    <p>If the "user" parameter is reflected below without sanitization, this could indicate a potential XSS vulnerability.</p>

    <%-- If a query parameter is provided, display the reflected value. --%>
    <% 
        if(Request.QueryString["user"] != null)
        {
            string userInput = Request.QueryString["user"];
            Response.Write("<p>Your input: <strong>" + userInput + "</strong></p>");
            Response.Write("<p>This reflects the user input on the page.</p>");
        }
        else
        {
            Response.Write("<p>Please provide a 'user' query parameter in the URL to test XSS.</p>");
        }
    %>

    Set user to admin<br />
    <a href="../InputValidationTesting/ReflectedCrossSiteScripting.aspx?user=admin">Test XSS (alert 123)</a><br><br />


    Test with URL-encoded Payload:<br /><br />
    <a href="../InputValidationTesting/ReflectedCrossSiteScripting.aspx?user=<script>alert(123)</script>">Test XSS (alert 123)</a><br>
    <a href="../InputValidationTesting/ReflectedCrossSiteScripting.aspx?user=%3Cscript%3Ealert(123)%3C%2Fscript%3E">Test XSS (URL-encoded alert)</a><br>
    <a href="../InputValidationTesting/ReflectedCrossSiteScripting.aspx?user=<script>alert(document.cookie)</script>">Test XSS (alert document.cookie)</a><br>
    <a href="../InputValidationTesting/ReflectedCrossSiteScripting.aspx?user=%22%3E%3CScRiPt%3Ealert(document.cookie)%3C%2FScRiPt%3E">Test XSS (mixed case script)</a><br>
    <a href="../InputValidationTesting/ReflectedCrossSiteScripting.aspx?user=<img src='x' onerror='alert(&quot;XSS&quot;)'>">Test XSS (image onerror)</a><br>
    <a href="../InputValidationTesting/ReflectedCrossSiteScripting.aspx?user=%22%20onfocus=%22alert(document.cookie)%22">Test XSS (onfocus event)</a><br>
    <a href="../InputValidationTesting/ReflectedCrossSiteScripting.aspx?user=<script>eval('alert(123)')</script>">Test XSS (eval function)</a><br>
    <a href="../InputValidationTesting/ReflectedCrossSiteScripting.aspx?user=%3C%2Fdiv%3E%3Cscript%3Ealert(123)%3C%2Fscript%3E">Test XSS (breaking out of HTML structure)</a><br>


    <br /><br />
    <b> Below is the HTML file with payloads that triggered reflection </b> <br /><br />


      <a href="../InputValidationTesting/ReflectedCrossSiteScripting.aspx?user=%3cscript%3ealert(document.cookie)%3c/script%3e">Test XSS (reflected script)</a><br>

    <!-- Payload 2 -->
    <a href="../InputValidationTesting/ReflectedCrossSiteScripting.aspx?user=%22%20onfocus=%22alert(document.cookie)%22">Test XSS (onfocus event)</a><br>

    <!-- Payload 3 -->
    <a href="../InputValidationTesting/ReflectedCrossSiteScripting.aspx?user=%3Cscript%3Ealert('XSS')%3C/script%3E">Test XSS (encoded script)</a><br>


</body>
</html>
