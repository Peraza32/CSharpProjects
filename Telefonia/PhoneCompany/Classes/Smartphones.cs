using Utilities;

public class Smartphones : Cellphone
{
    //Attibutes
    private double Version {get; set;}
    private double _webData;
    private double _socialData;
    private int _songsAvailable;
    

    //Constructor
    public Smartphones(string number, double version):base(number)
    {
        this.Version = version;
        this._webData = 0;
        this._socialData = 0;
        this._songsAvailable = 0;
    }

    public Smartphones(string number) : base(number)
    {
        this.Version = 0.0;
        this._webData = 0;
        this._socialData = 0;
        this._songsAvailable = 0;
    }

    //Properties
    public double WebData
    {
        get {return this._webData;}
        set 
        {
            //Valdiation for negative numbers 
            if( value < 0)
                throw new System.ArgumentOutOfRangeException(
                    $"{nameof(value)} cannot be a negative value"
                );

            this._webData = value;
        }
    }

    public double SocialData
    {
        get {return this._socialData;}
        set 
        {
            //Valdiation for negative numbers 
            if( value < 0)
                throw new System.ArgumentOutOfRangeException(
                    $"{nameof(value)} cannot be a negative value"
                );

            this._socialData = value;
        }
    }

    public int SongsAvailable
    {
        get {return this._songsAvailable;}
        set 
        {
            //Valdiation for negative numbers 
            if( value < 0)
                throw new System.ArgumentOutOfRangeException(
                    $"{nameof(value)} cannot be a negative value"
                );

            this._songsAvailable = value;
        }
    }
    
    //Methods
    public override (string costoTuple, string descriptionTuple) RechargeAirTime() //This function add airtime to the phone
    {
        try
        {
            double airtime = 0;
            System.Console.WriteLine("How much air time are you going to purchase?");
            //validaton that the amount that is added is a valid double value
            airtime = Tools.NumberValidation<double>(1.0, double.MaxValue, Tools.InRange, "Amount to purchase $: ");
            System.Console.WriteLine($"${airtime} has been added succesfully");
            this.AirTime += airtime; //We add the new airtime to the old one
            System.Console.WriteLine($"New airtime  available is {this.AirTime}");

            return (airtime.ToString(), "RechargeAirTime");
        }
        catch (System.Exception e)
        {
            System.Console.WriteLine(e.Message);
            throw;
        }
    
    }

    public (string costoTuple, string descriptionTuple) RechargeInternetData() //This function recharge internet data to the phone
    {
        try
        {
            double webData = 0;
            System.Console.WriteLine("How much internet data are you going to purchase?");
            //validaton that the amount that is added is a valid double value
            webData = Tools.NumberValidation<double>(1.0, double.MaxValue, Tools.InRange, "Amount to purchase $: ");
            System.Console.WriteLine($"${webData} has been added succesfully");
            this.WebData += webData; //We add the new internet data to the old one
            System.Console.WriteLine($"New internet data  available is {this.WebData}");

            return (webData.ToString(), "RechargeInternetData");
        }
        catch (System.Exception e)
        {
            System.Console.WriteLine(e.Message);
            throw;
        }
    }

    public (string costoTuple, string descriptionTuple) RechargeSocialMedia() //This function recharge social data to the phone
    {
        try
        {
            double socialData = 0;
            System.Console.WriteLine("How much social data are you going to purchase?");
            //validaton that the amount that is added is a valid double value
            socialData = Tools.NumberValidation<double>(1.0, double.MaxValue, Tools.InRange, "Amount to purchase $: ");
            System.Console.WriteLine($"${socialData} has been added succesfully");
            this.SocialData += socialData; //We add the new social data to the old one
            System.Console.WriteLine($"New internet data  available is {this.SocialData}");

            return (socialData.ToString(), "RechargeSocialMedia");
        }
        catch (System.Exception e)
        {
            System.Console.WriteLine(e.Message);
            throw;
        }
    }

    public override (string costoTuple, string descriptionTuple) MakeCall(double minutes, string callee) //This function is to make a call
    {
        try
        {
            double airTimeDeduction = Cellphone.minuteCost * minutes;

            //Validation that airtime soesn't goes negative due to a call with a cost greater than the airtime
            if(this.AirTime >= airTimeDeduction)
            {
                System.Console.WriteLine("Making a call to {0}", callee);
                System.Console.WriteLine("Calling...");
                System.Threading.Thread.Sleep(400);
                System.Console.WriteLine("Call has ended");
                System.Console.WriteLine($"Cost of the call ${airTimeDeduction}. ");
                this.AirTime -= airTimeDeduction;
                System.Console.WriteLine($"Airtime remaining: {this.AirTime}");
                
                if (this.AirTime == 0.0)
                {
                    System.Console.WriteLine("Please make a recharge");
                }

                return (airTimeDeduction.ToString(), "MakeCall");
            }
            else
            {
                System.Console.WriteLine("Not enough airtime, please recharge airtime");
                System.Console.WriteLine("Cost of the call: ${0}", airTimeDeduction);
                System.Console.WriteLine("Actual airtime: ${0}", this.AirTime);

                return ("Not enough", "MakeCall");
            }
            
        }
        catch(System.Exception e)
        {
            System.Console.WriteLine(e.Message);
            throw;
        }
    }

    public override (string costoTuple, string descriptionTuple) SendSMS(string words, string receiver) //This function is to send a SMS
    {
        try
        {
            double airTimeDeduction =  Cellphone.characterCost * words.Length;

            //Validation that airtime soesn't goes negative due to a call with a cost greater than the airtime
            if (this.AirTime >= airTimeDeduction)
            {
                System.Console.WriteLine("Sending a message to {0}", receiver);
                System.Console.WriteLine("Sending SMS...");
                System.Threading.Thread.Sleep(400);
                System.Console.WriteLine("Message has been sent");
                System.Console.WriteLine($"Cost of the SMS ${airTimeDeduction}. ");
                this.AirTime -= airTimeDeduction;
                System.Console.WriteLine($"Airtime remaining: {this.AirTime}");

                if(this.AirTime == 0.0)
                {
                    System.Console.WriteLine("Please make a recharge");
                }

                return (airTimeDeduction.ToString(), "SendSMS");
            }
            else
            {
                System.Console.WriteLine("Not enough airtime, please recharge airtime");
                System.Console.WriteLine("Cost of the SMS: ${0}", airTimeDeduction);
                System.Console.WriteLine("Actual airtime: ${0}", this.AirTime);

                return ("Not enough", "SendSMS");
            }

        }
        catch (System.Exception e)
        {
            System.Console.WriteLine(e.Message);
            throw;
        }
    }

    public (string costoTuple, string descriptionTuple) InternetBrowsing(double pages) //This function discount internet data from the phone by use
    {
        try
        {
            double webDataDeduction = Cellphone.webCost * pages;

            //Validation that WebData does not goes negative due to a internet browsing with a cost greater than the webDataDeduction
            if(this.WebData >= webDataDeduction)
            {
                System.Console.WriteLine("Browsing", pages, " internet pages");
                System.Threading.Thread.Sleep(400);
                System.Console.WriteLine("Internet browsing ended");
                System.Console.WriteLine($"Cost of the web browsing ${webDataDeduction}.");
                this.WebData -= webDataDeduction;
                System.Console.WriteLine($"Internet data remaining: {this.WebData}");

                if (this.WebData == 0.0)
                {
                    System.Console.WriteLine("Please make a recharge");
                }

                return (webDataDeduction.ToString(), "InternetBrowsing");
            }
            else
            {
                System.Console.WriteLine("Not enough internet data, please recharge");
                System.Console.WriteLine("Cost of this service: ${0}", webDataDeduction);
                System.Console.WriteLine("Actual internet data: ${0}", this.WebData);

                return ("Not enough", "InternetBrowsing");
            }
            
        }
        catch(System.Exception e)
        {
            System.Console.WriteLine(e.Message);
            throw;
        }
    }

    public (string costoTuple, string descriptionTuple) SocialMediaNav(double minutes) //This function discount social data from the phone by use
    {
        try
        {
            double socialDataDeduction = Cellphone.socialCost * minutes;

            //Validation that SocialData does not goes negative due to a social use with a cost greater than the socialDataDeduction
            if(this.SocialData >= socialDataDeduction)
            {
                System.Console.WriteLine("Browsing ", minutes, " in social media");
                System.Threading.Thread.Sleep(400);
                System.Console.WriteLine("Social media browsing ended");
                System.Console.WriteLine($"Cost of the social media browsing ${socialDataDeduction}.");
                this.SocialData -= socialDataDeduction;
                System.Console.WriteLine($"Social media data remaining: {this.SocialData}");

                if (this.SocialData == 0.0)
                {
                    System.Console.WriteLine("Please make a recharge");
                }

                return (socialDataDeduction.ToString(), "SocialMediaNav");
            }
            else
            {
                System.Console.WriteLine("Not enough social media data, please recharge");
                System.Console.WriteLine("Cost of this service: ${0}", socialDataDeduction);
                System.Console.WriteLine("Actual social media data: ${0}", this.SocialData);

                return ("Not enough", "SocialMediaNav");
            }
            
        }
        catch(System.Exception e)
        {
            System.Console.WriteLine(e.Message);
            throw;
        }
    }
}