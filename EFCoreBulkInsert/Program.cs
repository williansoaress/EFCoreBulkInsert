
using EFCore.BulkExtensions;
using EFCoreBulkInsert;
using EFCoreBulkInsert.Context;
using System.Diagnostics;

var clients = new List<Client>();

var numberOfClients = 100000;

for (int i = 0; i < numberOfClients; i++)
{
    clients.Add(new Client
    {
        Name = $"Name{i}",
        Email = $"Name{i}@client.com",
        Phone = $"123456789{i}"
    });
}

static void NormalInsert(List<Client> clients)
{
    using var context = new AppDbContext();

    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();

    var stopwatch = new Stopwatch();
    stopwatch.Start();

    context.AddRangeAsync(clients);
    context.SaveChanges();

    stopwatch.Stop();
    var resultTime = stopwatch.ElapsedMilliseconds / 1000;
    Console.WriteLine($"Normal Insert: {resultTime} seconds");
}

static void BulkInsert(List<Client> clients)
{
    using var context = new AppDbContext();

    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();

    var stopwatch = new Stopwatch();
    stopwatch.Start();

    context.BulkInsertAsync(clients);
    context.SaveChanges();

    stopwatch.Stop();
    var resultTime = stopwatch.ElapsedMilliseconds / 1000;
    Console.WriteLine($"BulkInsert: {resultTime} seconds");
}

Console.WriteLine($"Comparison of {numberOfClients} Record Inserts in EF Core: Standard Insert vs. Bulk Insert");

NormalInsert(clients);
BulkInsert(clients);

Console.ReadLine();