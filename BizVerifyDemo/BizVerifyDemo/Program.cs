using System;
using System.Collections.Generic;
using DnB;
using BizVerifyDemo;

namespace BizVerifyDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<CleanseMatchByNameAddressEntity> businessList = null;
            var bizData = new BizVerifyData();
           businessList = bizData.CompanyMatchByNameAddress();

            //============================================ BIZ VERIFY DATA OUTPUT
            // confirm data was returned from query
            if (businessList != null)
            {
                //show input
                Console.WriteLine("BizData Input: BizName: " +
                    BizVerifyData.bizName + " BizState: " + BizVerifyData.state + " BizCountry: " +BizVerifyData.country);
                Console.Write("Tap to continue");
                Console.ReadLine();

                // print output column headings
                Console.WriteLine("Verified Biz Data");
                Console.WriteLine("{0,2},{1,2},{2,2},{3,2},{4,2},{5,2},{6,2},{7,1},{8,2}", "DUNS", "Company Name",
                                                                "Street Address",
                                                                "City",
                                                                "State",
                                                                "County",
                                                               
                                                                "Zip",
                                                                "Confidence Code",
                                                                "Match Grade");
                // print query results
                foreach (CleanseMatchByNameAddressEntity entity in businessList)
                    Console.WriteLine("{0,2},{1,2},{2,2},{3,2},{4,2},{5,2},{6,2},{7,1},{8,2}", entity.DUNSNumber,
                        entity.Company,
                                                                    entity.Address,
                                                                    entity.City,
                                                                    entity.State,
                                                                    entity.CountryISOCode,
                                                                    
                                                                    entity.ZipCode,
                                                                    entity.ConfidenceCode,
                                                                    entity.MatchGrade);
            }
            // pause until a key is struck
            Console.Write("Tap any key to end. ");
            Console.ReadKey();
            Console.WriteLine();
        }
    }
}
