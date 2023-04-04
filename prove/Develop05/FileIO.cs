using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Develop05 {
  public class FileIO {
    public List<Goal> LoadGoalList(string filePath) {
      if (File.Exists(filePath)) {
        using (TextReader reader = new StreamReader(filePath)) {
          XmlSerializer serializer = new XmlSerializer(typeof(List<Goal>));
          return (List<Goal>)serializer.Deserialize(reader);
        }
      } else {
        throw new FileNotFoundException("Unable To Find File.");
      }
    }

    public void SaveGoalList(string fileName, List<Goal> goals) {
      if (!File.Exists(fileName)) {
        File.Create(fileName);
      }

      using (TextWriter writer = new StreamWriter(fileName)) {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Goal>));
        serializer.Serialize(writer, goals);
      }
    }
  }
}
