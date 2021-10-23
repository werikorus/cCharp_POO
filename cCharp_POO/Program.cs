using System;
using cCharp_POO.Entities;
using System.Collections.Generic;
using cCharp_POO.Entities.Enums;
using cCharp_POO.Entities.Exceptions;
using System.Globalization;
using System.IO;
using cCharp_POO.Services;

namespace cCharp_POO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number of POO problem or 0 to out of system: ");
            Console.WriteLine("1 - Bank");
            Console.WriteLine("2 - Sale Product");
            Console.WriteLine("3 - Share Area");
            Console.WriteLine("4 - Tax Payer");
            Console.WriteLine("5 - Try Except");
            Console.WriteLine("6 - Host Reserve");
            Console.WriteLine("7 - Account with exceptions");
            Console.WriteLine("8 - Files - Copy, Copy to show up -  Stream");
            Console.WriteLine("9 - Fechar try and finally to close - StreamReader");
            Console.WriteLine("10 - StreamWriter");
            Console.WriteLine("11 - CarRental");

            int problem = int.Parse(Console.ReadLine());

            if (problem != 0)
            {
                switch (problem)
                {
                    case 1:
                        {
                            Account acc1 = new Account(1101, "Alex", 500.0, 0);
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

                    case 5:
                        {
                            try
                            {
                                Console.WriteLine("Informe um número: ");
                                int n1 = int.Parse(Console.ReadLine());

                                Console.WriteLine("Informe outro número: ");
                                int n2 = int.Parse(Console.ReadLine());


                                int result = n1 / n2;
                                Console.Write("O resultado é: ");
                                Console.WriteLine(result);

                            }
                            catch (DivideByZeroException)
                            {
                                Console.WriteLine("Divisão por zero não é permitida!");
                            }
                            catch (FormatException e)
                            {
                                Console.WriteLine("Format error! " + e.Message);
                            }
                            finally
                            {
                                Console.WriteLine("Finalizado");
                                Console.WriteLine();
                            }

                        }
                        break;

                    case 6:
                        {
                            try
                            {

                                Console.WriteLine("Room number: ");
                                int roomNumber = int.Parse(Console.ReadLine());

                                Console.WriteLine("Check-in date (dd/MM/yyyy): ");
                                DateTime checkIn = DateTime.Parse(Console.ReadLine());

                                Console.WriteLine("Check-out date (dd/MM/yyyy): ");
                                DateTime checkOut = DateTime.Parse(Console.ReadLine());


                                Reservation reservation = new Reservation(roomNumber, checkIn, checkOut);
                                Console.WriteLine("Reservation: " + reservation);

                                Console.WriteLine();
                                Console.WriteLine("Enter data to update the reservation: ");


                                Console.WriteLine("Check-in date (dd/MM/yyyy): ");
                                checkIn = DateTime.Parse(Console.ReadLine());

                                Console.WriteLine("Check-out date (dd/MM/yyyy): ");
                                checkOut = DateTime.Parse(Console.ReadLine());


                                reservation.UpdateDates(checkIn, checkOut);
                                Console.WriteLine("Reservation: " + reservation);
                            }
                            catch (DomainException e)
                            {
                                Console.WriteLine("Error in reservation: " + e.Message);
                            }
                            catch (FormatException e)
                            {
                                Console.WriteLine("Error when entering data: " + e.Message);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Error reservation: " + e.Message);
                            }
                            finally
                            {
                                Console.WriteLine("End Reservation.");
                            }

                        }
                        break;

                    case 7:
                        {
                            //exercício fixação exceptions;

                            Console.WriteLine("Enter account data");

                            Console.Write("Number: ");
                            int cNumber = int.Parse(Console.ReadLine());

                            Console.Write("Holder: ");
                            string cHolder = Console.ReadLine();

                            Console.Write("Initial balance: ");
                            double cInitialBalance = double.Parse(Console.ReadLine());

                            Console.Write("Withdraw limit: ");
                            double cWithdrawLimit = double.Parse(Console.ReadLine());

                            Console.WriteLine();
                            Console.WriteLine("Enter amount for withdraw: ");
                            double cWithdraw = double.Parse(Console.ReadLine());

                            try
                            {
                                Account Acc = new Account(cNumber, cHolder, cInitialBalance, cWithdrawLimit);

                                Acc.Withdraw(cWithdraw);

                                Console.WriteLine("New Balance: " + Acc.Balance.ToString("F2", CultureInfo.InvariantCulture));
                            }
                            catch (DomainException e)
                            {
                                Console.WriteLine("Error in Transaction: " + e.Message);
                            }
                            catch (FormatException e)
                            {
                                Console.WriteLine("Data format error! " + e.Message);
                            }
                            finally
                            {
                                Console.WriteLine("End transaction!");
                            }
                        }
                        break;

                    case 8:
                        {
                            string sourcePath = @"C:\Projetos\C#\Estudos\cCharp_POO\files\file1.txt";
                            StreamReader sr = null;

                            try
                            {
                                sr = File.OpenText(sourcePath);

                                while (!sr.EndOfStream)
                                {
                                    string line = sr.ReadLine();
                                    Console.WriteLine(line);
                                };

                            }
                            catch (IOException e)
                            {
                                Console.WriteLine("An error ocurred");
                                Console.WriteLine(e.Message);
                            }
                            finally
                            {
                                if (sr != null) sr.Close();
                            }
                        }
                        break;

                    case 9:
                        {
                            string sourcePath = @"C:\Projetos\C#\Estudos\cCharp_POO\files\file1.txt";

                            try
                            {
                                using (StreamReader sr = File.OpenText(sourcePath))
                                {
                                    while (!sr.EndOfStream)
                                    {
                                        string line = sr.ReadLine();
                                        Console.WriteLine(line);
                                    }
                                }

                            }
                            catch (IOException e)
                            {
                                Console.WriteLine("An error ocurred:");
                                Console.WriteLine(e.Message);
                            }

                        }
                        break;

                    case 10:
                        {
                            string sourcePath = @"C:\Projetos\C#\Estudos\cCharp_POO\files\file1.txt";
                            string targetPath = @"C:\Projetos\C#\Estudos\cCharp_POO\files\file2.txt";

                            try
                            {
                                string[] lines = File.ReadAllLines(sourcePath);

                                using (StreamWriter sw = File.AppendText(targetPath))
                                {
                                    foreach (string line in lines)
                                    {
                                        sw.WriteLine(line.ToUpper());
                                    };
                                };

                            }
                            catch (IOException e)
                            {
                                Console.WriteLine("An error ocurred:");
                                Console.WriteLine(e.Message);
                            }
                        }
                        break;

                    case 11:
                        {
                            try
                            {
                                Console.WriteLine("Enter rental data");
                                Console.Write("Country: (BRL/CND/EUA)");
                                Countries country = Enum.Parse<Countries>(Console.ReadLine());

                                Console.Write("Car model: ");
                                string model = Console.ReadLine();

                                Console.Write("Pickup (dd/MM/yyyy hh:mm): ");
                                DateTime start = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

                                Console.Write("Return (dd/MM/yyyy hh:mm): ");
                                DateTime finish = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

                                Console.Write("Enter price per hour: ");
                                double hour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                                Console.Write("Enter price per day: ");
                                double day = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                                CarRental carRental = new CarRental(start, finish, new Vehicle(model));

                                // encontrar uma forma de retirar o BrazilTaxService e enviar só o enum do país!!
                                RentalService rentalService = new RentalService(hour, day, country, new BrazilTaxService());
                                rentalService.ProcessInvoice(carRental);
                                
                                Console.Write("INVOICE: ");
                                Console.WriteLine(carRental.Invoice);
                            }
                            catch (StackOverflowException error)
                            {
                                Console.WriteLine("Error in Rental Car: " + error.Message);
                            }
                            catch (Exception error)
                            {
                                Console.WriteLine("Error in Rental Car: " + error.Message);
                            }

                        }
                        break;

                }

            }

        }

    }

}


