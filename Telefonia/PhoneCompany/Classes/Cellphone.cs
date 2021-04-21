public abstract class Cellphone
{
    //Attibutes
    public string Number { get; set;}
    private double _airTime;

    //Standar cost for making calls and sending SMS, easier to maintain
    protected const double minuteCost = 0.15;
    protected const double characterCost = 0.05;
    protected const double webCost = 4.0;
    protected const double socialCost = 2.0;
    protected const int songCost = 1;

    //Constructors
    public Cellphone(string number)
    {
        this.Number = number;
        this._airTime = 0;
    }

    //Properties
    public double AirTime
    {
        get {return this._airTime;}
        set 
        {
            //Valdiation for negative numbers 
            if( value < 0)
                throw new System.ArgumentOutOfRangeException(
                    $"{nameof(value)} cannot be a negative value"
                );

            this._airTime = value;
        }
    }

    //Methods

    public abstract (string costoTuple, string descriptionTuple) RechargeAirTime();

    public abstract (string costoTuple, string descriptionTuple) MakeCall(double minutes, string callee);

    public abstract (string costoTuple, string descriptionTuple) SendSMS(string words, string receiver);


}