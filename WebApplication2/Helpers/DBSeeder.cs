using Microsoft.AspNetCore.DataProtection.XmlEncryption;
using Microsoft.EntityFrameworkCore;
using System;
using WebApplication2.Context;
using WebApplication2.Models;

namespace WebApplication2.Helpers
{
    public class DBSeeder
    {
        public static void Initialize(IConfiguration configuration)
        {



            using (var context = new ReservadoContext(configuration))
            {
                if (!context.Users.Any())
                {
                    context.Users.AddRange(
                       new User { id = 1, Name = "Fatih", Surname = "Vural", Email = "fv@q.com", Phone = "111", Password = "1234", isActive = true, Roles = "Admin,Root" },
                       new User { id = 2, Name = "Abdurrahman", Surname = "Çolakoğlu", Email = "ac@q.com", Phone = "111", Password = "1234", isActive = true, Roles = "User" },
                       new User { id = 3, Name = "Yunus", Surname = "Vural", Email = "yv@q.com", Phone = "111", Password = "1234", isActive = true, Roles = "BusinesUser" });

                    context.SaveChanges();
                }

                if (!context.Photos.Any())
                {
                    //context.Photos.AddRange(
                    //    new Photo { name="image" , path = "images/res.jpg"},
                    //    new Photo { name="image" , path = "images/res2.jpg"},
                    //    new Photo { name="image" , path = "images/res3.jpg"},
                    //    new Photo { name="image" , path = "images/res4.jpg"},
                    //    new Photo { name="image" , path = "images/res5.jpg"},
                    //    new Photo { name="image" , path = "images/res6.jpg"},
                    //    new Photo { name="image" , path = "images/rest.png"},
                    //    new Photo { name="image" , path = "images/rest1.png"},
                    //    new Photo { name="image" , path = "images/rest2.png"}


                    //    );



                }

                if (!context.Categories.Any())
                {
                    //context.Categories.AddRange(
                    //    new Category { description = "Sultanahmet", name = "Neighborhood" ,imageUrl="url"},
                    //    new Category { description = "Cuisines", name = "International, European, Turkish", imageUrl = "url" },
                    //    new Category { description = "Dining style", name = "Casual Dining", imageUrl = "url" },
                    //    new Category { description = "Dress code", name = "Business Casual", imageUrl = "url" },
                    //    new Category { description = "Parking details", name = "None", imageUrl = "url" }
                    //    );
                    //context.SaveChanges();

                }


                if (!context.Businesses.Any())
                {

                    var FaqMado = new List<Faq>() { new Faq { header = "Test", content = "TEST CONTENT" }, new Faq { header = "TEst2", content = "TEST CONTENT 2" } };
                    var FaqMado2 = new List<Faq>() { new Faq { header = "Test3", content = "TEST CONTENT3" }, new Faq { header = "TEst3", content = "TEST CONTENT 3" } };
                    var FaqMado3 = new List<Faq>() { new Faq { header = "Test4", content = "TEST CONTENT4" }, new Faq { header = "TEst5", content = "TEST CONTENT 5" } };
                    var FaqMado4 = new List<Faq>() { new Faq { header = "Test6", content = "TEST CONTENT6" }, new Faq { header = "TEst7", content = "TEST CONTENT 7" } };

                    var cat = new List<Category>(){new Category { description = "Sultanahmet", name = "Neighborhood", imageUrl = "url" },
                        new Category { description = "Cuisines", name = "International, European, Turkish", imageUrl = "url" },
                        new Category { description = "Dining style", name = "Casual Dining", imageUrl = "url" },
                        new Category { description = "Dress code", name = "Business Casual", imageUrl = "url" },
                        new Category { description = "Parking details", name = "None", imageUrl = "url" } };
                    var cat2 = new List<Category>(){new Category { description = "Sultanahmet", name = "Neighborhood", imageUrl = "url" },
                        new Category { description = "Cuisines", name = "International, European, Turkish", imageUrl = "url" },
                        new Category { description = "Dining style", name = "Casual Dining", imageUrl = "url" },
                        new Category { description = "Dress code", name = "Business Casual", imageUrl = "url" },
                        new Category { description = "Parking details", name = "None", imageUrl = "url" } };

                    var cat3 = new List<Category>(){new Category { description = "Sultanahmet", name = "Neighborhood", imageUrl = "url" },
                        new Category { description = "Cuisines", name = "International, European, Turkish", imageUrl = "url" },
                        new Category { description = "Dining style", name = "Casual Dining", imageUrl = "url" },
                        new Category { description = "Dress code", name = "Business Casual", imageUrl = "url" },
                        new Category { description = "Parking details", name = "None", imageUrl = "url" } };

                    var cat4 = new List<Category>(){new Category { description = "Sultanahmet", name = "Neighborhood", imageUrl = "url" },
                        new Category { description = "Cuisines", name = "International, European, Turkish", imageUrl = "url" },
                        new Category { description = "Dining style", name = "Casual Dining", imageUrl = "url" },
                        new Category { description = "Dress code", name = "Business Casual", imageUrl = "url" },
                        new Category { description = "Parking details", name = "None", imageUrl = "url" } };



                    var Categories = context.Categories.ToList();
                    var photos = context.Photos.ToList();
                    var rand = new Random();

                    var images = new List<Photo>()  {new Photo { name = "image", path = "images/res.jpg" },
                        new Photo { name = "image", path = "images/res2.png" },
                        new Photo { name = "image", path = "images/res3.jpeg" },
                        new Photo { name = "image", path = "images/res4.jpeg" },
                        new Photo { name = "image", path = "images/res5.jpeg" },
                        new Photo { name = "image", path = "images/res6.jpeg" },
                        new Photo { name = "image", path = "images/rest.png" },
                        new Photo { name = "image", path = "images/rest1.png" },
                        new Photo { name = "image", path = "images/rest2.jpg" }};




                    context.Businesses.AddRange(
                        new Business
                        {
                            District = "Beyoğlu",
                            PriceRating = 3,
                            Photos = new List<Photo>()  {new Photo { name = "image", path = "images/res.jpg" },
                        new Photo { name = "image", path = "images/res2.png" }},
                            Name = "MADO",
                            isActive = true,
                            Address = "Şehit Muhtar, Mahallesi, İstiklal Cd. no 38, 34430 Beyoğlu/İstanbul",
                            Capacity = 110,
                            Mail = "mado@mado.com",
                            Faqs = FaqMado,
                            Categories = cat,
                            Menu = "At present, we do not have menu information for this restaurant. Please see their website or wait to visit the restaurant to learn more.",
                            Description = "Haliç, Topkapı Sarayı, Ayasofya, Galata Kulesi. İstanbul'un en güzelleri, Golden City Hotel'in terasında ayaklarınızın altına serildi. Türk ve Dünya mutfağının seçkin örneklerini sizlerle buluşturan Peninsula Restaurant, en güzel sofraları nefes kesici",
                            rating = 5,
                            RegisterDate = DateTime.Now,
                            Type = BusinesType.Bar,
                            Latitude = 41.03593053736981,
                            Longitude = 28.981391411647547,
                        },
                         new Business
                         {
                             District = "Kadıköy",
                             PriceRating = 1,
                             Photos = new List<Photo>()  {new Photo { name = "image", path = "images/res3.jpeg" },
                        new Photo { name = "image", path = "images/res4.jpeg" }},
                             Name = "Asuman",
                             isActive = true,
                             Address = "Caferağa Mah, Şair Nefi Sk. No:9/a, 34710 Kadıköy/İstanbul",
                             Capacity = 110,
                             Mail = "Asuman@Asuman.com",
                             Faqs = FaqMado2,
                             Categories = cat2,
                             Menu = "At present, we do not have menu information for this restaurant. Please see their website or wait to visit the restaurant to learn more.",
                             Description = "Asuman, yaptığı özenli, özgün ve özel dokunuşlarla, geçmişten gelen yaşatmak istediğimiz değerleri, mutfağımızdaki tatları, annelerimizin teyzelerimizin tatlılarını, hatta isimlerini, coğrafyamızda yetişen ve değeri bilinmeyen ürünleri, kısacası tüm güzel değerlerimizi yaşatmak için var. Bunun için her bir tatlımızda kullanılan hammaddeleri kendine has bölgesinden, direkt üreticisinden temin ediyoruz. Tıpkı evde annelerimizin yaptığı saflıkta olsun diye tatlılarımızı günlük üretiyor ve hiçbir koruyucu, renklendirici, katkı maddesi ilave etmiyoruz. Aşina olduğumuz geleneksel tatları, deneyimlerimizle yeniden yorumlayarak eski usulün başına yeni icat çıkarıyoruz. Tezgahımızda yer alacak her yeni tatlıyı, isimleri bizlerle birlikte hep yaşasın diye annelerimizin, teyzelerimizin adlarıyla taçlandırıyoruz.",
                             rating = 4,
                             RegisterDate = DateTime.Now,
                             Type = BusinesType.Cafe,
                             Latitude = 41.03593053736981,
                             Longitude = 28.981391411647547,
                         },
                          new Business
                          {
                              District = "Beyoğlu",
                              PriceRating = 2,
                              Photos = new List<Photo>()  {new Photo { name = "image", path = "images/res5.jpeg" },
                        new Photo { name = "image", path = "images/res6.jpeg" }},
                              Name = "Caribou Coffee",
                              isActive = true,
                              Address = "Şahkulu, Galip Dede Cd. No:19, 34437 Beyoğlu/İstanbul",
                              Capacity = 110,
                              Mail = "Caribou@Caribou.com",
                              Faqs = FaqMado3,
                              Categories = cat3,
                              Menu = "At present, we do not have menu information for this restaurant. Please see their website or wait to visit the restaurant to learn more.",
                              Description = "Caribou Coffee, bir Amerikan kahve şirketi ve kahvehane zinciridir. Caribou Coffee, 1992 yılında Edina, Minnesota'da kuruldu. Mayıs 2015 itibarıyla, şirket dünya çapında 603 lokasyonda faaliyet gösteriyo",
                              rating = 2,
                              RegisterDate = DateTime.Now,
                              Type = BusinesType.Restaurant,
                              Latitude = 41.03593053736981,
                              Longitude = 28.981391411647547,
                          },
                           new Business
                           {
                               District = "Eyüp",
                               PriceRating = 4,
                               Photos = new List<Photo>()  {new Photo { name = "image", path = "images/res.jpg" },
                        new Photo { name = "image", path = "images/res2.png" }},
                               Name = "BigChefs",
                               isActive = true,
                               Address = "Yeşilpınar, Şht. Metin Kaya Sk. No:11, 34065 Eyüpsultan/İstanbul",
                               Capacity = 110,
                               Mail = "Caribou@Caribou.com",
                               Faqs = FaqMado4,
                               Categories = cat4,
                               Menu = "At present, we do not have menu information for this restaurant. Please see their website or wait to visit the restaurant to learn more.",
                               Description = "Her mevsim yeni bir başlangıç ve her yeni başlangıç yeni mutluluklar” inancıyla yola çıkan BigChefs, sunduğu menüsüyle ve her köşesinde aile sıcaklığı hissini duyacağınız konforlu dekorasyonu ile, sıcak buluşmalara ve keyifli zamanlara ev sahipliği yapıyor. Mevsimin taze ürünleriyle hazırlanan ve lezzet müdavimliği yaratan tatlarıyla BigChefs, sizleri bekliyor!",
                               rating = 3,
                               RegisterDate = DateTime.Now,
                               Type = BusinesType.Hotel,
                               Latitude = 41.03593053736981,
                               Longitude = 28.981391411647547,
                           }
                    );
                    context.SaveChanges();
                }
            }



        }
    }
}




