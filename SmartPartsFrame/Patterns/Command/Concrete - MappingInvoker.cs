using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace SmartPartsFrame.Patterns.Command
{
    /// <summary>
    /// Command invoker
    /// "Пользователь" комманд
    /// </summary>
    public class MappingInvoker
    {
        MappingCommandReceiver receiver;

        public MappingInvoker()
        {
            ///Создадим получателя комманд
            receiver = new MappingCommandReceiver(new Rectangle(0, 0, 100, 100));
        }

        /// <summary>
        /// Тестовый вызов
        /// </summary>
        public void TestInvoke()
        {
            ///Создадим и выполним 1000 различных команд
            Random r = new Random();
            for (int i = 0; i < 1000; i++)
            {
                MappingCommand cmd = new MappingCommand(receiver);
                cmd.MappingPoint = new Point(r.Next(-50, 150), r.Next(-50, 150));
                cmd.Execute();
            }

            ///Создадим 3 команды
            CommandBase cmd1 = new MappingCommand(receiver, new Point(10, 10));
            CommandBase cmd2 = new MappingCommand(receiver, new Point(0, 0));
            CommandBase cmd3 = new MappingCommand(receiver, new Point(99, 99));

            ///Выполним 3 команды
            cmd1.Execute();
            cmd2.Execute();
            cmd3.Execute();

            ///Отменим выполнение 3-х команд
            cmd1.UnExecute();
            cmd2.UnExecute();
            cmd3.UnExecute();

            ///Отобразим результат
            Console.WriteLine("total mapped: {0}", receiver.Points.Count);
            Console.WriteLine("mapped:");
            foreach (Point p in receiver.Points)
            {
                Console.WriteLine(p.ToString());
            }
        }
    }
}
