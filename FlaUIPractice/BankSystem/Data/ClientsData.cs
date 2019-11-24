using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
namespace BankSystem
{
    class ClientsData
    {
        static Client Cur;
        static int CurPosition;
        static FileStream FileStream;
        static BinaryReader Br;
        static BinaryWriter Bw;
        private ClientsData()
        { 
        }
        public static string OpenStreams()
        {
            try
            {
                String basePath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())));
                
                FileStream = new FileStream(basePath + "//BankSystem//bin//Release//Data.txt", FileMode.Open, FileAccess.ReadWrite);
                Br = new BinaryReader(FileStream);
                Bw = new BinaryWriter(FileStream);
                return "Opened";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static void AddUser(Client User)
        {
            int Position = 100*HashFunction(User.EM.ToLower());
            FileStream.Seek(Position, SeekOrigin.Begin);
            while (Br.PeekChar() == 'T')
            {
                FileStream.Seek(100, SeekOrigin.Current);
            }
            Bw.Write('T');
            Bw.Write(User.EM);
            Bw.Write(User.Pass);
            Bw.Write(User.FName);
            Bw.Write(User.LName);
            Bw.Write(User.Ctry);
            Bw.Write(User.Ag);
            Bw.Write(User.Visa);
            Bw.Write(User.Phone);
            Bw.Write(User.Am);
            Bw.Flush();
        }
        public static bool Registered(string Email)
        {
            int Position = 100*HashFunction(Email);
            FileStream.Seek(Position, SeekOrigin.Begin);
            while (Br.PeekChar() == 'T')
            {
                Br.ReadChar();
                if (Br.ReadString().ToLower() == Email)
                {
                    return false;
                }
                Position += 100;
                FileStream.Seek(Position, SeekOrigin.Begin);
            }
            return true;
        }
        public static bool LogInChecker(string Email, string Pass)
        {
            int Position = 100*HashFunction(Email);
            FileStream.Seek(Position, SeekOrigin.Begin);
            while (Br.PeekChar() == 'T')
            {
                int Temp = Position;
                Br.ReadChar();
                if (Br.ReadString().ToLower() == Email && Br.ReadString() == Pass)
                {
                   Cur = new Client(Email, Pass, Br.ReadString(), Br.ReadString(), Br.ReadString(),
                                    Br.ReadString(), Br.ReadString(), Br.ReadString(), Br.ReadInt32());
                   CurPosition = Position;
                   ClientsLogs.SetAdress(Temp);
                   return true;
                }
                Position += 100;
                FileStream.Seek(Position, SeekOrigin.Begin);
            }
            return false;
        }
        public static bool Transfer(string RecieverEmail,int Amount)
        {
            long Temp = FileStream.Position;
            int Position = 100 * HashFunction(RecieverEmail);
            FileStream.Seek(Position, SeekOrigin.Begin);
            while (Br.PeekChar() == 'T')
            {
                Br.ReadChar();
                if (Br.ReadString().ToLower() == RecieverEmail)
                {
                    Br.ReadString(); Br.ReadString(); Br.ReadString(); Br.ReadString();
                    Br.ReadString(); Br.ReadString(); Br.ReadString();
                    int RecieverAmount = Br.ReadInt32();
                    RecieverAmount += Amount;
                    Bw.Seek(-4, SeekOrigin.Current);
                    Bw.Write(RecieverAmount);
                    FileStream.Position = Position;
                    return true;
                }
                Position += 100;
                FileStream.Seek(Position, SeekOrigin.Begin);
            }
            FileStream.Position = Position;
            return false;
        }
        public static void UpdateAccount()
        {
            Bw.Seek(-4, SeekOrigin.Current);
            Bw.Write(Cur.Am);
            Bw.Flush();
        }
        public static void DeleteAccount()
        {
            Bw.Seek(CurPosition, SeekOrigin.Begin);
            Bw.Write('F');
        }
        public static bool CloseStreams()
        {
            try
            {
                Br.Close();
                Bw.Close();
                FileStream.Close();
                return true;
            }
            catch 
            {
                return false;
            }
        }
        private static int HashFunction(string Key)
        {
            long Postion = 0;
            long Power = 1;
            for (int i = 0; i < Key.Length; ++i)
            {
                Postion += Key[i] * Power;
                Power *= 2;
            }
            Postion %= 997;
            return (int)Postion;
        }
        public static Client Current { get { return Cur; } }
    }
}