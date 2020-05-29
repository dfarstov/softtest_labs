using System;

namespace SoftTestLab2Yamanko
{
    class FileServerStub : IFileService
    {

        public int MergeTemporaryFiles(string dir)
        {
            return 4;
        }

        public int RemoveTemporaryFiles(string dir)
        {
            return 3;
        }
    }
    class FileServerStubExeption : IFileService
    {
        public int MergeTemporaryFiles(string dir)
        {
            throw new NullReferenceException();
        }
        public int RemoveTemporaryFiles(string dir)
        {
            throw new NotImplementedException();
        }
    }
    class FileServerStubStopMetod : IFileService
    {
        public int MergeTemporaryFiles(string dir)
        {
            return 0;
        }
        public int RemoveTemporaryFiles(string dir)
        {
            throw new NotImplementedException();
        }
    }
}
