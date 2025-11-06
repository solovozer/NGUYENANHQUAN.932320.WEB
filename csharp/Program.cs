using System;

namespace csharp
{
    public class Fingerprint
    {
        public List<Double> features;

        public Fingerprint(List<Double> features)
        {
            this.features = features;
        }
    }

    public class User
    {
        private string userID;
        private string name;
        private string role;
        private Fingerprint userfp;
       
        User(string userID, string name, string role, Fingerprint userfp)
        {
            this.userID = userID;
            this.name = name;
            this.role = role;
            this.userfp = userfp;
        }  
        public Fingerprint GetFingerprint() { return  this.userfp; }
    }

    public class Database
    {
        public List<User> users;
        static readonly Double THRESH_HOLD = 0.99;
        public Database(List<User> users) { this.users = users; }

        public Double CompareFingerprints(Fingerprint fp1, Fingerprint fp2)
        {
            Double res = 0;
            for (int i = 0; i < Math.Max(fp1.features.Count(), fp2.features.Count()); i++)
            {
                Double num1 = 0, num2 = 0;
                if (i < fp1.features.Count()) num1 = fp1.features[i];
                if (i < fp2.features.Count()) num2 = fp2.features[i];
                res += Math.Pow((num1 - num2), 2);
            }
            return res;
        }
        public bool Search(Fingerprint fp)
        {
            foreach (User user in users)
            {
                Fingerprint userfp = user.GetFingerprint();
                Double evaluation = CompareFingerprints(userfp, fp);
                if (evaluation >= THRESH_HOLD) return true;
            }
            return false;
        }
    }

    public class FingerprintMachine
    {
        public bool isTouched = false;
        public void CheckTouched() { 
            if (true) isTouched = true; 
            else isTouched = false}
        public Fingerprint GetFingerprint() { return new Fingerprint(new List<Double>()); }
        public void OpenDoor(bool valid) { }
    }

    public class Security
    {
        public required List<FingerprintMachine> entrances;

        public void ForceOpenDoor(FingerprintMachine fm)
        {
            fm.OpenDoor(true);
        }
    }

    public class FingerController
    {
        Database db;
        FingerprintMachine fm;
        
        FingerController(Database db, FingerprintMachine fm)
        {
            this.db = db;
            this.fm = fm;
        }
        
        void Proceed()
        {
            while(!fm.isTouched)
            {
                if (fm.isTouched)
                {
                    Fingerprint receivedfp = fm.GetFingerprint();
                    if (receivedfp != null)
                    {
                        bool found = db.Search(receivedfp);
                        if (found) fm.OpenDoor(true);
                        else fm.OpenDoor(false);
                    }
                }
                fm.isTouched = false;
            }
        }
    }
}
