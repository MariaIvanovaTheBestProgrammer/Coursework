using DAL;
using System;
using System.Linq;

namespace BLL
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ac = new AgencyContext())
            {
                var a = ac.Clients;
                foreach (Client c in a)
                {
                    Console.WriteLine(c.ToString());
                }
            }
        }

    }
}
