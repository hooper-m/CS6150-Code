using System;
using System.Collections.Generic;
using System.Linq;

namespace HW6 {
    class Q2 {

        const int N_SERVERS = 10_000_000;

        public static void Q2a() {
            Random rng = new(8675309);
            Dictionary<int, int> histogram = new();
            int[] servers = new int[N_SERVERS];

            Stack<int> noLoad = new();

            for (int i = 0; i < N_SERVERS; i++) {

                servers[rng.Next(N_SERVERS)]++;
            }


            foreach (int server in servers) {
                if (histogram.ContainsKey(server)) {
                    histogram[server]++;
                }
                else {
                    histogram[server] = 1;
                }
            }

            foreach ((int key, int value) in histogram.OrderBy(kvp => kvp.Key)) {
                Console.WriteLine($"{key} {value}");
            }
        }

        public static void Q2b() {
            Random rng = new(8675309);
            Dictionary<int, int> histogram = new();
            int[] servers = new int[N_SERVERS];

            Stack<int> noLoad = new();

            for (int i = 0; i < N_SERVERS; i++) {

                int server1 = rng.Next(N_SERVERS);
                int server2;
                do {
                    server2 = rng.Next(N_SERVERS);
                } while (server1 == server2);

                int actualServer = servers[server1] < servers[server2]
                                 ? server1
                                 : server2;

                servers[actualServer]++;
            }


            foreach (int server in servers) {
                if (histogram.ContainsKey(server)) {
                    histogram[server]++;
                }
                else {
                    histogram[server] = 1;
                }
            }
            
            foreach ((int key, int value) in histogram.OrderBy(kvp => kvp.Key)) {
                Console.WriteLine($"{key} {value}");
            }
        }
    }
}
