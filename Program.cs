namespace ProductReviewManagement
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome");
            
            bool end = true;
            while (end)
            {
                Console.WriteLine("\n1. Retrive Top Three Records \n2. Retrive Record Based On Rating \n3. Skip Five Records \n4. Retrive Count Of Records \n5.Ge tProductId And Review From The Record \n6. Create Database \n7. Get Records From List Using Data Field \n8. Get Average Ratings \n9. Retrieve All Nice Reviews");
                Console.WriteLine("\nEnter your choice");
                int option = Convert.ToInt16(Console.ReadLine());
                switch (option)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        ProductHandler.TopRecords();
                        break;
                    case 2:
                        ProductHandler.GetRecordBasedOnRating();
                        break;
                    case 3:
                        ProductHandler.SkipRecords();
                        break;
                    case 4:
                        ProductHandler.GetCountOfRecords();
                        break;
                    case 5:
                        ProductHandler.GetProductIdAndReviewFromTheRecord();
                        break;
                    case 6:
                        ProductHandler.CreateDatabase();
                        break;
                    case 7:
                        ProductHandler.GetRecordsFromListUsingDataField();
                        break;
                    case 8:
                        ProductHandler.GetAverageRatings();
                        break;
                    case 9:
                        ProductHandler.RetrieveAllNiceReviews();
                        break;
                    case 10:
                        ProductHandler.RetrieveAllProductReviews_ByUserIDAndOrderByRating();
                        break;

                }
            }
        }
    }
}