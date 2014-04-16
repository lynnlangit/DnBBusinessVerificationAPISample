using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using DnB;

namespace BizVerifyDemo
{
    class BizVerifyData
    {
        //your Live ID <email> example format shown below
        private const string USER_ID = "me@live.com";

        //your API key -from 'Primary Account Key' in Windows Azure Marketplace>Explore this Dataset,
        //your key will contain more characters than the example below
        private const string SECURE_ACCOUNT_ID = "xyzaaaaaaaaaaaa";

        //endpoint for D&B Business Verification API in Windows Azure Marketplace
        private const string ROOT_SERVICE_URL = 
            "https://api.datamarket.azure.com/DNB/BusinessVerificationOffice/v1/CompanyMatchByNameAddress";

        public static string bizName = "Microsoft";
        public static string country = "US";
        public static string state = "WA";

        private readonly Uri serviceUri;
        private readonly DnContainer context;

        // constructor
        public BizVerifyData()
        {
            serviceUri = new Uri(ROOT_SERVICE_URL);
            context = new DnContainer(serviceUri);
            context.IgnoreMissingProperties = true;
            context.Credentials = new NetworkCredential(USER_ID,
                                                        SECURE_ACCOUNT_ID);
        }

        // the method that queries the service and returns the IList<> of bizVerify data
        public IList<CleanseMatchByNameAddressEntity> CompanyMatchByNameAddress()
        {
            //Calling the exposed method, pass the required parameters in at minimum
            IEnumerable<CleanseMatchByNameAddressEntity> bizQuery
                = context.CompanyMatchByNameAddress(bizName, null, null, state, null, country, null, null);

            try
            {
                return bizQuery.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("BizVerify ERROR {0}", ex.Message);
                return null;
            }
        }
    }
}
