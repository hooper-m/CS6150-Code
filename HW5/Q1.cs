using System;
using System.Collections.Generic;
using System.Linq;

namespace HW5 {
    class Q1 {

        const int N = 10_000_000;
        const double PERCENT_A = 0.55;
        const int TRIALS = 100;
        static readonly int[] SAMPLE_SIZES = new int[] { 20, 100, 400, 1000, 1200, 1400, 300 };

        static void Main(string[] args) {
            Q1a();
        }


        static void Q1a() {
            Random rng = new Random();
            char[] votes = new char[N];

            for (int i = 0; i < (int) (N * PERCENT_A); i++) {
                votes[i] = 'A';
            }
            for (int i = (int) (N * PERCENT_A); i < votes.Length; i++) {
                votes[i] = 'B';
            }

            votes = votes.OrderBy(_ => rng.Next()).ToArray();

            List<HashSet<int>> samples = new();

            foreach (int sampleSize in SAMPLE_SIZES) {
                for (int i = 0; i < TRIALS; i++) {
                    HashSet<int> sampleIndices = new();
                    while (sampleIndices.Count < sampleSize) {
                        int index = rng.Next(N);

                        while (sampleIndices.Contains(index)) {
                            index = rng.Next(N);
                        }

                        sampleIndices.Add(index);
                    }
                    samples.Add(sampleIndices);
                }
            }

            Dictionary<int, int> majorityCountsBySampleSize = SAMPLE_SIZES.ToDictionary(s => s, _ => 0);

            foreach (HashSet<int> sample in samples) {
                int As = sample.Select(s => votes[s])
                               .Count(v => v == 'A');

                if (As > sample.Count / 2) {
                    majorityCountsBySampleSize[sample.Count]++;
                }
            }

            foreach ((int sampleSize, int count) in majorityCountsBySampleSize) {
                Console.WriteLine($"Sample size {sampleSize}: {count} ~ {(double) count / TRIALS}");
            }
        }
    }
}
