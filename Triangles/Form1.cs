namespace Triangles
{
    public partial class Form1 : Form
    {
        Graphics graphics;
        List<Point[]> triangles = new List<Point[]>();
        Pen pen = new Pen(Color.Black, 1);
        public Form1()
        {
            InitializeComponent();

            //взять точки из файла
            using (var reader = new StreamReader("TextFile1.txt"))
            {
                string? line = reader.ReadLine();
                int trianglesNumber = int.Parse(line ?? "");

                if (trianglesNumber > 0)
                {

                    line = reader.ReadLine();

                    while (line != null)
                    {
                        int[] coardinates = line.Split().Select(int.Parse).ToArray();
                        triangles.Add(new Point[3]
                        {
                            new Point(coardinates[0], coardinates[1]),
                            new Point(coardinates[2], coardinates[3]),
                            new Point(coardinates[4], coardinates[5]),
                        });

                        line = reader.ReadLine();
                    }
                }
            }


            graphics = panel1.CreateGraphics();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }



        private void CheckIntersections()
        {
            for (int i = 0; i < triangles.Count - 1; i++)
            {
                for (int j = i + 1; j < triangles.Count; j++)
                {
                    if ((IsSidesIntersect(triangles[i][0], triangles[i][1], triangles[j][0], triangles[j][1])) ||
                        (IsSidesIntersect(triangles[i][0], triangles[i][1], triangles[j][1], triangles[j][2])) ||
                        (IsSidesIntersect(triangles[i][0], triangles[i][1], triangles[j][2], triangles[j][0])) ||
                        (IsSidesIntersect(triangles[i][1], triangles[i][2], triangles[j][0], triangles[j][1])) ||
                        (IsSidesIntersect(triangles[i][1], triangles[i][2], triangles[j][1], triangles[j][2])) ||
                        (IsSidesIntersect(triangles[i][1], triangles[i][2], triangles[j][2], triangles[j][0])) ||
                        (IsSidesIntersect(triangles[i][2], triangles[i][0], triangles[j][0], triangles[j][1])) ||
                        (IsSidesIntersect(triangles[i][2], triangles[i][0], triangles[j][1], triangles[j][2])) ||
                        (IsSidesIntersect(triangles[i][2], triangles[i][0], triangles[j][2], triangles[j][0])))
                    {
                        customrtb1.AppendText($"triangle {i} and triangle {j} intersect\n");
                    }
                }
            }
        }
        private bool IsSidesIntersect(Point p1, Point p2, Point p3, Point p4)
        {
            try
            {
                //проверка на коллинеарность

                if (p2.Y - p1.Y != 0 && p4.Y - p3.Y != 0)
                {
                    var k1 = (p2.X - p1.X) / (p2.Y - p1.Y);
                    var k2 = (p4.X - p3.X) / (p4.Y - p3.Y);

                    if (k1 != k2 && (p1.Y - p2.Y) * (p4.X - p3.X) - (p3.Y - p4.Y) * (p2.X - p1.X) != 0 && p4.X - p3.X != 0)
                    {

                        //высчитывание точки пересечения
                        var x = ((p1.X * p2.Y - p2.X * p1.Y) * (p4.X - p3.X) - (p3.X * p4.Y - p4.X * p3.Y) * (p2.X - p1.X)) /
                                            ((p1.Y - p2.Y) * (p4.X - p3.X) - (p3.Y - p4.Y) * (p2.X - p1.X));
                        var y = ((p3.Y - p4.Y) * x - (p3.X * p4.Y - p4.X * p3.Y)) / (p4.X - p3.X);

                        if ((p1.X < p2.X && x >= p1.X && x <= p2.X) || (p1.X > p2.X && x <= p1.X && x >= p2.X))
                        {
                            return true;
                        }
                    }

                }
            }
            catch
            {
                //return false;
            }

            return false;
        }
        private void DrawRectangles()
        {
            int colorOffset = 15;
            int i = 0;

            foreach (Point[] trianglePoints in triangles)
            {
                SolidBrush solidBrush = new SolidBrush(Color.FromArgb(0, 200 - colorOffset * NestingLevel(i), 0));
                graphics.FillPolygon(solidBrush, trianglePoints);
                graphics.DrawPolygon(pen, trianglePoints);
                i++;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //проверить на пересечение сторон треугольников
            CheckIntersections();

            //нарисовать треугольники
            DrawRectangles();
        }

        private int NestingLevel(int triangleNumber)
        {
            int level = 0;

            for (int j = 0; j < triangles.Count; j++)
            {
                int x0 = triangles[triangleNumber][0].X;
                int x1 = triangles[j][0].X;
                int x2 = triangles[j][1].X;
                int x3 = triangles[j][2].X;
                int y0 = triangles[triangleNumber][0].Y;
                int y1 = triangles[j][0].Y;
                int y2 = triangles[j][1].Y;
                int y3 = triangles[j][2].Y;

                if (((x1 < x2 && x0 > x1 && x0 < x2) ||
                    (x1 > x2 && x0 < x1 && x0 > x2) ||
                    (x2 < x3 && x0 > x2 && x0 < x3) ||
                    (x2 > x3 && x0 < x2 && x0 > x3) ||
                    (x1 < x3 && x0 > x1 && x0 < x3) ||
                    (x1 > x3 && x0 < x1 && x0 > x3)) &&
                        ((y1 < y2 && y0 > y1 && y0 < y2) ||
                        (y1 > y2 && y0 < y1 && y0 > y2) ||
                        (y2 < y3 && y0 > y2 && y0 < y3) ||
                        (y2 > y3 && y0 < y2 && y0 > y3) ||
                        (y1 < y3 && y0 > y1 && y0 < y3) ||
                        (y1 > y3 && y0 < y1 && y0 > y3)))
                {
                    level++;
                }
            }

            return level;
        }
    }
}