namespace Platforms_1
{
    /// <summary>
    /// Interface for file streaming.
    /// </summary>
    /// <remarks>
    /// Contains two file stream functions: read and write file.
    /// </remarks>
    public interface IFileManager
    {
        /// <summary>
        /// Read information about contact from file.
        /// </summary>
        /// <param name="path"> Path for file reading.</param>
        void ReadFromFile(string path);

        /// <summary>
        /// Write information about contact in file.
        /// </summary>
        /// <param name="path"> Path for file writing.</param>
        void WriteInFile(string path);
    }
}