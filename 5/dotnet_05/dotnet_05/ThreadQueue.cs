using System;
using System.Collections.Generic;
using System.Threading;

namespace dotnet_05
{
    internal class ThreadQueue
    {
        private Queue<Thread>[] queue;

        public ThreadQueue(int num) { 
            queue = new Queue<Thread>[num];
            for(int i = 0; i<queue.Length; i++)
            {
                queue[i] = new Queue<Thread>();
            }
        }

        public void addTask(Thread t)
        {
            int minNum = 0;
            for(int i = 0; i<queue.Length; i++)
            {
                if (queue[i].Count < minNum)
                    minNum = queue[i].Count;
            }
            queue[minNum].Enqueue(t);
        }
    }
}
