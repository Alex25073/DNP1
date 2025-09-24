using System;

namespace TrafficLight;

public class Pedestrian
{
    public int id;

    public Pedestrian(TrafficLight tl, int id)
    {
        this.id = id;
        tl.OnLightChange += ReactToLight;
    }

    private void ReactToLight(string color)
    {
        string result = $"Pedestrian {id} ";
        switch (color)
        {
            case "GREEN":
                result += " waits";
                break;
            case "YELLOW":
                result += " gets ready";
                break;
            case "RED":
                result += " walks across the street";
                break;
        }
        Console.WriteLine(result);
    }

}
