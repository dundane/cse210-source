using RestSharp;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace FinalProject.Business {
  public class ScryfallApi {

    private IRestClient restClient = null;
    public ScryfallApi() { 
      restClient = new RestClient();
    }
    public Card FindCard(string name) {
      string encryptedName = Uri.EscapeDataString(name);
      Task <RestResponse> scryfallResonse = QueryAPIForCard(encryptedName);
      String respone = scryfallResonse.Result.Content;
      Card card = null;
      if (scryfallResonse.Result.IsSuccessStatusCode) {
         card = JsonConvert.DeserializeObject<Card>(respone);
      } 
      return card;
    }

    public CommanderCard FindCommanderCard(string name) {
      string encryptedName = Uri.EscapeDataString(name);
      Task<RestResponse> scryfallResonse = QueryAPIForCard(encryptedName);
      String respone = scryfallResonse.Result.Content;
      CommanderCard card = null;
      if (scryfallResonse.Result.IsSuccessStatusCode) {
        card = JsonConvert.DeserializeObject<CommanderCard>(respone);
      }
      return card;
    }

    private async Task<RestResponse> QueryAPIForCard(string name) {
      String requestUri = $"https://api.scryfall.com/cards/named?fuzzy={name}";
      RestRequest request = new RestRequest(requestUri, Method.Get);
      return await restClient.ExecuteAsync(request);
    }

  }
}
