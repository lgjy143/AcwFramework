using Acw;
using Acw.DependencyInjection;
using Acw.Modularity;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace SimpleConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var application = AcwApplicationFactory.Create<MyConsoleModule>(options =>
            {
            }))
            {
                application.Initialize();

                Console.WriteLine("Acw initialized... Press ENTER to exit!");

                var writers = application.ServiceProvider.GetServices<IMessageWriter>();
                foreach (var writer in writers)
                {
                    writer.Write();
                }

                Console.ReadLine();
            }
        }
    }
    public class MyConsoleModule : AcwModule
    {

    }

    public interface IMessageWriter
    {
        void Write();
    }

    public class ConsoleMessageWriter : IMessageWriter, ITransientDependency
    {
        private readonly MessageSource _messageSource;

        public ConsoleMessageWriter(MessageSource messageSource)
        {
            _messageSource = messageSource;
        }

        public void Write()
        {
            Console.WriteLine(_messageSource.GetMessage());
        }
    }

    public class MessageSource : ITransientDependency
    {
        public string GetMessage()
        {
            return "Hello Acw!";
        }
    }
}
