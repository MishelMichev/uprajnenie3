using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sigleton
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                LoadBalancer b1 = LoadBalancer.GetLoadBalancer();
                LoadBalancer b2 = LoadBalancer.GetLoadBalancer();
                LoadBalancer b3 = LoadBalancer.GetLoadBalancer();
                LoadBalancer b4 = LoadBalancer.GetLoadBalancer();
               
                if (b1 == b2 && b2 == b3 && b3 == b4)
                {
                    Console.WriteLine("Same instance\n");
                }
               
                LoadBalancer balancer = LoadBalancer.GetLoadBalancer();
                for (int i = 0; i < 12; i++)
                {
                    string server = balancer.Server;
                    Console.WriteLine("Dispatch Request to: " + server);
                }
                
                Console.ReadKey();
            }
        }
        
        public class LoadBalancer
        {
            static LoadBalancer instance;
            List<string> servers = new List<string>();
            Random random = new Random();
            
            private static object locker = new object();
    
            protected LoadBalancer()
            {
                
                servers.Add("ServerI");
                servers.Add("ServerII");
                servers.Add("ServerIII");
                servers.Add("ServerIV");
                servers.Add("ServerV");
                servers.Add("ServerVI");
                servers.Add("ServerVII");
                servers.Add("ServerIX");
        }
            public static LoadBalancer GetLoadBalancer()
            {
                
                if (instance == null)
                {
                    lock (locker)
                    {
                        if (instance == null)
                        {
                            instance = new LoadBalancer();
                        }
                    }
                }
                return instance;
            }
           
            public string Server
            {
                get
                {
                    int r = random.Next(servers.Count);
                    return servers[r].ToString();
                }
            }
        }
    }

