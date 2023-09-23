namespace LibraryA
{
    public class Book
    {
        public String Title= String.Empty;
        public String Author= String.Empty;
        public String  Genre= String.Empty;
        public DateTime DateOfPublish;
        public int BooKPrice;
        public int TotalPages;
        public void OpenBook()//method
        {
            Console.WriteLine(  "book obj is created");
        }
        public void BookMarkPage(int pageno)//method with parameters
        {
            Console.WriteLine(  $"pageno: {pageno}book marked");

        }
        public int GetcurrentPage()
        {
            Random r = new Random();
            return r.Next(TotalPages);
        }

    }
}