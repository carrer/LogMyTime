using System;

namespace LogMyTime.Model
{
    public class MainModel
    {
        private Engine engine = new Engine();
        private TimeBook book;
        private TimeCard current;
        private FileHandler fileHandler = new FileHandler();
        private bool isRunning = false;

        private FileHandler io = new FileHandler();

        public MainModel()
        {
            string fileName = DateTime.Now.ToString("yyyyMMdd") + ".xml";
            if (fileHandler.FileExists("",fileName))
                book = (TimeBook) Utils.Deserialize<TimeBook>(fileHandler.ReadFromFile("", fileName));
            else
                book = new TimeBook(DateTime.Now);
        }

        public void Load()
        {
        }

        public void PersistData()
        {
        }

        public void Start()
        {
            System.Diagnostics.Debug.WriteLine("Starting engine");
            engine.Start();
            NewTimeCard();
            isRunning = true;
        }

        public void Stop()
        {
            System.Diagnostics.Debug.WriteLine("Stopping engine");
            engine.Stop();
            CloseCurrentCard();
            isRunning = false;
        }

        public void NewTimeCard()
        {
            if (DateTime.Now.Minute == 0 && DateTime.Now.Hour == 0)
                book = new TimeBook();
            current = new TimeCard(DateTime.Now);
            engine.Reset();
        }

        public void CloseCurrentCard()
        {
            current.Strokes = engine.Strokes();
            current.Clicks = engine.Clicks();
        }

        public void Tick()
        {
            ProgramInfo active = Utils.GetActiveProcess();
            current.Add(active);
            book.Add(active);
        }

        public void WrapUpMinute()
        {
            CloseCurrentCard();
            if (Utils.IsActive())
            {
                book.Add(current);
                fileHandler.WriteToFile("", DateTime.Now.ToString("yyyyMMdd") + ".xml", Utils.Serialize(book));
            }
            NewTimeCard();
        }

        public string GetTotalTime()
        {
            return book.Duration;
        }

        public bool IsRunning()
        {
            return isRunning;
        }

    }
}
