using System;
using cCharp_POO.Entities;
using System.Collections.Generic;
using cCharp_POO.Entities.Enums;
using System.Globalization;

namespace cCharp_POO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number of POO problem: ");
            Console.WriteLine("1 - Bank");
            Console.WriteLine("2 - Sale Product");
            Console.WriteLine("3 - Share Area");
            Console.WriteLine("4 - Tax Payer");
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

                case 3:
                    {
                        List<Shape> list = new List<Shape>();

                        Console.WriteLine("Enter the number of shapes: ");
                        int n = int.Parse(Console.ReadLine());

                        for (int i = 1; i <= n; i++)
                        {
                            Console.WriteLine($"Shape #{i} data: ");

                            Console.Write("Rectangle or Circle (r/c)? ");
                            char type = char.Parse(Console.ReadLine());

                            Console.Write("Color (Black/Blue/Red): ");
                            Color color = Enum.Parse<Color>(Console.ReadLine());

                            if (type == 'r')
                            {
                                Console.Write("Widht: ");
                                double width = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                                Console.Write("Height: ");
                                double height = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                                list.Add(new Rectangle(width, height, color));
                            }
                            else
                            {
                                Console.Write("Radius: ");
                                double radius = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                                list.Add(new Circle(radius, color));

                            }

                        }

                        Console.WriteLine();
                        Console.WriteLine("SHAPE AREAS: ");

                        foreach (Shape shape in list)
                        {
                            Console.WriteLine(shape.Area().ToString("F2", CultureInfo.InvariantCulture));
                        }

                    }
                    break;

                case 4:
                    {
                        Console.WriteLine("Enter the number of tax payers: ");
                        int n = int.Parse(Console.ReadLine());

                        List<TaxPayer> list = new List<TaxPayer>();

                        for (int i = 1; i <= n; i++)
                        {
                            Console.Write($"Tax payer #{i}: ");

                            Console.Write("Individual company(i/c)?");
                            char type = char.Parse(Console.ReadLine());

                            Console.Write("Name: ");
                            string name = Console.ReadLine();

                            Console.Write("Anual income:");
                            double anualIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                            if (type == 'i')
                            {
                                Console.Write("Health expenditures:");
                                double healthExpenditures = double.Parse(Console.ReadLine());
                                list.Add(new Individual(name, anualIncome, healthExpenditures));
                            }
                            else
                            {
                                Console.Write("Number of employees:");
                                int numberEmployees = int.Parse(Console.ReadLine());
                                list.Add(new Company(name, anualIncome, numberEmployees));
                            }

                            Console.WriteLine();
                        }

                        Console.WriteLine();
                        Console.WriteLine("TAX PAID:");

                        foreach (TaxPayer txtpayer in list)
                        {
                            Console.Write(txtpayer.Name + " $ ");
                            Console.WriteLine(txtpayer.Tax().ToString("F2", CultureInfo.InvariantCulture));
                        }

                        double totalTax = 0;

                        foreach (TaxPayer txtpayer in list)
                        {
                            totalTax += txtpayer.Tax();
                        }

                        Console.WriteLine();
                        Console.Write("TOTAL TAXES: $ " + totalTax.ToString("F2", CultureInfo.InvariantCulture));

                    }
                    break;

            };

        }

    }

}

