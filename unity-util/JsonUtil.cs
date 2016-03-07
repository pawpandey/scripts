using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

static class JsonUtil
{
    private const string INDENT_STRING = "    ";
    public static string PrettyPrint(string jsonStr)
    {
        var indent = 0;
        var quoted = false;
        var sb = new StringBuilder();
        for (var i = 0; i < jsonStr.Length; i++)
        {
            var ch = jsonStr[i];
            switch (ch)
            {
                case '{':
                case '[':
                sb.Append(ch);
                if (!quoted)
                {
                    sb.AppendLine();
                    ForEach(Enumerable.Range(0, ++indent), item => sb.Append(INDENT_STRING));
                }
                break;
                case '}':
                case ']':
                if (!quoted)
                {
                    sb.AppendLine();
                    ForEach(Enumerable.Range(0, --indent), item => sb.Append(INDENT_STRING));
                }
                sb.Append(ch);
                break;
                case '"':
                sb.Append(ch);
                bool escaped = false;
                var index = i;
                while (index > 0 && jsonStr[--index] == '\\')
                    escaped = !escaped;
                if (!escaped)
                    quoted = !quoted;
                break;
                case ',':
                sb.Append(ch);
                if (!quoted)
                {
                    sb.AppendLine();
                    ForEach(Enumerable.Range(0, indent), item => sb.Append(INDENT_STRING));
                }
                break;
                case ':':
                sb.Append(ch);
                if (!quoted)
                    sb.Append(" ");
                break;
                default:
                sb.Append(ch);
                break;
            }
        }
        return sb.ToString();
    }

    public static void ForEach<T>(IEnumerable<T> ie, Action<T> action)
    {
        foreach (var i in ie)
        {
            action(i);
        }
    }
}
