using Utilities;

public class IOS : Smartphones, IMusicPlayer, ISongAdquisition
{
    //Attibutes
    private string AppleId {get; set;}
    

    //Constructor
    public IOS(string number, double version,
     string clientName, string clientLastName):base(number, version)
    {
        this.AppleId = Generator.AppleId(clientName, clientLastName);
    }

    //Methods
    public (string costoTuple, string descriptionTuple) RechargeSong() //This function add more playable songs to the phone
    {
        try
        {
            int song = 0;
            System.Console.WriteLine("How much iTunes are you going to purchase?");
            //validaton that the amount that is added is a valid double value
            song = Tools.NumberValidation<int>(1, int.MaxValue, Tools.InRange, "Amount to purchase $: ");
            System.Console.WriteLine($"${song} has been added succesfully");
            this.SongsAvailable += song; //We add the new songs to the old one
            System.Console.WriteLine($"New songs available are {this.SongsAvailable}");

            return (song.ToString(), "RechargeSong");
        }
        catch (System.Exception e)
        {
            System.Console.WriteLine(e.Message);
            throw;
        }
    
    }

    public (string costoTuple, string descriptionTuple) PlayMusic(int songs) //This function is to play songs
    {
        try
        {
            int songsDeduction = Cellphone.songCost * songs;

            //Validation that songs does not goes negative due to a song with a cost greater than the total song
            if(this.SongsAvailable >= songsDeduction)
            {
                System.Console.WriteLine("Listening to  {0}", songs, " songs in iTunes");
                System.Console.WriteLine("Playing...");
                System.Threading.Thread.Sleep(400);
                System.Console.WriteLine("Playlist has ended");
                System.Console.WriteLine($"Cost of the songs ${songsDeduction}. ");
                this.SongsAvailable -= songsDeduction;
                System.Console.WriteLine($"Songs remaining: {this.SongsAvailable}");

                if (this.SongsAvailable == 0)
                {
                    System.Console.WriteLine("Please make a recharge");
                }

                return (songsDeduction.ToString(), "PlayMusic");
            }
            else
            {
                System.Console.WriteLine("Not enough songs, please recharge songs");
                System.Console.WriteLine("Cost of the songs: ${0}", songsDeduction);
                System.Console.WriteLine("Actual songs: ${0}", this.SongsAvailable);

                return ("Not enough", "PlayMusic");
            }
            
        }
        catch(System.Exception e)
        {
            System.Console.WriteLine(e.Message);
            throw;
        }
    }
}