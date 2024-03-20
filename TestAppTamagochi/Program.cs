namespace TamagotchiGame
{
    class Program
    {
        static void Main(string[] args)
        {
            RunProgram();
        }

        static void RunProgram()
        {
            Console.Clear();
            Console.WriteLine("Введите имя питомца:");
            string petName = Console.ReadLine();
            Pet pet = new Pet(petName);
            int days = 0;

            while (true)
            {
                days++;
                Console.Clear();
                PrintInfoOfPet(pet);
                PrintMenu();

                int action;

                try
                {
                    action = int.Parse(Console.ReadLine());
                }
                catch
                {
                    days--;
                    continue;
                }

                switch (action)
                {
                    case 1:
                        pet.Feed();
                        break;
                    case 2:
                        pet.Play();
                        break;
                    case 3:
                        pet.Sleep();
                        break;
                    case 4:
                        pet.Heal();
                        break;
                    case 9:
                        pet.Dead();
                        break;
                    default:
                        Console.WriteLine("Некорректный ввод. Попробуйте еще раз.");
                        break;
                }

                pet.Living();

                if (pet.Health == 0)
                {
                    PrintExitMenu(days, pet);
                    return;
                }
            }
        }

        static void PrintInfoOfPet(Pet pet)
        {
            string nameLine = new string('-', pet.Name.Length);
            Console.WriteLine($"-------------{nameLine}-------------");
            Console.WriteLine($"-------------{pet.Name}-------------");
            Console.WriteLine($"-------------{nameLine}-------------");

            Console.WriteLine("\nПоказатели питомца:");

            string healthBar = CreateBar('♥', pet.Health, 10);
            Console.WriteLine($"Здорове: {healthBar}");

            string hungerBar = CreateBar('▌', pet.Hunger, 10);
            Console.WriteLine($"Голод: {hungerBar}");

            string tirednessBar = CreateBar('Z', pet.Tiredness, 10);
            Console.WriteLine($"Усталость: {tirednessBar}");

            string happinessBar = CreateBar('☺', pet.Happiness, 10);
            Console.WriteLine($"Счатстье: {happinessBar}");

            if (pet.Disease)
            {
                Console.WriteLine($"{pet.Name}: \"Кхе кхе, что-то мне не хорошо\"");
            }
        }

        static void PrintMenu()
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Покормить");
            Console.WriteLine("2. Поиграть");
            Console.WriteLine("3. Укачать");
            Console.WriteLine("4. Лечение");
            Console.WriteLine("\n9. Убить");
            Console.Write("Выберите действие: ");
        }
        static void PrintExitMenu(int days, Pet pet)
        {
            Console.Clear();
            Console.WriteLine($"\n {pet.Name}: \"Спасибо за время проведенное весте ♥\"");
            Console.WriteLine($"\nИтоговый счет:{pet.Points}");
            Console.WriteLine($"\nСредний счет:{pet.Points / days}");

            Console.WriteLine("\nЧто будем делать дальше?" +
                "\nВведи \"R\" для перезапуска программы" +
                "\nИли введите любое другое значение, чтобы завершить программу");
            char lastAction = char.Parse(Console.ReadLine());

            switch (lastAction)
            {
                case 'R':
                    RunProgram();
                    break;
                case 'r':
                    RunProgram();
                    break;
                case 'К':
                    RunProgram();
                    break;
                case 'к':
                    RunProgram();
                    break;
                default:
                    return;
            }
        }
        static string CreateBar(char symbol, int value, int totalLength, string additionalText = "")
        {
            if (value > 10)
            {
                value = 10;
            }
            else if (value < 0) 
            {
                value = 0;
            }
            string bar = new string(symbol, value) + new string('_', totalLength - value);
            return $"{bar} {additionalText}";
        }
    }
}