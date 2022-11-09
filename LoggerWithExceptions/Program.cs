﻿/*
                                                        Задача:
                    Необхідно реалізувати логгер(Logger), який збиратиме інформацію про стан додатка

                                                       Критерії:

● Логер пише на консоль інформацію у форматі "{час_лога}: {тип_лога}: {повідомлення}" і одночасно пише у файл
● Типи лога: Error, Info, Warning
● Вся логіка роботи логгера має бути в окремому файлі
● Логер надає методи для взаємодії з ним
● Необхідно створити в окремому файлі клас Actions у якому буде 3 методи
● Сигнатура методів в класі Actions: методи нічого не приймають і повертають прапор
● Методи в класі Actions повинні викликати логгер для того, щоб записати повідомлення в якому буде вказаний текст:
    ○ 1 метод "Start method: " і ім'я цього методу. Ця балка має бути з типом Info. Метод повертає true
    ○ 2 метод кидає BusinessException з текстом "Skipped logic in method"
    ○ 3 метод кидає Exception з текстом "I broke a logic".
● Створити в окремому файлі клас Starter з методом Run. Сигнатура методу нічого не приймає і не повертає.
● Метод Run містить:
    ○ Цикл(лічильник) на 100 ітерацій.
    ○ Усередині циклу у випадковому порядку викликається один з 3х методів класу Actions
    ○  Якщо зловили Exception, то викликати логер і записати в нього "Action failed by reason: "
        і весь об'єкт виключення. Цей лог має бути з типом Error.
    ○ Якщо зловили BusinessException то викликати логер і записати в нього "Action got this custom Exception :"
        і сам текст виключення. Цей лог має бути з типом Warning.
●  Вся робота з файлом повинна відбуватися в класі FileService.
    Логгер не знає про те як писати у файл, але він знає, що це може робити клас FileService.
● FileService повинен уміти писати у файл. При кожному створенні нового файлу перевіряти
    кількість файлів в директорії і якщо їх більше 3,то видаляти найстаріший.
        Файли записуються у форматі HH.mm.ss dd.MM.yyyy.txt і в окремій створеній директорії.
● Назву директорій потрібно брати з файлу конфігурацій. Необхідний сервіс по роботі з конфігураціями. Файл формату JSON
● В методі Main класа Program викликати метод Run

 */

namespace LoggerWithExceptions
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Starter.Run();

            Console.Write("\nPress any key to continue . . .");
            Console.ReadKey();
        }
    }
}