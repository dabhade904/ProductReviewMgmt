namespace ProductReviewManagement
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome");
            List<ProductReview> productList = new List<ProductReview>();
            ProductHandler productHandler = new ProductHandler();
            productList.Add(new ProductReview(1, 1, 5, "good", false));
            productList.Add(new ProductReview(2, 2, 2, "good", false));
            productList.Add(new ProductReview(3, 4, 3, "good", true));
            productList.Add(new ProductReview(4, 5, 1, "bad", false));
            productList.Add(new ProductReview(6, 1, 3.5, "good", true));
            productList.Add(new ProductReview(2, 4, 3, "good", true));
            productList.Add(new ProductReview(7, 7, 4.5, "good", true));
            productList.Add(new ProductReview(1, 4, 4, "good", true));
            productList.Add(new ProductReview(9, 8, 3, "good", true));
            productList.Add(new ProductReview(7, 3, 1, "bad", false));
            productList.Add(new ProductReview(11, 1, 5, "good", true));
            productList.Add(new ProductReview(3, 10, 3, "good", false));

            /*Console.WriteLine("Top record");
            productHandler.TopRecords(productList);
            Console.WriteLine("Selected records");
            productHandler.GetRecordBasedOnRating(productList);
            Console.WriteLine("Skiped Records");
            productHandler.SkipRecords(productList);*/
            productHandler.GetCount(productList);
        }
    }
}