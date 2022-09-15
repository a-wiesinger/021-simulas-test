/*
Simula's Test
:: Enumerations (Using External Files) ::
*/

// Challenge Criteria:
// -------------
// DONE - Define enumeration with starting state of chest
// DONE - Create a variable with said enum as that variable's type
// DONE - Manipulate chest that MUST follow the following rules:
    // Open > Closed > Locked
    // Locked > Closed > Open
// DONE - Loop forever asking for the the next command

using Chest; // Defined in Models dir

Console.Title = "Simula's Test";
Console.Clear();

AppLoop();

void AppLoop()
{
    ChestPhase chestPhase = ChestPhase.Locked;

    while (true)
    {
        PrintValidResponses();

        PrintQuestionToUser(chestPhase);

        chestPhase = UpdateChestPhase(chestPhase, GetUserResponse());
    }
}

void PrintQuestionToUser(ChestPhase chestPhase)
{
    Console.Write($"The chest is {GetChestPhase(chestPhase)}. What do you want to do? ");
}

void PrintValidResponses()
{
    string validResponses = "The following commands are valid: open, close, lock, unlock";
    Console.WriteLine(validResponses);
}

string? GetUserResponse()
{
    string? response = Console.ReadLine();
    return response;
}

ChestPhase UpdateChestPhase(ChestPhase chestPhase, string? response)
{
    switch (response)
    {
        case "open":
            if (chestPhase == ChestPhase.Closed)
            {
                chestPhase = ChestPhase.Open;
                return chestPhase;
            }
            else
            {
                return chestPhase;
            }
        case "close":
            if (chestPhase == ChestPhase.Open)
            {
                chestPhase = ChestPhase.Closed;
                return chestPhase;
            }
            else
            {
                return chestPhase;
            }
        case "lock":
            if (chestPhase == ChestPhase.Closed)
            {
                chestPhase = ChestPhase.Locked;
                return chestPhase;
            }
            else
            {
                return chestPhase;
            }
        case "unlock":
            if (chestPhase == ChestPhase.Locked)
            {
                chestPhase = ChestPhase.Closed;
                return chestPhase;
            }
            else
            {
                return chestPhase;
            }
        default:
            return chestPhase;
    }
}

string GetChestPhase(ChestPhase chestPhase)
{
    switch (chestPhase)
    {
        case ChestPhase.Open:
            return "open";
        case ChestPhase.Closed:
            return "closed";
        case ChestPhase.Locked:
            return "locked";
        case ChestPhase.Unlocked:
            return "unlocked";
        default:
            return "locked";
    }
}
