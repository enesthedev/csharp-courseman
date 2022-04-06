using System.Collections.Generic;
using Courseman.Common.Entitys;
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

		/**
		 * Kurs ve Öğrenci listeleri
		 - Buradaki dinamik tipindeki listeler kursları ve öğrencileri içeriyor. Helpers kısmında Input sınıfında bu verilerin dinamik olarak
		 - seçenek halinde konsol ekranından alınmasını sağladığım için tipleri dinamik. Uygun kullanım aslında List<veriTipi>.
		 */ 
		static List<dynamic> Courses = new List<dynamic> {
			new Course("Java Programlama"),
			new Course("C# Programlama")
		};

		static List<dynamic> Students = new List<dynamic>() {
			new Student("Enes", 22, 63673031350),
			new Student("Emin", 21, 48561842566)
		};

		static List<dynamic> Academicians = new List<dynamic>() {
			new Academician("Tugba"),
			new Academician("Ömer"),
		};

		/**
		 * Çalıştırma metodu
		 - Sınıf açıklamasından`bu tanımlama sayesinde konsol aplikasyonlarında yaşanan hatalı girdilerde uygulamayı dinamik şekilde yeniden başlatabiliyorum.
		 */
		public static int Run()
        {
			Application.WriteLine("Ortalama kurs puanı hesaplama programına hoşgeldiniz.", true);
			Application.WriteLine("Lütfen alttaki kurslardan puanını hesaplamak istediğiniz kursu seçiniz:\nYeni bir kurs oluşturmak isterseniz -1 yazabilirsiniz.");

			/**
			 * Akademisyenleri Kurslarla eşleştirme
			 - Bu döngüde built-in girilmiş akademisyenleri kurslarla eşleştiriyorum, kriter olarak akademisyenin hiç bir kursa atanmamış sahip olmaması gerekiyor.
			 - aplikasyon yeniden başladığında hata yaşanmasını bu şekilde önlemiş oluyorum.
			 */
			for (int i = 0; i < Academicians.ToArray().Length; i++) {
				Academician academician = Academicians.ElementAt(i);
				if (academician.Courses.ToArray().Length == 0) {
					Academicians.ElementAt(i).AddCourse(Courses.ElementAt(i));
				}
            }

			for (int i = 0; i < Courses.ToArray().Length; i++)
				Application.WriteLine("{0}: {1} (Akademisyen: {2})", false, i, Courses.ElementAt(i).Name, Courses.ElementAt(i).Academician.Name);

			int selectedCourseIndex = Input.ReadOptions(Courses, true);

			if (selectedCourseIndex == -1) {
				Course course = new Course();

				if (!Wizard.Mount(
					course,
					new Course(), // Varsayılan değerler için yeni bir boş sınıf gönderiyorum
					true,
					"Kurs oluşturma sihirbazına hoşgeldiniz",
					"(Sihirbazdan çıkmak için -1 yazabilirsiniz"
				)) return Run();

				Courses.Add(course);

				Application.WriteLine("{0} adlı kurs başarıyla oluşturuldu", true, course.Name);
				Thread.Sleep(1000);

				return Run();
			}
		
			Course selectedCourse = Courses.ElementAt(selectedCourseIndex);

			if (selectedCourse.Academician.Name == new Course().Academician.Name) {
				Application.WriteLine("{0} kursu için lütfen alttaki akademisyenlerden birini seçin:\nYeni bir akademisyen oluşturmak istiyorsanız -1 yazabilirsiniz.", true, selectedCourse.Name);

				for (int i = 0; i < Academicians.ToArray().Length; i++)
					Application.WriteLine("{0}: {1}", false, i, Academicians.ElementAt(i).Name);

				int selectedAcademicianIndex = Input.ReadOptions(Academicians, true);

				if (selectedAcademicianIndex == -1) {
					Academician academician = new Academician();

					if (!Wizard.Mount(
						academician,
						new Academician(),
						true,
						"Akademisyen oluşturma sihirbazına hoşgeldiniz",
						"(Sihirbazdan çıkmak için -1 yazabilirsiniz)"
					)) return Run();

					Academicians.Add(academician);

					Application.WriteLine("{0} adlı akademisyen başarıyla eklendi.", true, academician.Name);
					Thread.Sleep(1000);

					return Run();
				}

				selectedCourse.AttachAcademician(Academicians.ElementAt(selectedAcademicianIndex));
			}

			Application.WriteLine("{0} kursu için {1} adlı akademisyenle devam ediliyor...", true, selectedCourse.Name, selectedCourse.Academician.Name);
			Thread.Sleep(500);

			Application.WriteLine("{0} kursu için lütfen alttaki öğrencilerden birini seçiniz:\nYeni bir öğrenci oluşturmak istiyorsanız -1 yazabilirsiniz.", true, selectedCourse.Name);

			for (int i = 0; i < Students.ToArray().Length; i++)
				Application.WriteLine("{0}: {1}", false, i, Students.ElementAt(i).Name);

			int selectedStudentIndex = Input.ReadOptions(Students, true);

			if (selectedStudentIndex == -1) {
				Student student = new Student();

				if (!Wizard.Mount(
					student,
					new Student(),
					true,
					"Öğrenci oluşturma sihirbazına hoşgeldiniz",
					"(Sihirbazdan çıkmak için -1 yazabilirsiniz)"
				)) return Run();

				Students.Add(student);

				Application.WriteLine("{0} adlı öğrenci başarıyla eklendi", true, student.Name);
				Thread.Sleep(1000);

				return Run();
			}

			Student selectedStudent = Students.ElementAt(selectedStudentIndex);

			Application.WriteLine(
				"{0} adlı eğitmenin vermiş olduğu {1} kursundan aldığınız vize notunu giriniz:",
				true,
				selectedCourse.Academician.Name,
				selectedCourse.Name
			);
			double midtermValue = Input.ReadDouble(0, 100);

			Application.WriteLine(
				"{0} adlı eğitmenin vermiş olduğu {1} kursundan aldığınız final notunu giriniz:",
				true,
				selectedCourse.Academician.Name,
				selectedCourse.Name
			);
			double finalValue = Input.ReadDouble(0, 100);

			double averagePoint = selectedCourse.CalculatePoint(midtermValue, 0) + selectedCourse.CalculatePoint(finalValue, 1);
			Application.WriteLine(
				"{0} adlı kurstan {1:0.00} notu ile {2}.",
				true,
				selectedCourse.Name,
				averagePoint,
				averagePoint >= 50 ? "geçtiniz" : "kaldınız"
			);

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

