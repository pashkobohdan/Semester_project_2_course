using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth_semester_project_
{
    //class Graph
    //{
    //    public List<Wall> Walls { set; get; }
    //    private Point start, end;
    //    public List<Point> Points { set; get; }
    //    public double[,] matrix_graph;

    //    public Graph(List<Wall> walls, Point start, Point end)
    //    {
    //        this.start = start;
    //        this.end = end;
    //        Walls = walls;

    //        Points = new List<Point>();
    //        matrix_graph = new double[walls.Count * 2 + 2, walls.Count * 2 + 2];

    //        for(int i=0;i< Walls.Count; ++i)
    //        {
    //            Points.Add(Walls.ElementAt(i).Dot_1);
    //            Points.Add(Walls.ElementAt(i).Dot_2);
    //        }
    //        Points.Add(start);
    //        Points.Add(end);
    //    }

    //    public Graph()
    //    { }

    //    private void read_matrix()
    //    {

    //    }

    //    private int multiplication_vectors(Point point_1, Point point_2)
    //    {
    //        return point_1.X * point_2.Y - point_2.X * point_1.Y;
    //    }

    //    private int multi(Point point_1, Point point_2, Point point_3, Point point_4)
    //    {
    //        return multiplication_vectors(new Point(point_1.X - point_2.X, point_1.Y - point_2.Y), new Point(point_3.X - point_4.X, point_3.Y - point_4.Y));
    //    }

    //    public bool collision(Wall wall_1, Wall wall_2)
    //    {
    //        if (
    //            (Math.Max(wall_1.Dot_1.X, wall_1.Dot_2.X) >= Math.Min(wall_2.Dot_1.X, wall_2.Dot_2.X))
    //            &&
    //            (Math.Max(wall_2.Dot_1.X, wall_2.Dot_2.X) >= Math.Min(wall_1.Dot_1.X, wall_1.Dot_2.X))
    //            &&
    //            (Math.Max(wall_2.Dot_1.Y, wall_2.Dot_2.Y) >= Math.Min(wall_1.Dot_1.Y, wall_1.Dot_2.Y))
    //            &&
    //            (Math.Max(wall_2.Dot_1.Y, wall_2.Dot_2.Y) >= Math.Min(wall_1.Dot_1.Y, wall_1.Dot_2.Y))
    //            )
    //        {
    //            if(multi(wall_2.Dot_1, wall_1.Dot_1,wall_1.Dot_2, wall_1.Dot_1)* multi(wall_2.Dot_2, wall_1.Dot_1, wall_1.Dot_2, wall_1.Dot_1) <= 0)
    //            {
    //                if (multi(wall_1.Dot_1, wall_2.Dot_1, wall_2.Dot_2, wall_2.Dot_1) * multi(wall_2.Dot_2, wall_2.Dot_1, wall_2.Dot_2, wall_2.Dot_1) <= 0)
    //                {
    //                    return true;
    //                }
    //            }
    //        }
    //        return false;
    //    }
    //}
}
