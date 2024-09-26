namespace EnterTheConsole
{
    internal class Utility
    {
        //싱글톤화 시켜놨습니다, 필드에 Utility 이름 = Utility.Instance 으로 이름 지정해서 쓰면 됩니다.
        //Utility.Instance.Selecter 으로 호출이 가능하지만 이름을 지어주면 이름.Selector 형태로 호출 가능합니다.
        #region singleton
        private static Utility instnace = null;
        public static Utility Instance
        {
            get
            {
                if(instnace == null)
                {
                    instnace = new Utility();
                }
                return instnace;
            }
            
        }
        private Utility() { }
        #endregion
        /// <summary>
        /// Console.RealLine() 입력을 정수형 int 로 변환, 변환에 실패하거나 선택지를 넘은 값 입력시 -1 반환
        /// input 콘솔입력내용, numberOfOption 선택지 갯수
        /// </summary>
        /// <param name="input"></param>
        /// <param name="numberOfOption"></param>
        /// <returns></returns>
        public int Selecter(string input, int numberOfOption)
        {
            if(int.TryParse(input, out int returnInt))
            {
                //입력값 int형으로 반환
                if(returnInt >= 1 && returnInt <= numberOfOption)
                {
                    return returnInt;
                }
                else
                {
                    //잘못된 입력 띄운후, 1초간 대기
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(1000);
                    return -1;
                }
            }
            else
            {
                //잘못된 입력 띄운후, 1초간 대기
                Console.WriteLine("잘못된 입력입니다.");
                Thread.Sleep(1000);
                return -1;
            }
        }
    }
}
