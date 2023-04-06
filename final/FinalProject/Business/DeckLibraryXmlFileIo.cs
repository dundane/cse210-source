using FinalProject.Business.Interfaces;
using System.Xml.Serialization;

namespace FinalProject.Business {
  public class DeckLibraryXmlFileIo : IFileIo {
    public T Load<T>(string path) where T : class {
      if (typeof(T) == typeof(DeckLibrary)) {
        return LoadDeckLibrary(path) as T;
      }
      return null;
    }

    public DeckLibrary LoadDeckLibrary(string filePath) {
      if (File.Exists(filePath)) {
        using (TextReader reader = new StreamReader(filePath)) {
          XmlSerializer serializer = new XmlSerializer(typeof(DeckLibrary));
          return (DeckLibrary)serializer.Deserialize(reader);
        }
      } else {
        throw new FileNotFoundException("Unable To Find File.");
      }
    }

    public void Save<T>(T objectToSave, string path) {
      if (objectToSave.GetType() == typeof(DeckLibrary)) {
        SaveDeckLibrary(objectToSave as DeckLibrary, path);
      }
    }

    public void SaveDeckLibrary(DeckLibrary library, string filePath) {
      using (FileStream writer = new FileStream(filePath,FileMode.OpenOrCreate)) {
        XmlSerializer serializer = new XmlSerializer(typeof(DeckLibrary));
        serializer.Serialize(writer, library);
      }
    }
  }
}
