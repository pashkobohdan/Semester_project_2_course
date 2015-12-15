using System;
using System.Collections.Generic;
using System.Drawing;

namespace Labyrinth_semester_project_
{
    public class Graph
    {
        public List<Wall> Walls { set; get; }
        private Point start, end;

        public List<Point> Points { set; get; }
        public double[,] Matrix_graph { set; get; }
        private const double inf = 1000000000.0;

        public List<int>[,] Ways { set; get; }


        public Graph(List<Wall> walls, Point start, Point end)
        {
            this.start = start;
            this.end = end;
            Walls = new List<Wall>();
            Walls = walls;

            Points = new List<Point>();


            Points.Add(start);
            for (int i = 0; i < Walls.Count; ++i)
            {
                Points.Add(Walls[i].Dot_1);
                Points.Add(Walls[i].Dot_2);
            }
            Points.Add(end);

            Matrix_graph = new double[Points.Count, Points.Count];

            Ways = new List<int>[Points.Count, Points.Count];
            for (int i = 0; i < Points.Count; i++)
            {
                for (int j = 0; j < Points.Count; j++)
                {
                    Ways[i, j] = new List<int>();
                }
            }

            fill_mass();
        }
        public Graph() { }
        private void fill_mass()
        {
            if (Points != null && Points.Count != 0)
            {
                for (int i = 0; i < Points.Count - 1; i++)
                {
                    Matrix_graph[i, i] = 0;
                    for (int j = i + 1; j < Points.Count; j++)
                    {
                        if (i < Points.Count && j < Points.Count && aviable_from_1_to_2(Points[i], Points[j]))
                        {
                            Matrix_graph[i, j] = distance_from_1_to_2(Points[i], Points[j]);
                            Matrix_graph[j, i] = distance_from_1_to_2(Points[i], Points[j]);

                            Ways[i, j].Add(j);
                            Ways[j, i].Add(i);
                        }
                        else
                        {
                            Matrix_graph[j, i] = inf;
                            Matrix_graph[i, j] = inf;
                        }
                    }
                }
                Matrix_graph[Points.Count - 1, Points.Count - 1] = 0;
            }
        }
        private double distance_from_1_to_2(Point point_1, Point point_2)
        {
            return Math.Sqrt((double)(point_1.X - point_2.X) * (point_1.X - point_2.X) + (double)(point_1.Y - point_2.Y) * (point_1.Y - point_2.Y));
        }
        private bool aviable_from_1_to_2(Point point_1, Point point_2)
        {
            if (point_1 != point_2)
            {
                foreach (Wall arg in Walls)
                {
                    if (arg.Dot_1 != point_1 && arg.Dot_2 != point_1 && arg.Dot_1 != point_2 && arg.Dot_2 != point_2)
                    {
                        if (collision(new Wall(point_1, point_2), arg))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        private int multiplication_vectors(Point point_1, Point point_2)
        {
            return point_1.X * point_2.Y - point_2.X * point_1.Y;
        }
        private int multi(Point point_1, Point point_2, Point point_3, Point point_4)
        {
            return multiplication_vectors(new Point(point_1.X - point_2.X, point_1.Y - point_2.Y), new Point(point_3.X - point_4.X, point_3.Y - point_4.Y));
        }
        private bool collision(Wall wall_1, Wall wall_2)
        {
            if (
                (Math.Max(wall_1.Dot_1.X, wall_1.Dot_2.X) >= Math.Min(wall_2.Dot_1.X, wall_2.Dot_2.X))
                &&
                (Math.Max(wall_2.Dot_1.X, wall_2.Dot_2.X) >= Math.Min(wall_1.Dot_1.X, wall_1.Dot_2.X))
                &&
                (Math.Max(wall_1.Dot_1.Y, wall_1.Dot_2.Y) >= Math.Min(wall_2.Dot_1.Y, wall_2.Dot_2.Y))
                &&
                (Math.Max(wall_2.Dot_1.Y, wall_2.Dot_2.Y) >= Math.Min(wall_1.Dot_1.Y, wall_1.Dot_2.Y))
                )
            {
                if (multi(wall_2.Dot_1, wall_1.Dot_1, wall_1.Dot_2, wall_1.Dot_1) * multi(wall_2.Dot_2, wall_1.Dot_1, wall_1.Dot_2, wall_1.Dot_1) <= 0)
                {
                    if (multi(wall_1.Dot_1, wall_2.Dot_1, wall_2.Dot_2, wall_2.Dot_1) * multi(wall_1.Dot_2, wall_2.Dot_1, wall_2.Dot_2, wall_2.Dot_1) <= 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public void Floyd_algorithm()
        {
            for (int k = 0; k < Points.Count; k++)
            {
                for (int i = 0; i < Points.Count; i++)
                {
                    for (int j = 0; j < Points.Count; j++)
                    {
                        if (i != j && Matrix_graph[i, k] + Matrix_graph[k, j] < Matrix_graph[i, j])
                        {
                            Matrix_graph[i, j] = Matrix_graph[i, k] + Matrix_graph[k, j];

                            Ways[i, j] = new List<int>();
                            Ways[i, j].AddRange(Ways[i, k]);
                            Ways[i, j].AddRange(Ways[k, j]);
                        }
                    }
                }
            }
        }
    }
}
