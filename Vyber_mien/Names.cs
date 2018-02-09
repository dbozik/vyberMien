using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vyber_mien
{
    public class Names
    {
        private List<string> names;
        private string pathName = "names.txt";

        private void MoveUp(int index)
        {
            if (index <= 0)
            {
                return;
            }

            this.names.Swap<string>(index, index - 1);
        }

        private void MoveDown(int index)
        {
            if (index >= this.names.Count - 1 )
            {
                return;
            }

            this.names.Swap<string>(index, index + 1);
        }

        public Names()
        {
            //var pathName = "names.txt";
            var path = Path.Combine(Environment.CurrentDirectory, pathName);

            this.names = new List<string>();

            using (var file = new StreamReader(path))
            {
                while (!file.EndOfStream)
                {
                    this.names.Add(file.ReadLine());
                }
            }
        }
        
        public Tuple<string, string> GetPair()
        {
            var random = new Random();
            var firstNumber = random.Next(0, this.names.Count() - 5);
            var secondNumber = random.Next(firstNumber + 1, firstNumber + 5);
            var shuffler = random.Next(0, 2);

            if (shuffler == 0)
            {
                return new Tuple<string, string>(this.names[firstNumber], this.names[secondNumber]);    
            }
            else
            {
                return new Tuple<string, string>(this.names[secondNumber], this.names[firstNumber]);
            }
            
        }

        public void ProcessChoice(string winner, string looser)
        {
            var winnerIndex = this.names.IndexOf(winner);
            var looserIndex = this.names.IndexOf(looser);

            if (winnerIndex < looserIndex)
            {
                this.names.MoveUp(winner);
                this.names.MoveDown(looser);
            }
            else
            {
                this.names.MoveDown(looser);
                this.names.MoveDown(looser);
                this.names.MoveUp(winner);
                this.names.MoveUp(winner);
            }
        }

        public void SaveFile()
        {
            var path = Path.Combine(Environment.CurrentDirectory, pathName);

            using (var file = new StreamWriter(path, false))
            {
                foreach (var name in this.names)
                {
                    file.WriteLine(name);
                }
            }
        }

        public void Delete(string name)
        {
            this.names.Remove(name);
        }

        public int Count 
        { 
            get
            {
                return names.Count;
            }
        }
    }
}
