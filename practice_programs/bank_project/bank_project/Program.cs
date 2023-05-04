using bank_project.myclasses;
using System;
using System.Text.Json.Serialization;

namespace bank_project
{

    namespace myclasses
    {
        public class Registeration
        {
            public int cust_id ;
            public string cname;
            public int bank_id;
            public string bank_name;
            public DateTime date_created;

            public void OpenAccount(int cust_id,string customer_name, int bank_id, string bank_name, DateTime date_created)
            {
                this.cust_id = cust_id;
                this.cname = customer_name;
                this.bank_id = bank_id;
                this.bank_name = bank_name;
                this.date_created = date_created;
            }
            public void EditDetails(string customer_name)
            {
                this.cname = customer_name;
        
            }
            public void ReadDetails()
            {
                Console.WriteLine("\t Displayng customer Details...");
                Console.WriteLine("\t User Name: {0}",this.cname);
                Console.WriteLine("\t Bank Id: {0}",this.bank_id);
                Console.WriteLine("\t Bank Name: {0}",this.bank_name);
                Console.WriteLine("\t Account Creation Date and Time: {0}",this.date_created);
            }


        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string[] bank_names = new string[3] { "HDFC", "ICICI", "SBI" };
            int[] bank_ids = new int[3] {121,122,123};

            Registeration[] arr = new Registeration[5];
            int arr_cnt = 0;
            Registeration obj1 = new Registeration();

            char ch = 'y';
            do
            {
                Console.WriteLine("Pick any service!");
                Console.WriteLine(" 1. Create Account \n 2. Edit Details \n 3. Read Details \n 4. Delete the bank details \n 5. Exit");
                int choice = Convert.ToInt32( Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter customer name:");
                        string customer_name = Console.ReadLine();
                        int cnt = 0;
                        foreach(string st in bank_names)
                        {
                            Console.WriteLine(" press {0} to select the bank => {1}", cnt, st);
                            cnt++;
                        }
                        Console.WriteLine("Enter the selected bank number:");
                        int  bank = Convert.ToInt32(Console.ReadLine());
                        DateTime date_created = DateTime.Now;
                        arr[arr_cnt] = new Registeration();
                        arr[arr_cnt].OpenAccount(arr_cnt,customer_name, bank_ids[bank], bank_names[bank],date_created);
                        
                        Console.WriteLine("\t\t Account created Successfully ! Your Customer id is:{0} ",arr_cnt);
                        arr_cnt++;
                        break;

                     case 2:
                        Console.WriteLine("\t Editing mode");
                        Console.WriteLine("Kindly Enter your ID associated with your bank account");
                        int uid = Convert.ToInt32(Console.ReadLine());

                        if (arr[uid] != null)
                        {
                            Console.WriteLine("Enter New customer name:");
                            string new_cname = Console.ReadLine();
                            arr[uid].EditDetails(new_cname);
                            Console.WriteLine("Changes Saved Successfully!");

                        }
                        else
                        {
                            Console.WriteLine("Sorry ! No user with the specified customer ID {0}", uid);
                        }
                     break;
                    case 3:
                        
                        Console.WriteLine("Kindly Enter your ID associated with your bank account");
                        int user_id = Convert.ToInt32(Console.ReadLine());
                        
                            if (arr[user_id] !=null)
                            {
                            arr[user_id].ReadDetails();
                            
                            }
                            else
                            {
                                Console.WriteLine("Sorry ! No user with the specified customer ID {0}", user_id);
                            }
                        

                        break;
                    case 4:
                        Console.WriteLine("Kindly Enter your ID associated with your bank account");
                        int del_user_id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Kindly Enter your Username associated with your bank account");
                        string del_username = Console.ReadLine();

                        if (arr[del_user_id] != null && arr[del_user_id].cname==del_username)
                        {
                            arr[del_user_id] = null ;
                            Console.WriteLine("Account Removed!");


                        }
                        else
                        {
                            Console.WriteLine("Invalid user !");
                        }


                        break;

                    case 5:
                        return;
                        break;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
                Console.WriteLine("Do you want to continue? (y/n)");
                ch = Convert.ToChar( Console.ReadLine()) ;
            } while (ch == 'y');



            
            
            
            
        }
    }
}