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

		public static void Run()
        {
			Console.WriteLine("Ortalama kurs puanı hesaplama programına hoşgeldiniz.");
			Console.WriteLine("Lütfen alttaki kurslardan puanını hesaplamak istediğiniz kursu seçiniz:\nYeni bir kurs oluşturmak isterseniz -1 yazabilirsiniz.");

			for (int i = 0; i < Courses.ToArray().Length; i++) {
				Console.WriteLine("{0}: {1}", i, Courses.ElementAt(i).Name);
			}

			int selectedCourseIndex = Input.ReadOptions(Courses, true);

			Console.Clear();

			if (selectedCourseIndex == -1) {

				Console.WriteLine("Kurs oluşturma sihirbazına hoşgeldiniz\nLütfen kurs adını giriniz:");
				string? courseName = Console.ReadLine();

				if (string.IsNullOrEmpty(courseName)) {
					Console.Clear();
					Console.WriteLine("Girilen kurs ismi boş olamaz. (Örnek isim: C# Uygulamaları)");
					return;
				}

				Console.Clear();

				Console.WriteLine("{0} adlı kursun vizelerinin yüzde ne kadar etkili olacağını giriniz (Varsayılan değer 20):", courseName);
				int courseMidtermRatio = Convert.ToInt32(Console.ReadLine());

				Console.Clear();

				Console.WriteLine("{0} adlı kursun final sınavının yüzde ne kadar etkili olacağını giriniz (Varsayılan değer 60):", courseName);
				int courseFinalRatio = Convert.ToInt32(Console.ReadLine());

				Console.Clear();

				Courses.Add(new Course(courseName, courseMidtermRatio, courseFinalRatio));
				Console.WriteLine("{0} adlı kurs başarıyla eklendi", courseName);

				selectedCourseIndex = Courses.ToArray().Length - 1;

				Console.Clear();
			}

			Course selectedCourse = Courses.ElementAt(selectedCourseIndex);

			List<dynamic> students = new List<dynamic>() {
				new Student("Enes", 22, 63673031350),
				new Student("Emin", 21, 48561842566)
			};

			Console.WriteLine("{0} kursu için lütfen alttaki öğrencilerden birini seçiniz:\nYeni bir öğrenci oluşturmak istiyorsanız -1 yazabilirsiniz.", selectedCourse.Name);

			for (int i = 0; i < students.ToArray().Length; i++) {
				Console.WriteLine("{0}: {1}", i, students.ElementAt(i).Name);
			}

			int selectedStudentIndex = Input.ReadOptions(students, true);

			Console.Clear();

			if (selectedStudentIndex == -1) {

				Console.WriteLine("Öğrenci oluşturma sihirbazına hoşgeldiniz\nLütfen yeni öğrenci adını giriniz:");
				string? studentName = Console.ReadLine();

				if (string.IsNullOrEmpty(studentName)) {
					Console.Clear();
					Console.WriteLine("Girilen öğrenci ismi boş olamaz. (Örnek isim: Enes Bayraktar)");
					return;
				}

				Console.Clear();

				Console.WriteLine("{0} adlı öğrencinin yaşını giriniz:", studentName);
				int studentAge = Convert.ToInt32(Console.ReadLine());

				Console.Clear();

				Console.WriteLine("{0} adlı öğrencinin kimlik numarasını giriniz:", studentName);
				long studentIdentityNumber = Convert.ToInt64(Console.ReadLine());

				Console.Clear();

				students.Add(new Student(studentName, studentAge, studentIdentityNumber));
				Console.WriteLine("{0} adlı öğrenci başarıyla eklendi", studentName);

				selectedStudentIndex = students.ToArray().Length - 1;

				Console.Clear();
			}

			Student selectedStudent = students.ElementAt(selectedStudentIndex);
		}
	}
}

