using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace SoftTestLab2Yamanko
{
    [TestClass]
    public class UnitTest1
    {
        private const string tempFilesDir = "tempFiles";
        StringFormatter strFormatter = new StringFormatter();
        ArrayProcessor arrProcessor = new ArrayProcessor();

        //Rectangle tests
        [TestMethod]
        public void Rectangle_Diagonal_Method_Test()
        {
            double[] arrayOfX = { 1, 4, 1, 4 };
            double[] arrayOfY = { 2, 6, 2, 6 };
            Rectangle rect = new Rectangle(arrayOfX, arrayOfY);
            Assert.AreEqual(rect.Diagonal(), 5);
        }

        [TestMethod]
        public void Rectangle_Diagonal_Method_Exception_Test()
        {
            double[] ArrayX = { -1, 4, 1, 4 };
            double[] ArrayY = { 2, 6, 2, 6 };
            Rectangle rectangle = new Rectangle(ArrayX, ArrayY);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => rectangle.Diagonal());
        }

        //StringFormatter tests
        [TestMethod]
        public void StringFormatter_Test_1()
        {
            Assert.AreEqual(strFormatter.WebString(""), "");
        }

        [TestMethod]
        public void StringFormatter_Test_2()
        {
            Assert.AreEqual(strFormatter.WebString("yamanko.git"), "git://yamanko.git");
        }

        [TestMethod]
        public void StringFormatter_Test_3()
        {
            Assert.AreEqual(strFormatter.WebString("yamanko"), "http://yamanko");
        }

        [TestMethod]
        public void StringFormatter_Test_4()
        {
            Assert.AreEqual(strFormatter.WebString("http://yamanko"), "http://yamanko");
        }

        [TestMethod]
        public void StringFormatter_Exception_Test()
        {
            Assert.ThrowsException<NullReferenceException>(() => strFormatter.WebString(null));
        }

        //ArrayProcessor test
        [TestMethod]
        public void ArrayProcessor_Test()
        {
            int[] a = { 1, 5, 11111, 0, -4850 };
            int[] c = arrProcessor.SortAndFilter(a);
            Assert.AreEqual(c[0], 11111);
        }

        //IFileService stub tests
        [TestMethod]
        public void IFileService_FileServerStub_Test_1()
        {
            IFileService fileService = new FileServerStub();
            Assert.AreEqual(fileService.MergeTemporaryFiles("C:\\Users\\Dmitry\\" + tempFilesDir), 4);

        }

        [TestMethod]
        public void IFileService_FileServerStub_Test_2()
        {
            IFileService fileService = new FileServerStub();
            int deletedBytes = fileService.RemoveTemporaryFiles("C:\\Users\\Dmitry\\" + tempFilesDir);
            Assert.AreEqual(3, deletedBytes);
        }

        [TestMethod]
        public void IFileService_FileServerStub_Test_3()
        {
            IFileService fileService = new FileServerStub();
            int deletedBytes = fileService.RemoveTemporaryFiles(tempFilesDir);
            Assert.AreEqual(3, deletedBytes);
        }

        [TestMethod]
        public void IFileService_FileServerStubStopMetod_Test()
        {
            IFileService fileService = new FileServerStubStopMetod();
            Assert.AreEqual(fileService.MergeTemporaryFiles("C:\\Users\\Dmitry\\" + tempFilesDir), 0);
        }

        [TestMethod]
        public void IFileService_FileServerStubExeption_Test_1()
        {
            IFileService fileService = new FileServerStubExeption();
            Assert.ThrowsException<NullReferenceException>(() => fileService.MergeTemporaryFiles(tempFilesDir));
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void IFileService_FileServerStubExeption_Test_2()
        {
            IFileService fileService = new FileServerStubExeption();
            fileService.RemoveTemporaryFiles(tempFilesDir);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void IFileService_FileServerStubExeption_Test_3()
        {
            IFileService fileService = new FileServerStubExeption();

            fileService.RemoveTemporaryFiles(tempFilesDir);
        }

        //Moq test
        [TestMethod]
        public void IFileServiceTestMoq1()
        {
            var mockInfo = new Mock<IFileService>();
            mockInfo.Setup(d => d.RemoveTemporaryFiles(It.IsAny<string>())).Returns(3);
            FileService fileService = new FileService(mockInfo.Object);
            int temp = fileService.RemoveTemporaryFiles(tempFilesDir);
            Assert.AreEqual(3, temp);
        }

        [TestMethod]
        public void IFileServiceTestMoq2()
        {
            var mockInfo = new Mock<IFileService>();
            mockInfo.Setup(d => d.RemoveTemporaryFiles(It.IsAny<string>())).Throws<ArgumentException>();
            FileService fileService = new FileService(mockInfo.Object);
            Assert.ThrowsException<ArgumentException>(() => fileService.RemoveTemporaryFiles(tempFilesDir));
        }
    }
}
