namespace Platforms_1
{
    public interface IFileManager
    {
        void ReadFromFile(string path);
        void WriteInFile(string path);
    }
}