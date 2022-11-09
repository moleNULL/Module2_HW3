# # &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NIX Solutions Module #2 Homework #3
                                                       Задача:
                           Необхідно реалізувати логгер(Logger), який збиратиме інформацію про стан додатка
                               
                                                      Критерії:

● Логер пише на консоль інформацію у форматі "{час_лога}: {тип_лога}: {повідомлення}" і одночасно пише у файл\
● Типи лога: Error, Info, Warning\
● Вся логіка роботи логгера має бути в окремому файлі\
● Логер надає методи для взаємодії з ним\
● Необхідно створити в окремому файлі клас Actions у якому буде 3 методи\
● Сигнатура методів в класі Actions: методи нічого не приймають і повертають прапор\
● Методи в класі Actions повинні викликати логгер для того, щоб записати повідомлення в якому буде вказаний текст:\
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;○ 1 метод "Start method: " і ім'я цього методу. Ця балка має бути з типом Info. Метод повертає true\
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;○ 2 метод кидає BusinessException з текстом "Skipped logic in method"\
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;○ 3 метод кидає Exception з текстом "I broke a logic".\
● Створити в окремому файлі клас Starter з методом Run. Сигнатура методу нічого не приймає і не повертає.\
● Метод Run містить\
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;○ Цикл(лічильник) на 100 ітерацій.\
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;○ Усередині циклу у випадковому порядку викликається один з 3х методів класу Actions\
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;○  Якщо зловили Exception, то викликати логер і записати в нього "Action failed by reason: "\
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;і весь об'єкт виключення. Цей лог має бути з типом Error.\
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;○ Якщо зловили BusinessException то викликати логер і записати в нього "Action got this custom Exception :"\
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;і сам текст виключення. Цей лог має бути з типом Warning.\
●  Вся робота з файлом повинна відбуватися в класі FileService.\
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Логгер не знає про те як писати у файл, але він знає, що це може робити клас FileService.\
● FileService повинен уміти писати у файл. При кожному створенні нового файлу перевіряти\
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;кількість файлів в директорії і якщо їх більше 3,то видаляти найстаріший.\
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Файли записуються у форматі HH.mm.ss dd.MM.yyyy.txt і в окремій створеній директорії.\
● Назву директорій потрібно брати з файлу конфігурацій. Необхідний сервіс по роботі з конфігураціями. Файл формату JSON\
● В методі Main класа Program викликати метод Run\
