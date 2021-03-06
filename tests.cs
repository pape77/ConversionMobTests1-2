//Compiler version 4.0.30319.17929 for Microsoft (R) .NET Framework 4.5

using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Rextester
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Runs 'Test1'
            conversionMobOrNumber();
            
            
            //Runs 'Test 2' for some examples
            TaxCalculator tc = new TaxCalculator();
            
            //Print example answer
            Console.WriteLine(tc.taxAmountInCents(12200.10 , 10));
            
            Debug.Assert(tc.taxAmountInCents(122.10 , 10).SequenceEqual(new char[]{'1','2','2','0','0', '1'}), "Wrong answer for inputs: 122.10 and 10.00");
            
            Debug.Assert(tc.taxAmountInCents(12 , 10).SequenceEqual(new char[]{'1','2','0'}), "Wrong answer  for inputs: 12 and 10");
            
            Debug.Assert(tc.taxAmountInCents(599.12 , 30.00).SequenceEqual(new char[]{'1','7','9','7','3',',','6'}), "Wrong answer for inputs: 599.12 and 30.00");
            
            Debug.Assert(tc.taxAmountInCents(599.1233 , 31.00) == new char[]{'1','8','5','7','2',',','7','2'}, "Wrong answer  for inputs: 599.1233 and 31.00");
            
            Debug.Assert(tc.taxAmountInCents(4123.1233 , 21.09).SequenceEqual(new char[]{'8','6','9','5','6',',','6','0','0','8'}), "Wrong answer  for inputs: 4123.1233 and 21.09");
            
            
       
            /* 
            //Example of homemade test because I couldn't make Assert work on online compiler
            
            if(tc.taxAmountInCents(12200.10 , 10).SequenceEqual(new char[]{'1','2','2','0','0', '1'}))
            {
                        Console.WriteLine("Correct!");
            }else
            {
                
                Console.Write("Incorrect! Your answer was: ");
                Console.Write(tc.taxAmountInCents(12200.10 , 10));
                Console.Write(". Correct answer is: ");
                Console.WriteLine( new char[]{'1','2','2','0','0', '1'});
            }
            */
        }
        
        
        
        public static void conversionMobOrNumber()
        {
            for(int i=1; i< 101; i++)
            {
                if(i % 15 == 0) //Multiples of 3 and 5 print 'ConversionMob'
                {
                    Console.WriteLine("ConversionMob" + ",");
                }
                else if (i % 3 == 0) //Multiples of 3 print 'Conversion'
                {
                    Console.WriteLine("Conversion" + ",");
                }
                else if (i% 5 == 0) //Multiples of 5 print 'Mob'
                {
                    Console.WriteLine("Mob" + ",");
                }
                else//No multiples of 3 or 5 , print number
                {
                    Console.WriteLine(i+ ",");
                }
            }
        }
        
        public class TaxCalculator
        {
        
            public TaxCalculator(){}
            
            public char[] taxAmountInCents(double amount, double taxPercentage)
            {
                if(taxPercentage > 100 || taxPercentage < 0)
                {
                    throw new System.ArgumentException("Tax percentage cannot be negative or over 100");
                }
                else
                {
                    double amountInCents = Math.Truncate(amount * 100);
                    
                    double answerDouble = (amountInCents * taxPercentage) / 100;
                    
                    return answerDouble.ToString().ToArray();
                        
                        
                    /*
                    
                    //Without the help of ToArray 
                    
                    string answerString = answerDouble.ToString();
                    int numbersInAnswer = answerString.Count();
                                    
                    char[] answer = new char[numbersInAnswer];
                    
                    for(int i = 0; i < numbersInAnswer ; i++)
                    {
                       answer[i] = answerString[i]; 
                    }
                    
                     return answer;
                     
                     */
                }
            }
        }
                
    }
}