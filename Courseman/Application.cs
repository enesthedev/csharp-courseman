using Courseman.Common.Classes;
using Courseman.Common.Helpers;

namespace Courseman
{
	public class Application
	{
		/**
		 * Uygulama sınıfı
		 * 
		 * Bu sınıfı tanımlama amacım tüm herşeyin Program.cs içerisinde olmasını istemememdi. Program.cs'i bir başlatıcı olarak düşünerek
		 * static Run metoduna sahip olan bir uygulama sınıfı oluşturdum. Bu Run metodu içerisinde sınıf tanımlamalarını ve uygulamanın genel yapısını
		 * barındırıyor.
		 * 
		 * Aynı zamanda bu tanımlama sayesinde konsol aplikasyonlarında yaşanan hatalı girdilerde uygulamayı dinamik şekilde yeniden başlatabiliyorum.
		 * Yeniden başlatma yanlış algılanmasın. Aynı process içerisinde tekrardan tanımlamaları yapıyorum.
		 */

		static List<dynamic> Courses = new List<dynamic> {
			new Course("Java Programlama"),
			new Course("C# Programlama")
		};

		static List<dynamic> Students = new List<dynamic>() {
				new Student("Enes", 22, 63673031350),
				new Student("Emin", 21, 48561842566)
		};

		public static int Run()
        {
			Application.WriteLine("Ortalama kurs puanı hesaplama programına hoşgeldiniz.", true);
			Application.WriteLine("Lütfen alttaki kurslardan puanını hesaplamak istediğiniz kursu seçiniz:\nYeni bir kurs oluşturmak isterseniz -1 yazabilirsiniz.");

			for (int i = 0; i < Courses.ToArray().Length; i++) {
				Application.WriteLine("{0}: {1}", false, i, Courses.ElementAt(i).Name);
			}

			int selectedCourseIndex = Input.ReadOptions(Courses, true);

			if (selectedCourseIndex == -1) {

				Application.WriteLine("Kurs oluşturma sihirbazına hoşgeldiniz\nLütfen kurs adını giriniz:", true);
				string? courseName = Console.ReadLine();

				if (string.IsNullOrEmpty(courseName)) {
					Application.WriteLine("Girilen kurs ismi boş olamaz. (Örnek isim: C# Uygulamaları)", true);
					Thread.Sleep(1500);

					return Run();
				}

				Application.WriteLine("{0} adlı kursun vizelerinin yüzde ne kadar etkili olacağını giriniz (Varsayılan değer 20):", true, courseName);
				int courseMidtermRatio = Convert.ToInt32(Console.ReadLine());

				Application.WriteLine("{0} adlı kursun final sınavının yüzde ne kadar etkili olacağını giriniz (Varsayılan değer 60):", true, courseName);
				int courseFinalRatio = Convert.ToInt32(Console.ReadLine());

				Courses.Add(new Course(courseName, courseMidtermRatio, courseFinalRatio));
				Application.WriteLine("{0} adlı kurs başarıyla eklendi", true, courseName);

				selectedCourseIndex = Courses.ToArray().Length - 1;
			}

			Course selectedCourse = Courses.ElementAt(selectedCourseIndex);

			Application.WriteLine("{0} kursu için lütfen alttaki öğrencilerden birini seçiniz:\nYeni bir öğrenci oluşturmak istiyorsanız -1 yazabilirsiniz.", true, selectedCourse.Name);

			for (int i = 0; i < Students.ToArray().Length; i++) {
				Application.WriteLine("{0}: {1}", false, i, Students.ElementAt(i).Name);
			}

			int selectedStudentIndex = Input.ReadOptions(Students, true);

			if (selectedStudentIndex == -1) {

				Application.WriteLine("Öğrenci oluşturma sihirbazına hoşgeldiniz\nLütfen yeni öğrenci adını giriniz:", true);
				string? studentName = Console.ReadLine();

				if (string.IsNullOrEmpty(studentName)) {
					Application.WriteLine("Girilen öğrenci ismi boş olamaz. (Örnek isim: Enes Bayraktar)", true);
					return Run();
				}

				Application.WriteLine("{0} adlı öğrencinin yaşını giriniz:", true, studentName);
				int studentAge = Convert.ToInt32(Console.ReadLine());

				Application.WriteLine("{0} adlı öğrencinin kimlik numarasını giriniz:", false, studentName);
				long studentIdentityNumber = Convert.ToInt64(Console.ReadLine());


				Students.Add(new Student(studentName, studentAge, studentIdentityNumber));
				Application.WriteLine("{0} adlı öğrenci başarıyla eklendi", true, studentName);

				selectedStudentIndex = Students.ToArray().Length - 1;

				Application.WriteLine(null, true);
			}

			Student selectedStudent = Students.ElementAt(selectedStudentIndex);

			return 1;
		}

		public static void WriteLine(string message, bool clear = false, params dynamic[] entitys)
        {
			if (clear)
				Console.Clear();

			if (!string.IsNullOrEmpty(message))
				Console.WriteLine(message, entitys);
        }
	}
}

