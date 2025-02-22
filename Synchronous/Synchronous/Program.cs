using System;
using System.Diagnostics;
using System.Threading;

class Program
{
    static void ProcessCustomer(int customerId)
    {
        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] User {customerId} yêu cầu data");
        Thread.Sleep(1000); // Giả lập mất 1 giây để xử lý tương ứng nếu câu query mất 1s để xử lí có thể do nhiều dữ liệu hoặc xuất báo cáo tính toán nhiều
        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] User {customerId} lấy được data");
    }

    static void Main()
    {
        Stopwatch stopwatch = Stopwatch.StartNew(); // Bắt đầu đo thời gian

        Console.WriteLine("Bắt đầu xử lý yêu cầu...");
        for (int i = 1; i <= 10; i++)
        {
            ProcessCustomer(i);
        }

        stopwatch.Stop(); // Dừng đồng hồ
        Console.WriteLine($"Tất cả user đã được data trong {stopwatch.Elapsed.TotalSeconds} giây.");
    }
}