namespace FinalProject.Business.Interfaces {
  public interface IFileIo {
    T Load<T>(string path);
    void Save<T>(T objectToSave, string path);
  }
}
