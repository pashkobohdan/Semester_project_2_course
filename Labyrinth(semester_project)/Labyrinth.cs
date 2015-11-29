using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Labyrinth_semester_project_
{
    //class Labyrinth
    //{
    //    [System.Xml.Serialization.XmlAttributeAttribute()]
    //    public List<Wall> Walls { set; get; }

    //    [System.Xml.Serialization.XmlAttributeAttribute()]
    //    public Point Start_dot { set; get; }

    //    [System.Xml.Serialization.XmlAttributeAttribute()]
    //    public Point End_dot { set; get; }

    //    public Labyrinth()
    //    {
    //        Walls = new List<Wall>();
    //    }

    //    public void read_from_file(string name, int count_walls)
    //    {
    //        StreamReader myStream = null;

    //        try
    //        {
    //            myStream = new StreamReader(name);

    //            using (myStream)
    //            {
    //                for (int i = 0; i < count_walls; ++i)
    //                {
    //                    myStream.BaseStream.ReadByte();
    //                    Walls.Add(new Wall(new Point(myStream.BaseStream.ReadByte(), myStream.BaseStream.ReadByte()), new Point(myStream.BaseStream.ReadByte(), myStream.BaseStream.ReadByte())));
    //                }
    //            }
    //            myStream.Close();
    //        }
    //        catch (Exception)
    //        {
    //        }
    //    }

    //    public void save_to_xml(string filename)
    //    {
    //        XmlSerializer serializer = new XmlSerializer(typeof(Labyrinth));
    //        using (TextWriter textWriter = new StreamWriter(filename))
    //        {
    //            serializer.Serialize(textWriter, Walls);
    //        }
    //    }
    //}
    
}
