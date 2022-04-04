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

		private const long IDENTITY_NUMBER = 10000000000;

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

			/**
			 * Kurs oluşturma sihirbazı
			 *
			 */
			if (selectedCourseIndex == -1) {

				Application.WriteLine("Kurs oluşturma sihirbazına hoşgeldiniz\nLütfen kurs adını giriniz:", true);
				string? courseName = Console.ReadLine();

				if (string.IsNullOrEmpty(courseName)) {
					Application.WriteLine("Girilen kurs ismi boş olamaz. (Örnek isim: {0}", true, Courses.ElementAt(0).Name);
					Thread.Sleep(1500);

					return Run();
				}

				Application.WriteLine("{0} adlı kursun vizelerinin yüzde ne kadar etkili olacağını giriniz (Varsayılan değer {1}):", true, courseName, Course.MIDTERM_RATIO);
				string? courseMidtermRatio = Console.ReadLine();

				if (string.IsNullOrEmpty(courseMidtermRatio))
					courseMidtermRatio = Course.MIDTERM_RATIO.ToString();

				if (!Int32.TryParse(courseMidtermRatio, out int numberValue)) { // numberValue değerinin atamasını yaptım, aynı zamanda TryParse ile string'in sayı değerlerini kontrol ettim.
					Application.WriteLine("{0} adlı kursun vizeler için girdiğiniz değer sadece sayı içermelidir", true, courseName);
					Thread.Sleep(1500);

					return Run();
				}

				Application.WriteLine("{0} adlı kursun final sınavının yüzde ne kadar etkili olacağını giriniz (Varsayılan değer {1}):", true, courseName, Course.FINAL_RATIO);
				string? courseFinalRatio = Console.ReadLine();

				if (string.IsNullOrEmpty(courseFinalRatio))
					courseFinalRatio = Course.FINAL_RATIO.ToString();

				if (!Int32.TryParse(courseFinalRatio, out numberValue)) { // int numberValue değeri zaten atandığı için direk kullandım.
					Application.WriteLine("{0} adlı kursun finaller için girdiğiniz değer sadece sayı içermelidir", true, courseName);
					Thread.Sleep(1500);

					return Run();
				}

				Courses.Add(new Course(
						courseName,
						Convert.ToInt32(courseMidtermRatio),
						Convert.ToInt32(courseFinalRatio)
					)	
				);

				Application.WriteLine("{0} adlı kurs başarıyla eklendi", true, courseName);

				return Run();
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
					Thread.Sleep(1500);

					return Run();
				}

				Application.WriteLine("{0} adlı öğrencinin yaşını giriniz (Varsayılan değer {1}):", true, studentName, Student.STUDENT_AGE);
				string? studentAge = Console.ReadLine();

				if (string.IsNullOrEmpty(studentAge))
					studentAge = Student.STUDENT_AGE.ToString();

				if (!Int32.TryParse(studentAge, out int numberValue)) {
					Application.WriteLine("{0} adlı öğrencinin yaşı için girdiğiniz değer sadece sayı içermelidir.", true, studentName);
					Thread.Sleep(1500);

					return Run();
                }

				Application.WriteLine("{0} adlı öğrencinin kimlik numarasını giriniz (Varsayılan değer {1}):", true, studentName, IDENTITY_NUMBER);
				string? studentIdentityNumber = Console.ReadLine();

				if (string.IsNullOrEmpty(studentIdentityNumber))
					studentIdentityNumber = IDENTITY_NUMBER.ToString();

				if (!Int64.TryParse(studentIdentityNumber, out long longValue)) {
					Application.WriteLine("{0} adlı öğrencinin kimlik numarası sadece sayı içermelidir.", true, studentIdentityNumber);
					Thread.Sleep(1500);

					return Run();
                }

				Students.Add(new Student(studentName, Convert.ToInt32(studentAge), Convert.ToInt64(studentIdentityNumber)));

				Application.WriteLine("{0} adlı öğrenci başarıyla eklendi", true, studentName);

				selectedStudentIndex = Students.ToArray().Length - 1;

				Thread.Sleep(1000);

				Application.WriteLine("", true);

				return Run();
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

