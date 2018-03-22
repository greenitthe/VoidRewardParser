using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using VoidRewardParser.Entities;

namespace VoidRewardParser.Logic
{
    class DucatValues
    {
        private const String _baseUrl = "https://api.warframe.market/v1/items/{0}";
        public static async Task<int> GetDucatPriceValue(DisplayPrime displayPrime)
        {
            if(displayPrime.Ducats == "?")
            {
                return 0;
            }

            if(displayPrime.Prime.Ducats != 0)
            {
                return displayPrime.Prime.Ducats;
            }

            var partName = displayPrime.Prime.Name.ToLower().Replace(' ', '_');

            string jsonData;
            using (var client = new WebClient())
            {
                var uri = new Uri(string.Format(_baseUrl, Uri.EscapeDataString(partName)));

                try
                {
                    jsonData = await client.DownloadStringTaskAsync(uri);

                    dynamic result = JsonConvert.DeserializeObject(jsonData);

                    IEnumerable<dynamic> itemSets = result.payload.item.items_in_set;

                    int ducats = itemSets
                        .Where(itemSet => itemSet.url_name == partName)
                        .Min(itemSet => itemSet.ducats);

                    return ducats;
                }
                catch
                {
                    return 0;
                }
            }
        }
    }
}
