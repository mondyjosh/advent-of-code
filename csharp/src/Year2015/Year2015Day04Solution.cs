namespace AdventOfCode.Year2015;

using System.Security.Cryptography;
using System.Text;

class Year2015Day04Solution : ISolution
{
    public int SolvePart1(string input) => ComputeMD5ZeroPrefixHash(input, 5);

    public int SolvePart2(string input) => ComputeMD5ZeroPrefixHash(input, 6);

    private static int ComputeMD5ZeroPrefixHash(string input, int zeroLength)
    {
        int zeroHashIndex = 0;
        var zeroKey = new String('0', zeroLength);
        var check = string.Empty;

        do
        {
            byte[] bytes = _md5.ComputeHash(Encoding.UTF8.GetBytes($"{input}{zeroHashIndex}"));
            
            check = BitConverter.ToString(bytes)
                .Replace("-", string.Empty)
                .Substring(0, zeroLength);

            if (check.Equals(zeroKey))
                break;

            zeroHashIndex++;
        } while (!check.Equals(zeroKey));

        return zeroHashIndex;
    }

    private static readonly MD5 _md5 = MD5.Create();
}
