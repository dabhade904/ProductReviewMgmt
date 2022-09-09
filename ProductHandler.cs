using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReviewManagement
{
    public static class ProductHandler
    {
        public static List<ProductReview> productList = new List<ProductReview>();
        public static DataTable dataTable = new DataTable();
        public static List<ProductReview> ListOfRecords()
        {
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
            return productList;
        }
        public static void TopRecords()
        {
            var topRecords = (from ProductReview in ListOfRecords()
                              orderby ProductReview.Ratings descending
                              select ProductReview
                            ).Take(3);
            foreach (ProductReview review in topRecords)
            {
                Console.WriteLine("Product: {0},{1},{2},{3},{4}", review.ProductID, review.UserID, review.Ratings, review.Review, review.IsLike);
            }
        }
        public static void GetRecordBasedOnRating()
        {
            var selectedRecords = from ProductReview in ListOfRecords()
                                  where (ProductReview.ProductID == 1 && ProductReview.Ratings > 3) ||
                                    (ProductReview.ProductID == 4 && ProductReview.Ratings > 3) ||
                                    (ProductReview.ProductID == 9 && ProductReview.Ratings > 3)
                                  select ProductReview;
            foreach (ProductReview records in selectedRecords)
            {
                Console.WriteLine("Product: {0},{1},{2},{3},{4}", records.ProductID, records.UserID, records.Ratings, records.Review, records.IsLike);
            }
        }
        public static void GetCountOfRecords()
        {
            var recordData = ListOfRecords()
                .GroupBy(user => user.ProductID).
                Select(user => new { ProductID = user.Key, Count = user.Count() });
            foreach (var reocrdCount in recordData)
            {
                Console.WriteLine(reocrdCount.ProductID + " ------- " + recordData.Count());
            }
        }
        public static void SkipRecords()
        {
            var skipRecord = ListOfRecords().Skip(5).ToList();
            foreach (ProductReview records in skipRecord)
            {
                Console.WriteLine("Product: {0},{1},{2},{3},{4}", records.ProductID, records.UserID, records.Ratings, records.Review, records.IsLike);
            }
        }
        public static void GetProductIdAndReviewFromTheRecord()
        {
            var simpleUsers = ListOfRecords().Select(user => new
            {
                ProductId = user.ProductID,
                Review = user.Review
            });
            foreach (var user in simpleUsers)
            {
                Console.WriteLine(user.ProductId + "" + user.Review);
            }
        }
        public static string CreateDatabase()
        {
            dataTable.Columns.Add("ProductId");
            dataTable.Columns.Add("UserId");
            dataTable.Columns.Add("Rating");
            dataTable.Columns.Add("Review");
            dataTable.Columns.Add("IsLike");
            dataTable.Rows.Add(1, 111, 5, "bad", false);
            dataTable.Rows.Add(2, 112, 5, "best", true);
            dataTable.Rows.Add(3, 113, 4, "better", true);
            dataTable.Rows.Add(4, 114, 3, "Good", true);
            dataTable.Rows.Add(5, 115, 5, "best", true);
            dataTable.Rows.Add(6, 116, 4, "better", true);
            dataTable.Rows.Add(7, 117, 3, "Good", true);
            dataTable.Rows.Add(8, 118, 4, "Good", true);
            dataTable.Rows.Add(9, 119, 1, "worst", false);
            dataTable.Rows.Add(10, 120, 5, "best", true);
            dataTable.Rows.Add(11, 121, 4, "better", true);
            dataTable.Rows.Add(12, 122, 4, "better", true);
            dataTable.Rows.Add(13, 123, 2, "bad", false);
            dataTable.Rows.Add(14, 124, 1, "bad", false);
            dataTable.Rows.Add(15, 125, 5, "best", true);
            dataTable.Rows.Add(16, 126, 5, "best", true);
            dataTable.Rows.Add(17, 127, 4, "better", true);
            dataTable.Rows.Add(18, 128, 4, "Good", true);
            dataTable.Rows.Add(19, 129, 3, "Good", true);
            dataTable.Rows.Add(20, 130, 3, "Good", true);
            dataTable.Rows.Add(21, 131, 2, "better", true);
            dataTable.Rows.Add(22, 132, 5, "best", true);
            dataTable.Rows.Add(23, 133, 4, "better", true);
            dataTable.Rows.Add(24, 134, 3, "Good", true);
            dataTable.Rows.Add(25, 135, 2, "Good", true);

            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine("\n");
                Console.WriteLine($"{row["ProductId"]}\t|{row["UserId"]}\t|{row["Review"]}\t|{row["Rating"]}\t|{row["IsLike"]}");
            }
            return dataTable.ToString();
        }

        public static string GetRecordsFromListUsingDataField()
        {
            List<ProductReview> productList = new List<ProductReview>();
            CreateDatabase();
            string productsList = "";
            var result = from data in dataTable.AsEnumerable()
                         where data.Field<bool>("IsLike") == true
                         select data;
            foreach (var product in result)
            {
                Console.WriteLine("{0} | {1} | {2} | {3} | {4} ", product["ProductId"], product["UserId"], product["Rating"], product["Review"], product["IsLike"]);
                productsList += product["UserId"] + " ";
            }
            return productsList;
        }

        public static string GetAverageRatings()
        {
            string result = "";
            var res = from product in dataTable.AsEnumerable() group product by product.Field<int>("ProductId") into temp select new { ProductId = temp.Key, Average = Math.Round(temp.Average(x => x.Field<int>("Rating")), 1) };
            foreach (var ratings in res)
            {
                Console.WriteLine("Product id: {0} Average Rating: {1}", ratings.ProductId, ratings.Average);
                result += ratings.Average + " ";
            }     
            return result;
        }

        public static string RetrieveAllNiceReviews()
        {
            CreateDatabase();
            List<ProductReview> ProductReviewsList = new List<ProductReview>();

            string productsList = "";
            var res = from product in dataTable.AsEnumerable() where product.Field<string>("Review") == "nice" select product;
            foreach (var data in res)
            {
                Console.WriteLine("{0} | {1} | {2} | {3} | {4} ", data["ProductId"], data["UserId"], data["Rating"], data["Review"], data["IsLike"]);
                productsList += data["UserId"] + " ";
            }
            return productsList;
        }
    } 
}
