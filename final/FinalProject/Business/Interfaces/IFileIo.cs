using System.Data.SqlTypes;

namespace FinalProject.Business.Interfaces {
  public interface IFileIo {
    T Load<T>(string path) where T : class;
    void Save<T>(T objectToSave, string path);
  }
}
