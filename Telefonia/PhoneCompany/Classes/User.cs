
using Utilities;
public class User
{
    //Attributes
    public string UserFirstName { get; set; }
    public string UserLastName { get; set; }

    public string Dui { get; set; }

    public string Nit { get; set; }

    public string BirthDate { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public  System.Collections.Generic.List<Cellphone>  Cellphones{set;get;}

    public System.Collections.Generic.List<Movements> History{set;get;} 

    //Constructor

    public User(string userName, string dui, string nit, string birthDate, 
    string email, string password, System.Collections.Generic.List<Cellphone> cellphones,
    System.Collections.Generic.List<Movements> history) 
    {
        this.UserFirstName = userName;
        this.Dui = dui;
        this.Nit = nit;
        this.BirthDate = birthDate;
        this.Email = email;
        this.Password = password;
        this.Cellphones = cellphones;
        this.History = history;
    }

    public User()
    {
        this.UserFirstName = string.Empty;
        this.UserLastName = string.Empty;
        this.Dui =string.Empty;
        this.Nit = string.Empty;
        this.BirthDate = string.Empty;
        this.Email = string.Empty;
        this.Password = string.Empty;
        
    }

    //Properties 
    


    //Methods
    //Add a new cellphone according to the preference of the client.
    public void AddCellphone()
    {
        int opc = 0;
        double version = 0;
        string  brand = string.Empty, 
                model = string.Empty; 
        string newPhoneNumber = Generator.GeneratePhoneNumber();
        System.Collections.Generic.List<string> models = new System.Collections.Generic.List<string>();
        models.Add("Legacy");
        models.Add("Smartphone: Android");
        models.Add("Smartphone: IOS");


        System.Console.WriteLine("Let's add another cellphone");
        System.Console.WriteLine("Select the type");
        opc = Tools.Menu(models);
        switch(opc)
        {
            case 1:
                //Addinga legacy phone 
                
                Legacy oldSchool = new Legacy(newPhoneNumber);
                System.Console.WriteLine("new Legacy cellphone added");
                System.Console.WriteLine("New phone Number is {0}",newPhoneNumber);
                this.Cellphones.Add(oldSchool);
                break;

            case 2: //Adding android phone, with its attributes
                System.Console.WriteLine("New Android phone");
                version = Tools.NumberValidation<double>(1.0,10.0, Tools.InRange,"Please add the Operative System Version");
                brand = Tools.StringValidator("Please input the brand of the new android phone");
                model = Tools.StringValidator("Please input the model of the new android phone");
                Android androidPhone = new Android(newPhoneNumber,version,brand, model);
                this.Cellphones.Add(androidPhone);
                System.Console.WriteLine("New Android phone added");
                break;

            case 3://Adding IOS phone, with its attributes
                System.Console.WriteLine("New IOS phone");
                version = Tools.NumberValidation<double>(1.0, 10.0, Tools.InRange, "Please add the Operative System Version");
                IOS iosPhone = new IOS(newPhoneNumber, version, this.UserFirstName, this.UserLastName);
                this.Cellphones.Add(iosPhone);
                System.Console.WriteLine("New IOS phone added");
                break;

            case 4:
                System.Console.WriteLine("Process Finished");
                break;

            default:
                System.Console.WriteLine("How do I get here?");
                break;
        }
          
    }

    public void ShowHistory()
    {
        System.Console.WriteLine("History of transactions for {0} {1}", this.UserFirstName, this.UserLastName);
        foreach(Movements movement in this.History)
        {
            System.Console.WriteLine($"Description: {movement.Description}   Cost: {movement.Value}");
        }
        System.Console.WriteLine("End of file for {0} {1}", this.UserFirstName, this.UserLastName);
    }

    public void Recharge(Cellphone cel){};
    public void CallSomeone(Cellphone cel){};
    public void TextSomeone(Cellphone cel) { };
    public void ListenMudic(Cellphone cel) { };

    public void DisplayCellphones()
    {
        
    }

    public bool Authentication(){};

    public void UseCellphone(){};

    private void AddRegister(Movements movement){};


}