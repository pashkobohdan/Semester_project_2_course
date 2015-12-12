using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Labyrinth_semester_project_
{
    public class Labyrinth
    {
        public List<Wall> Walls { set; get; }
        public Point Start_dot { set; get; }
        public Point End_dot { set; get; }

        public Labyrinth()
        {
            Walls = new List<Wall>();
        }

        public void read_from_file(string name, int count_walls)
        {
            StreamReader myStream = null;
            try
            {
                myStream = new StreamReader(name);
                using (myStream)
                {
                    Walls = null;
                    Walls = new List<Wall>();

                    Wall arg;
                    int i = 0;
                    while (i < count_walls)
                    {
                        myStream.BaseStream.ReadByte();
                        arg = new Wall(new Point(myStream.BaseStream.ReadByte(), myStream.BaseStream.ReadByte()), new Point(myStream.BaseStream.ReadByte(), myStream.BaseStream.ReadByte()));
                        if ((arg.Dot_1.X != 0 && arg.Dot_1.Y != 0) || (arg.Dot_2.X != 0 && arg.Dot_2.Y != 0))
                        {
                            Walls.Add(arg);
                            ++i;
                        }
                    }
                }
                myStream.Close();
            }
            catch (Exception)
            {
            }
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
