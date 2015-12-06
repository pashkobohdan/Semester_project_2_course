using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Labyrinth_semester_project_
{
    public partial class Form1 : Form
    {
        private int x_center, y_center;
        private double coef_center_x, coef_center_y, coef_lab = 1.0;
        private int height, width;

        private Labyrinth labyrinth = new Labyrinth();
        private Graph graph = new Graph();

        private bool is_start = false, is_end = false;

        private int x_s, y_s;

        private bool moving_picture = false;
        private int number_moving_wall = -1;
        private int first_second_dot_in_wall = -1;

        private int dx;
        private int dy;

        private Point real_dot;
        private Point real_corrdinate_dot;

        private List<Point> way_from_start_to_end;
        private List<Point> list_step_by_step;
        private int step_number;

        private void Form1_Load(object sender, EventArgs e)
        {
            height = pictureBox1.Height - 1;
            width = pictureBox1.Width - 1;
            x_center = pictureBox1.Width / 2;
            y_center = pictureBox1.Height / 2;
            coef_center_x = x_center / pictureBox1.Width;
            coef_center_y = y_center / pictureBox1.Height;
            coef_center_x = 0.5;
            coef_center_y = 0.5;
            coef_lab = 1.0;

            pictureBox1.ContextMenuStrip = contextMenuStrip1;
            pictureBox1.MouseWheel += new MouseEventHandler(pictureBox1_MouseWheel);
        }

        public Form1()
        {
            InitializeComponent();
        }
        

        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            refresh_height_width();
            x_center = (int)(coef_center_x * width);
            y_center = (int)(coef_center_y * height);
            pictureBox1.Refresh();
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            moving_picture = false;
            number_moving_wall = -1;
            first_second_dot_in_wall = -1;
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            moving_picture = !is_wall_in_dot();
            x_s = e.X;
            y_s = e.Y;
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            real_dot = new Point(e.X, e.Y);
            real_corrdinate_dot = new Point((int)(((double)real_dot.X - x_center) / coef_lab + 128), (int)(((double)real_dot.Y - y_center) / coef_lab + 128));
            if (pictureBox1.Capture)
            {
                dx = e.X - x_s;
                dy = e.Y - y_s;

                if (moving_picture)
                {
                    x_center += dx;
                    y_center += dy;
                    coef_center_x = (double)x_center / pictureBox1.Width;
                    coef_center_y = (double)y_center / pictureBox1.Height;
                }
                else
                {
                    if (first_second_dot_in_wall == 1)
                    {
                        labyrinth.Walls[number_moving_wall].Dot_1 = real_corrdinate_dot;
                    }
                    if (first_second_dot_in_wall == 2)
                    {
                        labyrinth.Walls[number_moving_wall].Dot_2 = real_corrdinate_dot;
                    }
                }

                pictureBox1.Refresh();

                x_s = e.X;
                y_s = e.Y;
            }
        }
        private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (coef_lab + e.Delta / 600.0 > 0.1 && coef_lab + e.Delta / 600.0 < 15)
            {
                coef_lab += e.Delta / 600.0;
                pictureBox1.Refresh();
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5:
                    search_way();
                    pictureBox1.Refresh();
                    break;

                case Keys.Space:
                    if (list_step_by_step != null && way_from_start_to_end != null)
                    {
                        next_step();
                    }
                    pictureBox1.Refresh();
                    break;
            }
        }


        private void началоПутиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            way_from_start_to_end = null;
            is_start = true;
            labyrinth.Start_dot = real_corrdinate_dot;
            pictureBox1.Refresh();
        }
        private void конецПутиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            way_from_start_to_end = null;
            is_end = true;
            labyrinth.End_dot = real_corrdinate_dot;
            pictureBox1.Refresh();
        }
        private void прочитатьСВидеофайлаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            way_from_start_to_end = null;
            list_step_by_step = null;
            if (new count().ShowDialog() == DialogResult.No)
            {
                openFileDialog1.InitialDirectory = "D:\\Фильмы";
                openFileDialog1.Filter = "mkv files (*.mkv)|*.mkv|avi files (*.avi)|*.avi";
                openFileDialog1.FilterIndex = 1;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    labyrinth.read_from_file(openFileDialog1.FileName, 20);

                    coef_center_x = 0.5;
                    coef_center_y = 0.5;
                    coef_lab = 1.0;

                    is_end = false;
                    is_start = false;

                    pictureBox1.Refresh();
                }
            }
            else
            {
                openFileDialog1.InitialDirectory = "D:\\Фильмы";
                openFileDialog1.Filter = "mkv files (*.mkv)|*.mkv|avi files (*.avi)|*.avi";
                openFileDialog1.FilterIndex = 1;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    labyrinth.read_from_file(openFileDialog1.FileName, 50);

                    coef_center_x = 0.5;
                    coef_center_y = 0.5;
                    coef_lab = 1.0;

                    is_end = false;
                    is_start = false;

                    pictureBox1.Refresh();
                }
            }
        }
        private void построитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            list_step_by_step = null;
            search_way();
            pictureBox1.Refresh();
        }
        private void сохранитьВФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "xml files (*.xml)|*.xml";
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Labyrinth));
                using (TextWriter textWriter = new StreamWriter(saveFileDialog1.FileName))
                {
                    serializer.Serialize(textWriter, labyrinth);
                }
            }
        }
        private void прочитатьСФайлаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "xml files (*.xml)|*.xml";
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                way_from_start_to_end = null;
                list_step_by_step = null;
                XmlSerializer deserializer = new XmlSerializer(typeof(Labyrinth));
                using (TextReader textReader = new StreamReader(openFileDialog1.FileName))
                {
                    labyrinth = (Labyrinth)deserializer.Deserialize(textReader);
                }

                if (labyrinth.Start_dot.X != 0)
                {
                    is_start = true;
                }
                if (labyrinth.End_dot.X != 0)
                {
                    is_end = true;
                }

                pictureBox1.Refresh();
            }
        }
        private void очистиьтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            way_from_start_to_end = null;
            pictureBox1.Refresh();
        }
        private void поШагамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            list_step_by_step = null;
            way_from_start_to_end = null;
            pictureBox1.Refresh();
            search_way();

            if (way_from_start_to_end != null)
            {
                list_step_by_step = new List<Point>();
                MessageBox.Show("Построение пути по шагам запушено.\n Нажимайте на кнопку space для следующего шага", "По шагам", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            step_number = 0;
        }
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа для построения кратчайшего пути в лабиринте\n\t\t\t\t© Пашко Богдан", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void алгоритмФлойдаУоршеллаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Path.GetDirectoryName(Application.ExecutablePath) + "/Resources/Floyd_alg.html");
        }
        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void сброситьКоординатыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            height = pictureBox1.Height - 1;
            width = pictureBox1.Width - 1;
            x_center = pictureBox1.Width / 2;
            y_center = pictureBox1.Height / 2;
            coef_center_x = x_center / pictureBox1.Width;
            coef_center_y = y_center / pictureBox1.Height;
            coef_center_x = 0.5;
            coef_center_y = 0.5;
            coef_lab = 1.0;

            pictureBox1.Refresh();
        }
        private void сохранитьОтчётToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (labyrinth.Walls.Count != 0 && way_from_start_to_end != null)
            {
                StreamReader read = new StreamReader("Resources/reports/count_reports.txt");
                int count_reports = int.Parse(read.ReadLine());
                ++count_reports;
                read.Close();

                StreamWriter file = new StreamWriter("Resources/reports/count_reports.txt");
                file.WriteLine(count_reports);
                file.Close();


                file = new StreamWriter("Resources/reports/report_" + count_reports + ".html", false, Encoding.UTF8);
                file.WriteLine(getReport(count_reports));

                file.Close();

                Bitmap res = new Bitmap(Width, Height);
                DrawToBitmap(res, new Rectangle(Point.Empty, Size));

                res.Save("Resources/reports/picture" + count_reports + ".bmp");
            }
            else
            {
                MessageBox.Show("Чтобы сохранить отчёт постройте путь !", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            write_report();
        }
        private void инструкцияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = "manual.pdf";
            p.Start();
        }

        private void write_report()
        {
            if (labyrinth.Walls.Count != 0 && way_from_start_to_end != null)
            {
                StreamReader read = new StreamReader("Resources/reports/count_reports.txt");
                int count_reports = int.Parse(read.ReadLine());
                ++count_reports;
                read.Close();

                StreamWriter file = new StreamWriter("Resources/reports/count_reports.txt");
                file.WriteLine(count_reports);
                file.Close();


                file = new StreamWriter("Resources/reports/report_" + count_reports + ".html", false, Encoding.UTF8);
                file.WriteLine(getReport(count_reports));

                file.Close();

                Bitmap res = new Bitmap(Width, Height);
                DrawToBitmap(res, new Rectangle(Point.Empty, Size));

                res.Save("Resources/reports/picture" + count_reports + ".bmp");
            }
        }
        private void search_way()
        {
            way_from_start_to_end = null;
            if (labyrinth.Walls.Count == 0)
            {
                MessageBox.Show("Сначала откройте файл !", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (!is_start || !is_end)
                {
                    MessageBox.Show("Выберите начальную и конечную точку !", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    graph = new Graph(labyrinth.Walls, labyrinth.Start_dot, labyrinth.End_dot);
                    graph.Floyd_algorithm();
                    if (graph.Matrix_graph[0, graph.Points.Count - 1] != 1000000000.0)
                    {
                        way_from_start_to_end = new List<Point>();
                        way_from_start_to_end.Add(labyrinth.Start_dot);

                        way_from_start_to_end.Add(graph.Points[graph.Ways[0, graph.Points.Count - 1][0]]);

                        for (int i = 1; i < graph.Ways[0, graph.Points.Count - 1].Count; i++)
                        {
                            way_from_start_to_end.Add(graph.Points[graph.Ways[0, graph.Points.Count - 1][i]]);
                        }

                        way_from_start_to_end.Add(graph.Points[graph.Points.Count - 1]);
                    }
                    else
                    {
                        MessageBox.Show("Пути от заданной начальной точки до конечной не существует !", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private bool is_wall_in_dot()
        {
            if (labyrinth == null)
            {
                return false;
            }
            Wall arg;
            for (int i = 0; i < labyrinth.Walls.Count; ++i)
            {
                arg = labyrinth.Walls[i];
                if (Math.Abs(arg.Dot_1.X - real_corrdinate_dot.X) <= 1 && Math.Abs(arg.Dot_1.Y - real_corrdinate_dot.Y) <= 1)
                {
                    number_moving_wall = i;
                    first_second_dot_in_wall = 1;
                    return true;
                }
                if (Math.Abs(arg.Dot_2.X - real_corrdinate_dot.X) <= 1 && Math.Abs(arg.Dot_2.Y - real_corrdinate_dot.Y) <= 1)
                {
                    number_moving_wall = i;
                    first_second_dot_in_wall = 2;
                    return true;
                }
            }
            return false;
        }
        private void show_big_dot(PaintEventArgs e, Point point, Color color)
        {
            e.Graphics.DrawLine(new Pen(color), new Point((int)((point.X - 128) * coef_lab + x_center) - 1, (int)((point.Y - 128) * coef_lab + y_center) - 1), new Point((int)((point.X - 128) * coef_lab + x_center) - 1, (int)((point.Y - 128) * coef_lab + y_center) + 1));
            e.Graphics.DrawLine(new Pen(color), new Point((int)((point.X - 128) * coef_lab + x_center), (int)((point.Y - 128) * coef_lab + y_center) - 1), new Point((int)((point.X - 128) * coef_lab + x_center), (int)((point.Y - 128) * coef_lab + y_center) + 1));
            e.Graphics.DrawLine(new Pen(color), new Point((int)((point.X - 128) * coef_lab + x_center) + 1, (int)((point.Y - 128) * coef_lab + y_center) - 1), new Point((int)((point.X - 128) * coef_lab + x_center) + 1, (int)((point.Y - 128) * coef_lab + y_center) + 1));
        }
        private void next_step()
        {
            if (step_number >= way_from_start_to_end.Count - 1)
            {
                list_step_by_step = null;
                way_from_start_to_end = null;
                MessageBox.Show("Построение пути по шагам закончено !", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                step_number = 0;
            }
            else
            {
                list_step_by_step.Add(way_from_start_to_end[step_number]);
                ++step_number;
                pictureBox1.Refresh();
            }
        }
        private void show_start_end_dots(PaintEventArgs e)
        {
            if (is_start)
            {
                show_big_dot(e, labyrinth.Start_dot, Color.Green);
            }
            if (is_end)
            {
                show_big_dot(e, labyrinth.End_dot, Color.Red);
            }
        }
        private void show_wall(PaintEventArgs e, Point start, Point end)
        {
            e.Graphics.DrawLine(new Pen(Color.Black), new Point((int)((start.X - 128) * coef_lab + x_center), (int)((start.Y - 128) * coef_lab + y_center)), new Point((int)((end.X - 128) * coef_lab + x_center), (int)((end.Y - 128) * coef_lab + y_center)));
            show_big_dot(e, start, Color.Black);
            show_big_dot(e, end, Color.Black);
        }
        private string getReport(int number)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<!DOCTYPE HTML PUBLIC \" -//W3C//DTD HTML 4.01 Transitional//EN\" \"http://www.w3.org/TR/html4/loose.dtd\"><html> <head><meta http-equiv=\"Content - Type\" content=\"text / html; charset = windows - 1251\" /><style> h1{text-align:center;}table {border: 2px solid #ccc;margin: 0 auto;}th, td {border: 1px solid black;text - align: center;padding: 1em;}# left, #right {position: fixed;top: 5em;}# left {left: 5em;   }# center { margin: 0 auto;}# right {right: 5em;}# green {background: #81FF7A;}# red {background: #FF5252;}</style></head><body>");
            sb.Append("\n<h1>Результат построения пути :</h1>");
            sb.Append("\n<h1>Снимок экрана :</h1>");

            sb.Append("<center><img src=\"picture" + number + ".bmp\" alt=\"picture\"></center>");

            sb.Append("<TABLE>\n");

            sb.Append("<TR>\n");

            sb.Append("<TD>");
            sb.Append("Все точки");
            sb.Append("</TD>");

            sb.Append("<TD>");
            sb.Append("Точки, входящие в путь");
            sb.Append("</TD>");

            sb.Append("</TR>\n");

            for(int j=0;j<graph.Points.Count;++j)
            { 
                sb.Append("<TR>\n");
                
                sb.Append("<TD>");
                sb.Append(graph.Points[j].X+" , "+ graph.Points[j].Y);
                sb.Append("</TD>");

                if (j < way_from_start_to_end.Count)
                {
                    sb.Append("<TD>");
                    sb.Append(way_from_start_to_end[j].X + " , " + way_from_start_to_end[j].Y);
                    sb.Append("</TD>");
                }

                sb.Append("</TR>\n");

            }

            sb.Append("</TABLE>");
            sb.Append("</body>/n</ html > ");

            return sb.ToString();
        }
        private void show_wall(PaintEventArgs e,Pen pen, Point start, Point end)
        {
            e.Graphics.DrawLine(pen, new Point((int)((start.X - 128) * coef_lab + x_center), (int)((start.Y - 128) * coef_lab + y_center)), new Point((int)((end.X - 128) * coef_lab + x_center), (int)((end.Y - 128) * coef_lab + y_center)));
        }
        private void show_labyrinth(PaintEventArgs e)
        {
            if (labyrinth != null)
            {
                if (labyrinth.Walls.Count != 0)
                {
                    foreach (Wall arg in labyrinth.Walls)
                    {
                        show_wall(e, arg.Dot_1, arg.Dot_2);
                    }
                }
            }
        }
        private void refresh_height_width()
        {
            height = pictureBox1.Height - 1;
            width = pictureBox1.Width - 1;
        }
        private void show_edges(PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(Color.Red), new Point(0, 0), new Point(0, height));
            e.Graphics.DrawLine(new Pen(Color.Red), new Point(0, 0), new Point(width, 0));

            e.Graphics.DrawLine(new Pen(Color.Red), new Point(width, height), new Point(0, height));
            e.Graphics.DrawLine(new Pen(Color.Red), new Point(width, height), new Point(width, 0));
        }
        private void show_ways_list(List<Point> ways_points, PaintEventArgs e)
        {
            Point start = ways_points[0];
            Point end;

            for (int i = 1; i < ways_points.Count; ++i)
            {
                end = ways_points[i];
                show_wall(e, new Pen(Color.Blue), start, end);
                start = end;
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            show_edges(e);
            if (labyrinth != null)
            {
                show_labyrinth(e);
            }

            show_start_end_dots(e);

            if (list_step_by_step != null)
            {
                show_ways_list(list_step_by_step,e);
            }
            else
            {
                if (way_from_start_to_end != null)
                {
                    show_ways_list(way_from_start_to_end, e);
                }
            }

        }
    }
    
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
        {}
    }
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
    }
    public class Graph
    {
        public List<Wall> Walls { set; get; }
        private Point start, end;

        public List<Point> Points { set; get; }
        public double[,] Matrix_graph { set; get; }
        private double inf = 1000000000.0;

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
        public bool collision(Wall wall_1, Wall wall_2)
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