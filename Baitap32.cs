public abstract class Person
{
    public string Name { get; set; }
}
public interface KPI
{
    void kpi();
}

// File Student.cs
public class Student : Person, KPI
{
    public string Major { get; set; }
    public void kpi()
    {
        Console.WriteLine("Implementing KPI method");
    }
}

// File Program.cs
class Program
{
    static void Main(string[] args)
    {
        // Khai báo biến obs kiểu Person, cấp phát obs là một Student
        Person obs = new Student { Name = "Nguyễn Văn Nam", Major = "ICT" };

        // Kiểm tra xem obs có phải là Student hay không
        if (obs is Student)
        {
            // Nếu đúng, gọi phương thức kpi() của Student
            ((Student)obs).kpi();
        }
        else
        {
            Console.WriteLine("obs is not a Student");
        }
    }
}