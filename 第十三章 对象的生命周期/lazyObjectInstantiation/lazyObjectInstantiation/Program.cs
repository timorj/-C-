using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lazyObjectInstantiation
{
    class Program
    {
        static void Main(string[] args)
        {
            MediaPlayer myPlayer = new MediaPlayer();
            myPlayer.Play();
            AllTracks yourMusic =myPlayer.GetAllTracks();
            Console.Read();
            Solution solution = new Solution();
            string s = solution.LongestPalindrome("ac");
        }
        public class Solution
        {
            public string LongestPalindrome(string s)
            {
                List<string> resultList = new List<string>();
                string result = "";
                bool haveSame = false;
                Char[] strings = s.ToCharArray();
                if (strings.Length == 1)
                {
                    result = strings[0].ToString();
                    return result;
                }
                for (int i = 0; i < strings.Length; i++)
                {
                    result += strings[i];
                    for (int j = i + 1; j < strings.Length; j++)
                    {
                        if (strings[j] == strings[i])
                        {
                            haveSame = true;
                            result += strings[j];
                            break;
                        }
                        else
                        {
                            result += strings[j];
                        }
                    }
                    if (haveSame)
                    {
                        resultList.Add(result);
                    }
                    result = "";
                    haveSame = false;
                }
                int index = 0;
                int max = 0;
                for (int i = 0; i < resultList.Count; i++)
                {
                    var tempList = resultList[i].ToCharArray();
                    if (tempList.Length > max)
                    {
                        max = tempList.Length;
                        index = i;
                    }
                }
                result = resultList[index];
                return result;
            }
        }

    }
    class Song
    {
        public string Artist { get; set; }
        public string TrackName { get; set; }
        public double TrackLength { get; set; }
    }
    class AllTracks
    {
        private Song[] allSongs = new Song[10000];
        public AllTracks()
        {
            Console.WriteLine("Filling up the songs");
        }

    }
    class MediaPlayer
    {
        public void Play() { }
        public void Pause() { }
        public void Stop() { }

        //private Lazy<AllTracks> allSongs = new Lazy<AllTracks>();
        private Lazy<AllTracks> allSongs = new Lazy<AllTracks>(() => {
            Console.WriteLine("Creating AllTracks object");
            return new AllTracks();
        });
        public AllTracks GetAllTracks() 
        {
            return allSongs.Value;
        }
    }
}
