﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldDempProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(args.Length);

            //Console.Read();
            //var teilnehmer = "Teilnehmer 1";
            try
            {
                

                //Console.WriteLine($"Hallo Sage {args[1]}!");
                //Console.WriteLine("Super, kein Fehler.");
                
            }
            //catch(IndexOutOfRangeException ioore)
            //{
            //    Console.WriteLine(ioore.Message);
            //}
            catch (UnauthorizedAccessException uae)
            {

                Console.WriteLine("Logging ist nicht möglich, Fehler landen im EventLog von Windows.");
            }
            catch (Exception ex)
            {
                throw new DemoException();
            }
            
            //Console.WriteLine("Super, kein Fehler");
        }
    }


     

    public class DemoException : Exception
    {
        public DemoException(string message)
        {

        }
        public DemoException()
        {

        }

    }
}
