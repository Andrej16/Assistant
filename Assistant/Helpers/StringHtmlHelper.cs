namespace Assistant.Helpers
{
    public class StringHtmlHelper
    {
        public static bool FindTagRangeById(string html, string id, out int start, out int end)
        {
            start = 0;
            end = 0;

            string textToFind = $"id=\"{id}\"";
            string tagName = string.Empty;

            if (!html.Contains(textToFind))
                return false;

            int intermediateIndex = html.IndexOf(textToFind);

            for (int i = intermediateIndex; ; i--)
            {
                if (html[i] == '<')
                {
                    start = i;
                    break;
                }
            }

            if (start == 0)
                return false;

            for (int j = start + 1; ; j++)
            {
                if (html[j] == ' ')
                    break;

                tagName += html[j];
            }

            if (string.IsNullOrEmpty(tagName))
                return false;

            string closingTagPattern = $"/{tagName}>";

            end = html.IndexOf(closingTagPattern, intermediateIndex);
            end += closingTagPattern.Length;

            return true;
        }
    }
}
