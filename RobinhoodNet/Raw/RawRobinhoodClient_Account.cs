using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace BasicallyMe.RobinhoodNet.Raw
{
    public partial class RawRobinhoodClient
    {
        

        public Task<JToken>
        DownloadAccounts (string accountsUrl = null)
        {
            string url = accountsUrl ?? ACCOUNTS_URL;
            return doGet(url);
        }


        public Task<JToken>
        DownloadAccountPositions (string accountPositionsUrl)
        {
            return doGet(accountPositionsUrl);
        }

        
    }
}
