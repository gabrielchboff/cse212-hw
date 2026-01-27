public static class MysteryStack1 {
    //This algo is usefull to invert words
    public static string Run(string text) {
        // text = null;
        var stack = new Stack<char>();  // { }
        foreach (var letter in text)
            stack.Push(letter);
            // It pushes to the stack each letter in the text
            // racecar: r - a - c - e - c - a - r
            // stressed: s - t - r - e - s - s - e - d
            // a nut for a jar of tuna: 
            // a - " " - n - u - t - " " - f - o - r - " " - a - " " - j - a - r - " " - o - f
            //- " " - t - u - n - a

        var result = "";
        while (stack.Count > 0)
            result += stack.Pop();
            // Pop the last letter into the result string
            // r - a - c - e - c - a - r
            // d - e - s - s - e - r - t - s 
            // anut fo raj a rof tun a
            
        return result; 
        // racecar
        // desserts
        //anut fo raj a rof tun a
    }
}