namespace lab13.Pages.Models
{
    public class QuizQuestion
    {
        private static int ID_count = 1;
        public int ID { get; set; }
        public int Num1 {  get; set; }
        public int Num2 {  get; set; }
        public int Opcode {  get; set; }

        public int RightAnswer { get; set; }
        public QuizQuestion() { }
        public QuizQuestion(Random r)
        {
            ID = ID_count;
            ID_count++;
            Num1 = r.Next(0, 10);
            Num2 = r.Next(0, 10);
            if (Num2 == 0) Opcode = r.Next(1, 4);
            else Opcode = r.Next(1, 5);
            RightAnswer = Calculate();
        }

        public char ToChar()
        {
            return Opcode switch
            {
                0 => '_',
                1 => '+',
                2 => '-',
                3 => '*',
                _ => '/'
            };
        }

        private int Calculate()
        {
            return Opcode switch
            {
                1 => Num1 + Num2,
                2 => Num1 - Num2,
                3 => Num1 * Num2,
                4 => Num1 / Num2,
                _ => 0 
            };
        }
    }
}
