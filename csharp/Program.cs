namespace csharp
{
    public class Fingerprint
    {
        public List<double> Features { get; }

        public Fingerprint(List<double> features)
        {
            Features = features;
        }
    }
    public class User
    {
        static int ID_counter = 0;
        private string userID;
        private string name;
        private string role;
        private Fingerprint userfp;
        private bool isBanned = false;

        public string GetID() => userID;
        public string GetName() => name;
        public string GetRole() => role;
        public Fingerprint GetFp() => userfp;
        public bool IsBanned() => isBanned;
        public Fingerprint GetFingerprint() => userfp;

        public void SetBan(bool a)
        {
            isBanned = a;
        }

        public User(string name, string role, Fingerprint userfp)
        {
            this.userID = ID_counter.ToString();
            this.name = name;
            this.role = role;
            this.userfp = userfp;
            ID_counter++;
        }

        public User(User user)
        {
            this.userID = user.userID;
            this.name = user.name;
            this.role = user.role;
            this.userfp = user.userfp;
        }
    }

    public class Security : User
    {
        private List<FingerprintMachine> entrances;
        private LogsController logs;

        public Security(string name, string role, Fingerprint userfp, List<FingerprintMachine> entrances, LogsController logs)
            : base(name, role, userfp)
        {
            this.entrances = entrances;
            this.logs = logs;
        }

        public void ForceOpenDoor(FingerprintMachine fm)
        {
            if (entrances.Contains(fm))
            {
                Console.WriteLine($"Security {GetName()} is forcing door open...");
                fm.OpenDoor(true);
                logs.AddEntry(new LogEntry(DateTime.Now.ToString(), this, fm));
            }
            else
            {
                Console.WriteLine($"Security {GetName()} cannot open this entrance.");
            }
        }
    }

    public class Admin : User
    {
        FingerController fc;

        public Admin(string name, string role, Fingerprint userfp, FingerController fc)
                    : base(name, role, userfp)
        {
            this.fc = fc;
        }
        public string GetLog()
        {
            return fc.PrintLog(0);
        }
        public string GetNLatestLogEntries(int n)
        {
            return fc.PrintLog(n);
        }
        
        public Fingerprint CreateFingerprint(List<double> features)
        {
            return new Fingerprint(features);
        }

        public void CreateUser(string name, string role, Fingerprint userfp)
        {
            User temp = new User(name, role, userfp);
            fc.AddUser(temp);
        }

        public User GetUserInfo(String ID)
        {
            return fc.SearchUserByID(ID);
        }
        public void BanUser(User user)
        {
            user.SetBan(true);
        }
        public void UnbanUser(User user)
        {
            user.SetBan(false);
        }
    }

    public class Database
    {
        private List<User> users;
        private const double THRESH_HOLD = 0.99;

        public Database(List<User> users)
        {
            this.users = users;
        }

        public double CompareFingerprints(Fingerprint fp1, Fingerprint fp2)
        {
            double res = 0;
            int size = Math.Max(fp1.Features.Count, fp2.Features.Count);

            for (int i = 0; i < size; i++)
            {
                double num1 = i < fp1.Features.Count ? fp1.Features[i] : 0;
                double num2 = i < fp2.Features.Count ? fp2.Features[i] : 0;
                res += Math.Pow(num1 - num2, 2);
            }
            return 1.0 - (res / size);
        }

        public void AddUser(User user)
        {
            users.Add(user);
        }
        public User Search(Fingerprint fp)
        {
            foreach (User user in users)
            {
                double evaluation = CompareFingerprints(user.GetFingerprint(), fp);
                if (evaluation >= THRESH_HOLD)
                    return user;
            }
            return null;
        }

        public User SearchUserByID(String ID)
        {
            foreach (User user in users)
            {
                if (user.GetID() == ID) return user;
            }
            return null;
        }
    }

    public class FingerprintMachine
    {
        static int ID_counter = 0;
        private readonly string ID;

        private bool isTouched = false;
        public bool IsTouched() => isTouched;

        public string GetID() { return ID; }
        FingerprintMachine()
        {
            ID = ID_counter.ToString();
            ID_counter++;
        }
        private void Reset()
        {
            isTouched = false;
        }

        public Fingerprint GetFingerprint()
        {
            return new Fingerprint(new List<double> { 0.12, 0.45, 0.33, 0.91 });
        }

        public bool OpenDoor(bool valid)
        {
            if (valid)
            {
                Console.WriteLine("Door opened.");
                Reset();
                return true;
            }
            else
            {
                Console.WriteLine("Access denied.");
                return false;
            }
        }
    }

    public class LogEntry
    {
        private string dateTime;
        private User user;
        private FingerprintMachine entrance;

        public LogEntry(string dateTime, User user, FingerprintMachine entrance)
        {
            this.dateTime = dateTime;
            this.user = user;
            this.entrance = entrance;
        }

        public bool Valid()
        {
            return user != null && user.GetID() != null;
        }

        public string Print()
        {
            return $"DateTime: {dateTime} | User: {user.GetID()} | Name: {user.GetName()} | Entrance: {entrance.GetID()}\n";
        }
    }

    public class LogsController
    {
        private List<LogEntry> logEntries = new List<LogEntry>();

        public bool AddEntry(LogEntry entry)
        {
            if (entry.Valid())
            {
                logEntries.Add(entry);
                return true;
            }
            return false;
        }

        public string Print(int n)
        {
            if (n <= 0) return PrintAll();
            return string.Join("", logEntries.TakeLast(n).Select(e => e.Print()));
        }

        public string PrintAll()
        {
            return string.Join("", logEntries.Select(e => e.Print()));
        }
    }

    public class FingerController
    {
        private readonly Database db;
        private readonly List<FingerprintMachine> fms;
        private readonly LogsController logs;

        public FingerController(Database db, List<FingerprintMachine> fms, LogsController logs)
        {
            this.fms = fms;
            this.db = db;
            this.logs = logs;
        }

        public void Proceed()
        {
            foreach (FingerprintMachine fm in fms)
            {
                if (fm.IsTouched())
                {
                    Fingerprint receivedfp = fm.GetFingerprint();
                    if (receivedfp != null)
                    {
                        User user = db.Search(receivedfp);
                        bool valid = user != null && user.IsBanned() != false;
                        fm.OpenDoor(valid);
                        if (user != null) logs.AddEntry(new LogEntry(DateTime.Now.ToString(), user, fm));
                    }
                }
            }
        }

        public User SearchUserByID(String ID)
        {
            return db.SearchUserByID(ID);
        }

        public string PrintLog(int lines)
        {
            return logs.Print(lines);   
        }

        public void AddUser(User user)
        {
            db.AddUser(user);
        }
    }

    public class Program
    {
        public static void Main()
        {

        }
    }
}


