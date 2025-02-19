
namespace LAB_3

    public class program
{
    public static void Main(string[] args) 
    {
        Task1();
        task2();
        task3();
    }

    //Це завдання №1
    private static void Task1()
    {
        int user_age = 18;
        string UserName = "Микита";

        Console.WriteLine("ПРИВІТ, " + UserName "! Твій вік: " + user_age);
    }

    //Це завдання №2
    private static void task2()
    {
        int int = 10;
        string class = "Ні";
            bool new = true;

            Console.WriteLine(int + " " + class + " " + new);
       }
    
       //Це завдання №3
       private static void task3()
    {
        string name = "Анастасія";
        int age = 25;
        Console.WriteLine("ПРИВІТ, " + name + "! Твій вік: " + age);
    }

}
}