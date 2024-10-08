﻿using System;
using System.Linq;
using System.ServiceModel;
using ConsoleApp2;
using ConsoleApp2.ObjectClass;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;
using Text = DocumentFormat.OpenXml.Wordprocessing.Text;

namespace OpenXmlSetBookmarkText
{
    class Program
    {
        private BasicHttpBinding basic_binding = new BasicHttpBinding(BasicHttpSecurityMode.None);

        // Specify the web service endpoint (replace with the actual URL of your WSDL)        
        private EndpointAddress calculator_endpoint = new EndpointAddress("http://www.dneonline.com/calculator.asmx");
       
        private EndpointAddress numberConversion_endpoint = new EndpointAddress("http://www.dataaccess.com/webservicesserver/numberconversion.wso?WSDL");
        static void Main(string[] args)
        {
            new Program();
        }

        public Program() {

            string filePath = "C://Temp//Test.docx";
            string bookmarkName = "bm1"; // The name of the bookmark to update
            string newText = "This is the new text inside the bookmark."; // The new text to insert
            testfunction2();

            testFunction();
            /*
            WebServiceASMX_ViaClassGenerated();
            int result = WebServiceASMX_ViaServiceReference().Result;
            Console.WriteLine(result);
            */


            string slipResult = RestAPIExample("https://api.adviceslip.com/advice/1").Result;
            RootSlip slipObj = JsonConvert.DeserializeObject<RootSlip>(slipResult);
            Console.WriteLine(slipObj.slip.id);

            slipResult = RestAPIExample("https://api.adviceslip.com/advice/search/spider").Result;
            SearchResult searchResult = JsonConvert.DeserializeObject<SearchResult>(slipResult);
            Console.WriteLine(searchResult.total_results);



            string taiwanResult = RestAPIExample("https://restcountries.com/v3.1/name/taiwan").Result;

            List<Country> countryObj = JsonConvert.DeserializeObject<List<Country>>(taiwanResult);
          
            Console.WriteLine(countryObj);

        }


        private void testfunction2()
        {
            throw new NotImplementedException();
        }
        private void testFunction()
        {
            // abc

        }

        private async Task<string> RestAPIExample(string url)
        {
            RestAPI_Trial restExample1 = new RestAPI_Trial(url);
            string result = restExample1.runAPI().Result;          



            return result;
        }

        private async void WebServiceASMX_Trial2()
        {
            var client = new NumberConversionNamespace.NumberConversionSoapTypeClient(basic_binding, numberConversion_endpoint);  // Replace with your actual client name.
            ulong number = 12;

            try
            {
                var result = await client.NumberToWordsAsync(number); // Call the method
                Console.WriteLine(result);

                var result2 = await client.NumberToDollarsAsync(number); // Call the method
                Console.WriteLine(result2);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

        }

        private void API2()
        {
            
            NumberConversionSoapTypeClient client = new NumberConversionSoapTypeClient(basic_binding, calculator_endpoint);        
            ulong x = 12;
            string numberToWords = client.NumberToWords(x);
            
            Console.WriteLine(numberToWords);
            client.Close();
        }

      
        private async Task<int> WebServiceASMX_ViaServiceReference()
        {
            calculatorReference.CalculatorSoapClient client = new calculatorReference.CalculatorSoapClient(basic_binding, calculator_endpoint);
            int result = await client.AddAsync(2, 2);
            client.Close();
            return result;

        }

        private void WebServiceASMX_ViaClassGenerated()
        {
            // Create a client for the service (replace 'CalculatorSoapClient' with your actual service client class)
            CalculatorSoapClient client = new CalculatorSoapClient(basic_binding, calculator_endpoint);

            // Call a web service method, for example, Add method            
            int result = client.Add(5, 10);

            // Output the result
            Console.WriteLine("Sum Result: " + result);

            // Close the client when done
            int divide = client.Divide(9, 2);
            Console.WriteLine("divide Result: " + divide);
            
            client.Close();
        }

      
    }
}