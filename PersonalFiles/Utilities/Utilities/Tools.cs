using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace Utilities
{
    public static class Tools
    {
        //Template for Menu
        public static int Menu(List<string> options)
        {
            try
            {

                int opc = 0;
                Console.WriteLine("----------Menu----------");
                for (int i = 0; i < options.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {options[i]}");
                }
                Console.WriteLine($"{options.Count+1}. Salir ");
                Console.WriteLine("---------------------------");  
                opc = NumberValidation(1, options.Count+1, InRange, "Select an option");

                
                
                return opc;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            
        }
        
        
        
        
        //Template for validating if a string can be converted to a number
        public static T NumberConversion<T>( string message)
        {
            try
            {
                
                T result = default(T);
                bool evaluation = false;
                string value;
                //this variable allows to get the right TryParse, since T should work for every possible type
                //And won't work on a normal TryParse csll
                var converter = TypeDescriptor.GetConverter(typeof(T));
                //Validates that the value is not null and that we are not getting an overflow
                
                do
                {
                        
                    Console.WriteLine(message);
                    value = Console.ReadLine();
                    if (converter != null && converter.IsValid(value) )
                    {
                        result = (T)converter.ConvertFromString(value);
                        evaluation = true;
                    }else
                    {
                        Console.WriteLine("That's not a valid value. Try Again");
                    }
                    


                } while (evaluation == false);

                return result;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }


        //Series of templates that validate if a number is within certan range
        public static bool InRange(int value, int min, int max = int.MaxValue)
        {
            if (value < min || value > max)
                return false;
            else
                return true;
        }
        
        public static bool InRange(float value, float min, float max = float.MaxValue)
        {
            if (value < min || value > max)
                return false;
            else
                return true;
        }
        
        public static bool InRange(double value, double min, double max = double.MaxValue)
        {
            if (value < min || value > max)
                return false;
            else
                return true;
        }

        public delegate bool RangeFunction<T>(T value, T min, T max);

        //Function that converts a string to a number and verifies if its within range, unifies various functions
        //Requiere the mmin, max value of the value and also the function to check if its in range
        public static T NumberValidation<T>(T min, T max, RangeFunction<T> range, string message)
        {
            T value = default(T);
            bool flag = false;
            do
            {
                value = NumberConversion<T>(message);
                if (range(value, min, max))
                    flag = true;
            } while (flag == false);

            return value;

        }
        

    }
}