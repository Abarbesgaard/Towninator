using TowninatorCLI.Model;
using TowninatorCLI.Model.EventModel;
using TowninatorCLI.Repositories;
using TowninatorCLI.Utilities.Events;

namespace TowninatorCLI.Controller;

public class GameController(string dbFileName)
{
    private readonly TownsfolkRepository _townsfolkRepository = new(dbFileName);
    private readonly EventController _eventController = new(dbFileName);


    public void StartGameLoop()
    {
       var continueGame = true;
       while (continueGame)
       {
           var townsfolk = _townsfolkRepository.GetAll();

           // Iterate through each townsfolk and generate events for them
           foreach (var tf in townsfolk)
           {
               var eventModel = _eventController.GenerateEventForTownsfolk(tf);
            
               // Display the event and choices for the current townsfolk
               DisplayEventAndChoices(eventModel, tf);
           }
           Console.WriteLine("Would you like to continue? (Y/N)");
           var input = Console.ReadLine();
           continueGame = input?.ToLower() == "y";
       }
    }

    private void DisplayEventAndChoices(EventModel eventModel, Townsfolk townsfolk)
    {
        // Check if eventModel or townsfolk are null
        if (eventModel == null)
        {
            throw new ArgumentNullException(nameof(eventModel), "EventModel cannot be null.");
        }
        if (townsfolk == null)
        {
            throw new ArgumentNullException(nameof(townsfolk), "Townsfolk cannot be null.");
        }

        Console.WriteLine($"Event: {eventModel.Name}");
    
        if (eventModel.SubEvent is { Count: > 0 })
        {
            Console.WriteLine("Sub-events:");
            foreach (var subEvent in eventModel.SubEvent)
            {
                Console.WriteLine($"- {subEvent.Name}");
            }
        }
    
        Console.WriteLine($"Description: {eventModel.Description}");
        Console.WriteLine("Choose an option:");
        Console.WriteLine("1. Option 1");
        Console.WriteLine("2. Option 2");
        Console.WriteLine("3. Option 3");

        var choice = Console.ReadLine();
        if (choice != null) ProcessChoice(choice, eventModel, townsfolk);
    }


    private void ProcessChoice(string choice, EventModel? eventModel, Townsfolk townsfolk)
    {
        switch (choice)
        {
            case "1":
                Console.WriteLine("You chose option 1.");
                // Implement logic for option 1
                break;
            case "2":
                Console.WriteLine("You chose option 2.");
                // Implement logic for option 2
                break;
            case "3":
                Console.WriteLine("You chose option 3.");
                // Implement logic for option 3
                break;
            default:
                Console.WriteLine("Invalid choice. Please choose again.");
                DisplayEventAndChoices(eventModel, townsfolk);
                break;
        }
    }}