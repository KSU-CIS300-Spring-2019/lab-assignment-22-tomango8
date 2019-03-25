using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
   
    public class TrieWithNoChildren : ITrie
    {
        /// <summary>
        /// Whether the trie contains the empty string
        /// </summary>
        private bool _emptyString = false;

        

        public ITrie Add(string s)
        {
            if (s == "")
            {
                _emptyString = true;
                
            }
            else
            {
                TrieWithOneChild result = new TrieWithOneChild(s, _emptyString);
                return result;
            }
            return this;
            
        }

        public bool Contains(string s)
        {
            if (s == "")
            {
                return _emptyString;
            }
            return false;
        }
    }
}
