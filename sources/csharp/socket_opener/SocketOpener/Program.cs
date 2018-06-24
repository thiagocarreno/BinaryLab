using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;

namespace SocketOpener
{
    class Program
    {
        /// <summary>
        /// Localizador de Threads, conexões e clientes.
        /// Com volatile torna possível o acesso compartilhado de Threads.
        /// </summary>
        private static volatile Dictionary<int, Connections> ThreadLocation;

        /// <summary>
        /// Inicializador
        /// </summary>
        /// <param name="args">Argumentos de sistema</param>
        static void Main(string[] args)
        {
            // Inicializa um dicionário de dados que guarda uma porta e a sua conexão aberta.
            ThreadLocation = new Dictionary<int, Connections>();
            Console.SetWindowSize(100, 20);
            //Este loop não permite que o programa seja finalizado sem o comando "quit".
            while (true)
            {
                //Escreve banner inicial.
                string banner = 
@"
#    _________              __           __  ________                                     
#   /   _____/ ____   ____ |  | __ _____/  |_\_____  \ ______   ____   ____   ___________ 
#   \_____  \ /  _ \_/ ___\|  |/ // __ \   __\/   |   \\____ \_/ __ \ /    \_/ __ \_  __ \
#   /        (  <_> )  \___|    <\  ___/|  | /    |    \  |_> >  ___/|   |  \  ___/|  | \/
#  /_______  /\____/ \___  >__|_ \\___  >__| \_______  /   __/ \___  >___|  /\___  >__|   
#          \/            \/     \/    \/             \/|__|        \/     \/     \/       
";
                Console.WriteLine(banner);
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Este programa foi criado com o intuito de receber pacotes e interpretá-los como string em uma porta específica.");
                Console.WriteLine("Comandos disponíveis: quit, open [port], close [port]");

                string command = Console.ReadLine();

                if (!string.IsNullOrEmpty(command))
                {
                    int port = 0;

                    string lowerCommand = command.ToLowerInvariant();
                    if (lowerCommand.Contains("quit"))
                    {
                        if (ThreadLocation != null
                            && ThreadLocation.Count > 0)
                        {
                            ClosePort();
                        }
                        break;
                    }
                    else if (lowerCommand.Contains("open"))
                    {
                        string[] splittedOpen = lowerCommand.Split(' ');
                        if (splittedOpen != null
                            && splittedOpen.Length > 1)
                        {
                            if (int.TryParse(splittedOpen[1], out port))
                            {
                                if (ThreadLocation != null
                                    && !ThreadLocation.ContainsKey(port))
                                {
                                    OpenPort(port);
                                }
                                else
                                {
                                    Console.WriteLine("Esta porta {0} já  está em uso!", port);
                                }
                            }
                        }
                    }
                    else if (lowerCommand.Contains("close"))
                    {
                        string[] splittedOpen = lowerCommand.Split(' ');
                        if (splittedOpen != null
                            && splittedOpen.Length > 1)
                        {
                            if (int.TryParse(splittedOpen[1], out port))
                            {
                                ClosePort(port);
                            }
                        }
                    }
                }

                Console.Clear();
            }
        }

        /// <summary>
        /// Abre uma porta via Socket no ip localhost (127.0.0.1)
        /// </summary>
        /// <param name="port">Porta utilizada para abrir o socket.</param>
        private static void OpenPort(int port)
        {
            ParameterizedThreadStart paramStart = new ParameterizedThreadStart(ThreadListener);
            Thread th = new Thread(paramStart);

            ThreadLocation.Add(port, new Connections()
            {
                Thread = th
            });
            th.Start(port);
        }

        /// <summary>
        /// Cria o socket listener para a porta utilizada no método: OpenPort
        /// Este método é utilizado por Threads... mantenha-o sem guardar qualquer estado de dados
        /// Threads conseguem conversar apenas por Object, dentro do método existe uma validação de tipo e um TypeCast para inteiro.
        /// </summary>
        /// <param name="port">Objeto porta</param>
        private static void ThreadListener(object port)
        {
            if (port is int)
            {
                int convertedPort = (int)port;
                Connections conn = ThreadLocation[convertedPort];

                string directoryName = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                string pathName = System.IO.Path.Combine(directoryName, string.Format("{0}{1}{2}", "logReceived_", DateTime.Now.ToString("ddMMyyyy_HHmmss"), ".txt"));
                string readedContent = string.Empty;

                System.Net.IPAddress serverAddress = System.Net.IPAddress.Parse("127.0.0.1"); // <-- Change that as appropriate!

                conn.Listener = new TcpListener(serverAddress, convertedPort);
                conn.Listener.Start();

                try
                {
                    conn.Client = conn.Listener.AcceptTcpClient();

                    NetworkStream ourStream = conn.Client.GetStream();
                    byte[] data = new byte[conn.Client.ReceiveBufferSize];

                    int bytesRead = ourStream.Read(data, 0, System.Convert.ToInt32(conn.Client.ReceiveBufferSize));
                    readedContent = Encoding.ASCII.GetString(data, 0, bytesRead);

                    if (!System.IO.Directory.Exists(directoryName))
                    {
                        System.IO.Directory.CreateDirectory(directoryName);
                    }

                    System.IO.File.WriteAllText(pathName, Encoding.ASCII.GetString(data, 0, bytesRead));

                    if (ThreadLocation != null
                        && ThreadLocation.ContainsKey(convertedPort))
                    {
                        conn.Client.Close();
                        conn.Listener.Stop();
                        ThreadLocation.Remove(convertedPort);
                    }
                }
                catch
                { }
            }
        }

        /// <summary>
        /// Fecha todas as portas as quais foram abertas por este OpenPort
        /// </summary>
        private static void ClosePort()
        {
            int[] allKeys = new int[ThreadLocation.Keys.Count];
            ThreadLocation.Keys.CopyTo(allKeys, 0);

            for (int i = allKeys.Length - 1; i >= 0; i--)
            {
                ClosePort(allKeys[i]);
            }
        }

        /// <summary>
        /// Fecha uma porta específica a qual foi aberta pelo OpenPort.
        /// </summary>
        /// <param name="port"></param>
        private static void ClosePort(int port)
        {
            if (ThreadLocation != null
                && ThreadLocation.ContainsKey(port))
            {
                if (ThreadLocation[port].Thread != null)
                {
                    ThreadLocation[port].Thread.Interrupt();
                }

                if (ThreadLocation[port].Client != null)
                {
                    ThreadLocation[port].Client.Close();
                }

                if (ThreadLocation[port].Listener != null)
                {
                    ThreadLocation[port].Listener.Stop();
                }

                ThreadLocation.Remove(port);
            }
        }
    }

    /// <summary>
    /// Class helper para guardar estado multi-thread.
    /// </summary>
    public class Connections
    {
        public TcpListener Listener { get; set; }
        public TcpClient Client { get; set; }
        public Thread Thread { get; set; }
    }
}
