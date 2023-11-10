
namespace InitOnly
{
    class Transaction
    {
        public string From { get; init; }
        public string To { get; init; }
        public int Amount { get; init; }

        public override string? ToString()
        {
            return $"{From,-10}->{To,-10}: ${Amount}";
        }
    }
    class MainClass
        {
            public static void Main(string[] args)
            {
            Transaction tr1 = new Transaction { From = "Alice", To = "Bob", Amount = 100 };
            Console.WriteLine(tr1 );
            }
        }

    }

