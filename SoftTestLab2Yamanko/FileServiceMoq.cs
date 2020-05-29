using System;

namespace SoftTestLab2Yamanko
{
    class FileServiceMoq
    {
        public int RemoveFilesIdDirectory(IFileService fileService)
        {
            return fileService.RemoveTemporaryFiles("DSDS");
        }

        public int RemoveFilesIdDirectoryExp(IFileService fileService)
        {
            throw new ArgumentException();
        }

    }
}
