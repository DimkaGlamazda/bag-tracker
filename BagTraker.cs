using System;
using TaskLib;

namespace BagTraker
{

    class BagTraker
    {
        static void Main(string[] args)
        {
            bool loop = true;

            int tasksAmount = 0;

            do
            {
                try
                {
                    tasksAmount = int.Parse(NumberValidation(GetValue("task amount")));
                    loop = false;
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                }
            } while (loop);

            Console.Clear();

            TaskLib.Task[] tasksList = new Task[0];

            do
            {
                try
                {
                    tasksList = GenerateTasks(tasksAmount);
                    loop = false;
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                    loop = true;
                }

            } while (loop);

            Console.Clear();

            do
            {
                try
                {
                    int sprintTime = 30;

                    while (sprintTime > 0)
                    {
                        for (int i = 0; i < tasksList.Length; i++)
                        {
                            float statusValue = tasksList[i].WorkIteration();

                            if (statusValue < 1)
                            {
                                continue;
                            }
                            else
                            {
                                break;
                            }
                        }
                        sprintTime--;
                    }

                    loop = false;

                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                    loop = true;
                }
            } while (loop);

            PrintSprintResult(tasksList);
        }

        public static string GetValue(string title, string description = null)
        {
            string value = null;
            bool loop = true;

            while (loop)
            {
                try
                {
                    Console.WriteLine($"Please enter {title}");

                    if (!string.IsNullOrEmpty(description))
                    {
                        Console.WriteLine(description);
                    }

                    value = Console.ReadLine();

                    if (string.IsNullOrEmpty(value))
                    {
                        throw new Exception($"{title} can't be empty.");
                    }

                    loop = false;
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                }
            }

            return value;
        }

        public static string NumberValidation(string numberStr)
        {

            if(! int.TryParse(numberStr, out int number))
            {
                throw new Exception($"{numberStr} is not a number.");
            }

            if(number <= 0)
            {
                throw new Exception($"{number} can't be less or equal 0.");
            }

            return numberStr;
        }

        public static TaskLib.Task[] GenerateTasks(int tasksAmount)
        {
            TaskLib.Task[] tasksList = new TaskLib.Task[tasksAmount];
            string title = " task type";
            string description = "(Options: Bug - 1; Feature - 2; TechnicalDebt - 3)";

            TaskType type;

            string name;
            string complexity;

            string nameTitle = "name";
            string complexityTitle = "complexity";
            string complexityDescription = "(value should be from 1 to 5)";

            for (int i = 0; i < tasksList.Length; i++)
            {
                
                type = (TaskType)int.Parse(NumberValidation(GetValue(title, description)));
                name = GetValue(nameTitle);
                complexity = GetValue(complexityTitle, complexityDescription);

                switch(type)
                {
                    case TaskType.Bug :
                        tasksList[i] = new Bug(name, complexity);
                        break;
                    case TaskType.Feature:
                        tasksList[i] = new Feature(name, complexity);
                        break;
                    case TaskType.TechnicalDebt:
                        tasksList[i] = new TechnicalDebt(name, complexity);
                        break;
                    default:
                        throw new Exception("Task type is not found.");
                }
            }
            return tasksList;
        }

        public static void PrintSprintResult(TaskLib.Task[] tasks)
        {
            Console.Clear();
            Console.WriteLine("Results:");

            for(int i = 0; i < tasks.Length; i++)
            {
                if(tasks[i].WorkIteration() < 1)
                {
                    Console.WriteLine($"{tasks[i].Name} : +");
                }
                else
                {
                    Console.WriteLine($"{tasks[i].Name} : -");
                }
            }
            Console.ReadLine();
        }
    }

    internal enum TaskType
    {
        Bug = 1,
        Feature = 2,
        TechnicalDebt = 3
    }
}
