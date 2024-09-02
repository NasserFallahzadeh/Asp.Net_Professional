using System.Collections;

namespace ConsoleApp.TestData;

public class MemberClassData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return [8, 3, 11];
        yield return [3, 1, 4];
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}