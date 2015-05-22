# counted-stream
CountedStream is a simple wrapper that allows you to count bytes written to a stream:

```c#
var memStream = new MemoryStream();
var countedStream = new CountedStream(memStream);

countedStream.Write(new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 0, 10);

Console.WriteLine(countedStream.WrittenBytes); // 10

```
