using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Linq;

namespace JeonsoftTeamScriptManager
{
    public sealed class StashManager
    {
        private static StashManager instance;
        private List<IndexedFile> indexedFiles;

        private StashManager()
        {
            indexedFiles = new List<IndexedFile>();
        }

        public static StashManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new StashManager();
                return instance;
            }
        }

        public void Clear()
        {
            indexedFiles.Clear();
        }

        public bool Contains(IndexedFile idx)
        {
            return indexedFiles.Contains(idx, new SimpleCompare());
        }

        public void Add(IndexedFile idx)
        {
            indexedFiles.Add(idx);
        }

        public void Remove(IndexedFile idx)
        {
            indexedFiles.Remove(idx);   
        }

        public int Count
        {
            get { return indexedFiles.Count; }
        }

        public List<IndexedFile> Stash
        {
            get { return indexedFiles; }
        }
    }

    class SimpleCompare : IEqualityComparer<IndexedFile>
    {
        public bool Equals(IndexedFile x, IndexedFile y)
        {
            return x.path.ToLower() == y.path.ToLower();
        }
        public int GetHashCode(IndexedFile idx)
        {
            return idx.path.ToLower().GetHashCode();
        }
    }

    //class Compare : IEqualityComparer<IndexedFile>
    //{
    //    public bool Equals(IndexedFile x, IndexedFile y)
    //    {
    //        try
    //        {
    //            if (Utils.GetHostType(x.path.ToLower()) != UriHostNameType.Basic)
    //            {
    //                if (Utils.AreHostNameEqual(x.path.ToLower(), y.path.ToLower()))
    //                {
    //                    try
    //                    {
    //                        string h1 = Utils.GetHost(x.path.ToLower());
    //                        string h2 = Utils.GetHost(y.path.ToLower());
    //                        string path1 = x.path.ToLower().Replace(h1.ToLower(), h2.ToLower());
    //                        return path1.ToLower() == y.path.ToLower();
    //                    }
    //                    catch(Exception)
    //                    {
    //                        return x.path.ToLower() == y.path.ToLower();
    //                    }
    //                }
    //                else
    //                    return x.path.ToLower() == y.path.ToLower();
    //            }
    //            else
    //            {
    //                return x.path.ToLower() == y.path.ToLower();
    //            }
    //        }
    //        catch(Exception)
    //        {
    //            return x.path.ToLower() == y.path.ToLower();
    //        }
    //    }
    //    public int GetHashCode(IndexedFile idx)
    //    {
    //        return idx.path.ToLower().GetHashCode();
    //    }
    //}
}
