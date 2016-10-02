using SecretSolution_g_3_1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSolution_g_3_1.Implementation
{
    internal class EscapeBunnyAnswer : IAnswer
    {
        private void PrintMap(int[,] map)
        {
            Console.WriteLine("Map:");
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write("{0} ", map[i, j]);
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
        }

        struct Point
        {
            public int x;
            public int y;
            public int distance;
        }
        // write the bfs base code
        Queue<Point> nodeQueue = new Queue<Point>();
        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };
        

        public int answer(object o)
        {
            // left, right, down, up
            
            // this will not be included in the item to copy
            // to the solution file of foobar
            int[,] maze = (int[,])Convert.ChangeType(o, typeof(int[,]));
            int[,] visitedNodes = new int[maze.GetLength(0), maze.GetLength(1)];//maze.Length][];

            // You code goes here.
            // the solution probably uses a modified BFS
            int pathLength = 0;

            // need a queue
            // need a visit array

            //int[][] visitedNodes = new int[maze.Length, maze[0].Length];//maze.Length][];
            Console.WriteLine("Starting iteration...");
            PrintMap(maze);
            Console.ReadKey();

            // visit the first node
            int endPointX = maze.GetUpperBound(1);
            int endPointY = maze.GetUpperBound(0);

            Point p = new Point { x = endPointX, y = endPointY, distance = 11 };

            nodeQueue.Enqueue(p);
            visitedNodes[endPointY, endPointX] = 1;
            maze[endPointY, endPointX] = 11;
            Console.WriteLine("Post iteration map:");
            PrintMap(maze);
            Console.ReadKey();

            while (nodeQueue.Count > 0) 
            {
                var current = nodeQueue.Dequeue(); // this contains the current node

                // check up left right down
                for (int i = 0; i < 4; i++) 
                {
                    int xAxis = current.x + dx[i];
                    int yAxis = current.y + dy[i];
                    // bounds checking
                    if (xAxis >= 0 && xAxis < maze.GetLength(1) && yAxis >= 0 && yAxis < maze.GetLength(0))
                    {
                        // put a distance
                        if (maze[yAxis,xAxis] == 0 && visitedNodes[yAxis, xAxis]==0) 
                        {
                            maze[yAxis, xAxis] = current.distance + 1;
                            visitedNodes[yAxis, xAxis] = 1;
                            nodeQueue.Enqueue(new Point { x = xAxis, y = yAxis, distance = current.distance + 1 });
                        }
                    }
                }
                Console.WriteLine("Post iteration map:");
                PrintMap(maze);
                Console.ReadKey();

            }

            // we now try to remove a wall, and update neighbouring nodes
            // by choosing the lower valued


            int wallLength = maze[0,0] == 0? endPointX * endPointY + 10 : maze[0,0];

            for (int i = endPointY; i >=0 ; i-- ) 
            {
                for (int j = endPointX; j >=0; j--) 
                {
                    if (maze[i, j] == 1) 
                    {
                        // check the up left right down
                        int left = j - 1;
                        int right = j + 1;
                        int down = i + 1;
                        int up = i - 1;
                        int higher = -1;
                        int lower = 1000;

                        if (up >= 0 && (visitedNodes[up, j] == 1 || maze[up,j] != 1)) 
                        {
                            if(maze[up, j] < lower)
                                lower = maze[up,j];
                            if(maze[up, j] > higher)
                                higher = maze[up,j];
                        }
                        if (down < maze.GetLength(0) && (visitedNodes[down, j] == 1 || maze[down, j] != 1)) 
                        {
                            if(maze[down, j] < lower)
                                lower = maze[down,j];
                            if(maze[down, j] > higher)
                                higher = maze[down,j];
                            // need to store this value
                        }
                        if (left >= 0 && (visitedNodes[i, left] == 1 || maze[i, left] != 1)) 
                        {
                            if (maze[i, left] < lower)
                                lower = maze[i, left];
                            if (maze[i, left] > higher)
                                higher = maze[i, left];
                        }
                        if (right < maze.GetLength(1) && (visitedNodes[i, right] == 1 || maze[i, right] != 1))
                        {
                            if (maze[i, right] < lower)
                                lower = maze[i, right];
                            if (maze[i, right] > higher)
                                higher = maze[i, right];
                        }
                        // get the highest value
                        // int result = (higher - lower);
                        if (higher != lower)
                        {
                            
                            maze[i, j] = lower == 0 ? higher + 1 : lower + 1;
                            int res = updateMap(maze, j, i);
                            if (res > 0 && res < wallLength)
                            {
                                wallLength = res;
                            }
                            maze[i, j] = 1;
                        }
                    }
                    // wallLength = updateMap
                }
            }



            return wallLength - 10;
        }

        private int updateMap(int[,] copy, int qx, int qy) 
        {
            // this will not be included in the item to copy
            // to the solution file of foobar
            int [,] maze = new int[copy.GetLength(0), copy.GetLength(1)];
            Array.Copy(copy, maze, copy.Length);
            int[,] visitedNodes = new int[maze.GetLength(0), maze.GetLength(1)];//maze.Length][];
            // You code goes here.
            // the solution probably uses a modified BFS
            int pathLength = 0;

            // need a queue

            // need a visit array

            //int[][] visitedNodes = new int[maze.Length, maze[0].Length];//maze.Length][];

            // visit the first node
            Point p = new Point { x = qx, y = qy, distance = maze[qy,qx] };
            nodeQueue.Enqueue(p);

            // no need for a visit node. just update while the queue has value
            visitedNodes[qy, qx] = 1;
            Console.WriteLine("Starting iteration...");
            PrintMap(maze);
            Console.ReadKey();
            while (nodeQueue.Count > 0)
            {
                var current = nodeQueue.Dequeue(); // this contains the current node

                // check up left right down
                for (int i = 0; i < 4; i++)
                {
                    var xAxis = current.x + dx[i];
                    var yAxis = current.y + dy[i];
                    // bounds checking
                    if (xAxis >= 0 && xAxis < maze.GetLength(1) && yAxis >= 0 && yAxis < maze.GetLength(0))
                    {
                        // put a distance
                        if ((maze[yAxis, xAxis] == 0 || maze[yAxis, xAxis] > current.distance + 1) && visitedNodes[yAxis, xAxis] == 0)
                        {
                            maze[yAxis, xAxis] = current.distance + 1;
                            visitedNodes[yAxis, xAxis] = 1;
                            nodeQueue.Enqueue(new Point { x = xAxis, y = yAxis, distance = current.distance + 1 });
                        }
                        //else if(visitedNodes[yAxis,xAxis] > 0)
                        //{
                        //    if(maze[yAxis,xAxis] > current.distance)
                        //        maze[yAxis,xAxis] = current.distance;
                        //}
                    }
                }

                Console.WriteLine("Post iteration map:");
                PrintMap(maze);
                Console.ReadKey();

            }
            return maze[0, 0];
        }
    }
}
