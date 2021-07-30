using System;

namespace Double_Ended_Queue
{
    class Program
    {
        public class Deque <T>
        {
            public int Count { get; private set; }
            int front;
            int rear;
            readonly int size = 10;
            T[] arr;
            public Deque()
            {
                arr = new T[size];
                front = -1;
                rear = -1;
                Count = 0;
            }
            public void InsertAtFront(T value)
            {
                if(front == -1 && rear == -1)
                {
                    front = rear = 0;
                    arr[front] = value;
                    Count++;
                    return;
                }
                else if(front == 0 && (size-1) != rear)
                {
                    front = size - 1;
                    arr[front] = value;
                    Count++;
                    return;
                }
                else if(front != 0  && (front-1) != rear)
                {
                    arr[--front] = value;
                    Count++;
                    return;
                }
                else
                {
                    Console.WriteLine("Deque is Overflow.");
                    return;
                }

            }
            public T DeleteFromFront()
            {
                if (front == -1 && rear == -1)
                {
                    Console.WriteLine("Deque is empty.");
                    return default(T);
                }
                else if(front == rear)
                {
                    T temp1 = arr[front];
                    front = rear = -1;
                    Count = 0;
                    return temp1;
                }
                T temp = arr[front];
                front = (++front % size);
                Count--;
                return temp;
            }
            public void InsertAtRear(T value)
            {
                if (front == -1 && rear == -1)
                {
                    front = rear = 0;
                    arr[rear] = value;
                    Count++;
                    return;
                }
                else if ((rear+1)%size != front)
                {
                    arr[++rear] = value;
                    Count++;
                    return;
                }
                else
                {
                    Console.WriteLine("Deque is Overflow.");
                    return;
                }

            }
            public T DeleteFromRear()
            {
                if (front == -1 && rear == -1)
                {
                    Console.WriteLine("Deque is empty.");
                    return default(T);
                }
                else if (front == rear)
                {
                    T temp1 = arr[rear];
                    front = rear = -1;
                    Count = 0;
                    return temp1;
                }
                else if (rear == 0 && rear != front)
                {
                    T temp2 = arr[rear];
                    rear = size-1;
                    Count--;
                    return temp2;
                }
                T temp = arr[rear];
                rear--;
                Count--;
                return temp;
            }
            public void Print()
            {
               
                if(Count == 0)
                {
                    Console.WriteLine("Deque is empty.");
                    return;
                }
                else
                {
                    Console.WriteLine("Deque items are : ");
                    int i = front;
                    while(i != rear)
                    {
                        Console.WriteLine(arr[i]);
                        i = ++i % size;
                    }
                    Console.WriteLine(arr[rear]);
                }
            }
            public T Front()
            {
                if(front != -1)
                {
                    T temp = arr[front];
                    return temp;
                }

                return default(T);
            }
            public T Rear()
            {
                if (rear != -1)
                {
                    T temp = arr[rear];
                    return temp;
                }

                return default(T);
            }

            public bool IsEmpty()
            {
                if (rear == -1 && front  == -1)
                {
                    return true;
                }

                return false;
            }
            public bool IsFull()
            {
                if (Count == size)
                {
                    return true;
                }

                return false;
            }
            public void Clear()
            {
                front = rear = -1;
                Count = 0;
            }
        }
        static void Main(string[] args)
        {
            Deque<int> deque = new Deque<int>();
            deque.InsertAtFront(1);
            deque.InsertAtFront(2);
            deque.InsertAtFront(3);
            deque.Clear();
            deque.DeleteFromRear();
            deque.Print();
            Console.WriteLine(deque.Count);
            Console.ReadKey();
        }
    }
}
