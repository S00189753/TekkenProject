using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TekkenProject
{
    public class Account
    {
        public string AccountNumber { get; set; }
        public int TotalPlayed { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }

        public Account(string accountNumber, int totalPlayed, int wins, int losses)
        {
            AccountNumber = accountNumber;
            TotalPlayed = totalPlayed;
            Wins = wins;
            Losses = losses;
        }

        public Account(string accountNumber) : this(accountNumber, 0, 1, 2) { }

        public Account() : this("Unknown") { }

        public override string ToString()
        {
            return string.Format("[{0}] {1} {2} {3}", this.GetType().Name.ToUpper(), AccountNumber, TotalPlayed, Wins, Losses);
        }
    }
}
