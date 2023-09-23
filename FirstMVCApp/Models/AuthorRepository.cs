using System.Text;
namespace FirstMVCApp.Models
{
    public class AuthorRepository
    {
        public static Dictionary<int, Author> GetAuthorDictionary()
        {
            String fName = @"c:\temp\author.csv";
            Dictionary<int, Author> list = new Dictionary<int, Author>();
            bool isFileAExits = System.IO.File.Exists(fName);
            if (isFileAExits)
            {
                using (StreamReader sr = new StreamReader(fName))
                {
                    string strAuthor = $"{sr.ReadLine()}";
                    String[] data = strAuthor.Split(',');
                    Author author = null;
                    if (data.Length == 5)
                    {
                        author = StringToAuthor(data, new Author());
                        list.Add(author.AuthorID, author);
                        while (!sr.EndOfStream)
                        {
                            strAuthor = $"{sr.ReadLine()}";
                            data = strAuthor.Split(",");
                            if (data.Length == 5)
                            {
                                author = StringToAuthor(data, new Author());
                                list.Add(author.AuthorID, author);
                            }
                        }
                    }
                }
            }
            return list;
        }
        private static Author StringToAuthor(String[] data, Author author)
        {
            author.AuthorID = int.Parse(data[0]);
            author.AuthorName = data[1];
            author.DateOfBirth = data[2];
            author.BookPublished = int.Parse(data[3]);
            author.RoyalityCompany = data[4];
            return author;
        }


        //        public static List <Author> GetAuthorList() { }
        public static Author FindAuthorByID(int id)
        {
            Dictionary<int, Author> list = AuthorRepository.GetAuthorDictionary();
            Author author = null;
            if (list != null)
            {
                author = list.FirstOrDefault(x => (x.Key == id)).Value;
            }
            return author;

        }
        public static void SaveToFile(Author pAuthor)
        {
            String fName = @"c:\temp\author.csv";
            string strAuthor = $"{pAuthor.AuthorID},{pAuthor.AuthorName},{pAuthor.DateOfBirth},{pAuthor.BookPublished},{pAuthor.RoyalityCompany}";
            using (StreamWriter sw = new StreamWriter(fName, true))
            {
                sw.WriteLine(strAuthor);
            }

        }
        public static void UpdateAuthorToFile(Author pAuthor)
        {
            String fName = @"c:\temp\author.csv";
            Dictionary<int, Author> list = AuthorRepository.GetAuthorDictionary();
            string strAuthor = String.Empty;
            using (StreamWriter sw = new StreamWriter(fName))
            {
                foreach (Author author in list.Values)
                {
                    if (author.AuthorID != pAuthor.AuthorID)
                    {
                        strAuthor = $"{author.AuthorID},{author.AuthorName},{author.DateOfBirth},{author.BookPublished},{author.RoyalityCompany}";
                    }
                    else
                    {
                        strAuthor = $"{pAuthor.AuthorID},{pAuthor.AuthorName},{pAuthor.DateOfBirth},{pAuthor.BookPublished},{pAuthor.RoyalityCompany}";
                    }

                    sw.WriteLine(strAuthor);
                }


            }
        }

            public static void RemoveAuthor(int id)
            {
                String fName = @"c:\temp\author.csv";
                Dictionary<int, Author> list = AuthorRepository.GetAuthorDictionary();
                StringBuilder sbAuthor = new StringBuilder(list.Count + 100);
                foreach (Author author in list.Values)
                {
                        if (author.AuthorID!=id)
                        {
                        sbAuthor.Append( $"{author.AuthorID},{author.AuthorName},{author.DateOfBirth},"+
                            $"{author.BookPublished},{author.RoyalityCompany} {Environment.NewLine}");
                        }
                        File.WriteAllText(fName, sbAuthor.ToString());
                }


                
                //public static void SaveAllAuthorsToFile(Dictionary<int, Author> pAuthorList)
            }
    }
}


