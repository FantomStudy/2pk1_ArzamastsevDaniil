namespace PZ_16
{
    internal class Program
    {
        // Размер карты
        static int mapSize = 25;
        static char[,] map = new char[mapSize, mapSize + 1];

        // Координаты на карте игрока
        static int playerY = mapSize / 2;
        static int playerX = mapSize / 2;

        // Спавн по количеству
        static byte enemies = 10; // Врагов
        static byte buffs = 5; // Усилений
        static int health = 5;  // Аптечек

        // Счетчики
        static int enCount = 5;
        static int CountForBoss = 1;
        static int Buffcount = 20;

        // Параметры игрока
        static int plHP = 50;
        static int plDMG = 10;

        static int step = 0;
        static int stepsave;
        static bool Alive = true;

        // Параметры врага
        static byte enDMG = 5;
        static int enHP = 30;

        // Параметры Босса
        static int bossHP = 500;
        static int bossDMG = 15;
        static int bossCount = 0;
        static bool isBoss;
        static bool isBossFight = false;
        static bool bossIsRight;

        // Сервисные переменные
        static string lastAction = "Начало игры";
        static int centerY = Console.WindowHeight / 2;
        static int selectedMenuItem = 0;
        static int winHeight = 25;
        static int winWidth = 70;

        static void Main(string[] args)
        {
            Console.Title = "Game";
            Console.CursorVisible = false;
            Console.SetWindowSize(winWidth, winHeight);
            Menu();
        }

        // Карта и движение

        static void GenerationMap() // Создание карты и условия спавна
        {
            Random random = new Random();
            //создание пустой карты
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    map[i, j] = '_';
                }
            }

            map[playerY, playerX] = 'P'; // в чередину карты ставится игрок

            //временные координаты для проверки занятости ячейки
            int x;
            int y;

            while (bossIsRight)
            {
                x = random.Next(1, mapSize - 5);
                y = random.Next(1, mapSize - 5);
                if (map[x, y] == '_' && map[x + 1, y] != 'P' && map[x - 1, y] != 'P' && map[x, y + 1] != 'P' && map[x, y - 1] != 'P'
                    && map[x + 1, y - 1] != 'P' && map[x - 1, y - 1] != 'P' && map[x + 1, y + 1] != 'P' && map[x - 1, y + 1] != 'P'
                     && map[x - 1, y + 2] != 'P' && map[x + 1, y + 2] != 'P' && map[x, y + 3] != 'P' && map[x - 1, y + 3] != 'P'
                      && map[x + 1, y + 3] != 'P' && map[x, y + 2] != 'P')
                {
                    map[x, y] = '>'; map[x, y + 1] = '-'; map[x, y + 2] = '<';
                    map[x, y - 1] = '▒'; map[x + 1, y - 1] = '▒'; map[x - 1, y - 1] = '▒';
                    map[x + 1, y] = '▒'; map[x - 1, y] = '▒'; map[x - 1, y + 1] = '▒';
                    map[x - 1, y + 2] = '▒'; map[x + 1, y + 2] = '▒'; map[x, y + 3] = '▒';
                    map[x + 1, y + 3] = '▒'; map[x - 1, y + 3] = '▒';
                    bossIsRight = false;
                }
            }
            //добавление врагов
            while (enemies > 0)
            {
                x = random.Next(1, mapSize - 3);
                y = random.Next(1, mapSize - 3);

                //если ячейка пуста  - туда добавляется враг
                if (map[x, y] == '_' && map[x + 1, y] != 'E' && map[x - 1, y] != 'E' && map[x, y + 1] != 'E' && map[x, y - 1] != 'E'
                    && map[x + 1, y - 1] != 'E' && map[x - 1, y - 1] != 'E' && map[x + 1, y + 1] != 'E' && map[x - 1, y + 1] != 'E')
                {
                    map[x, y] = 'E';
                    enemies--; //при добавлении врагов уменьшается количество нерасставленных врагов
                }
            }
            //добавление баффов
            while (buffs > 0)
            {
                x = random.Next(1, mapSize - 1);
                y = random.Next(1, mapSize - 1);

                if (map[x, y] == '_' && map[x + 1, y] != 'B' && map[x - 1, y] != 'B' && map[x, y + 1] != 'B' && map[x, y - 1] != 'B'
                        && map[x + 1, y - 1] != 'B' && map[x - 1, y - 1] != 'B' && map[x + 1, y + 1] != 'B' && map[x - 1, y + 1] != 'B')
                {
                    map[x, y] = 'B';
                    buffs--;
                }
            }
            //добавление аптечек
            while (health > 0)
            {
                x = random.Next(1, mapSize - 3);
                y = random.Next(1, mapSize - 3);

                if (map[x, y] == '_' && map[x + 1, y] != 'H' && map[x - 1, y] != 'H' && map[x, y + 1] != 'H' && map[x, y - 1] != 'H'
                    && map[x + 1, y - 1] != 'H' && map[x - 1, y - 1] != 'H' && map[x + 1, y + 1] != 'H' && map[x - 1, y + 1] != 'H')
                {
                    map[x, y] = 'H';
                    health--;
                }
            }
            UpdateMap(); //отображение заполненной карты на консоли
        }

        static void UpdateMap() // Отображение карты
        {
            Console.Clear();
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if (map[i, j] == 'B') Console.ForegroundColor = ConsoleColor.Blue;
                    if (map[i, j] == 'E') Console.ForegroundColor = ConsoleColor.Red;
                    if (map[i, j] == 'H') Console.ForegroundColor = ConsoleColor.Green;
                    if (map[i, j] == '>' || map[i, j] == '-' || map[i, j] == '<') Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    if (map[i, j] == '▒') Console.ForegroundColor = ConsoleColor.DarkGray;
                    if (map[i, j] == 'P') Console.ForegroundColor = ConsoleColor.Magenta;
                    if (map[i, j] == '_') Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(map[i, j]);
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }

        static void Move() // Движение и применение функций
        {
            //предыдущие координаты игрока
            int playerOldY;
            int playerOldX;

            while (Alive)
            {
                playerOldX = playerX;
                playerOldY = playerY;

                //смена координат в зависимости от нажатия клавиш
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.UpArrow:
                        playerY--;
                        step++;
                        if (playerY < 0)
                        {
                            playerY = 0;
                            step--;
                        }
                        if (map[playerY, playerX] == '-')
                            BossFight();
                        break;
                    case ConsoleKey.DownArrow:
                        playerY++;
                        step++;
                        if (playerY >= mapSize)
                        {
                            playerY = mapSize - 1;
                            step--;
                        }
                        if (map[playerY, playerX] == '-')
                        {
                            playerX = playerOldX;
                            playerY = playerOldY;
                            step--;
                        }
                        break;
                    case ConsoleKey.B:
                        BossFight();
                        break;
                    case ConsoleKey.LeftArrow:
                        playerX--;
                        step++;
                        if (playerX < 0)
                        {
                            playerX = 0;
                            step--;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        playerX++;
                        step++;
                        if (playerX >= mapSize)
                        {
                            playerX = mapSize - 1;
                            step--;
                        }
                        break;
                    case ConsoleKey.Escape:
                        Pause();
                        break;
                    default:
                        UpdateMap();
                        Move();
                        break;
                }

                if (step - stepsave == 20 && stepsave > 0)
                {
                    BuffUp();
                }

                if (map[playerY, playerX] == '>' || map[playerY, playerX] == '<')
                {
                    playerX = playerOldX;
                    playerY = playerOldY;
                    step--;
                }

                if (map[playerY, playerX] == 'B')
                {
                    stepsave = step;
                    BuffUp();
                }

                if (map[playerY, playerX] == 'E')
                {
                    Fight();
                }

                if (map[playerY, playerX] == 'H')
                {
                    Heal();
                }

                //предыдущее положение игрока затирается
                if (map[playerOldY, playerOldX] == '▒')
                {
                    Console.SetCursorPosition(playerOldX, playerOldY);
                    Console.Write('▒');
                }
                else
                {
                    map[playerOldY, playerOldX] = '_';
                    Console.SetCursorPosition(playerOldX, playerOldY);
                    Console.Write('_');
                }

                if (map[playerY, playerX] == '▒' && plHP > 0)
                {
                    plHP -= 5;
                    Console.SetCursorPosition(playerX, playerY);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write('P');
                    Console.ResetColor();
                }
                else
                {
                    map[playerY, playerX] = 'P';
                    Console.SetCursorPosition(playerX, playerY);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write('P');
                    Console.ResetColor();
                }

                if (plHP <= 0)
                {
                    Alive = false;
                    GameOver();
                }

                if (enCount == 0 && CountForBoss == 1)
                {
                    CountForBoss--;
                    BossSpawn();
                }

                int x, y;
                x = playerX; y = playerY;
                Console.SetCursorPosition(30, 3);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Здоровье: {plHP}  ");

                Console.SetCursorPosition(30, 5);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Сила атаки: {plDMG}  ");

                Console.SetCursorPosition(30, 7);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"Осталось врагов до босса:  {enCount}   ");

                Console.SetCursorPosition(30, 9);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(lastAction);

                Console.SetCursorPosition(30, 11);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Сделано шагов: {step}  ");

                Console.SetCursorPosition(30, 13);
                Console.WriteLine($"x = {x}, y = {y}" + "  ");

                if (isBoss)
                {
                    Console.SetCursorPosition(30, 15);
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("Босс появился, атакуй снизу!");
                    Console.SetCursorPosition(30, 16);
                    Console.WriteLine($"Здоровье босса: {bossHP} ");
                    Console.SetCursorPosition(30, 17);
                    Console.WriteLine($"Сила атаки босса: {bossDMG}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }


        // Основные механики

        static void Fight() // Бой с врагами
        {
            while (plHP > 0 && enHP > 0)
            {
                for (int i = 0; i < 3; i++) // Перебор символов анимации
                {
                    Console.SetCursorPosition(playerX, playerY);
                    Console.Write('|');
                    Thread.Sleep(60);
                    Console.SetCursorPosition(playerX, playerY);
                    Console.Write('/');
                    Thread.Sleep(60);
                    Console.SetCursorPosition(playerX, playerY);
                    Console.Write('-');
                    Thread.Sleep(60);
                }
                plHP -= enDMG;
                enHP -= plDMG;

                Console.Write('_');
            }
            lastAction = "Вы победили врага, но потеряли " + (50 - plHP) + " HP   ";
            enCount--;
            enHP = 30;
        }

        static void BuffUp() // Баффы
        {
            if (step - stepsave == 20 && stepsave > 0)
            {
                plDMG = 10;
                lastAction = "Бафф закончился!                      ";
            }
            else
            {
                stepsave = step; //сохранение шага на котором взят бафф
                plDMG *= 2;
                map[playerX, playerY] = '_'; // Решение проблемы "фантомного элемента"
                lastAction = "Вы подняли бафф!                      ";
            }
        }

        static void Heal() // Аптечки
        {
            plHP = 50;
            map[playerX, playerY] = '_'; // Решение проблемы "фантомного элемента"
            lastAction = "Вы исцелились!                        ";
        }


        // Босс

        static void BossFight() // Бой с боссом
        {
            while (plHP > 0 && bossHP > 0 && bossCount < 2)
            {
                for (int i = 0; i < 3; i++) // Перебор символов анимации
                {
                    Console.SetCursorPosition(playerX, playerY);
                    Console.Write('|');
                    Thread.Sleep(60);
                    Console.SetCursorPosition(playerX, playerY);
                    Console.Write('/');
                    Thread.Sleep(60);
                    Console.SetCursorPosition(playerX, playerY);
                    Console.Write('-');
                    Thread.Sleep(60);
                }
                plHP -= bossDMG;
                bossHP -= plDMG;

                Console.Write('_');
                bossCount++;
            }
            if (bossHP <= 0)
            {
                Victory();
                ResetAll();
            }
            isBossFight = true;
            BossSpawn();
        }

        static void BossSpawn() // Спавн босса
        {
            if (!isBossFight)
            {
                plDMG = 10;
            }
            isBoss = true;
            ResetForBoss();
            GenerationMap();
            Move();
        }


        // Финал игры

        static void Victory() // Экран победы
        {
            Console.Clear();
            Centertext("Игра пройдена!", centerY);
            Centertext("Вы сделали " + step + " шагов!", centerY + 1);
            Centertext("Нажмите Enter для выхода в меню", centerY + 5);

            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey();
            } while (keyInfo.Key != ConsoleKey.Enter);

            Environment.Exit(0); // Выход
        }

        static void GameOver() // Экран смерти
        {
            Console.Clear();
            Centertext("Игра окончена!", centerY);
            Centertext("Нажмите Enter для выхода из игры", centerY + 2);

            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey();
            } while (keyInfo.Key != ConsoleKey.Enter);

            Environment.Exit(0); // Выход
        }


        // Сервисные функции

        static void ResetAll() // Перезапуск всей карты
        {
            plHP = 50;
            plDMG = 10;
            step = 0;
            enemies = 10;
            enCount = 5;
            buffs = 5;
            health = 5;
            enDMG = 5;
            enHP = 30;
            playerY = mapSize / 2;
            playerX = mapSize / 2;
            Alive = true;
            isBoss = false;
        }

        static void ResetForBoss() // Подготовка карты к боссу
        {
            plDMG = 10;
            bossCount = 0;
            enemies = 0;
            enCount = 0;
            buffs = 4;
            health = 3;
            Alive = true;
            bossIsRight = true;
        }

        static void Centertext(string text, int y) // Сделано для оформления по середине
        {
            int centerX = Console.WindowWidth / 2 - text.Length / 2;
            Console.SetCursorPosition(centerX, y);
            Console.WriteLine(text);
        }


        // Сохранения

        static string GameSave() // Сохранения
        {
            Console.Clear();

            Centertext("Вы успешно сохранили игру!", centerY);

            Centertext("Нажмите любую клавишу, чтобы вернуться в меню паузы", centerY + 2);
            Console.ReadKey();

            string path = "save.txt";
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine($"playerX={playerX}");
                writer.WriteLine($"playerY={playerY}");
                writer.WriteLine($"plHP={plHP}");
                writer.WriteLine($"plDMG={plDMG}");
                writer.WriteLine($"step={step}");
                writer.WriteLine($"enemies_count={enCount}");
                writer.WriteLine($"CountForBoss={CountForBoss}");
                writer.WriteLine($"bossHP={bossHP}");
                writer.WriteLine($"bossCount={bossCount}");
                writer.WriteLine($"bossDMG={bossDMG}");
                writer.WriteLine($"Alive={Alive}");
                writer.WriteLine($"isBoss={isBoss}");
                writer.WriteLine($"isBossFight={isBossFight}");

                for (int i = 0; i < mapSize; i++)
                {
                    for (int j = 0; j < mapSize; j++)
                    {
                        writer.Write(map[i, j]);
                    }
                    writer.WriteLine();
                }
            }
            Pause();
            return path;
        }
        static void GameLoad() // Загрузка игры
        {
            string path = "save.txt";
            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);
                if (lines.Length >= mapSize)
                {
                    if (int.TryParse(lines[0].Split('=')[1], out int loadedPlayerX) &&
                        int.TryParse(lines[1].Split('=')[1], out int loadedPlayerY) &&
                        int.TryParse(lines[2].Split('=')[1], out int loadedPlHP) &&
                        int.TryParse(lines[3].Split('=')[1], out int loadedPlDMG) &&
                        int.TryParse(lines[4].Split('=')[1], out int loadedstep) &&
                        int.TryParse(lines[5].Split('=')[1], out int loadedEnemies_count) &&
                        int.TryParse(lines[6].Split('=')[1], out int loadedCountForBoss) &&
                        int.TryParse(lines[7].Split('=')[1], out int loadedbossHP) &&
                        int.TryParse(lines[8].Split('=')[1], out int loadedbossCount) &&
                        int.TryParse(lines[9].Split('=')[1], out int loadedbossDMG) &&
                        bool.TryParse(lines[10].Split('=')[1], out bool loadedAlive) &&
                        bool.TryParse(lines[11].Split('=')[1], out bool loadedisBoss) &&
                        bool.TryParse(lines[12].Split('=')[1], out bool loadedisBossFight))
                    {
                        playerX = loadedPlayerX;
                        playerY = loadedPlayerY;
                        plHP = loadedPlHP;
                        plDMG = loadedPlDMG;
                        step = loadedstep;
                        enCount = loadedEnemies_count;
                        CountForBoss = loadedCountForBoss;
                        bossHP = loadedbossHP;
                        bossCount = loadedbossCount;
                        bossDMG = loadedbossDMG;
                        Alive = loadedAlive;
                        isBoss = loadedisBoss;
                        isBossFight = loadedisBossFight;

                        for (int i = 0; i < mapSize; i++)
                        {
                            for (int j = 0; j < mapSize; j++)
                            {
                                map[i, j] = '_';
                            }
                        }
                        for (int i = 0; i < mapSize; i++)
                        {
                            for (int j = 0; j < mapSize; j++)
                            {
                                map[i, j] = lines[i + 13][j];
                            }
                        }
                        map[playerY, playerX] = 'P';
                        UpdateMap();
                        Move();
                    }

                }
                else
                {
                    Console.WriteLine("Ошибка чтения файла сохранения.");
                }
            }
            else
            {
                Console.WriteLine("Файл сохранения не найден.");
            }
        }


        // Менюшки

        static void DisplayMenu() // Интерфейс
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 10);

            Console.ForegroundColor = (selectedMenuItem == 0) ? ConsoleColor.Green : ConsoleColor.White; // Если равно, то зеленый. Нн равно - белый. 
            Centertext("1. Новая игра", centerY - 3);
            Console.ForegroundColor = (selectedMenuItem == 1) ? ConsoleColor.Green : ConsoleColor.White;
            Centertext("2. Загрузка", centerY - 1);
            Console.ForegroundColor = (selectedMenuItem == 2) ? ConsoleColor.Green : ConsoleColor.White;
            Centertext("3. Выход", centerY + 1);
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void DisplayPause()
        {
            Console.CursorVisible = false;
            Centertext("A PAUSE", centerY - 5);
            Console.ForegroundColor = (selectedMenuItem == 0) ? ConsoleColor.Green : ConsoleColor.White; // Если равно, то зеленый. Нн равно - белый. 
            Centertext("1. Продолжить", centerY - 3);
            Console.ForegroundColor = (selectedMenuItem == 1) ? ConsoleColor.Green : ConsoleColor.White;
            Centertext("2. Сохранить", centerY - 1);
            Console.ForegroundColor = (selectedMenuItem == 2) ? ConsoleColor.Green : ConsoleColor.White;
            Centertext("3. Выход", centerY + 1);
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void HandleMenuSelection() // Передача и открытие функций
        {
            Console.Clear();
            switch (selectedMenuItem)
            {
                case 0:
                    if (!Alive) ResetAll();
                    GenerationMap();
                    Move();
                    break;
                case 1:
                    Alive = true;
                    Console.WriteLine("Выполняется загрузка...");
                    GameLoad();
                    break;
                case 2:
                    Console.WriteLine("До следующей игры!");
                    Environment.Exit(0);
                    break;
            }
            Console.ReadKey(true);
        }
        static void HandlePauseSelection()
        {
            Console.Clear();
            switch (selectedMenuItem)
            {
                case 0:
                    UpdateMap();
                    Move();
                    break;
                case 1:
                    GameSave();
                    break;
                case 2:
                    Console.WriteLine("До следующей игры!");
                    Environment.Exit(0);
                    break;
            }
            Console.ReadKey(true);
        }

        static void Menu() // Управление стрелочками и основной вызов меню
        {
            ConsoleKeyInfo key;
            do
            {
                Console.Clear();
                DisplayMenu();
                Console.WriteLine("    /\\_____/\\\r\n   /  o   o  \\\r\n  ( ==  ^  == )\r\n   )         (\r\n  (           )\r\n ( (  )   (  ) )\r\n(__(__)___(__)__)");
                Centertext("THE GAME", centerY - 5);
                key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedMenuItem = (selectedMenuItem - 1 + 3) % 3;
                        break;
                    case ConsoleKey.DownArrow:
                        selectedMenuItem = (selectedMenuItem + 1) % 3;
                        break;
                    case ConsoleKey.Enter:
                        HandleMenuSelection();
                        break;
                }
            } while (key.Key != ConsoleKey.Enter);
        }
        static void Pause()
        {
            ConsoleKeyInfo key;
            do
            {
                Console.Clear();
                DisplayPause();
                key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedMenuItem = (selectedMenuItem - 1 + 3) % 3;
                        break;
                    case ConsoleKey.DownArrow:
                        selectedMenuItem = (selectedMenuItem + 1) % 3;
                        break;
                    case ConsoleKey.Enter:
                        HandlePauseSelection();
                        break;
                }
            } while (key.Key != ConsoleKey.Enter);
        }
    }
}