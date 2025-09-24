using System;

namespace DocWaitRoomProg;

public class WaitingRoom
{
    public Action<int>? NumberChange { get; set; }
    private int currentNumber = 0;
    private int ticketCount = 0;

    public void RunWaitingRoom()
    {
        while (currentNumber < ticketCount)
        {
            currentNumber++;
            Console.WriteLine($"Now serving number {currentNumber}");
            NumberChange?.Invoke(currentNumber);
            Thread.Sleep(2000);
        }
    }

    public int DrawNumber()
    {
        ticketCount++;
        Console.WriteLine($"Patient {ticketCount} enters the waiting room");
        return ticketCount;
    }
    

}
