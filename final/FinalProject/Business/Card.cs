using Newtonsoft.Json;

namespace FinalProject.Business
{
    public class Card {
    private List<string> keywords;
    private List<string> types;
    private List<string> colors;
    private string oracleText;
    private List<string> colorIdentitites;
    private Legality legalities;

    public Card() {
      keywords = new List<string>();
      types = new List<string>();
      colors = new List<string>();
      colorIdentitites = new List<string>();
      legalities = new Legality();
    }

    [JsonProperty("keywords")]
    public List<String> Keywords {
      get { return keywords; }
      set {
        keywords = value;
      }
    }

    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("mana_cost")]
    public string ManaCost { get; set; }
    [JsonProperty("cmc")]
    public double ConvertedManaCost { get; set; }
    [JsonProperty("type_line")]

    public string TypeLine { get; set; }

    [JsonIgnore]
    public List<string> Types {
      get {
        if (types.Count < 1 && !String.IsNullOrEmpty(TypeLine)) {
          string cleanedType = new string(TypeLine.Where(c => Char.IsLetter(c) || Char.IsWhiteSpace(c)).ToArray());
          types.AddRange(cleanedType.Split(" ",StringSplitOptions.RemoveEmptyEntries));
        } 
        return types; 
      }
      set {
        types = value;
      }
    }

    [JsonProperty("oracle_text")]
    public string OracleText {
      get { return oracleText; }
      set {
        oracleText = value;
      }
    }

    [JsonProperty("colors")]
    public List<string> Colors {
      get { return colors; }
      set {
        colors = value;
      }
    }

    [JsonProperty("color_identity")]
    public List<string> ColorIdentitites {
      get { return colorIdentitites; }
      set {
        colorIdentitites = value;
      }
    }

    public Boolean IsInColorIdentity(string colorIdentity) {
      foreach (string color in ColorIdentitites) {
        if (!colorIdentity.Contains(color)) {
          return false;
        }
      }
      return true;
    }

    [JsonProperty("legalities")]
    public Legality Legalities {
      get { return legalities; }
      set {
        legalities = value;
      }
    }



  }
}
