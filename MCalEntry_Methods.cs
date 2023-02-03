//
// ${Melquiceded Balbi Villanueva}
//
// Author:
//       ${Melquiceded} <${melquiceded.balbi@gmail.com}>
//
// Copyright (c) ${2089} MIT
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using QuickTools;
namespace MCal
{
      public partial class MCalEntry
      {



            ///<summary>
            /// If the operation is not suppored this will say it 
            ///</summary>
            public static void NotSuported()
            {

                  Console.WriteLine("Invalid Operation or not suppored");
                  Console.WriteLine("Valid Operation Format  a + b");
                  Console.WriteLine("Operations allowed + , - , * , / , ^");

            }

            public static void MainMenu(string[] args)  
            {

                  try{

                        //Get.Wait(Get.Path); 


                        //CoConsole.ForegroundColor = ConsoleColor.Green;

                        // values taken from the console 
                        double v1, v2;
                        v1 = 0.0000;
                        v2 = 0.0000;
                        string f = null;



                        if (args.Length > 0)
                        {
                              IsWithParameters = true;
                        }
                        if (args.Length >= 2 && args[1] == "=")
                        {

                              if ((args.Length > 1) && (!Get.IsNumber(args[0])))
                              {

                                    if (!Get.IsNumber(args[0]))
                                    {

                                          AsingVariable(args);
                                          Arguments = new string[0];
                                          Environment.Exit(0);
                                          //Get.Wait($"{v1} {v2}");
                                    }
                                    //ClearConsole();
                                    //Calculate()

                              }
                        }

                        if (args.Length == 0)
                        {
                              Get.Green();
                              Console.WriteLine("Welcome To Console Calculator");
                              Console.WriteLine("Created By MBV \n");
                              Console.WriteLine("Please Introduce value1...:");
                              string check = Get.Input().Text;
                                    //Get.Wait(check);
                                    if (check[0] == 'F')
                                    {
                                          string command, type;
                                          string[] temp = IConvert.TextToArray(check.Substring(1));
                                          command = temp[0]; 
                                          type = temp.Length > 1 ? IConvert.TextToArray(check.Substring(1))[1] : "";
                                          //Get.Wait($"Command: {command} Type: {type}"); 
                                          RunCommand(command, type);
                                          return;
                                    }


                                    if (IConvert.TextToArray(check).Length >= 3)
                                          {
                                   

                                          string[] arr = IConvert.TextToArray(check.Substring(3));
                                                //Get.Wait(check.Substring(3));
                                                AsingVariable(arr);
                                                return;
                                          }
                                          v1 = Convert.ToDouble(check);
                                          Console.WriteLine("Type Enter to View the menu");
                                          Console.WriteLine("PLease Introduce the Type of operation...:");
                                          Console.WriteLine("Operation allwoed:  +  -  /   ^ ");
                                          f = Get.Input().Text;
                                          Console.WriteLine("Please Introduce  value2...:");
                                          v2 = Convert.ToDouble(Get.Input().Text);
                                          double total = Calculate(v1, f, v2);

                                    }
                        if (args.Length == 3)
                        {
                              //  Console.WriteLine("Recived Value");
                              v1 = Convert.ToDouble(args[0]);
                              f = args[1];
                              v2 = Convert.ToDouble(args[2]);
                              double total = Calculate(v1, f, v2);



                              //Console.WriteLine(v1 + f + v2 + "=" + total);
                              //    SaveHistory($"{v1} {f} {v2} = { total }"); 
                              return;
                        }
                        else
                        {
                              //NotSuported();

                        }

                  }
                  catch (Exception e)
                  {
                        Menu(e);
                        //NotSuported();

                  }
                                  
            }

            public static void Menu(Exception e)
            {
                  Log.Event($"FatalError", e.Message);
                  string[] optionsList = { "Go Back", "View History", "View Variables", "Delete History", "Delete Variables", "Transfer To File", "Exit" };

                  switch (new Options(optionsList).Pick())
                  {
                        case 0:
                              Get.Clear();
                              break;
                        case 1:
                              ReadOperation();
                              break;
                        case 2:
                              ReadAllVars();
                              break;
                        case 3:
                              ClearHistory();
                              break;
                        case 4:
                              ClearVariables();
                              break;
                        case 5:
                              ExportFile(Get.Input("Type the variable that you would like to export the value from").Text);
                              break;
                        case 6:
                              Environment.Exit(0);
                              break;
                  }
            }



            //mcal a = 2; //3L
            //mcal b = 7 / 3; //5L
            //mcal z = a x 9; 
            //mcal m = 4 - a; 
            //mcal b = a + b; //5L
            private static void AsingVariable(string[] args)
            {
                  try
                  {
                        string a, b, f, v;
                        v = args[0];
                        //Get.Yellow(args.Length);
                        switch (args.Length)
                        {
                              case 2:
                                    RunCommand(v, args[1]);
                                    break;
                              case 3:
                                    a = args[2];

                                    //if the assingment is a number just assing it 
                                    // but if is  a variable get the variable value and set it 
                                    if (Get.IsNumber(a))
                                    {
                                          SetVariable(v, a);
                                          return;
                                    }
                                    if (!Get.IsNumber(a))
                                    {
                                          SetVariable(v, GetVariable(a));
                                    }
                                    break;
                              case 5:
                                    a = args[2];
                                    b = args[4];
                                    f = args[3];

                                    //same than above but now 
                                    // if you give an operation the operation should be process first then the value
                                    // will be assing to the variable
                                    if (Get.IsNumber(a) && Get.IsNumber(b))
                                    {
                                          Calculate(Convert.ToDouble(a), f, Convert.ToDouble(b));
                                          SetVariable(v, x);
                                          //Get.Blue($"{a} {f} {b} = {x}"); 
                                          return;
                                    }
                                    if (!Get.IsNumber(a) && Get.IsNumber(b))
                                    {
                                          Calculate(Convert.ToDouble(GetVariable(a)), f, Convert.ToDouble(b));
                                          SetVariable(v, x);
                                          //Get.Blue($"{a} {f} {b} = {x}"); 
                                          return;
                                    }
                                    if (Get.IsNumber(a) && !Get.IsNumber(b))
                                    {
                                          Calculate(Convert.ToDouble(a), f, GetVariable(b));
                                          SetVariable(v, x);
                                          //Get.Blue($"{a} {f} {b} = {x}"); 
                                          return;
                                    }
                                    if (!Get.IsNumber(a) && !Get.IsNumber(b))
                                    {
                                          Calculate(Convert.ToDouble(GetVariable(a)), f, GetVariable(b));
                                          SetVariable(v, x);
                                          //Get.Blue($"{a} {f} {b} = {x}"); 
                                          return;
                                    }

                                    break;
                              default:
                                    Get.Red("Variable Asingment not allowed");
                                    Get.Green("Valid Formats: ");
                                    Get.Yellow(@"
                              a = 2; //3L
                              b = 7 / 3; //5L
                              b = a + b; //5L
                              ");
                                    break;
                        }
                        //if (args.Length > 0) ;
                  }
                  catch (Exception e)
                  {
                        Get.Yellow("Something went wrong while assinging the variable");
                        Menu(e);
                  }
            }



            private static void RunCommand(string command, string type)
            {
                  try
                  {


                        switch (command)
                        {
                              case "clear-console":
                              case "Clear":
                                    Get.Clear(); 
                                    break; 
                              case "get-var":
                              case "g-var":
                              case "gv":
                                    PrintVar(type);
                                    break;
                              case "transfer-to-file":
                              case "transfer":
                              case "cat":
                              case "export":
                              case "ex":
                                    ExportFile(type);
                                    break;
                              case "delete":
                              case "clear":
                              case "del":
                              case "-d":
                              case "d":
                              case "-c":
                              case "c":
                                    switch (type)
                                    {
                                          case "history":
                                          case "his":
                                          case "-h":
                                          case "h":
                                                ClearHistory();
                                                break;
                                          case "variables":
                                          case "vars":
                                          case "-v":
                                          case "v":
                                                ClearVariables();
                                                break;
                                          default:
                                                Get.Red($"The Given Type Is Not a valid : {type}");
                                                break;
                                    }
                                    break;
                              case "show":
                              case "print":
                              case "-p":
                              case "p":
                              case "-s":
                              case "s":
                                    switch (type)
                                    {
                                          case "history":
                                          case "-h":
                                          case "h":
                                                ReadOperation();
                                                break;
                                          case "variables":
                                          case "vars":
                                          case "v":
                                                ReadAllVars();
                                                break;
                                          default:
                                                Get.Red($"The Given Type Is Not a valid : {type}");
                                                break;
                                    }
                                    break;
                              default:
                                    Get.Red($"The Given Command Is Not a valid command: {command}");
                                    break;
                        }
                  }
                  catch (Exception e)
                  {
                        Get.Yellow("There was an error while processing the given command");
                        Menu(e);
                  }
            }

            /*

              i want you to know that i'm never leaving
              that because i'm missing the snow (snow or soul) that will be freassing me you want
              my heart my heart for a season come on let's go                  
        */


            private static void ExportFile(string type) => Writer.Write($"{Get.Path}/{type}", GetVariable(type));

            private static void PrintVar(string type) => Get.Yellow($" {type} = {GetVariable(type)} ");

            private static void ReadAllVars()
            {
                  using (MiniDB db = new MiniDB(dbVars, true))
                  {
                        db.Create();
                        db.Load();
                        if(db.DataBase.Count > 0)
                        {
                              db.DataBase.ForEach((item) => {
                                    Get.Yellow($"{item.Key} = {item.Value}");
                              });
                              return;
                        }
                        else
                        {
                              Get.Yellow("Not Variables set yet"); 
                        }
                  }
            }

            private static void ClearVariables()
            {
                  var db = new MiniDB(dbVars, true);
                  db.Drop();
                  db.Create();
                  Get.Yellow("Variables Deleted"); 
            }

            private static void ClearHistory()
            {
                  var db = new MiniDB(dbName, true);
                  db.Drop();
                  db.Create();
                  Get.Yellow("History was Deleted");

            }



            static void SetVariable(string variable, object x)
            {
                  using (MiniDB db = new MiniDB(dbVars, true))
                  {
                        db.Create();
                        db.Load();
                        if (db.SelectWhereKey(variable).Count > 0)
                        {
                              db.UpdateKeyValue(db.SelectWhereKey(variable)[0].Id, x);
                              Get.Yellow($"Variable Updated: {variable} = {x}");
                              return;
                        }
                        db.AddKey(variable, x);
                        Get.Yellow($"Variable Set: {variable} = {x}");
                        return;
                  }
            }
            static double GetVariable(string variable)
            {
                  using (MiniDB db = new MiniDB(dbVars, true))
                  {
                        db.Create();
                        db.Load();
                        if (db.SelectWhereKey(variable).Count > 0)
                        {
                              return Convert.ToDouble(db.SelectWhereKey(variable)[0].Value);
                        }
                  }
                  return new double();
            }



            static void ReadOperation()
            {
                  using (MiniDB db = new MiniDB(dbName, true))
                  {
                        db.Create();
                        db.Load();
                        db.DataBase.ForEach((item) => {
                              Get.Yellow(item.Value);
                        });
                  }
            }
            static void SaveOperation(double a, string f, double b, double x)
            {
                  using (MiniDB db = new MiniDB(dbName, true))
                  {
                        db.Create();
                        db.AllowRepeatedKeys = true;
                        db.AddKey("operation", $" {a} {f} {b} = {x}");
                  }
            }
            static void ClearConsole()
            {
                  if (!IsWithParameters)
                  {
                        Get.Wait();
                        Get.Clear();
                  }
            }



            static double Calculate(double v1, string f, double v2)
            {
                  //  Console.WriteLine("Calculation:");

                  if (f == "+")
                  {
                        x = v1 + v2;
                        SaveOperation(v1, f, v2, x);
                        Console.WriteLine(" {0} {1} {2} = {3}", v1, f, v2, x);
                  }
                  if (f == "-")
                  {
                        x = v1 - v2;
                        SaveOperation(v1, f, v2, x);
                        Console.WriteLine(" {0} {1} {2} = {3}", v1, f, v2, x);

                  }
                  if (f == "x" || f == "X")
                  {
                        x = v1 * v2;
                        SaveOperation(v1, f, v2, x);
                        Console.WriteLine(" {0} {1} {2} = {3}", v1, f, v2, x);

                  }
                  if (f == "/")
                  {
                        x = v1 / v2;
                        SaveOperation(v1, f, v2, x);
                        Console.WriteLine(" {0} {1} {2} = {3}", v1, f, v2, x);

                  }
                  if (f == "%")
                  {
                        x = v1 % v2;
                        SaveOperation(v1, f, v2, x);
                        Console.WriteLine(" {0} {1} {2} = {3}", v1, f, v2, x);

                  }
                  if (f == "^")
                  {
                        x = (v1 * v1) * v2;
                        SaveOperation(v1, f, v2, x);
                        Console.WriteLine(" {0} {1} {2} = {3}", v1, f, v2, x);

                  }
                  ClearConsole();
                  return x;
            }


            //Console.ResetColor();

      }
}
