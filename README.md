# CountedStream
CountedStream is a simple wrapper that allows you to count bytes written to a stream:

available on nuget: https://www.nuget.org/packages/Was.CountedStream/0.0.1.1

```c#
var memStream = new MemoryStream();
var countedStream = new CountedStream(memStream);

countedStream.Write(new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 0, 10);

Console.WriteLine(countedStream.WrittenBytes); // 10

```
