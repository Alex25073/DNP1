using System;

namespace DocWaitRoomProg;

public class Patient
{
    int numberInQueue;

    public Patient(WaitingRoom wr)
    {
        numberInQueue = wr.DrawNumber();
        wr.NumberChange += ReactToNumber;
    }

    public void ReactToNumber(int currentNumber)
    {
        if (currentNumber == numberInQueue)
        {
            Console.WriteLine($"Patient {numberInQueue} looks up");
            Console.WriteLine($"Patient {numberInQueue} goes in the doctor's office");
        }
        else if (currentNumber < numberInQueue)
        {
            Console.WriteLine($"Patient {numberInQueue} looks up");
            Console.WriteLine($"Patient {numberInQueue} goes back looking at the phone");
        }
    }

}
