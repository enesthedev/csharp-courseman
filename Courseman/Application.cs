using Courseman.Common.Classes;
using Courseman.Common.Helpers;

namespace Courseman
{
	public class Application
	{
		public static void Run()
        {
			Console.WriteLine("Ortalama kurs puanı hesaplama programına hoşgeldiniz.");
			Console.WriteLine("Lütfen alttaki kurslardan puanını hesaplamak istediğiniz kursu seçiniz:\nYeni bir kurs oluşturmak isterseniz -1 yazabilirsiniz.");

			List<dynamic> courses = new List<dynamic>() {
				new Course("Java Programlama"),
				new Course("C# Programlama")
			};

			for (int i = 0; i < courses.ToArray().Length; i++) {
				Console.WriteLine("{0}: {1}", i, courses.ElementAt(i).Name);
			}

			int selectedCourseIndex = Input.ReadOptions(courses, true);

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

				courses.Add(new Course(courseName, courseMidtermRatio, courseFinalRatio));
				Console.WriteLine("{0} adlı kurs başarıyla eklendi", courseName);

				selectedCourseIndex = courses.ToArray().Length - 1;

				Console.Clear();
			}

			Course selectedCourse = courses.ElementAt(selectedCourseIndex);

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

