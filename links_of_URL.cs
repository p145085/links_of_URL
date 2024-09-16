using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter the URL to analyze: ");
        string url = Console.ReadLine();

        try
        {
            List<string> links = GetLinksFromUrl(url);
            PrintLinks(links);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    static List<string> GetLinksFromUrl(string url)
    {
        using (WebClient client = new WebClient())
        {
            string html = client.DownloadString(url);
            return ExtractLinksFromHtml(html, url);
        }
    }

    static List<string> ExtractLinksFromHtml(string html, string baseUrl)
    {
        List<string> links = new List<string>();
        string pattern = @"<a\s+(?:[^>]*?\s+)?href=""([^""]*)""";

        MatchCollection matches = Regex.Matches(html, pattern, RegexOptions.IgnoreCase);

        foreach (Match match in matches)
        {
            string href = match.Groups[1].Value;
            if (!string.IsNullOrWhiteSpace(href))
            {
                // Resolve relative URLs
                Uri resolvedUri = new Uri(new Uri(baseUrl), href);
                links.Add(resolvedUri.AbsoluteUri);
            }
        }

        return links.Distinct().ToList();
    }

    static void PrintLinks(List<string> links)
    {
        Console.WriteLine($"Found {links.Count} unique links:");
        foreach (string link in links)
        {
            Console.WriteLine(link);
        }
    }
}
