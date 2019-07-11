using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableNamespace
{
    class HashTable
    {
        object[] keyMap;
        int length;
        public HashTable(int length)
        {
            this.length = length;
            this.keyMap = new object[length];
        }
        static void Main(string[] args)
        {
            HashTable newHT = new HashTable(4);
            Console.WriteLine("Red: " + newHT.Set("red", "FF0000"));
            Console.WriteLine("Blue: " + newHT.Set("blue", "2000FF"));
            Console.WriteLine("Green: " + newHT.Set("green", "00FF31"));
            Console.WriteLine("Cyan: " + newHT.Set("cyan", "00FDFF"));
            Console.WriteLine("Purple: " + newHT.Set("purple", "780BCC"));
            Console.WriteLine("pink: " + newHT.Set("pink", "FF1B93"));

            Console.WriteLine("Enter a key to search for value in the Hashtable");
            string input = Console.ReadLine();

            Console.WriteLine("Searching for " + input);
            Console.WriteLine(newHT.Get(input));
            Console.WriteLine("Search again?");
            string response = Console.ReadLine();
            while (response == "y" || response == "Y")
            {
                Console.WriteLine("Enter a key to search for value in the Hashtable");
                input = Console.ReadLine();
                Console.WriteLine("Searching for " + input);
                Console.WriteLine(newHT.Get(input));
                Console.WriteLine("Search again?");
                response = Console.ReadLine();
            }
        }

        int Set(string color, string hex)
        {
            int length = this.length;
            int result = 0;
            int prime = 31;
            foreach (char x in color)
            {
                result = ((result * prime + (int)x) % length);
            }
            if (this.keyMap[result] == null)
            {
                List<object> list = new List<object>();
                string[] keyValue = new string[2] { color, hex };
                list.Add(keyValue);
                this.keyMap[result] = list;
                Console.WriteLine("Added " + color + " and " + hex + " in new index");
            }
            else
            {
                List<object> list = this.keyMap[result] as List<object>;
                string[] keyValue = new string[2] { color, hex };
                list.Add(keyValue);
                Console.WriteLine("Index taken. Added " + color + " and " + hex + " to existing list.");
            }
            return result;
        }
        string Get(string key)
        {
            int result = 0;
            int prime = 31;
            foreach (char x in key)
            {
                result = ((result * prime + (int)x) % length);
            }
            Console.WriteLine("Hash index: " + result);
            if (this.keyMap[result] == null)
            {
                return "Index is null, value not found";
            }
            List<object> mylist = this.keyMap[result] as List<object>;
            for (int i = 0; i < mylist.Count; i++)
            {
                var kvpair = mylist[i] as string[];
                if (kvpair[0] == key)
                {
                    Console.WriteLine(key + " " + kvpair[1]);
                    return kvpair[1];
                }
            }
            return "Value Not found";
        }
    }
}
