# links_of_URL
Displays every href link of a supplied page.

This program does the following:

It prompts the user to enter a URL.
It uses the WebClient class to download the HTML content of the specified URL.
It uses a regular expression to find all <a> tags with href attributes in the HTML content.
It extracts the URLs from the href attributes and resolves relative URLs to absolute URLs.
It removes duplicate links and prints the list of unique links found on the page.
Here's a breakdown of the main components:

GetLinksFromUrl: This method uses WebClient to download the HTML content of the given URL.
ExtractLinksFromHtml: This method uses a regular expression to find all links in the HTML content. It also handles relative URLs by resolving them against the base URL.
PrintLinks: This method prints the list of unique links found on the page.
Note that this implementation has some limitations:

It doesn't handle JavaScript-generated links or links added dynamically to the page.
The regular expression used for link extraction is simple and may not cover all possible variations of HTML link syntax.
It doesn't respect robots.txt or implement any rate limiting.
It doesn't handle potential encoding issues that might arise with certain websites.
For a more robust solution, you might want to consider:

Implementing proper HTML parsing (which typically requires a third-party library for best results).
Adding error handling for network issues or invalid HTML.
Implementing respect for robots.txt and rate limiting.
Handling different character encodings properly.
