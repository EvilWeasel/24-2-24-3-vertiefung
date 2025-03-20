var person1 = new Person("Max", "Mustermann");
var person2 = new Person("Melanie", "Musterfrau");
Console.WriteLine(person1);
Console.WriteLine(person2);

var page = SingletonPage.Instance;
page.Title = "MainPage";
Console.WriteLine(page);
var pageOther = SingletonPage.Instance;
pageOther.Title = "PageOther";
Console.WriteLine(pageOther);
Console.WriteLine(page);
Console.WriteLine(page == pageOther);


class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Person(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }
}
class SingletonPage
{
    private static SingletonPage? instance = null;
    public static SingletonPage Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new SingletonPage();
            }
            return instance;
        }
    }
    public string Title { get; set; }
    private SingletonPage()
    {
    }
    public override string ToString()
    {
        return Title;
    }
}