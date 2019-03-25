using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    public class TrieWithOneChild : ITrie
    {
        /// <summary>
        /// Whether the trie contains the empty string
        /// </summary>
        private bool _emptyString;

        /// <summary>
        /// the only child
        /// </summary>
        private ITrie _onlyChild;

        /// <summary>
        /// the child's label
        /// </summary>
        private char _label;

        public TrieWithOneChild(string s, bool hasEmpty)
        {
            if (s == "" || (s[0] < 'a' || s[0] > 'z'))
            {
                throw new ArgumentException();
            }
            _emptyString = hasEmpty;
            _label = s[0];
            TrieWithNoChildren result = new TrieWithNoChildren();
             _onlyChild = result.Add(s.Substring(1));

        }



        public ITrie Add(string s)
        {
            if (s == "")
            {
                _emptyString = true;
               
                return this;
            }
            else if (s[0] == _label)
            {
                _onlyChild = _onlyChild.Add(s.Substring(1));
                return this;
            }
            else
            {
                TrieWithManyChildren result = new TrieWithManyChildren(s, _emptyString, _label, _onlyChild);
                
                return result;
            }

        }

        public bool Contains(string s)
        {
            if (s == "")

            {
                return _emptyString;
            }
            else if(s[0] == _label)
            {
                return _onlyChild.Contains(s.Substring(1));
            }
            else
            {
                return false;
            }
        }
    }
}
