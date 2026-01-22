using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        // HashSet to track words we've processed to find symmetric pairs
        // Using HashSet for O(1) average case lookups
        var seen = new HashSet<string>();
        var result = new List<string>();

        // Process each word in the input array
        foreach (string word in words)
        {
            // Skip words with identical characters as they can't form symmetric pairs
            // ("aa" would only pair with itself, which would be a duplicate)
            if (word[0] == word[1])
                continue;

            // Create the reverse of the current word (e.g., "am" -> "ma")
            string reversed = $"{word[1]}{word[0]}";
            
            // If we've already seen the reversed word, we've found a symmetric pair
            if (seen.Contains(reversed))
            {
                // Add the pair in the format "word1 & word2"
                result.Add($"{reversed} & {word}");
            }
            else
            {
                // Add current word to the set for future lookups
                seen.Add(word);
            }
        }

        return result.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        // Initialize a dictionary to store degree counts
        var degrees = new Dictionary<string, int>();

        // Process each line in the file
        foreach (var line in File.ReadLines(filename))
        {
            // Split the CSV line into individual fields
            var fields = line.Split(',');
        
            // Ensure the line has at least 4 columns (0-3)
            if (fields.Length > 3) 
            {
                // Extract and clean the degree from the 4th column (index 3)
                string degree = fields[3].Trim();
            
                // Skip empty degree entries
                if (!string.IsNullOrEmpty(degree))
                {
                    // Update the count for this degree in the dictionary
                    if (degrees.ContainsKey(degree))
                    {
                        // Increment count if degree already exists
                        degrees[degree]++;
                    }
                    else
                    {
                        // Initialize count to 1 for new degrees
                        degrees[degree] = 1;
                    }
                }
            }
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        if (word1 == null || word2 == null)
            return false;

        // Dictionary to count character frequencies
        var charCount = new Dictionary<char, int>();

        // Process word1: increment counts (ignore whitespace, use lowercase)
        foreach (char c in word1)
        {
            if (!char.IsWhiteSpace(c))
            {
                char lower = char.ToLower(c);
                if (charCount.ContainsKey(lower))
                    charCount[lower]++;
                else
                    charCount[lower] = 1;
            }
        }

        // Process word2: decrement counts (ignore whitespace, use lowercase)
        foreach (char c in word2)
        {
            if (!char.IsWhiteSpace(c))
            {
                char lower = char.ToLower(c);
                if (charCount.ContainsKey(lower))
                    charCount[lower]--;
                else
                    charCount[lower] = -1;
            }
        }

        // Check if all counts are zero
        foreach (var count in charCount.Values)
        {
            if (count != 0)
                return false;
        }

        return true;
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.
        return [];
    }
}