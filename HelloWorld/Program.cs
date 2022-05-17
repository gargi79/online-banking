//Garhajpal Singh
//011470057

using System;

namespace HelloWorld
{
    class Program
    {

        static void Main(string[] args)
        {
            //instatiating BasicMessageClass
            var bmc = new BasicMessageClass("Hello World!");
            while (true)
            {
                //printing menu
                Console.WriteLine("1 - Show the pass by reference and pass by value scenario");
                Console.WriteLine("2 - Show Hello World on the screen");
                Console.WriteLine("3 - Write Hello World in a file");
                Console.WriteLine("4 - Adding two numbers in a linked list");
                Console.WriteLine("0 - Quit");
                //declaring control variable
                bool isNumber = false;

                while (isNumber != true)
                {
                    //getting input from user
                    string input = Console.ReadLine();
                    int inputNumber;
                    //parsing input into integer
                    isNumber = int.TryParse(input, out inputNumber);

                    //deciding what to do based on input
                    switch (inputNumber)
                    {
                        case 1:
                            PassByValueVersusPassByReference();
                            break;
                        case 2:
                            bmc.ShowMessageInConsole();
                            break;
                        case 3:
                            bmc.WriteMessageToFile();
                            break;
                        case 4:
                            LinkedList linkedList = new LinkedList();
                            linkedList.Add(new LinkedListNode(5));
                            linkedList.Add(new LinkedListNode(2));
                            Console.WriteLine("Numbers in Linked List");
                            foreach (var num in linkedList.Nodes)
                            {
                                Console.WriteLine(num.Value);
                            }
                            break;
                        case 0:
                            return;


                    }
                }
            }

        }

        private static void PassByValueVersusPassByReference()
        {
            Console.WriteLine("Starting with structures");
            AngleStruct angleStruct = new AngleStruct
            {
                AngleDegrees = 90
            };
            Console.WriteLine("Structure at creation");
            angleStruct.ShowInfo();
            Console.WriteLine();
            AngleStruct angleStruct2 = angleStruct;
            angleStruct.AngleDegrees = 180;
            Console.WriteLine("Structure after modification");
            angleStruct.ShowInfo();
            Console.WriteLine();
            Console.WriteLine("Structure 2");
            angleStruct2.ShowInfo();
            Console.WriteLine();

            AngleClass angleClass = new AngleClass
            {
                AngleDegrees = 90
            };
            Console.WriteLine("Class at creation");
            angleClass.ShowInfo();
            Console.WriteLine();
            AngleClass angleClass2 = angleClass;
            angleClass.AngleDegrees = 180;
            Console.WriteLine("Class after modification");
            angleClass.ShowInfo();
            Console.WriteLine();
            Console.WriteLine("Class 2");
            angleClass2.ShowInfo();
            Console.WriteLine();




        }

    }

}