using System;
using System.Reflection.PortableExecutable;

namespace lineCookLife
{
    class versionOne
    {
        static void Main(string[] args)
        {
            int stamina = 0, prestige = 0, health = 0, choice = 0, order = 0;
            Random r = new Random();
            bool win = false;
            Console.Write("What is the name of your cook? ");
            string name = Console.ReadLine();
            initValues(ref stamina, ref prestige, ref health, r);
            while (stamina > 0 && prestige > 0 && health > 0 && win == false)
            {
                choice = chooseChoice();
                if (choice == 1)
                    actions(r.Next(4), ref stamina, ref prestige, ref health);
                else
                    actions(r.Next(10), ref stamina, ref prestige, ref health);
                checkResults(ref order, ref stamina, ref prestige, ref health, ref win);
            }
            if (win)
                Console.WriteLine("You've done a great job!");
            else if (stamina <= 0)
                Console.WriteLine("You feel your stamina hit rock bottom. You decide maybe cooking just isn't for you and head home.");
            else if (prestige <= 0)
                Console.WriteLine("With your latest blunder, your prestige is completely gone. You have been fired.");
            else if (health <= 0)
                Console.WriteLine("After all your cuts, burns, and bruises, you decide cooking has a poor impact on your health. You decide to retire.");

        }

        private static void checkResults(ref int order, ref int stamina, ref int prestige, ref int health, ref bool win)
        {
            order++;
            Console.WriteLine($"Order {order}");
            Console.WriteLine($"You have {health} health");
            Console.WriteLine($"You have {prestige} prestige");
            Console.WriteLine($"You have {stamina} stamina");
            if (order >= 25)
            {
                Console.WriteLine("You show the Head Chef that you can stand the heat. He promotes you to Sous Chef! Congrats!");
                win = true;
            }
            if (prestige >= 50)
            {
                Console.WriteLine("Through all your hard work, you've been promoted to Head Chef! Congrats!");
            }
            return;
        }

        private static void actions(int v, ref int stamina, ref int prestige, ref int health)
        {
            Random r = new Random();
            int num = r.Next(10);
            switch (num)
            {
                case 0:
                    Console.WriteLine("While working the dish tank, a spoon ricochets water back into your face. You're sad.");
                    Console.WriteLine("You lose 1 unit of health and 1 unit of prestige");
                    health -= 1;
                    prestige -= 1;
                    break;
                case 1:
                    Console.WriteLine("You cook a delicious dish, it lifts everyones' spirit!");
                    Console.WriteLine("You gain 2 units of health and prestige, but lose one stamina");
                    health += 2;
                    prestige += 2;
                    stamina -= 1;
                    break;
                case 2:
                    Console.WriteLine("You were caught handling the Head Chef's Shun. You fumble it and cut your hand. Ouch!");
                    Console.WriteLine("You lose 2 units of health and 1 unit of prestige");
                    health -= 2;
                    prestige -= 1;
                    break;
                case 3:
                    Console.WriteLine("You manage to save your coworker's dish! Nice job!");
                    Console.WriteLine("You gain 1 unit of health and 2 units of prestige");
                    health += 1;
                    prestige += 2;
                    break;
                case 4:
                    Console.WriteLine("You spend all day stirring authentic rissoto. Your body is in shambles, but it turned out perfect!");
                    Console.WriteLine("You lose 3 units of health, but gain 2 units of prestige.");
                    health -= 3;
                    prestige += 2;
                    break;
                case 5:
                    Console.WriteLine("A server brings you a cool and freshing glass of water. Wow, that's good!");
                    Console.WriteLine("You gain 2 units of health and stamina");
                    health += 2;
                    stamina += 2;
                    break;
                case 6:
                    Console.WriteLine("You confit some duck. Boy, that's tasty!");
                    Console.WriteLine("You gain 3 units of health and prestige");
                    health += 3;
                    prestige += 3;
                    break;
                case 7:
                    Console.WriteLine("Your coworker convinces you the restaurant is haunted. Yikes.");
                    Console.WriteLine("You lose 1 unit of health and 2 units of prestige");
                    health += 1;
                    prestige += 1;
                    break;
                case 8:
                    Console.WriteLine("You work a double, but you absolutely killed it!");
                    Console.WriteLine("You gain 3 units of prestige, but lose 2 units of stamina");
                    prestige += 3;
                    stamina -= 2;
                    break;
                case 9:
                    Console.WriteLine("It's your day off! Relax a little bit!");
                    Console.WriteLine("You gain 2 units of stamina and health");
                    health += 2;
                    stamina += 2;
                    break;
                default:
                    Console.WriteLine("You spend your shift chopping mirepoix. Your hands are blisted. ");
                    Console.WriteLine("You lose 1 unit of health and 2 units of stamina");
                    health -= 1;
                    stamina -= 2;
                    break;
            }
        }

        private static int chooseChoice()
        {
            Console.WriteLine($"What should you do? Enter 1 or 2 to act!");
            int choice = int.Parse(Console.ReadLine());
            while (choice != 1 && choice != 2)
            {
                Console.WriteLine("You entered an invalid number, please enter a 1 for left or a 2 to act.");
                choice = int.Parse(Console.ReadLine());
            }
            return choice;
        }

        private static void initValues(ref int stamina, ref int prestige, ref int health, Random r)
        {
            stamina = r.Next(10) + 1;
            prestige = r.Next(15) + 5;
            health = r.Next(14) + 5;
        }
    }
}