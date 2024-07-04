using System;

abstract class Shape
{
    private int _so_dinh;

    public int so_dinh
    {
        get { return _so_dinh; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Số đỉnh phải lớn hơn 0.");
            }
            _so_dinh = value;
        }
    }

    public Shape(int soDinh)
    {
        this.so_dinh = soDinh;
    }

    public abstract void Draw();
}

class tam_giac : Shape
{
    public tam_giac() : base(3)
    {
        if (base.so_dinh != 3)
        {
            throw new ArgumentException("Số đỉnh của tam giác phải là 3.");
        }
    }

    public override void Draw()
    {
        Console.WriteLine("Vẽ một tam giác với 3 đỉnh.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            tam_giac tg = new tam_giac();
            tg.Draw();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Lỗi: {ex.Message}");
        }
    }
}