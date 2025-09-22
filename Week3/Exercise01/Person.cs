using System;

namespace Exercise01;

public class Person
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public int age { get; set; }
    public double height { get; set; }
    public bool isMarried { get; set; }
    public char Sex { get; set; }
    public string[] Hobbies { get; set; }

    public Person(string firstName, string lastName, int age, double height, bool isMarried, char Sex, string[] hobbies)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
        this.height = height;
        this.isMarried = isMarried;
        this.Sex = Sex;
        this.Hobbies = hobbies;
    }

    public override string ToString()
    {
        return $"First Name: {firstName}, Last Name: {lastName}, Age: {age}, Height: {height}, Is Married: {isMarried}, Sex:{Sex}, Hobbies: [{string.Join(", ", Hobbies)}]";
    }

}
