using AjnalsDotnet;
while (true)
{
    var word = RandomWords.Get();
    var found = new List<int>();
    var incorrect = new List<char>();
    var lives = 12;
    Console.WriteLine("Choose difficulty: (e)asy, (m)edium, (h)ard");
    var difficulty = Console.ReadKey(true);
    switch (difficulty.KeyChar)
    {
        case 'm':
            lives = 10;
            break;
        case 'h':
            lives = 8;
            break;
    }
    while (found.Count != word.Length && incorrect.Count < lives)
    {
        Console.Clear();
        var placeholder = "";
        var remainingLives = lives - incorrect.Count;
        for (int i = 0; i < word.Length; i++)
        {
            if (found.Contains(i))
            {
                placeholder = placeholder + word[i];
            }
            else
            {
                placeholder = placeholder + "_";
            }
        }
        Console.WriteLine(placeholder);
        Console.WriteLine("Remaining lives: " + remainingLives + " of " + lives);
        if (incorrect.Count > 0)
        {
            Console.WriteLine("Already guessed: " + string.Join(", ", incorrect));
        }
        var userInput = Console.ReadKey(true);
        if (word.Contains(userInput.KeyChar))
        {
            for (int position = 0; position < word.Length; position++)
            {
                var letter = char.ToLower(word[position]);
                if (letter == userInput.KeyChar && !found.Contains(position))
                {
                    found.Add(position);
                }
            }
        }
        else
        {
            incorrect.Add(userInput.KeyChar);
            Console.WriteLine("Wrong! Press any key to continue.");
            Console.ReadKey(true);
        }

    }
    if (found.Count == word.Length)
    {
        Console.WriteLine("Found the word: " + word);
    }
    Console.WriteLine("Would you like to try again? (y)es, (n)o");
    var input = Console.ReadKey(true);
    if (input.KeyChar.ToString().ToLower() == "p")
    {
        Console.WriteLine(" --- ");
        Console.WriteLine("Wow, you have been blessed by the hairy potato cat");
        Console.WriteLine(" --- ");
    }
    else if (input.KeyChar.ToString().ToLower() != "y")
    {
        break;
    }
}