namespace SoftTestLab2Yamanko
{
    public interface IFileService
    {
        int MergeTemporaryFiles(string dir);
        int RemoveTemporaryFiles(string dir);
    }
}
