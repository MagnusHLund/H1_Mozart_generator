using System;
using System.Media;

namespace H1_Mozart_generator
{
    internal class Program
    {
        static void Main()
        {
            // Calls the controller
            Controller();

            // Once the program is finished, it does a readline, to keep it running.
            Console.ReadLine();
        }

        static void Controller()
        {
            // Creates 2 random numbers, which act like 6 sided dices
            Random random = new Random();

            int num1 = random.Next(1, 7);
            int num2 = random.Next(1, 7);

            // Adds the dice results together
            int result = num1 + num2;

            // Creates a string array, with 32 slots
            string[] files = new string[32];

            // Creates a soundPlayer, to play media
            SoundPlayer player = new SoundPlayer();

            // For loop to run through each of the mennuets and add it to files
            for (int i = 0; i < 16; i++)
            {
                files[i] = @"C:\Users\magnu\source\repos\H1_Mozart_generator\H1_Mozart_generator\Wav files\M" + MennuetsModel()[result, i] + ".wav";
            }

            // For loop to run through each of the trios and add it to files
            for (int i = 0; i < 16; i++)
            {
                files[i+16] = @"C:\Users\magnu\source\repos\H1_Mozart_generator\H1_Mozart_generator\Wav files\T" + TriosModel()[result / 2, i] + ".wav";
            }

            // For each string in the files array
            foreach (string file in files)
            {
                // Creates a string, which contains the same string as file, except for the first 78 characters
                string sound = file.Remove(0, 78);
                
                // If its a mennuet then its red color and if its trios then its green
                if(sound.Contains("M"))
                    Console.ForegroundColor = ConsoleColor.Red;
                else 
                    Console.ForegroundColor = ConsoleColor.Green;
                
                // Write in console, by calling the View method and giving it the sound string
                View(sound);

                // Play the file from the location
                player.SoundLocation = file;
                player.Load();
                player.PlaySync();
            }
        }

        static void View(string sound)
        {
            // Writes the sounds that play
            Console.WriteLine($"Playing {sound}");
        }

        static int[,] MennuetsModel()
        {
            // Array containing menuets, which returns the array when called

            int[,] menuets = {
                { 96, 22, 141, 41, 105, 122, 11, 30, 70, 121, 26, 9, 112, 49, 109, 14 },
                { 32, 6, 128, 63, 146, 46, 134, 81, 117, 39, 126, 56, 174, 18, 116, 83 },
                { 69, 95, 158, 13, 153, 55, 110, 24, 66, 139, 15, 132, 73, 58, 145, 79 },
                { 40, 17, 113, 85, 161, 2, 159, 100, 90, 176, 7, 34, 67, 160, 52, 170 },
                { 148, 74, 163, 45, 80, 97, 36, 107, 25, 143, 64, 125, 76, 136, 1, 93 },
                { 104, 157, 27, 167, 154, 68, 118, 91, 138, 71, 150, 29, 101, 162, 23, 151 },
                { 152, 60, 171, 53, 99, 133, 21, 127, 16, 155, 57, 175, 43, 168, 89, 172 },
                { 119, 84, 114, 50, 140, 86, 169, 94, 120, 88, 48, 166, 51, 115, 72, 111 },
                { 98, 142, 42, 156, 75, 129, 62, 123, 65, 77, 19, 82, 137, 38, 149, 8 },
                { 3, 87, 165, 61, 135, 47, 147, 33, 102, 4, 31, 164, 144, 59, 173, 78 },
                { 54, 130, 10, 103, 28, 37, 106, 5, 35, 20, 108, 92, 12, 124, 44, 131 } };

            return menuets;
        }

        static int[,] TriosModel()
        {
            // Array containing trios, which returns the array when called

            int[,] trios = {
                { 72, 6, 59, 25, 81, 41, 89, 13, 36, 5, 46, 79, 30, 95, 19, 66 },
                { 56, 82, 42, 74, 14, 7, 26, 71, 76, 20, 64, 84, 8, 35, 47, 88 },
                { 75, 39, 54, 1, 65, 43, 15, 80, 9, 34, 93, 48, 69, 58, 90, 21 },
                { 40, 73, 16, 68, 29, 55, 2, 61, 22, 67, 49, 77, 57, 87, 33, 10 },
                { 83, 3, 28, 53, 37, 17, 44, 70, 63, 85, 32, 96, 12, 23, 50, 91 },
                { 18, 45, 62, 38, 4, 27, 52, 94, 11, 92, 24, 86, 51, 60, 78, 31 } };

            return trios;
        }
    }
}