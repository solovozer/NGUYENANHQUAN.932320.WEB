namespace lab13.Models
{
    public class QuizQuestion
    {
        private int Id { get; set; }
        public int Num1 { get; private set; }
        public int Num2 { get; private set; }
        public int RightAnswer { get; private set; }
        public int OpCode { get; private set; }

        public QuizQuestion()
        {
            Random r = new Random();
            OpCode = r.Next(1, 4); 
            Num1 = r.Next(0, 10);
            Num2 = (OpCode == 4) ? r.Next(1, 10) : r.Next(0, 10);


            RightAnswer = OpCode switch
            {
                1 => Num1 + Num2,
                2 => Num1 - Num2,
                3 => Num1 * Num2,
                4 => Num1 / Num2,
                _ => 0
            };
        }
        public string ToSign()
        {
            return OpCode switch
            {
                1 => "+",
                2 => "-",
                3 => "*",
                4 => "/",
                _ => "?"
            };
        }
    }
}
