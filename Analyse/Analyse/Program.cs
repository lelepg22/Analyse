using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Analyse
{
    class Program
    {
        static void Main(string[] args)
        {
            // Donner la liste des acteurs qui ont joue le plus de roles,
            // ainsi que la liste des films dans lequels ils ont joue.

            var readCredits = File.ReadAllLines(@"C:\Users\Administrateur\source\repos\exercice weekend 1106\Analyse\Analyse\Analyse\NetflixCredits.csv");

            var readTitles = File.ReadAllLines(@"C:\Users\Administrateur\source\repos\exercice weekend 1106\Analyse\Analyse\Analyse\NetflixTitles.csv");

            var donneesCredits = readCredits.Skip(1).Select(x => x.Split(',')).ToList();
            var donneesTitles = readTitles.Skip(1).Select(x => x.Split(',')).ToList();

            var resultCredits = donneesCredits.Select(x => x[2]).GroupBy(x => x).ToList();
           
            var plusRoleActeurs = resultCredits.OrderBy(x => x.Count()).Reverse().Select(x => x).ToList();

            for (int i = 0;  i < 5; i++) {

                Console.WriteLine("TOP " + (i +1) + " Acteur/trice by Roleplayed quantity :!");


                                
                var allMoviesId = donneesCredits.Where(x => x[2].IndexOf(plusRoleActeurs[i].Key) != -1).Select(x => { return x; }).ToList();

                List<string> allIdByActor = new List<string>();
                List<string> moviesAndTitle = new List<string>();
                
                for(int x = 0; x < allMoviesId.Count(); x++)
                {
                    allIdByActor.Add(allMoviesId[x][1]);

                }

                for(int y = 0; y < allIdByActor.Count(); y++)
                {
                  var theMovie =  donneesTitles.Where(x => x[0].IndexOf(allIdByActor[y]) != -1).Select(x => x).ToList();
                  moviesAndTitle.Add(theMovie[0][1]);
                }

                Console.WriteLine("Acteur/trice : " + plusRoleActeurs[i].Key + " played in : " + plusRoleActeurs[i].Count() + " movies : Participations ----- >");
                for(int f = 0; f < moviesAndTitle.Count(); f++)
                {
                    Console.WriteLine(moviesAndTitle[f]);
                }
            }

            var resultTitles = donneesTitles.Select(x => x[0]).ToList();
            
            

            //resultCredits.Sort();



        }
    }
}
