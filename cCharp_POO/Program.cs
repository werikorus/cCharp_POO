using System;
using cCharp_POO.Entities;
using System.Collections.Generic;

namespace cCharp_POO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number of POO problem: ");
            Console.WriteLine("1 - Bank");
            Console.WriteLine("2 - Sale Product");
            int problem = int.Parse(Console.ReadLine());

            switch (problem)
            {
                case 1:
                    {
                        Account acc1 = new Account(1101, "Alex", 500.0);
                        Account acc2 = new SavingsAccount(1002, "Anna", 500.0, 0.01);

                        acc1.Withdraw(10.0);
                        acc2.Withdraw(10.0);

                        Console.WriteLine(acc1.Balance);
                        Console.WriteLine(acc2.Balance);
                    }
                    break;

                case 2:
                    {
                        Console.WriteLine("Enter a number of products");
                        int n = int.Parse(Console.ReadLine());

                        List<Product> product = new List<Product>();

                        for (int i = 1; i <= n; i++)
                        {
                            Console.WriteLine($"Product #{i} data:");
                            Console.Write("Common, used or imported (c/u/i)?: ");
                            char productType = char.Parse(Console.ReadLine());

                            Console.Write("Name: ");
                            string productName = Console.ReadLine();

                            Console.Write("Price: ");
                            double productPrice = double.Parse(Console.ReadLine());


                            if (productType == 'c')
                            {
                                product.Add(new Product(productName, productPrice));
                            }
                            else if (productType == 'i')
                            {
                                Console.Write("Customs fee: ");
                                double customsFee = double.Parse(Console.ReadLine());

                                product.Add(new ImportedProduct(productName, productPrice, customsFee));
                            }
                            else
                            {
                                Console.Write("Manufacture date (DD/MM/YYYY):");
                                DateTime productManufacture = DateTime.Parse(Console.ReadLine());
                                product.Add(new UsedProduct(productName, productPrice, productManufacture));
                            }

                        }
                        Console.WriteLine("PRICE TAGS:");
                        foreach (Product prod in product)
                        {
                            Console.WriteLine(prod.PriceTag());
                        }

                    }
                    break;




            };

        }

    }

}

