// See https://aka.ms/new-console-template for more information
using System.Text;

Solution s = new Solution();
string s1 = "cgokcgerolkgksgbhgmaaealacnsshofjinidiigbjerdnkolc";
string s2 = "rjjlkbmnprkslilqmbnlasardrossiogrcboomrbcmgmglsrsj";
string baseStr = "bxbwjlbdazfejdsaacsjgrlxqhiddwaeguxhqoupicyzfeupcn";
var answer = s.SmallestEquivalentString(s1, s2, baseStr);
Console.WriteLine(answer);

public class Solution
{
  public string SmallestEquivalentString(string s1, string s2, string baseStr)
  {
    var map = new List<SortedSet<char>>();
    int i = 0;
    while (i < s1.Length)
    {
      char c1 = s1[i];
      char c2 = s2[i];
      bool found = false;
      foreach (var m in map)
      {
        if (m.Contains(c1) || m.Contains(c2))
        {
          found = true;
          m.Add(c1); m.Add(c2);
          break;
        }
      }
      if (!found)
      {
        map.Add(new SortedSet<char>() { c1, c2 });
      }
      i++;
    }

    var builder = new StringBuilder();
    for (int j = 0; j < baseStr.Length; j++)
    {
      var c = baseStr[j];
      var cc = GetChar(c);
      builder.Append(cc);
    }

    char GetChar(char c)
    {
      char cc = c;
      foreach (var m in map)
      {
        if (m.Contains(c))
        {
          cc = m.First();
          break;
        }
      }

      return cc;
    }

    return builder.ToString();
  }
}
