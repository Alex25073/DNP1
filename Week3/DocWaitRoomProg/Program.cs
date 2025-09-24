 
 namespace DocWaitRoomProg;

class Program
{
    static void Main(string[] args)
    {
        WaitingRoom wr = new WaitingRoom();
        Patient p1 = new Patient(wr);
        Patient p2 = new Patient(wr);
        Patient p3 = new Patient(wr);
        wr.RunWaitingRoom();
    }
}