using Utilities;

public static class Generator
{
    public static string GeneratePhoneNumber()
    {
        int cellphoneGenerated = 0;
        //object used to generate the random phone number
        System.Random cellphoneGenerator = new System.Random((int)System.DateTime.Now.Ticks);
        //Generation of the phone number, 8 digits with first number different from 0
        cellphoneGenerated =  cellphoneGenerator.Next(10000000,99999999);
        return cellphoneGenerated.ToString();
    }

    public static string Password()
    {
        //StringBuilder creeates a string that is mutable, therefore any operation 
        //over her doesn't return a different string, it modifies itself
        System.Text.StringBuilder pass = new System.Text.StringBuilder();

        System.Random randomizer = new System.Random((int)System.DateTime.Now.Ticks);
        //Just to add a layer of security, we change subrandomly the order of the number and letters
        if(randomizer.Next() % 2 == 0)
        {

            pass.Append(randomizer.Next(1000,9999));
            pass.Append(Tools.RandomString(2));
            pass.Append(Tools.RandomString(2,false));
            return pass.ToString();
        }
        else
        {
            pass.Append(Tools.RandomString(4));
            pass.Append(Tools.RandomString(2, false));
            pass.Append(randomizer.Next(1000, 9999));
            return pass.ToString();
        }

    }


    //Creates an Apple Id for the client with IOS devices
    public static  string AppleId(string init, string end )
    {
        System.Random randomizer = new System.Random((int)System.DateTime.Now.Ticks);
        string appleId = init[0] + end[0] +  randomizer.Next().ToString();

        return appleId;
    }

    public static string GeneratePIN()
    {
        int pinGenerated = 0;
        //object used to generate the random PIN
        System.Random pinGenerator = new System.Random((int)System.DateTime.Now.Ticks);
        //Generation of the pin number, 4 digits 
        pinGenerated = pinGenerator.Next(0000, 9999);
        return pinGenerated.ToString();
    }



}