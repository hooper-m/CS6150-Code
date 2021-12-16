using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6 {
    class Q1 {
        const int N = 500;
        const int M = 500;
        const int D = 25;

        const string IN_PATH = @"D:\Documents\School\CS6150\HW6\q1d.txt";

        public static void Q1a() {
            Random rng = new(8675309);

            HashSet<int>[] people = new HashSet<int>[N];
            HashSet<int>[] skills = new HashSet<int>[M];

            do {
                for (int i = 0; i < M; i++) {
                    skills[i] = new();
                }

                for (int i = 0; i < N; i++) {
                    HashSet<int> person = new();

                    while (person.Count < D) {
                        person.Add(rng.Next(M));
                    }

                    people[i] = person;

                    foreach (int skill in person) {
                        skills[skill].Add(i);
                    }
                }
            } while (skills.Any(peopleWithSkill => peopleWithSkill.Count == 0));

            Console.Write("min: x0");
            for (int i = 1; i < N; i++) {
                Console.Write($" + x{i}");
            }
            Console.WriteLine(";");

            for (int i = 0; i < M; i++) {
                HashSet<int> peopleWithSkill = skills[i];
                var ordered = peopleWithSkill.OrderBy(i => i);
                Console.Write($"x{ordered.First()}");

                foreach (int personWithSkill in ordered.Skip(1)) {
                    Console.Write($" + x{personWithSkill}");
                }

                Console.WriteLine(" >= 1;");
            }
            Console.WriteLine();

            double[] weights = new double[N];
            using StreamReader sr = File.OpenText(IN_PATH);
            for (int i = 0; i < N; i++) {
                string[] line = sr.ReadLine().Split();
                weights[i] = double.Parse(line[^1]);
            }

            double[] ts = { 1.0, 2.0, 4.0, 8.0 };

            Console.WriteLine("t\tHired\tUncovered Skills");

            foreach (double t in ts) {
                int hired = 0;
                HashSet<int> coveredSkills = new();

                for (int i = 0; i < N; i++) {
                    double w = weights[i];
                    if (t * w >= rng.NextDouble()) {
                        hired++;
                        coveredSkills.UnionWith(people[i]);
                    }
                }
                Console.Write($"{t}\t");
                Console.Write($"{hired}\t");
                Console.WriteLine($"{M - coveredSkills.Count}");
            }
        }
    }
}
