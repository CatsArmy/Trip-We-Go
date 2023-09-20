using Trip_We_Go;

Tour t1 = new Tour("first trip");
Tour t2 = new Tour("second trip");
Point p1 = new Point(1, 2);
Point p2 = new Point(1, 5);
Point p3 = new Point(2, 10);
Point p4 = new Point(8, 10);
Point p5 = new Point(6, 8);

t1.AddPoint(p1);
t1.AddPoint(p2);
t1.AddPoint(p3);
t1.AddPoint(p4);
t1.AddPoint(p5);
Console.WriteLine("first trip:" + t1);

t2.AddPoint(new Point());
t2.AddPoint(new Point());
t2.AddPoint(p5);
t2.AddPoint(new Point());
t2.AddPoint(new Point());



Console.WriteLine("second trip:" + t2);
static bool SharePoint(Tour t1, Tour t2)
{
    Point[] arr1 = t1.GetPlaces();
    for (int i = 0; i < arr1.Length; i++)
    {
        if (arr1[i] != null)
        {
            if (t2.Exist(arr1[i]))
                return true;
        }
    }
    return false;
}
