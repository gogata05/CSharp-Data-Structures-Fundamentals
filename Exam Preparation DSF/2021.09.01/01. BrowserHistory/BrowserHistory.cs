namespace _01._BrowserHistory
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using _01._BrowserHistory.Interfaces;

    public class BrowserHistory : IHistory
    {
        private LinkedList<ILink> _history;

        public BrowserHistory()
        {
            _history = new LinkedList<ILink>();
        }

        public int Size => _history.Count;

        public void Clear()
        {
            _history.Clear();
        }

        public bool Contains(ILink link)
        {
            return _history.Contains(link);
        }

        public ILink DeleteFirst()
        {
            if (_history.Count == 0)
            {
                throw new InvalidOperationException();
            }

            ILink firstLink = _history.Last.Value;
            _history.RemoveLast();
            return firstLink;
        }

        public ILink DeleteLast()
        {
            if (_history.Count == 0)
            {
                throw new InvalidOperationException();
            }

            ILink lastLink = _history.First.Value;
            _history.RemoveFirst();
            return lastLink;
        }

        public ILink GetByUrl(string url)
        {
            foreach (var link in _history)
            {
                if (link.Url == url)
                {
                    return link;
                }
            }

            return null;
        }

        public ILink LastVisited()
        {
            if (_history.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return _history.First.Value;
        }

        public void Open(ILink link)
        {
            _history.AddFirst(link);
        }

        public int RemoveLinks(string url)
        {
            int count = 0;
            LinkedListNode<ILink> current = _history.First;

            while (current != null)
            {
                LinkedListNode<ILink> next = current.Next;
                if (current.Value.Url.IndexOf(url, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    _history.Remove(current);
                    count++;
                }
                current = next;
            }

            if (count == 0)
            {
                throw new InvalidOperationException();
            }

            return count;
        }

        public ILink[] ToArray()
        {
            ILink[] result = new ILink[_history.Count];
            int index = 0;
            foreach (var link in _history)
            {
                result[index++] = link;
            }
            return result;
        }

        public List<ILink> ToList()
        {
            List<ILink> result = new List<ILink>(_history.Count);
            foreach (var link in _history)
            {
                result.Add(link);
            }
            return result;
        }

        public string ViewHistory()
        {
            if (_history.Count == 0)
            {
                return "Browser history is empty!";
            }

            StringBuilder sb = new StringBuilder();
            foreach (var link in _history)
            {
                sb.AppendLine(link.ToString());
            }
            return sb.ToString();
        }
    }
}
