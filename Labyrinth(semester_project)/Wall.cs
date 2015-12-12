using System.Drawing;

namespace Labyrinth_semester_project_
{
    public class Wall
    {
        public Point Dot_1 { set; get; }
        public Point Dot_2 { set; get; }

        public Wall(Point dot_1, Point dot_2)
        {
            Dot_1 = dot_1;
            Dot_2 = dot_2;
        }
        public Wall()
        { }

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
