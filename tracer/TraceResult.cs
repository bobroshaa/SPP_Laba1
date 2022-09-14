﻿using System.Collections.Concurrent;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace tracer
{
    [Serializable]
    public class TraceResult
    {
        public TraceResult(){}
        public List<ThreadInfo> Threads { get; }
        public TraceResult(ConcurrentDictionary<int, ThreadInfo> dictionary)
        {
            Threads = new List<ThreadInfo>();
            foreach (var thread in dictionary)
            {
                dictionary.TryGetValue(thread.Key, out ThreadInfo threadInfo);
                threadInfo.EndThread();
                Threads.Add(threadInfo);
            }
        }
    }
}
