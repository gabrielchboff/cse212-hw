public static class MysteryStack2 {
    private static bool IsFloat(string text) {
        return float.TryParse(text, out _);
    }

    public static float Run(string text) {
        // "5 3 7 + *"
        var stack = new Stack<float>();
        foreach (var item in text.Split(' ')) {
            // text.Split = ["5", "3", "7", "+", "*"]
            if (item == "+" || item == "-" || item == "*" || item == "/") {
                if (stack.Count < 2)
                    throw new ApplicationException("Invalid Case 1!");
                    // It is not possible make operations with one number

                var op2 = stack.Pop(); // pops 7.0 - 5.0
                var op1 = stack.Pop(); // pops 3.0 - 0.0 -> no numbers are available
                float res;
                if (item == "+") {
                    res = op1 + op2;
                    // 7.0 + 3.0 = 10.0
                }
                else if (item == "-") {
                    res = op1 - op2;
                }
                else if (item == "*") {
                    res = op1 * op2; // 0.0
                }
                else {
                    if (op2 == 0)
                        throw new ApplicationException("Invalid Case 2!");
                        // division by 0 is not possible

                    res = op1 / op2;
                }

                stack.Push(res);
            }
            else if (IsFloat(item)) {
                stack.Push(float.Parse(item));
                // stack = { 5.0, } ... { 5.0, 3.0 } ... { 5.0 , 3.0, 7.0 }
            }
            else if (item == "") {
            }
            else {
                throw new ApplicationException("Invalid Case 3!");
                // If its not a number
            }
        }

        if (stack.Count != 1)
            throw new ApplicationException("Invalid Case 4!");
            // Its empty the stack or have more numbers for operations

        return stack.Pop(); // pops again
    }
}