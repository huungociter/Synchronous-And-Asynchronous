using System;
using System.Diagnostics;
using System.Threading.Tasks;

class Program
{
    static async Task ProcessCustomerAsync(int customerId)
    {
        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] User {customerId} yêu cầu data");
        await Task.Delay(1000); // Giả lập mất 1 giây để xử lý
        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] User {customerId} Lấy được data.");
    }

    static async Task Main()
    {
        Stopwatch stopwatch = Stopwatch.StartNew(); // Bắt đầu đo thời gian

        Console.WriteLine("Bắt đầu xử lý khách hàng...");

        Task[] tasks = new Task[1000];  //Tạo 1000 request giả lập cùng 1 lúc
        for (int i = 0; i < 1000; i++)
        {
            tasks[i] = ProcessCustomerAsync(i + 1);
        }

        await Task.WhenAll(tasks); // Chờ tất cả hoàn tất

        stopwatch.Stop(); // Dừng đồng hồ
        Console.WriteLine($"Tất cả yêu cầu của user đã được xử lý trong {stopwatch.Elapsed.TotalSeconds} giây.");
    }
}