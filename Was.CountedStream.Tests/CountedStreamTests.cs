namespace Was.CountedStream.Tests
{
    using System;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CountedStreamTests
    {
        [TestMethod]
        public void Write_Write10Bytes_Returns10Bytes()
        {
            var memStream = new MemoryStream();
            var countedStream = new CountedStream(memStream);

            countedStream.Write(new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 0, 10);

            var writtenBytes = countedStream.WrittenBytes;

            Assert.AreEqual(10, writtenBytes);
        }

        [TestMethod]
        public void WriteByte_Twice_SetsWrittenByteTo2()
        {
            var memStream = new MemoryStream();
            var countedStream = new CountedStream(memStream);

            countedStream.WriteByte(1);
            countedStream.WriteByte(10);

            var writtenBytes = countedStream.WrittenBytes;
            Assert.AreEqual(2, writtenBytes);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_EmptyStream_ThrowsArgNullException()
        {
            new CountedStream(null);
        }

        [TestMethod]
        public void BaseMetaProperties_OfWrapperStream_AreTheSame()
        {
            var mem = new MemoryStream();
            mem.WriteByte(1);

            var s = new CountedStream(mem);

            Assert.AreEqual(mem.CanRead, s.CanRead);
            Assert.AreEqual(mem.CanSeek, s.CanSeek);
            Assert.AreEqual(mem.CanWrite, s.CanWrite);
            Assert.AreEqual(mem.CanTimeout, s.CanTimeout);
            Assert.AreEqual(mem.Length, s.Length);
            Assert.AreEqual(mem.Position, s.Position);
        }


    }
}
