using System;


namespace ConsoleAppForHW_03
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, we need to collect some data about you.\nPress any \"key\" to continue...");
            Console.ReadKey();
            var (name, lastname, age, petnum, petname, favocolorsnum, favocolors) = UserDataEntery();
            ShowUserData(in name, lastname, age, petnum, petname, favocolorsnum, favocolors);

            
            Console.ReadKey();
        }

        static (string name, string lastname,int age, int petnum, string[] petname, int favocolorsnum, string[] favocolors)  UserDataEntery()
        {
            (string name, string lastname,int age,int petnum, string[] petname, int favocolorsnum, string[] favocolors) userdata;

            userdata.petnum = 0;
            userdata.petname = new string[userdata.petnum];
            string haveapet = "";

            userdata.favocolorsnum = 0;
            userdata.favocolors = new string[userdata.favocolorsnum];

            var type1 = "Yor name";
            GetName(out string name, in type1);
            userdata.name = name;

            var type2 = "Yor lastname";
            GetName(out string lastname, in type2);
            userdata.lastname = lastname;

            var type3 = "Your age";
            GetAge(out int age, in type3);
            userdata.age = age;


            HaveaPet(ref haveapet);
            if (haveapet == "yes")
            {
                GetPetNum(ref userdata.petnum);
                GetPetName(ref userdata.petname, userdata.petnum);
            }
            else if (haveapet == "no") { }

            GetColorsNum(ref userdata.favocolorsnum);
            GetFevocolors(ref userdata.favocolors, userdata.favocolorsnum);



            return userdata;


        }
        static void GetName(out string name,in string nametype)
        {
            Console.WriteLine("Enter : {0}\tDon't use the numbers.\tThe length of the name should not exceed 20 symbols (the \"space\" is symbol)", nametype);
            name = Console.ReadLine();
            for (int i = 0; i <= name.Length -1; i++)
            {
                
             
                if (char.IsNumber(name[i]) || name.Length > 20)
                {
                    Console.WriteLine("!!!Not correct, try enter again!!!");
                    GetName(out name,in nametype);
                    break;
                }
            }
            
            
        }
        static void GetAge(out int age,in string type)
        {

                Console.WriteLine("Enter : {0}\tUse only numbers", type);
                var a = Console.ReadLine();                
                int.TryParse(a, out age);
                if(age <= 0) 
                {
                Console.WriteLine("!!!Not correct, try enter again!!!");
                GetAge(out age,in type);
                }

            

                


         }   
        static void GetPetNum(ref int petnum )
        {
            Console.WriteLine("How many pet you have?\tEnter a number no more  10");
            string pet  = Console.ReadLine();
            int.TryParse(pet, out petnum);
            if (petnum <= 0 || petnum > 10)
            {
                Console.WriteLine("!!!Not correct, try enter again!!!");
                GetPetNum(ref petnum);
            }
        }
        static void GetPetName(ref string[] petname,int petnum)
        {
            petname = new string[petnum];
            Console.WriteLine("Enter pet name : \t\tDon't use the numbers.\t\tThe length of the name should not exceed 20 symbols (the \"space\" is symbol)");
            for (int i = 0; i < petnum; i++)
            {
                Console.WriteLine("Pet name : {0}", i + 1);
                petname[i] = NameCheck();


            }
        }
        static void HaveaPet(ref string haveapet)
        {
            Console.WriteLine("Do you have a pet?\nyes\\no");
            haveapet = Console.ReadLine();
            if (haveapet != "no" && haveapet != "yes")
            {
                Console.WriteLine("!!!Not correct, try enter again!!!");
                HaveaPet(ref haveapet);
            }
           
        }  
        static void GetColorsNum(ref int colorsnum)
        {
            Console.WriteLine("How many favorite colors do you have?\nEnter a number no more  10");
            string colors = Console.ReadLine();
            int.TryParse(colors, out colorsnum);
            if (colorsnum <= 0 || colorsnum > 10)
            {
                Console.WriteLine("!!!Not correct, try enter again!!!");
                GetColorsNum(ref colorsnum);
            }
        }
        static void GetFevocolors(ref string[] favocolors, int favocolorsnum)
        {
            favocolors = new string[favocolorsnum];
            Console.WriteLine("Enter your favorite color : \t\tDon't use the numbers.\t\tThe length of the color name should not exceed 20 symbols (the \"space\" is symbol)");
            for (int i = 0; i < favocolorsnum; i++)
            {
                Console.WriteLine("Enter your favorite color number : {0}", i + 1);
                favocolors[i] = NameCheck();
            }

        }
        static void ShowUserData(in string name, string lastname, int age, int petnum, string[] petname, int favocolorsnum, string[] favocolors)
        {            
            Console.WriteLine("\nUserName : {0}\t\tUserLastname : {1}\t\tUserAge : {2}\nNumber of user's pets : {3}\tNumber of user's favorite colors : {4}", name, lastname, age, petnum, favocolorsnum);
            Console.WriteLine("\nPet names :");
            foreach (var item in petname)
            {      
                Console.WriteLine("\n" + item);
                
            }
            Console.WriteLine("\nFavorite colors :");
            foreach (var item in favocolors)
            {   
                Console.WriteLine("\n" + item);
            }
        }
        static string NameCheck()
        { 
        string name = Console.ReadLine();
            for (int i = 0; i <= name.Length -1 ; i++)
            {
                if (char.IsNumber(name[i]) || name.Length > 20)
                {
                    Console.WriteLine("!!!Not correct, try enter again!!!");
                    NameCheck();
                    break;
                }
            }
        return name;
        }
        
    }
}
