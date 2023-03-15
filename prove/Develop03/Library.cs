using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Develop03 {
  public class Library {

    private List<Scripture> scriptures;
    private int selectedScripture = 0;

    public Library() {
      scriptures = new List<Scripture>();
    }

    public List<Scripture> Scriptures {
      get { return scriptures; }
      set {
        scriptures = value;
      }
    }

    public void AddScripture(Scripture scriptureToAdd) {
      scriptures.Add(scriptureToAdd);
    }

    public static Library LoadScriptures(string fileName) {
      if (File.Exists(fileName)) {
        using (TextReader reader = new StreamReader(fileName)) {
          XmlSerializer serializer = new XmlSerializer(typeof(Library));
          return (Library)serializer.Deserialize(reader);
        }
      } else {
        throw new FileNotFoundException("Unable To Find File.");
      }
    }

    public void SaveScriptures(string fileName) {
      using (TextWriter writer = new StreamWriter(fileName)) {
        XmlSerializer serializer = new XmlSerializer(typeof(Library));
        serializer.Serialize(writer, this);
      }
    }

    public Scripture SetCurrentScripture(int scriptureIndex) {
      selectedScripture = scriptureIndex;
      return GetCurrentScripture();
      
    }

    public Scripture GetCurrentScripture() {
      return scriptures[selectedScripture];
    }
  }
}
