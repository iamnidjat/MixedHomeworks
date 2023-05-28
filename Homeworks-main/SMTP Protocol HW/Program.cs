Console.WriteLine("Выберите формат: ");
Console.WriteLine("1 - shutdown /s X /m X /h X");
Console.WriteLine("2 - shutdown /s X /h X /m X");
Console.WriteLine("3 - shutdown /m X /s X /h X");
Console.WriteLine("4 - shutdown /m X /h X /s X");
Console.WriteLine("5 - shutdown /h X /m X /s X");
Console.WriteLine("6 - shutdown /h X /s X /m X");
Console.WriteLine("7 - shutdown /h X /s X");
Console.WriteLine("8 - shutdown /s X /h X");
Console.WriteLine("9 - shutdown /h X /m X");
Console.WriteLine("10 - shutdown /m X /h X");
Console.WriteLine("11 - shutdown /m X /s X");
Console.WriteLine("12 - shutdown /s X /m X");
Console.WriteLine("13 - shutdown /s X");
Console.WriteLine("14 - shutdown /m X");
Console.WriteLine("15 - shutdown /h X");
Console.Write("=> ");

int op = Int32.Parse(Console.ReadLine());

smtpMessage smtpMessage = new smtpMessage();
smtpMessage.SendMessage(op);
smtpMessage.ShutdownPC();
