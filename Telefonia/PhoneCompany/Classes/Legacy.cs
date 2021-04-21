using Utilities;

public class Legacy:Cellphone
{

    public Legacy(string number):base(number){}


    //This function add airtime to the phone
    public override (string costoTuple, string descriptionTuple) RechargeAirTime()
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

    public override (string costoTuple, string descriptionTuple) MakeCall(double minutes, string callee)
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

    public override (string costoTuple, string descriptionTuple) SendSMS(string words, string receiver)
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

}