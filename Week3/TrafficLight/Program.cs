
using TrafficLight;

namespace TrafficLight;

public class Program
{
    public static void Main()
    {
        TrafficLight tl = new TrafficLight();
        Car car1 = new Car(tl, 1);
        Car car2 = new Car(tl, 2);
        Taxi taxi1 = new Taxi(tl, 1);
        Pedestrian ped1 = new Pedestrian(tl, 1);
        tl.RunTrafficLight();
    }
}
